using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Login : BasePage
    {
        protected void LoginUser_Click(object sender, EventArgs e)
        {
            string libraryCardNumber = LibraryCardNumber.Text;

            DataTable user = Repository.GetLibrarian(libraryCardNumber);

            if (user.Rows.Count == 1)
            {
                string password = Password.Text;

                if (BCrypt.Net.BCrypt.Verify(password, user.Rows[0].Field<string>("HashedPassword")))
                {
                    FormsAuthentication.RedirectFromLoginPage(libraryCardNumber, false);
                }
            }

            FailureMessage.Visible = true;
        }
    }
}