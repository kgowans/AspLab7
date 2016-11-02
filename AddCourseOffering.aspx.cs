using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRegistrationEFDataModel;




public partial class AddCourseOffering : PageBase
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        

        if (!Page.IsPostBack)
        {
            drpSemester.AppendDataBoundItems = true;
            drpSemester.DataSource = Semester.ToList();
            drpYears.AppendDataBoundItems = true;
            drpYears.DataSource = Years.ToList();

            using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
            {
                List<Course> courseList = entityContext.Courses.ToList<Course>();
                if(courseList.Count == 0)
                {
                    Response.Redirect("AddCourse.aspx");
                }
                else
                {
                    foreach (Course course in courseList)
                    {
                        ListItem li = new ListItem(course.CourseNumber + " " + course.CourseName, course.CourseNumber);
                        drpCourse.Items.Add(li);
                    }
                    courseList.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));
                } 
            }
        }
       // DataBind();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {

            var courseOfferingList = (from c in entityContext.CourseOfferings
                              orderby c.Year, c.Semester, c.Course.CourseTitle
                              select new
                              {
                                  CourseCode = c.Course_CourseID,
                                  Title = c.Course.CourseTitle,
                                  Year = c.Year,
                                  Semester = c.Semester
                              }).ToList();
           
            gvAddCourseOffering.DataSource = courseOfferingList;
            gvAddCourseOffering.DataBind();
            
        }
        DataBind();
    }

    protected void btnSubmitCourseOffering_Click(object sender, EventArgs e)
    {
        using (StudentRegistrationEntities entityContext = new StudentRegistrationEntities())
        {
            var course = (from c in entityContext.Courses
                          where c.CourseID == drpCourse.SelectedValue
                          select c).FirstOrDefault<Course>();
            CourseOffering courseOffering = new CourseOffering(course, int.Parse(drpYears.SelectedValue), drpSemester.SelectedValue);
            entityContext.CourseOfferings.Add(courseOffering);
            entityContext.SaveChanges();
        }
        drpCourse.SelectedIndex = drpYears.SelectedIndex = drpSemester.SelectedIndex = 0;
    }

}