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
    public partial class ItemEdit : BasePage
    {
        int itemId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out itemId))
            {
                Response.Redirect("~/ItemsList.aspx");
            }

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

                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Title, AuthorId, ISBN
                    from Item
                    where Id = @ItemId
                ", new SqlParameter("@ItemId", itemId));

                if (dt.Rows.Count == 1)
                {
                    ItemTitle.Text = dt.Rows[0].Field<string>("Title");
                    Author.SelectedValue = dt.Rows[0].Field<int>("AuthorId").ToString();
                    ISBN.Text = dt.Rows[0].Field<string>("ISBN");
                }
                else
                {
                    Response.Redirect("~/ItemsList.aspx");
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string title = ItemTitle.Text;
            int authorId = int.Parse(Author.SelectedValue);
            string isbn = ISBN.Text;

            DatabaseHelper.Update(@"
                update Item set
                    Title = @Title,
                    AuthorId = @AuthorId,
                    ISBN = @ISBN
                where Id = @ItemId
            ",
                new SqlParameter("@Title", title),
                new SqlParameter("@AuthorId", authorId),
                new SqlParameter("@ISBN", isbn),
                new SqlParameter("@ItemId", itemId));

            Response.Redirect("~/ItemsList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ItemsList.aspx");
        }
    }
}