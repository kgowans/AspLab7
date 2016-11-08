using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentRegistrationEFDataModel;

/// <summary>
/// Summary description for CourseDataAccess
/// </summary>
public class CourseDataAccess : DataAccessBase
{
    public CourseDataAccess() : base(){}

    public void AddCourse(Course course)
    {
        
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        entityContext.Courses.Add(course);
        entityContext.SaveChanges();

    }
    
    public Course GetCourseByID(string courseID)
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        var course = (from c in entityContext.Courses
                      where c.CourseID == courseID
                      select c).FirstOrDefault<Course>();
        return course;

    }

    public List<Course> GetCourses()
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        List<Course> courseList = entityContext.Courses.ToList<Course>();
        return courseList;
    }
}