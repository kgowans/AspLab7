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

        public double Fee
        {
            get { return tuitionPayable();  }
        }


        public Student(string number, string name, double fee) : this()
        {
            this.StudentNum = number;
            this.Name = name;
            //fee = Fee;
        }

        //public int CompareTo(Student other)
        //{
        //    //if other is not a valid object reference, this instance will return 1
        //}

        public abstract double tuitionPayable();
    }
}