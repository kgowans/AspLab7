using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationEFDataModel;
/// <summary>
/// Summary description for CourseOfferingComparer
/// </summary>
public class CourseOfferingComparer /*: IComparer<CourseOffering>*/
{
    public CourseOfferingComparer(){}

    //public int Compare(CourseOffering x, CourseOffering y)
    //{
    //    //Year
    //    int result = x.Year.CompareTo(y.Year);
    //    if(result != 0)
    //        return result;

    //    //Semester
    //    result = Semester.Compare(x.Semester, y.Semester);
    //    if(result != 0)
    //        return result;

    //    //Course Name
    //    result = x.CourseOffered.CourseName.CompareTo(y.CourseOffered.CourseName);
    //    return result;
    //}

    public static List<int> ToList()
    { return new List<int>() { 2015, 2016, 2017, 2018 }; }



}