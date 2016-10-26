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

    public static int Rank(string semester)
    {
       return (semester == "Fall") ? 1 :
            (semester == "Winter") ? 2 :
            (semester == "Summer") ? 3 : -1;

        //switch (semester)
        //{
        //    case "Fall":
        //        return 1;
        //    case "Winter":
        //        return 2;
        //    case "Summer":
        //        return 3;
        //}

    }

    public static int Compare(string x, string y)
    {
        return Rank(x).CompareTo(Rank(y));
    }
}