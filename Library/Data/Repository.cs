using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library.Data
{
    public static class Repository
    {
        public static DataTable GetLibrarian(string libraryCardNumber)
        {
            return DatabaseHelper.Retrieve(@"
                select p.Id, p.FirstName, p.LastName, p.LibraryCardNumber,
                    l.Id LibraryId, l.LocationName LibraryLocationName,
                    lb.EmployeeNumber, lb.HashedPassword 
                from Patron p
                    join Librarian lb on lb.PatronId = p.Id
                    join Library l on l.Id = lb.LibraryId
                where p.LibraryCardNumber = @LibraryCardNumber
            ",
                new SqlParameter("@LibraryCardNumber", libraryCardNumber));
        }
    }
}