using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Semester
/// </summary>
public class Semester
{
    public Semester(){}

    public const string Fall = "Fall";
    public const string Winter = "Winter";
    public const string SpringSummer = "Spring/Summer";

    public static List<string> ToList()
    { return new List<string>() { Fall, Winter, SpringSummer }; }


    //public static int Rank(string semester)
    //{
    //   return (semester == "Fall") ? 1 :
    //        (semester == "Winter") ? 2 :
    //        (semester == "Summer") ? 3 : -1;
    //}

    //public static int Compare(string x, string y)
    //{
    //    return Rank(x).CompareTo(Rank(y));
    //}
}