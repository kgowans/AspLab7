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
    public StudentType()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //{
    //    public const string FullTime = "Full time";
    //    public const string PartTime = "Part time";
    //    public const string Co-op = "Co-op";
    //}

        


    public static string GetStudentType(Student student)
    {
        if (student is FullTimeStudent)
        {
            return "Full Time";
        }
        if (student is PartTimeStudent)
        {
            return "Part Time";
        }
        if (student is CoopStudent)
        {
            return "Coop Student";
        }
        return "";
    }

    public static Student MakeStudent(string name, string number, string type)
    { 
        Student student = null;
        if (type == "Full Time")
        {
            student = new FullTimeStudent(number, name);
        }
        else if (type == "Part Time")
        {
            student = new PartTimeStudent(number, name);
        }
        else if (type == "Coop Student")
        {
            student = new CoopStudent(number, name);
        }
        return student;
    }
}