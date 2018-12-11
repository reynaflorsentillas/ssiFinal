<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="addClient.aspx.vb" Inherits="ssiFinal.addClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Add New User
                    </h4>
                </div>
                <div class="widget-body">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Visible="False" />
                    <div class="control-group">
                        <label class="control-label"></label>
                        <div class="controls text-center">
                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="1" Text="Admin" CssClass="radio" CausesValidation="False" AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="1" Text="SSI Employee" CssClass="radio" AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="1" Text="Client" CssClass="radio" AutoPostBack="True" Checked="True" />
                                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="1" Text="Client Supervisor" CssClass="radio" AutoPostBack="True" />
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Panel ID="panel1" runat="server">
                            <label class="control-label">Client Company:</label>
                            <div class="controls">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CompanyCode" CssClass="span6">
                                </asp:DropDownList>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="control-group">
                        <asp:Panel ID="pnael2" runat="server">
                            <label class="control-label">Client Department:</label>
                            <div class="controls">
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="DepartmentName" DataValueField="DepartmentCode" CssClass="span6">
                                </asp:DropDownList>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="control-group">
                        <label class="control-label">First Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="firstNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Last Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lastNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Email:</label>
                        <div class="controls">
                            <asp:TextBox ID="emailTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Password:</label>
                        <div class="controls">
                            <asp:TextBox ID="passwordTextBox" runat="server" CssClass="span6" TextMode="Password"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="passwordTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Contact Number:</label>
                        <div class="controls">
                            <asp:TextBox ID="contactNumberTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="contactNumberTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Address:</label>
                        <div class="controls">
                            <asp:TextBox ID="addressTextBox" runat="server" TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="addressTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label"></label>
                        <div class="controls">
                            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label"></label>
                        <div class="controls">
                            <%--<asp:Button ID="Button1" runat="server" Text="Add New User" />--%>
                            <button id="addNewUser" runat="server" class="btn btn-primary"><i class="icon-ok"></i>Add New User</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <%-----------------------------DATA SOURCES-----------------------------%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Departments] WHERE ([CompanyCode] = @CompanyCode)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [ClientUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ClientUsers] ([username], [DepartmentCode], [FirstName], [LastName], [email], [address], [ContactNumber], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [isAdmin], [CompanyCode]) VALUES (@username, @DepartmentCode, @FirstName, @LastName, @email, @address, @ContactNumber, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate, @isAdmin, @CompanyCode)" SelectCommand="SELECT * FROM [ClientUsers]" UpdateCommand="UPDATE [ClientUsers] SET [username] = @username, [DepartmentCode] = @DepartmentCode, [FirstName] = @FirstName, [LastName] = @LastName, [email] = @email, [address] = @address, [ContactNumber] = @ContactNumber, [CreatedBy] = @CreatedBy, [ModifiedBy] = @ModifiedBy, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate, [isAdmin] = @isAdmin, [CompanyCode] = @CompanyCode WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="emailTextBox" Name="username" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownList2" Name="DepartmentCode" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="firstNameTextBox" Name="FirstName" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lastNameTextBox" Name="LastName" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="emailTextBox" Name="email" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="addressTextBox" Name="address" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="contactNumberTextBox" Name="ContactNumber" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="CreatedBy" SessionField="Username" Type="String" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:SessionParameter Name="CreatedDate" SessionField="dtn" Type="DateTime" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="isAdmin" Type="Decimal" />
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
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
<asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="Type" SessionField="AlertType" Type="String" />
            <asp:Parameter DefaultValue="NEW" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="1" Name="Alerts" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status FROM Messages WHERE (Sender &lt;&gt; @Sender) AND (Status = 1) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status =0 WHERE (ConvoId = @InboxID) AND (Status = 1) AND (Receiver = @Receiver)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:SessionParameter Name="Receiver" SessionField="AdminUserName" />
        </UpdateParameters>
    </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
                                            </SelectParameters>
                                     </asp:SqlDataSource>

                                 </asp:Content>
<asp:Content ID="myAlerts" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-bell-alt"></i>
        <span id="TotalCount" runat="server" class="badge badge-warning"></span>
    </a>
    <ul class="dropdown-menu extended notification" id="Notifications" runat="server">
       
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-envelope-alt"></i>
        <span id="TotalMessages" runat="server" class="badge badge-warning"></span>
    </a>
    <ul id="messagesNotif" class="dropdown-menu extended inbox portlet-scroll-1" runat="server">
        
    </ul>
</asp:Content>
