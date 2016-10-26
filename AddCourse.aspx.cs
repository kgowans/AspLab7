using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRegistrationEFDataModel;

public partial class AddCourse : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        CourseDataAccess cda = new CourseDataAccess();
        List<Course> courseList = cda.GetCourses();
        if (courseList.Count == 0)
        {
            TableHelper.AddErrorRow(tblAddCourse, 3, "No Course Records Exist!");
        }
        else
        {
            foreach (Course course in courseList)
            {
                TableHelper.AddRow(tblAddCourse, course.CourseNumber, course.CourseName, course.WeeklyHours.ToString());
            }

        }
    }

    protected void btnSubmitCourse_Click(object sender, EventArgs e)
    {
        Course course = new Course(txtCourseNumber.Text, txtCourseName.Text, int.Parse(txtWeeklyHours.Text));
        CourseDataAccess cda = new CourseDataAccess();
        cda.AddCourse(course);
        txtCourseNumber.Text = txtCourseName.Text = txtWeeklyHours.Text = "";
        
    }
}