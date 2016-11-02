using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentRegistrationEFDataModel;

/// <summary>
/// Summary description for CourseOfferingDataAccess
/// </summary>
public class CourseOfferingDataAccess : DataAccessBase
{
    public CourseOfferingDataAccess() : base() { }

    public void AddCourseOffering(CourseOffering courseOffering)
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        entityContext.CourseOfferings.Add(courseOffering);
        entityContext.SaveChanges();
        
    }

    public List<CourseOffering> GetCourseOfferings()
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        List<CourseOffering> courseOfferingList = entityContext.CourseOfferings.ToList<CourseOffering>();
        return courseOfferingList;

       
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