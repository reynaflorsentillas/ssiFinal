<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImportUtility.aspx.vb" Inherits="ssiFinal.ImportUtility" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!-- ERROR MESSAGES -->
    <div id="ErrMsgs">
        <% 
            If errMsg <> "" Then
                Response.Write(errMsg)
            End If
        %>
    </div>
    <!-- END ERROR MESSAGES -->
  
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PanelMsterLogin" runat="server">
            <asp:TextBox ID="TextBoxMasterPassword" runat="server"></asp:TextBox><asp:Button ID="ButtonMasterLogin" runat="server" Text="Master Login" />
            <asp:Button ID="ButtonReset" runat="server" Text="Reset" />
            <asp:Label ID="LabelMasterStatus" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelImport" runat="server" Visible="false">
            <asp:DropDownList ID="DropDownListImport" runat="server">
                <asp:ListItem>Users</asp:ListItem>
                <asp:ListItem>Masterlist</asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="FileUploadImport" runat="server" /><asp:Button ID="ButtonUpload" runat="server" Text="Upload" /><asp:Button ID="ButtonImport" runat="server" Text="Import" style="height: 26px" />
            <asp:Label ID="LabelImportStatus" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridViewUsers" runat="server">
            </asp:GridView>
            <br />
            <asp:GridView ID="GridViewMasterlist" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [ClientUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ClientUsers] ([username], [DepartmentCode], [FirstName], [LastName], [email], [address], [ContactNumber], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [isAdmin], [CompanyCode]) VALUES (@username, @DepartmentCode, @FirstName, @LastName, @email, @address, @ContactNumber, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate, @isAdmin, @CompanyCode)" SelectCommand="SELECT * FROM [ClientUsers]" UpdateCommand="UPDATE [ClientUsers] SET [username] = @username, [DepartmentCode] = @DepartmentCode, [FirstName] = @FirstName, [LastName] = @LastName, [email] = @email, [address] = @address, [ContactNumber] = @ContactNumber, [CreatedBy] = @CreatedBy, [ModifiedBy] = @ModifiedBy, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate, [isAdmin] = @isAdmin, [CompanyCode] = @CompanyCode WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="DepartmentCode" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="ContactNumber" Type="String" />
                    <asp:Parameter Name="CreatedBy" Type="String" />
                    <asp:Parameter Name="ModifiedBy" Type="String" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                    <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    <asp:Parameter Name="isAdmin" Type="Decimal" />
                    <asp:Parameter Name="CompanyCode" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="username" Type="String" />
                    <asp:Parameter Name="DepartmentCode" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="address" Type="String" />
                    <asp:Parameter Name="ContactNumber" Type="String" />
                    <asp:Parameter Name="CreatedBy" Type="String" />
                    <asp:Parameter Name="ModifiedBy" Type="String" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                    <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    <asp:Parameter Name="isAdmin" Type="Decimal" />
                    <asp:Parameter Name="CompanyCode" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceCheckUser" runat="server"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourceMasterlist" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [MasterList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterList] ([CompanyCode], [Department], [BarCode], [BoxNumber], [Description], [Status], [LocationCode], [DestructionDate], [StockReceipt_id], [QRCode], [Retention], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Pickup], [Retrieval], [Repickup], [Destruction]) VALUES (@CompanyCode, @Department, @BarCode, @BoxNumber, @Description, @Status, @LocationCode, @DestructionDate, @StockReceipt_id, @QRCode, @Retention, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @Pickup, @Retrieval, @Repickup, @Destruction)" SelectCommand="SELECT * FROM [MasterList]" UpdateCommand="UPDATE [MasterList] SET [CompanyCode] = @CompanyCode, [Department] = @Department, [BarCode] = @BarCode, [BoxNumber] = @BoxNumber, [Description] = @Description, [Status] = @Status, [LocationCode] = @LocationCode, [DestructionDate] = @DestructionDate, [StockReceipt_id] = @StockReceipt_id, [QRCode] = @QRCode, [Retention] = @Retention, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate, [Pickup] = @Pickup, [Retrieval] = @Retrieval, [Repickup] = @Repickup, [Destruction] = @Destruction WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CompanyCode" Type="String" />
                    <asp:Parameter Name="Department" Type="String" />
                    <asp:Parameter Name="BarCode" Type="String" />
                    <asp:Parameter Name="BoxNumber" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="LocationCode" Type="String" />
                    <asp:Parameter Name="DestructionDate" Type="String" />
                    <asp:Parameter Name="StockReceipt_id" Type="String" />
                    <asp:Parameter Name="QRCode" Type="String" />
                    <asp:Parameter Name="Retention" Type="String" />
                    <asp:Parameter Name="CreatedBy" Type="String" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                    <asp:Parameter Name="ModifiedBy" Type="String" />
                    <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    <asp:Parameter Name="Pickup" Type="Int32" />
                    <asp:Parameter Name="Retrieval" Type="Int32" />
                    <asp:Parameter Name="Repickup" Type="Int32" />
                    <asp:Parameter Name="Destruction" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="CompanyCode" Type="String" />
                    <asp:Parameter Name="Department" Type="String" />
                    <asp:Parameter Name="BarCode" Type="String" />
                    <asp:Parameter Name="BoxNumber" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Status" Type="String" />
                    <asp:Parameter Name="LocationCode" Type="String" />
                    <asp:Parameter Name="DestructionDate" Type="String" />
                    <asp:Parameter Name="StockReceipt_id" Type="String" />
                    <asp:Parameter Name="QRCode" Type="String" />
                    <asp:Parameter Name="Retention" Type="String" />
                    <asp:Parameter Name="CreatedBy" Type="String" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                    <asp:Parameter Name="ModifiedBy" Type="String" />
                    <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    <asp:Parameter Name="Pickup" Type="Int32" />
                    <asp:Parameter Name="Retrieval" Type="Int32" />
                    <asp:Parameter Name="Repickup" Type="Int32" />
                    <asp:Parameter Name="Destruction" Type="Int32" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
