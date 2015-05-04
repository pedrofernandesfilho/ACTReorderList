<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FromList.aspx.cs" Inherits="ACTReorderList.UI.WebForms.FromList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <h5>To do:</h5>
    <%--<asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>--%>
            <act:ReorderList runat="server" ID="ReorderList" CssClass="reorderList" ClientIDMode="AutoID"
                DataKeyField="Id"
                SortOrderField="Sequence"
                ItemInsertLocation="End"
                AllowReorder="true"
                DragHandleAlignment="Left"
                PostBackOnReorder="false"
                ShowInsertItem="false">
                <EmptyListTemplate>
                    Empty List!
                </EmptyListTemplate>
                <ItemTemplate>
                    <div class="itemTemplate">
                        <span><%#Eval("Description") %></span>
                        <span> (initial sequence: <asp:Label runat="server" ID="lblSequence" Text='<%#Eval("Sequence") %>'></asp:Label>)</span>
                    </div>
                </ItemTemplate>
                <DragHandleTemplate>
                    <div class="dragHandleTemplate"></div>
                </DragHandleTemplate>
                <ReorderTemplate>   
                    <div class="reorderTemplate"></div>
                </ReorderTemplate>
            </act:ReorderList>
<%--            </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>