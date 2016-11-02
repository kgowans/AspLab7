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
        //    CourseOfferingDataAccess coda = new CourseOfferingDataAccess();
        //    List<CourseOffering> courseOfferingList = coda.GetCourseOfferings();
        //    CourseOfferingComparer comparer = new CourseOfferingComparer();
        //    courseOfferingList.Sort(comparer);
        //    foreach (CourseOffering courseOffering in courseOfferingList)
        //    {
        //        string label = string.Format("{0} {1} {2} {3}", courseOffering.CourseOffered.CourseNumber, courseOffering.CourseOffered.CourseName, courseOffering.Year, courseOffering.Semester);
        //        string value = string.Format("{0};{1};{2}", courseOffering.CourseOffered.CourseNumber, courseOffering.Year, courseOffering.Semester);
        //        ListItem li = new ListItem(label, value);
        //        drpCourseOfferingList.Items.Add(li);
        //    }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (drpCourseOfferingList.SelectedIndex == 0)
        {
           // TableHelper.AddErrorRow(tblStudents, 3, "No Course Offering Selected!");
            return;
        }

        CourseOffering courseOffering = GetCourseOfferingFromDropdown();
        List<Student> studentList = courseOffering.GetStudents();
        if (studentList.Count == 0)
        {
          //  TableHelper.AddErrorRow(tblStudents, 3, "No Students Registered for Course Offering!");
        }
        else
        {
            foreach (Student student in studentList)
            {
             //   TableHelper.AddRow(tblStudents, student.Number, student.Name, StudentType.GetStudentType(student));
            }

        }
    }

    protected void AddStudent_Click(object sender, EventArgs e)
    {
        if (drpCourseOfferingList.SelectedValue != "-1")
        {
            StudentDataAccess sda = new StudentDataAccess();
            Student student = sda.GetStudentByID(txtStudentNumber.Text);

            if (student == null)
            {
                if (rbFullTime.Checked)
                    student = new FullTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                else if (rbPartTime.Checked)
                    student = new PartTimeStudent(txtStudentNumber.Text, txtStudentName.Text);
                else if (rbCoop.Checked)
                    student = new CoopStudent(txtStudentNumber.Text, txtStudentName.Text);

                sda.AddStudent(student);
            }

            CourseOffering courseOffering = GetCourseOfferingFromDropdown();
            RegistrationDataAccess rda = new RegistrationDataAccess();
            List<Student> registeredStudents = rda.GetRegistration(courseOffering);
            if (!registeredStudents.Exists(x => x.Number == student.Number))
            {
                rda.AddRegistration(student, courseOffering);
            }
        }
        
    }

    protected CourseOffering GetCourseOfferingFromDropdown()
    {
        string[] details = drpCourseOfferingList.SelectedValue.Split(';');
        string courseID = details[0];
        int year = int.Parse(details[1]);
        string semester = details[2]; 
        CourseOfferingDataAccess coda = new CourseOfferingDataAccess();
        return coda.GetCourseOfferingByKeys(year, semester, courseID);
    }
}