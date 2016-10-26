using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseOffering
/// </summary>
namespace StudentRegistrationEFDataModel
{
    public partial class CourseOffering
    {
        public Course CourseOffered
        {
            get { return Course; }
            set { Course = value; }
        }

        //Must call 'this()' to call constructor from entity framework, so things can be initialized (ex. Students in this case)
        public CourseOffering(Course courseOffered, int year, string semester) : this()
        {
            this.Course = courseOffered;
            this.Year = year;
            this.Semester = semester;
        }

        public List<Student> GetStudents()
        {
            //return list of students from the entity framework
            return this.Students.ToList<Student>();
        }

        public void AddStudents(List<Student> students)
        {
            foreach(Student student in students)
            {
                AddStudent(student);
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}