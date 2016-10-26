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
    public CourseDataAccess() : base()
    {

    }

    public int AddCourse(Course course)
    {
        int added;
        string insertCourseSQL = "INSERT INTO Course (CourseID, CourseTitle, HoursPerWeek) VALUES (@courseID, @courseTitle, @courseHours)";
        SqlCommand sqlCmd = new SqlCommand(insertCourseSQL, connection);

        sqlCmd.Parameters.AddWithValue("@courseID", course.CourseNumber);
        sqlCmd.Parameters.AddWithValue("@courseTitle", course.CourseName);
        sqlCmd.Parameters.AddWithValue("@courseHours", course.WeeklyHours);

        try
        {
            connection.Open();
            added = sqlCmd.ExecuteNonQuery();
        }
        catch(SqlException e)
        {
            added = -1;
        }
        finally
        {
            connection.Close();
        }

        return added;
    }

    public Course GetCourseByID(string courseID)
    {
        //Must initialize the variable before its used
        SqlDataReader reader = null;
        string selectCoursesSQL = "SELECT * FROM Course WHERE CourseID = @courseID";
        SqlCommand sqlCmd = new SqlCommand(selectCoursesSQL, connection);
        sqlCmd.Parameters.AddWithValue("@courseID", courseID);
        Course course = null;

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                string courseNumber = (string)reader["CourseID"];
                string courseTitle = (string)reader["CourseTitle"];
                //string description = (string)reader["Description"];
                int hoursPerWeek = (int)reader["HoursPerWeek"];
                //double feeBase = (double)reader["FeeBase"];
                course = new Course(courseNumber, courseTitle, hoursPerWeek);
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (reader != null) reader.Close();
            connection.Close();
        }
        return course;
    }

    public List<Course> GetCourses()
    {
        //Must initialize the variable before its used
        SqlDataReader reader = null;
        string selectCoursesSQL = "SELECT * FROM Course";
        SqlCommand sqlCmd = new SqlCommand(selectCoursesSQL, connection);
        List<Course> courseList = new List<Course>();

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string courseID = (string)reader["CourseID"];
                string courseTitle = (string)reader["CourseTitle"];
                int hoursPerWeek = (int)reader["HoursPerWeek"];
                Course course = new Course(courseID, courseTitle, hoursPerWeek);
                courseList.Add(course);
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            if (reader != null) reader.Close();
            connection.Close();
        }
        return courseList;
    }
}