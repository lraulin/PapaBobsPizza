﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PapaBobs.Web.Login" %>

<%@ Import Namespace="System.Web.Security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Logon Page</h3>
    <table>
        <tr>
            <td>E-mail address:</td>
            <td>
                <asp:TextBox ID="UserEmail" runat="server" /></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    ControlToValidate="UserEmail"
                    Display="Dynamic"
                    ErrorMessage="Cannot be empty."
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="UserPass" TextMode="Password"
                    runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    ControlToValidate="UserPass"
                    ErrorMessage="Cannot be empty."
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>Remember me?</td>
            <td>
                <asp:CheckBox ID="Persist" runat="server" /></td>
        </tr>
    </table>
    <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On"
        runat="server" />
    <p>
        <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>
</asp:Content>
