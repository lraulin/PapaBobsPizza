<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobs.Web.AdminPages.OrderManagement2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="ordersGridView" runat="server" OnRowCommand="ordersGridView_RowCommand">
            <Columns>
                <asp:ButtonField Text="Complete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
