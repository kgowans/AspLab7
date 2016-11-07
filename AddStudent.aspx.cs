using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRegistrationEFDataModel;

public partial class AddStudent : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!Page.IsPostBack)
        {
            using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
            {
                var courseOfferingList = (from c in entityContext.CourseOfferings
                                          orderby c.Year, c.Semester, c.Course.CourseTitle
                                          select new
                                          {
                                              CourseCode = c.Course_CourseID + ";" +
                                              c.Year + ";" +
                                              c.Semester,
                                              CourseOfferingText = c.Course_CourseID + " " + c.Course.CourseTitle + " " + c.Year + " " + c.Semester
                                          }).ToList();

                if (courseOfferingList.Count() == 0)
                {
                    Response.Redirect("AddCourseOffering.aspx");
                }
                else
                {
                    drpCourseOfferingList.DataSource = courseOfferingList;
                    drpCourseOfferingList.DataTextField = "CourseOfferingText";
                    drpCourseOfferingList.DataValueField = "CourseCode";
                    drpCourseOfferingList.AppendDataBoundItems = true;
                    drpCourseOfferingList.DataBind();
                }
            }
        }
    }



    protected void Page_PreRender(object sender, EventArgs e)
    {

        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {
            //string selectSQL = "SELECT s.StudentNum, s.Name, s.Type FROM Student s "
            //            + "JOIN Registration r ON s.StudentNum = r.Student_StudentNum  "
            //            + "WHERE r.CourseOffering_Course_CourseID = @courseID "
            //            + "  AND r.CourseOffering_Year = @year "
            //            + "  AND r.CourseOffering_Semester = @Semester";

            ////example
            ////from s in dc.Students
            ////from c in s.Courses
            ////where c.CourseID == courseID
            ////select s;


            //var studentList = (from student in entityContext.Students
            //                   from co in student.CourseOfferings
            //                   where co.CourseOffered.CourseID == Course_CourseID
            //                   select new
            //                   {
            //                       StudentID = student.Number,
            //                       Name = student.Name,
            //                       Type = student.GetType(),
            //                       Fee = student.tuitionPayable()
            //                   };


            ////var studentList = (from student in entityContext.Students
            ////                   from co in entityContext.CourseOfferings
            ////                   on student.CourseOfferings equals co.Students
            ////                   select new {
            ////                       StudentID = student.Number,
            ////                       Name = student.Name,
            ////                       Type = student.GetType(),
            ////                       Fee = student.tuitionPayable()
            ////                   };

            //gvAddStudent.DataSource = courseOfferingList;
            //gvAddStudent.DataBind();

            if (drpCourseOfferingList.SelectedIndex == 0)
            {
                gvAddStudent.EmptyDataText = "No Course Offering Selected";
                return;
            }

            CourseOffering courseOffering = GetCourseOfferingFromDropdown();
            List<Student> studentList = courseOffering.GetStudents();


            if (studentList.Count == 0)
            {
                gvAddStudent.EmptyDataText = "No Students Registered";
            }
            else
            {


                gvAddStudent.DataBind();

                //TODO BUILD TABLE


            }

        }
        //DataBind();
    }

    protected void AddStudent_Click(object sender, EventArgs e)
    {
        if (drpCourseOfferingList.SelectedValue != "-1")
        {
            using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
            {
                List<Student> studentList = entityContext.Students.ToList<Student>();
                var student = (from c in studentList
                               where c.StudentNum ==  txtStudentNumber.Text
                               select c).FirstOrDefault<Student>();

                if (student == null)
                {
                    if (rbFullTime.Checked)
                        student = new FullTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                    else if (rbPartTime.Checked)
                        student = new PartTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                    else if (rbCoop.Checked)
                        student = new CoopStudent(txtStudentNumber.Text, txtStudentName.Text);

                    entityContext.Students.Add(student);
                    entityContext.SaveChanges();
                }

                //TODO Register student using EF
                CourseOffering courseOffering = GetCourseOfferingFromDropdown();

                RegistrationDataAccess rda = new RegistrationDataAccess();
                List<Student> registeredStudents = rda.GetRegistration(courseOffering);
                if (!registeredStudents.Exists(x => x.Number == student.Number))
                {
                    rda.AddRegistration(student, courseOffering);
                }
            }
        }
    }

    protected CourseOffering GetCourseOfferingFromDropdown()
    {
        string[] details = drpCourseOfferingList.SelectedValue.Split(';');
        string courseID = details[0];
        int year = int.Parse(details[1]);
        string semester = details[2];

        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {
            var cos = (from co in entityContext.CourseOfferings
                       where co.Course.CourseID == courseID && co.Year == year && co.Semester == semester
                       select co).FirstOrDefault<CourseOffering>();
            return cos;
        }
    }
}