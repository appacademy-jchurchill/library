<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorsList.aspx.cs" Inherits="Library.AuthorsList" %>
<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2 class="py-3">Authors</h2>

    <div class="p-4">
        <asp:hyperlink runat="server" cssclass="btn btn-primary" navigateurl="~/AuthorAdd.aspx">Add New Author</asp:hyperlink>
    </div>

    <asp:repeater id="Authors" runat="server" itemtype="DataRow">
        <headertemplate>
            <table class="table table-sm table-striped table-hover">
                <thead class="thead-dark">
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
        </headertemplate>
        <itemtemplate>
            <tr>
                <td><%# Item.Field<string>("FirstName") %></td>
                <td><%# Item.Field<string>("LastName") %></td>
                <td class="text-right pr-4"><asp:hyperlink runat="server" cssclass="btn btn-secondary btn-sm" navigateurl='<%# $"~/AuthorEdit.aspx?ID={Item.Field<int>("Id")}" %>' text="Edit" /></td>
            </tr>
        </itemtemplate>
        <footertemplate>
                </tbody>
            </table>
        </footertemplate>
    </asp:repeater>

</asp:Content>
