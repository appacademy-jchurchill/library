<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Login</h2>

    <asp:panel id="FailureMessage" runat="server" visible="false">
        <p>Login failure.</p>
    </asp:panel>

    <fieldset>

        <div class="form-group">
            <asp:label id="LibraryCardNumberLabel" runat="server" associatedcontrolid="LibraryCardNumber" text="Library Card Number: " />
            <asp:textbox id="LibraryCardNumber" runat="server" cssclass="form-control" />
        </div>

        <div>
            <asp:label id="PasswordLabel" runat="server" associatedcontrolid="Password" text="Password: " />
            <asp:textbox id="Password" runat="server" cssclass="form-control" textmode="Password" />
        </div>

    </fieldset>

    <div class="p-3">
        <asp:button id="LoginUser" runat="server" text="Login" cssclass="btn btn-success btn-lg" onclick="LoginUser_Click" />
   </div>

</asp:Content>
