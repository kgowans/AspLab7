using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentDataAccess
/// </summary>
public class StudentDataAccess : DataAccessBase
{
    public StudentDataAccess() : base()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    //if you use new  public const student you can do magix: @type, StudentType.Coop


    public int AddStudent(Student student)
    {
        int added;
        string insertStudentSQL = "INSERT INTO Student (StudentNum, Name, Type) VALUES (@studentNum, @name, @type)";
        SqlCommand sqlCmd = new SqlCommand(insertStudentSQL, connection);

        sqlCmd.Parameters.AddWithValue("@studentNum", student.Number);
        sqlCmd.Parameters.AddWithValue("@name", student.Name);
        sqlCmd.Parameters.AddWithValue("@type", StudentType.GetStudentType(student));

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

    public Student GetStudentByID(string studentID)
    {
        //Must initialize the variable before its used
        SqlDataReader reader = null;
        string selectStudentSQL = "SELECT * FROM Student WHERE StudentNum = @studentNum";
        SqlCommand sqlCmd = new SqlCommand(selectStudentSQL, connection);
        sqlCmd.Parameters.AddWithValue("@studentNum", studentID);
        Student student = null;

        try
        {
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                string studentNum = (string)reader["StudentNum"];
                string name = (string)reader["Name"];
                string type = (string)reader["Type"];

                student = StudentType.MakeStudent(name, studentNum, type);
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
        return student;
    }
}