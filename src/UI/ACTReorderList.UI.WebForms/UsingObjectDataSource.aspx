<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UsingObjectDataSource.aspx.cs" Inherits="ACTReorderList.UI.WebForms.UsingObjectDataSource" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource" 
        TypeName="ACTReorderList.Core.Domain.Service.ServiceTask" OnObjectCreating="ObjectDataSource_ObjectCreating"
        SelectMethod="Get"
        UpdateMethod="UpdateOrder"
        InsertMethod="Add">
    </asp:ObjectDataSource>
    <h3>To do list:</h3>
    <asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>
            <act:ReorderList runat="server" ID="ReorderList" CssClass="reorderList" ClientIDMode="AutoID"
                DataKeyField="Id"
                SortOrderField="Priority"
                ItemInsertLocation="End"
                AllowReorder="true"
                DragHandleAlignment="Left"
                PostBackOnReorder="true"
                ShowInsertItem="true"
                EnableViewState="true"
                DataSourceID="ObjectDataSource">
                <EmptyListTemplate>
                    Empty List!
                </EmptyListTemplate>
                <ItemTemplate>
                    <div class="itemTemplate">
                        <span>Priority: #<%#Eval("Priority") %> - <%#Eval("Description") %></span>
                    </div>
                </ItemTemplate>
                <DragHandleTemplate>
                    <div class="dragHandleTemplate"></div>
                </DragHandleTemplate>
                <ReorderTemplate>   
                    <div class="reorderTemplate"></div>
                </ReorderTemplate>
                <InsertItemTemplate>
                    <input type="text" name="txtDescription" />
                    <asp:Button runat="server" Text="add" CommandName="Insert" />
                </InsertItemTemplate>
            </act:ReorderList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>