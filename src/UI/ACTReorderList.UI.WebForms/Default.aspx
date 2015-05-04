<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ACTReorderList.UI.WebForms.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li><a href="<%=ResolveClientUrl("~/UsingSqlDataSource.aspx")%>">Using SqlDataSource</a></li>
    </ul>
</asp:Content>