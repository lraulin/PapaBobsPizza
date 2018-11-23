<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="PapaBobs.Web.OrderForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>Papa Bob's Pizza
                    <br />
                <small>Pizza to Code By</small>
            </h2>
        </div>
        <div class="form-group">
            <div class=""></div>
            <label>Size:</label>
            <asp:DropDownList ID="sizeDropDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="RecalculateTotalCost" AutoPostBack="true">
                <asp:ListItem Text="Choose One..." Selected="True" Value="" />
                <asp:ListItem Text="Small (12 inch - $12)" Value="Small" />
                <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium" />
                <asp:ListItem Text="Large (16 inch - $16)" Value="Large" />
            </asp:DropDownList>
            <br />
            <label>Crust:</label>
            <asp:DropDownList ID="crustDropDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="RecalculateTotalCost" AutoPostBack="true">
                <asp:ListItem Text="Choose One..." Selected="True" Value="" />
                <asp:ListItem Text="Regular" Value="Regular" />
                <asp:ListItem Text="Thin" Value="Thin" />
                <asp:ListItem Text="Thick" Value="Thick" />
            </asp:DropDownList>
        </div>
        <br />
        <label>Toppings:</label>
        <div class="form-group btn-group">
            <span class="input-group-addon">
                <asp:CheckBox ID="sausageCheckBox" runat="server" OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" />
                Sausage
            </span>
            <span class="input-group-addon">
                <asp:CheckBox ID="pepperoniCheckBox" runat="server" OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" />
                Pepperoni
            </span>
            <span class="input-group-addon">
                <asp:CheckBox ID="onionCheckBox" runat="server" OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" />
                Onion
            </span>
            <span class="input-group-addon">
                <asp:CheckBox ID="greenCheckBox" runat="server" OnCheckedChanged="RecalculateTotalCost" AutoPostBack="true" />
                Green Peppers
            </span>
        </div>
        <br />
        <h3>Deliver To:</h3>
        <div class="form-group">
            <label>Name:</label>
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control" />
            <label>Address:</label>
            <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control" />
            <label>Zip Code:</label>
            <asp:TextBox ID="zipCodeTextBox" runat="server" CssClass="form-control" />
            <label>Phone</label>
            <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control" />
        </div>
        <h3>Payment:</h3>
        <div class="form-group">
            <div class="radio">
                <label>
                    <asp:RadioButton ID="cashRadio" runat="server" GroupName="PaymentGroup" Checked="true" />
                    Cash
                </label>
            </div>
            <div class="radio">
                <label>
                    <asp:RadioButton ID="creditRadio" runat="server" GroupName="PaymentGroup" />
                    Credit
                </label>
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="orderButton" Text="Place Order" runat="server" OnClick="OrderButton_Click" CssClass="btn btn-primary" />
            <asp:Label ID="validationLabel" Text="" Visible="false" runat="server" CssClass="bg-danger" />
        </div>
        <h3>Total Cost:</h3>
        <div class="form-group">
            <asp:Label ID="resultLabel" runat="server" />
        </div>
    </div>
</asp:Content>
