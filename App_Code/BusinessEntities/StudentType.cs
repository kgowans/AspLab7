using StudentRegistrationEFDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentType
/// </summary>
public class StudentType
{
    public StudentType() {}

    public const string FullTime = "Full Time";
    public const string PartTime = "Part Time";
    public const string Coop = "Coop Student";

    public static string GetStudentType(Student student)
    {
        if (student is FullTimeStudent)
        {
            return FullTime;
        }
        if (student is PartTimeStudent)
        {
            return PartTime;
        }
        if (student is CoopStudent)
        {
            return Coop;
        }
        return "";
    }

    public static Student MakeStudent(string name, string number, string type)
    { 
        Student student = null;
        if (type == FullTime)
        {
            student = new FullTimeStudent(number, name);
        }
        else if (type == PartTime)
        {
            student = new PartTimeStudent(number, name);
        }
        else if (type == Coop)
        {
            student = new CoopStudent(number, name);
        }
        return student;
    }
}