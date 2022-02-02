
namespace Library_Mvc_Jashim.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;


    public partial class Librarian
    {

        public int LibrarianID { get; set; }
        public string Name { get; set; }

        [Range(15,32, ErrorMessage ="Age is allowed between 15 to 32.")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
