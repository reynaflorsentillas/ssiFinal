<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="redirectUser.aspx.vb" Inherits="ssiFinal.redirectUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table {
            max-width: 100%;
            background-color: transparent;
            border-collapse: collapse;
            border-spacing: 0;
        }

        * {
            color: #000 !important;
            text-shadow: none !important;
            background: transparent !important;
            box-shadow: none !important;
        }

        .auto-style1 {
            color: buttontext;
            border-left: 1px solid buttonhighlight;
            border-right: 1px solid buttonshadow;
            border-top: 1px solid buttonhighlight;
            border-bottom: 1px solid buttonshadow;
            background-color: buttonface;
        }

        .auto-style2 {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
    <asp:SqlDataSource ID="SqlDataSourceNewActiveUser" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [ActiveUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ActiveUsers] ([UserId], [Username], [Name]) VALUES (@UserId, @Username, @Name)" SelectCommand="SELECT * FROM [ActiveUsers]" UpdateCommand="UPDATE [ActiveUsers] SET [Username] = @Username, [Name] = @Name WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="Username" SessionField="Username" Type="String" />
            <asp:SessionParameter Name="Name" SessionField="Name" Type="String" />
            <asp:SessionParameter Name="UserId" SessionField="UserId" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Username" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSourceGetName" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT FirstName, LastName FROM ClientUsers WHERE (username = @username)">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
        <asp:SqlDataSource ID="SqlDataSourceGetCompany" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies] WHERE ([CompanyCode] = @CompanyCode)" DataSourceMode="DataReader">
            <SelectParameters>
                <asp:SessionParameter Name="CompanyCode" SessionField="cCode" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceGetClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [ClientUsers] WHERE ([username] = @username)">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSourceGetDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT DepartmentCode, DepartmentName, CompanyCode, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate FROM Departments WHERE (DepartmentCode = @dCode)">
            <SelectParameters>
                <asp:SessionParameter Name="CompanyCode" SessionField="cCode" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceUserLogin" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [UserLogins] WHERE [Id] = @Id" InsertCommand="INSERT INTO [UserLogins] ([User], [DateLogin], [Alerts]) VALUES (@User, @DateLogin, @Alerts)" SelectCommand="SELECT * FROM [UserLogins]" UpdateCommand="UPDATE [UserLogins] SET [User] = @User, [DateLogin] = @DateLogin, [Alerts] = @Alerts WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="User" Type="String" />
                <asp:Parameter DbType="DateTime2" Name="DateLogin" />
                <asp:Parameter DefaultValue="1" Name="Alerts" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="User" Type="String" />
                <asp:Parameter DbType="DateTime2" Name="DateLogin" />
                <asp:Parameter Name="Alerts" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
