using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseOfferingDataAccess
/// </summary>
public class CourseOfferingDataAccess : DataAccessBase
{
    public CourseOfferingDataAccess() : base() { }

    public int AddCourseOffering(CourseOffering courseOffering)
    {
        int added;
        string insertCourseOfferingSQL = "INSERT INTO CourseOffering (Year, Semester, Course_CourseID) VALUES (@year, @Semester, @courseID)";
        SqlCommand sqlCmd = new SqlCommand(insertCourseOfferingSQL, connection);

        sqlCmd.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlCmd.Parameters.AddWithValue("@Semester", courseOffering.Semester);
        sqlCmd.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);

        try
        {
            connection.Open();
            added = sqlCmd.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            added = -1;
        }
        finally
        {
            connection.Close();
        }
        return added;
    }

    public List<CourseOffering> GetCourseOfferings()
    {
        //Must initialize the variable before its used
        SqlDataReader reader = null;
        string selectCoursesSQL = "SELECT * FROM CourseOffering";
        SqlCommand sqlCmd = new SqlCommand(selectCoursesSQL, connection);
        List<CourseOffering> courseOfferings = new List<CourseOffering>();

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                CourseOffering courseOffering = BuildCourseOffering(reader);
                courseOfferings.Add(courseOffering);

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
        return courseOfferings;
    }
    public CourseOffering GetCourseOfferingByKeys(int year, string semester, string courseNumber)
    {
        //Must initialize the variable before its used
        SqlDataReader reader = null;
        string selectCourseOfferingSQL = "SELECT * FROM CourseOffering WHERE Year = @year AND Semester = @semester AND Course_CourseID = @courseID";
        SqlCommand sqlCmd = new SqlCommand(selectCourseOfferingSQL, connection);
        sqlCmd.Parameters.AddWithValue("@courseID", courseNumber);
        sqlCmd.Parameters.AddWithValue("@year", year);
        sqlCmd.Parameters.AddWithValue("@semester", semester);
        CourseOffering courseOffering = null;

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                courseOffering = BuildCourseOffering(reader);
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
        return courseOffering;
    }

    protected CourseOffering BuildCourseOffering(SqlDataReader reader)
    {
        int year = (int)reader["Year"];
        string semester = (string)reader["Semester"];
        string courseID = (string)reader["Course_CourseID"];

        CourseDataAccess cda = new CourseDataAccess();
        Course course = cda.GetCourseByID(courseID);

        CourseOffering courseOffering = new CourseOffering(course, year, semester);

        RegistrationDataAccess rda = new RegistrationDataAccess();
        List<Student> students = rda.GetRegistration(courseOffering);

        StudentComparer compare = new StudentComparer();
        students.Sort(compare);

        courseOffering.AddStudents(students);
            
        return courseOffering;
    }
}