<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UsingSqlDataSource.aspx.cs" Inherits="ACTReorderList.UI.WebForms.UsingSqlDataSource" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>

    <h3>To do list:</h3>
    <asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>    <asp:SqlDataSource runat="server" ID="SqlDataSource" ConnectionString="<%$ ConnectionStrings:Default%>"
        SelectCommand="SELECT [Id], [Priority], [Description] FROM [Task] ORDER BY Priority ASC" 
        UpdateCommand="UPDATE [Task] SET [Priority] = @Priority WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [Task] (Priority, Description) VALUES (@Priority, @Description)">
        <UpdateParameters>
            <asp:Parameter Name="Priority" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Priority" Type="Int32" />
            <asp:FormParameter Name="Description" Type="String" FormField="txtDescription" />
        </InsertParameters>
    </asp:SqlDataSource>
            <act:ReorderList runat="server" ID="ReorderList" CssClass="reorderList" ClientIDMode="AutoID"
                DataKeyField="Id"
                SortOrderField="Priority"
                ItemInsertLocation="End"
                AllowReorder="true"
                DragHandleAlignment="Left"
                PostBackOnReorder="true"
                ShowInsertItem="true"
                EnableViewState="true"
                DataSourceID="SqlDataSource">
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