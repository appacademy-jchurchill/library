<%@ Page Title="Edit Author" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorEdit.aspx.cs" Inherits="Library.AuthorEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Edit Author</h2>

    <fieldset>

        <div>
            <asp:label id="FirstNameLabel" runat="server" associatedcontrolid="FirstName" text="First Name: " />
            <asp:textbox id="FirstName" runat="server" />
        </div>

        <div>
            <asp:label id="LastNameLabel" runat="server" associatedcontrolid="LastName" text="Last Name: " />
            <asp:textbox id="LastName" runat="server" />
        </div>

    </fieldset>

    <div>
        <asp:button id="Save" runat="server" text="Save" onclick="Save_Click" />
        <asp:button id="Cancel" runat="server" text="Cancel" onclick="Cancel_Click" />
    </div>

</asp:Content>
