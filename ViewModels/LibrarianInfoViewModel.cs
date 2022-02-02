using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Library_Mvc_Jashim.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_Mvc_Jashim.ViewModels
{
    public class LibrarianInfoViewModel
    {

        public Librarian Librarian { get; set; }
        public string Name { get; set; }

        [Range(15, 32, ErrorMessage = "Age is allowed between 15 to 32.")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PageTitle { get; set; }
        public string PageHeader { get; set; }

    }
}