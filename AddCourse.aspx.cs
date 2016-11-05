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
        
        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {
            //List<Course> courseList = entityContext.Courses.ToList<Course>();
            var courseList = (from c in entityContext.Courses
                              orderby c.CourseTitle
                              select new
                              {
                                  CourseId = c.CourseID,
                                  CourseTitle = c.CourseTitle,
                                  WeeklyHours =  c.HoursPerWeek
                              }).ToList();

            gvAddCourse.DataSource = courseList;
        }
        DataBind();
        
    }

    protected void btnSubmitCourse_Click(object sender, EventArgs e)
    {
        Course course = new Course(txtCourseNumber.Text, txtCourseName.Text, int.Parse(txtWeeklyHours.Text));
        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {

            entityContext.Courses.Add(course);
            entityContext.SaveChanges();
        }
           


    }
}