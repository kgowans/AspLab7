using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class Course 
    {
        public static double CourseHourlyFeeRate = 80.0;

        public string CourseNumber
        { 
            get { return CourseID; }
            set { CourseID = value; }
        }

        public string CourseName
        {
            get { return CourseTitle; }
            set { CourseTitle = value; }
        }

        public int WeeklyHours
        {
            get { return (int)HoursPerWeek; }
            set { HoursPerWeek = value; }
        }
        public Course(string courseNumber, string courseName, int weeklyHours) : this()
        {
            this.CourseID = courseNumber;
            this.CourseTitle = courseName;
            this.HoursPerWeek = weeklyHours;
        }

    }
}
