<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemsList.aspx.cs" Inherits="Library.ItemsList" %>
<%@ import namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Books</h2>

    <div>
        <asp:hyperlink runat="server" navigateurl="~/ItemAdd.aspx">Add New Book</asp:hyperlink>
    </div>

    <asp:repeater id="Items" runat="server" itemtype="DataRow">
        <headertemplate>
            <table>
                <tr>
                    <th>Author</th>
                    <th>Title</th>
                    <th>ISBN</th>
                    <th>&nbsp;</th>
                </tr>
        </headertemplate>
        <itemtemplate>
            <tr>
                <td><%# Item.Field<string>("AuthorName") %></td>
                <td><%# Item.Field<string>("Title") %></td>
                <td><%# Item.Field<string>("ISBN") %></td>
                <td><asp:hyperlink runat="server" navigateurl='<%# $"~/ItemEdit.aspx?ID={Item.Field<int>("Id")}" %>' text="Edit" /></td>
            </tr>
        </itemtemplate>
        <footertemplate>
            </table>
        </footertemplate>
    </asp:repeater>

</asp:Content>
