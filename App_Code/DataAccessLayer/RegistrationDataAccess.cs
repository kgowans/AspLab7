using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentRegistrationEFDataModel;

/// <summary>
/// Summary description for RegistrationDataAccess
/// </summary>
public class RegistrationDataAccess : DataAccessBase
{
    public RegistrationDataAccess() : base() {}


    // List<CourseOffering> GetRegisteredCourseOfferingByStudent(Student) 

    public int AddRegistration(Student student, CourseOffering courseOffering)
    {
        int added;
        string insertRegistrationSQL =
            "INSERT INTO Registration "
                + "(Student_StudentNum, CourseOffering_Course_CourseID, CourseOffering_Year, CourseOffering_Semester) "
                + "VALUES (@studentNum, @courseID, @year, @semester)";
        SqlCommand sqlCmd = new SqlCommand(insertRegistrationSQL, connection);

        sqlCmd.Parameters.AddWithValue("@studentNum", student.Number);
        sqlCmd.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);
        sqlCmd.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlCmd.Parameters.AddWithValue("@semester", courseOffering.Semester);

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

    public List<Student> GetRegistration(CourseOffering courseOffering)
    {
        SqlDataReader reader = null;
        string selectSQL = "SELECT s.StudentNum, s.Name, s.Type FROM Student s "
                                + "JOIN Registration r ON s.StudentNum = r.Student_StudentNum  "
                                + "WHERE r.CourseOffering_Course_CourseID = @courseID "
                                + "  AND r.CourseOffering_Year = @year "
                                + "  AND r.CourseOffering_Semester = @Semester";
        SqlCommand sqlCmd = new SqlCommand(selectSQL, connection);

        sqlCmd.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);
        sqlCmd.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlCmd.Parameters.AddWithValue("@Semester", courseOffering.Semester);

        List<Student> students = new List<Student>();

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string studentNum = (string)reader["StudentNum"];
                string name = (string)reader["Name"];
                string type = (string)reader["Type"];
                Student student = StudentType.MakeStudent(name, studentNum, type);
                students.Add(student);
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

        return students;
    }

    public List<CourseOffering> GetRegisteredCourseOfferingByStudent(Student student)
    {
        //TODO Implement  method return all the things
        return null;
    }

}