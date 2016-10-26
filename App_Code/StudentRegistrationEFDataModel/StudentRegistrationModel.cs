﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CoopStudent : Student
    {
    }
}
namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseOfferings = new HashSet<CourseOffering>();
        }
    
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public Nullable<int> HoursPerWeek { get; set; }
        public Nullable<decimal> FeeBase { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
    }
}
namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseOffering
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseOffering()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int Year { get; set; }
        public string Semester { get; set; }
        public string Course_CourseID { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class FullTimeStudent : Student
    {
    }
}
namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartTimeStudent : Student
    {
    }
}
namespace StudentRegistrationEFDataModel
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.CourseOfferings = new HashSet<CourseOffering>();
        }
    
        public string StudentNum { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseOffering> CourseOfferings { get; set; }
    }
}
