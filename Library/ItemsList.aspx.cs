using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class ItemsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select i.Id, i.AuthorId, i.Title, i.ISBN,
	                    a.FirstName + ' ' + a.LastName as AuthorName
                    from Item i
	                    join Author a on i.AuthorId = a.Id
                ");

                Items.DataSource = dt.Rows;
                Items.DataBind();
            }
        }
    }
}