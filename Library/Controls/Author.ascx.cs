using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class Author : BaseUserControl
    {
        int authorId = 0;

        public Mode Mode { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Mode == Mode.Edit)
            {
                if (!int.TryParse(Request.QueryString["ID"], out authorId))
                {
                    Response.Redirect("~/AuthorsList.aspx");
                }

                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select FirstName, LastName
                    from Author
                    where Id = @AuthorId
                ", new SqlParameter("@AuthorId", authorId));

                    if (dt.Rows.Count == 1)
                    {
                        FirstName.Text = dt.Rows[0].Field<string>("FirstName");
                        LastName.Text = dt.Rows[0].Field<string>("LastName");
                    }
                    else
                    {
                        Response.Redirect("~/AuthorsList.aspx");
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;

            switch (Mode)
            {
                case Mode.Add:
                    DatabaseHelper.Insert(@"
                        insert into Author (FirstName, LastName)
                        values (@FirstName, @LastName);
                    ",
                        new SqlParameter("@FirstName", firstName),
                        new SqlParameter("@LastName", lastName));
                    break;
                case Mode.Edit:
                    DatabaseHelper.Update(@"
                        update Author set
                            FirstName = @FirstName,
                            LastName = @LastName
                        where Id = @AuthorId
                    ",
                        new SqlParameter("@FirstName", firstName),
                        new SqlParameter("@LastName", lastName),
                        new SqlParameter("@AuthorId", authorId));
                    break;
                default:
                    throw new ApplicationException("Unexpected Mode enum value: " + Mode);
            }

            Response.Redirect("~/AuthorsList.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorsList.aspx");
        }
    }
}