using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Library
{
    public class BasePage : System.Web.UI.Page
    {
        public Librarian CurrentUser { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.IsAuthenticated)
            {
                DataTable dt = Repository.GetLibrarian(User.Identity.Name);
                Librarian librarian = new Librarian(dt);
                CurrentUser = librarian;
            }
        }
    }
}