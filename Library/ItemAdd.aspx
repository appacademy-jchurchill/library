<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemAdd.aspx.cs" Inherits="Library.ItemAdd" %>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Add Book</h2>

    <fieldset>

        <div>
            <asp:label id="ItemTitleLabel" runat="server" associatedcontrolid="ItemTitle" text="Title: " />
            <asp:textbox id="ItemTitle" runat="server" />
        </div>

        <div>
            <asp:label id="AuthorLabel" runat="server" associatedcontrolid="Author" text="Author: " />
            <asp:dropdownlist id="Author" runat="server" />
        </div>

        <div>
            <asp:label id="ISBNLabel" runat="server" associatedcontrolid="ISBN" text="ISBN: " />
            <asp:textbox id="ISBN" runat="server" />
        </div>

    </fieldset>

    <div>
        <asp:button id="Save" runat="server" text="Save" onclick="Save_Click" />
        <asp:button id="Cancel" runat="server" text="Cancel" onclick="Cancel_Click" />
    </div>

</asp:Content>
