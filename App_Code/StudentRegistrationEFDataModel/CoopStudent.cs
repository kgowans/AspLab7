using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoopStudent
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class CoopStudent
    {
        public CoopStudent(string number, string name) : base(number, name)
        {
            
        }
        public CoopStudent() : base() { }

        public override double tuitionPayable()
        {
            double hours = 0;
            double coopFee = 300;

            foreach(CourseOffering registeredCourses in this.CourseOfferings)
            {
                hours += registeredCourses.CourseOffered.WeeklyHours;
                return hours * Course.CourseHourlyFeeRate + coopFee;
            }
            return 0;
       }
}


}