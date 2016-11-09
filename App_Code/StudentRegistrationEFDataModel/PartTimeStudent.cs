using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartTimeStudent
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class PartTimeStudent
    {
        public PartTimeStudent(string number, string name) : base(number, name) {}
        public PartTimeStudent() : base() { }

        public override double tuitionPayable()
        {
            double hours = 0;

            foreach (CourseOffering registeredCourses in this.CourseOfferings)
                hours += registeredCourses.CourseOffered.WeeklyHours;

            return hours * Course.CourseHourlyFeeRate;
        }

        public override string typeOfStudent()
        {
            return StudentType.PartTime;
        }
    }
}