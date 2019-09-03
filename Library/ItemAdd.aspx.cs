using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class ItemAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable authors = DatabaseHelper.Retrieve(@"
                    select Id, LastName + ', ' + FirstName as Name
                    from Author
                    order by LastName, FirstName
                ");

                Author.DataValueField = "Id";
                Author.DataTextField = "Name";

                // Add an empty 1st option element.
                Author.Items.Add(string.Empty);
                Author.AppendDataBoundItems = true;

                Author.DataSource = authors;
                Author.DataBind();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string title = ItemTitle.Text;
            int authorId = int.Parse(Author.SelectedValue);
            string isbn = ISBN.Text;

            DatabaseHelper.Insert(@"
                insert into Item (Title, AuthorId, ISBN)
                values (@Title, @AuthorId, @ISBN);
            ",
                new SqlParameter("@Title", title),
                new SqlParameter("@AuthorId", authorId),
                DatabaseHelper.GetNullableStringSqlParameter("@ISBN", isbn));

            Response.Redirect("~/ItemsList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ItemsList.aspx");
        }
    }
}