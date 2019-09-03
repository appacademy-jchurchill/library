using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Librarian
    {
        public Librarian(DataTable dt)
        {
            if (dt.Rows.Count != 1)
            {
                throw new ArgumentException("Unexpected number of rows.");
            }

            DataRow dr = dt.Rows[0];

            Id = dr.Field<int>("Id");
            FirstName = dr.Field<string>("FirstName");
            LastName = dr.Field<string>("LastName");
            LibraryCardNumber = dr.Field<string>("LibraryCardNumber");
            LibraryId = dr.Field<int>("LibraryId");
            LibraryLocationName = dr.Field<string>("LibraryLocationName");
            EmployeeNumber = dr.Field<string>("EmployeeNumber");
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LibraryCardNumber { get; set; }
        public int LibraryId { get; set; }
        public string LibraryLocationName { get; set; }
        public string EmployeeNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}