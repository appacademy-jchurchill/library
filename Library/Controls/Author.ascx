<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Author.ascx.cs" Inherits="Library.Controls.Author" %>

<h2 class="py-3"><%= Mode.ToString() %> Author</h2>

<fieldset>

    <div class="form-group">
        <asp:label id="FirstNameLabel" runat="server" associatedcontrolid="FirstName" text="First Name: " />
        <asp:textbox id="FirstName" runat="server" cssclass="form-control" />
    </div>

    <div>
        <asp:label id="LastNameLabel" runat="server" associatedcontrolid="LastName" text="Last Name: " />
        <asp:textbox id="LastName" runat="server" cssclass="form-control" />
    </div>

</fieldset>

<div class="p-3">
    <asp:button id="Save" runat="server" text="Save" cssclass="btn btn-success btn-lg" onclick="Save_Click" />
    <asp:button id="Cancel" runat="server" text="Cancel" cssclass="btn btn-outline-warning btn-lg ml-2" onclick="Cancel_Click" />
</div>
