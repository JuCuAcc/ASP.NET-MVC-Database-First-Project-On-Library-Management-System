//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Mvc_Jashim.Models
{
    using System;
    using System.Collections.Generic;


    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public int StudentID { get; set; }
        public int GroupID { get; set; }
        public int MemberID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }
}
