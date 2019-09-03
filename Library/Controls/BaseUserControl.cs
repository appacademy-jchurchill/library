using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Controls
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        public Librarian CurrentUser
        {
            get
            {
                Librarian librarian = null;
                BasePage basePage = Page as BasePage;
                if (basePage != null)
                {
                    librarian = basePage.CurrentUser;
                }
                return librarian;
            }
        }
    }
}