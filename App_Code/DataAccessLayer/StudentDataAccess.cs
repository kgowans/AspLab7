using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentRegistrationEFDataModel;

/// <summary>
/// Summary description for StudentDataAccess
/// </summary>
public class StudentDataAccess : DataAccessBase
{
    public StudentDataAccess() : base(){}
    
    public void AddStudent(Student student)
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();
        entityContext.Students.Add(student);
        entityContext.SaveChanges();

    }

    public Student GetStudentByID(string studentID)
    {
        StudentRegistrationEntities entityContext = new StudentRegistrationEntities();

        List<Student> studentList = entityContext.Students.ToList<Student>();
        var student = (from c in studentList
                        where c.StudentNum == studentID
                        select c).FirstOrDefault<Student>();
        return student;

    }
}