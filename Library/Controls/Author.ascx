<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Author.ascx.cs" Inherits="Library.Controls.Author" %>

<h2><%= Mode.ToString() %> Author</h2>

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
