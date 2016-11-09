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
            CourseOffering courseOffering = GetCourseOfferingFromDropdown(entityContext);
            List<Student> studentList = courseOffering.Students.ToList<Student>();
            gvAddStudent.DataSource = studentList;

            if (drpCourseOfferingList.SelectedIndex == 0)
            {
                gvAddStudent.EmptyDataText = "No Course Offering Selected";
            }
            else if (studentList.Count == 0)
            {
                gvAddStudent.EmptyDataText = "No Students Registered";
            }

            gvAddStudent.DataBind();
        }
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

                CourseOffering courseOffering = GetCourseOfferingFromDropdown(entityContext);
                List<Student> registeredStudents = courseOffering.Students.ToList<Student>();
                if (!registeredStudents.Exists(x => x.Number == student.Number))
                {
                    courseOffering.Students.Add(student);
                    entityContext.SaveChanges();
                }
            }
        }
    }

    protected CourseOffering GetCourseOfferingFromDropdown(StudentRegistrationEntities entityContext)
    {
        string[] details = drpCourseOfferingList.SelectedValue.Split(';');
        if(details.Count() < 3)
            return new CourseOffering();

        string courseID = details[0];
        int year = int.Parse(details[1]);
        string semester = details[2];

        var cos = (from co in entityContext.CourseOfferings
                       where co.Course.CourseID == courseID && co.Year == year && co.Semester == semester
                       select co).FirstOrDefault<CourseOffering>();
        return cos;
    }
}