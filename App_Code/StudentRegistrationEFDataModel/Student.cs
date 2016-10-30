using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class Student
    {
        public string Number
        {
            get { return StudentNum; }
            set { StudentNum = value; }
        }

        public Student(string number, string name) : this()
        {
            this.StudentNum = number;
            this.Name = name;
        }

        public abstract double tuitionPayable();
    }
}