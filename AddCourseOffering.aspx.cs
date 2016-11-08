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
                var cs = (from c in entityContext.Courses
                          orderby c.CourseTitle
                          select new
                          {
                              CourseId = c.CourseID,
                              CourseText = c.CourseID + " - " + c.CourseTitle
                          }).ToList();
                if (cs.Count() == 0)
                {
                    Response.Redirect("AddCourse.aspx");
                }
                else
                {
                    drpCourse.DataSource = cs;
                    drpCourse.DataTextField = "CourseText";
                    drpCourse.DataValueField = "CourseID";
                    drpCourse.AppendDataBoundItems = true;

                }
            }
        }
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