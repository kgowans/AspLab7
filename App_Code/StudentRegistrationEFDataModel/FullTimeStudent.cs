using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FullTimeStudent
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class FullTimeStudent
    {
        public FullTimeStudent(string number, string name) : base(number, name){}
        public FullTimeStudent() : base() { }

        public override double tuitionPayable()
        {
            return 1000.0;
        }

        public override string typeOfStudent()
        {
            return StudentType.FullTime;
        }
    }
}