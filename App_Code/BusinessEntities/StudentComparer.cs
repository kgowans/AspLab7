using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentComparer
/// </summary>
public class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
       int compare = x.Name.CompareTo(y.Name);
        if (compare == 0)
        {
            compare = Rank(x).CompareTo(Rank(y));
            if(compare == 0)
            {
                compare = x.Number.CompareTo(y.Number);
            }
        }
        return compare;
    }

    public int Rank(Student student)
    {
        if(student is FullTimeStudent)
        {
            return 1;
        }
        if( student is PartTimeStudent)
        {
            return 2;
        }
        if(student is CoopStudent)
        {
            return 3;
        }
        return 0;
    }
}