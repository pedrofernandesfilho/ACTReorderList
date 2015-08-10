<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UsingObjectDataSource.aspx.cs" Inherits="ACTReorderList.UI.WebForms.UsingObjectDataSource" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource"  OnObjectCreating="ObjectDataSource_ObjectCreating" 
        TypeName="ACTReorderList.Core.Domain.Service.TaskService"
        SelectMethod="GetAllOrderByPriority"
        UpdateMethod="Update"
        InsertMethod="Add">
        <InsertParameters>
            <asp:FormParameter Name="description" Type="String" FormField="txtDescription" />
        </InsertParameters>
    </asp:ObjectDataSource>

<%--    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"  
        TypeName="ACTReorderList.UI.WebForms.UsingObjectDataSource"
        SelectMethod="ObjectDataSource_SelectMethod"
        UpdateMethod="ObjectDataSource_UpdateMethod"
        InsertMethod="ObjectDataSource_InsertMethod">
        <InsertParameters>
            <asp:Parameter Name="priority" Type="Int32" />
            <asp:FormParameter Name="description" Type="String" FormField="txtDescription" />
        </InsertParameters>
    </asp:ObjectDataSource>--%>

    <h3>Using ObjectDataSource</h3>
    <b>Tasks:</b>
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
                        <span>Priority: #<%#string.Format("{0} - {1} ({2})", Eval("Priority"), Eval("Description"), Eval("Id"))%></span>
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
                    <asp:Button runat="server" Text="add" CommandName="Insert" ID="Button1" />
                </InsertItemTemplate>
            </act:ReorderList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>