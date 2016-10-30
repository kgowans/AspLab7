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
            CourseDataAccess cda = new CourseDataAccess();
            List<Course> courseList = cda.GetCourses();

            courseList.Sort((x, y) => x.CourseName.CompareTo(y.CourseName));
            foreach (Course course in courseList)
            {
                ListItem li = new ListItem(course.CourseNumber + " " + course.CourseName, course.CourseNumber);
                drpCourse.Items.Add(li);
            }
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        CourseOfferingDataAccess coda = new CourseOfferingDataAccess();
        List<CourseOffering> courseOfferingList = coda.GetCourseOfferings();
        CourseOfferingComparer comparer = new CourseOfferingComparer();
        courseOfferingList.Sort(comparer);
        if (courseOfferingList.Count == 0)
        {
            TableHelper.AddErrorRow(tblCourseOffering, 4, "No Course Offering Records Exist!");
        }
        else
        {
            foreach (CourseOffering courseOffering in courseOfferingList)
            {
                TableHelper.AddRow(tblCourseOffering, courseOffering.CourseOffered.CourseNumber, courseOffering.CourseOffered.CourseName, courseOffering.Year.ToString(), courseOffering.Semester);
            }
        }
    }

    protected void btnSubmitCourseOffering_Click(object sender, EventArgs e)
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        var course = (from c in entityContext.Courses
                      where c.CourseID == drpCourse.SelectedValue
                      select c).FirstOrDefault<Course>();
        CourseOffering courseOffering = new CourseOffering(course, int.Parse(drpYears.SelectedValue), drpSemester.SelectedValue);
        entityContext.CourseOfferings.Add(courseOffering);
        entityContext.SaveChanges();

        //CourseDataAccess cda = new CourseDataAccess();
        //Course selectedCourse = cda.GetCourseByID(drpCourse.SelectedValue);
        //CourseOfferingDataAccess coda = new CourseOfferingDataAccess();
        //coda.AddCourseOffering(new CourseOffering(selectedCourse, int.Parse(drpYears.SelectedValue), drpSemester.SelectedValue));
        drpCourse.SelectedIndex = drpYears.SelectedIndex = drpSemester.SelectedIndex = 0;
    }
}