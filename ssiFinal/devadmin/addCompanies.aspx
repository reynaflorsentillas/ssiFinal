<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="addCompanies.aspx.vb" Inherits="ssiFinal.addCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Add Client Companies:
                    </h4>
                </div>
                <div class="widget-body">
                    
                    <div class="control-group">
                        <label class="control-label">Company Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="CompanyNameTextBox" runat="server" CssClass="span6" MaxLength="50" ValidationGroup="999"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CompanyNameTextBox" ErrorMessage="Enter A Company Name" ValidationGroup="999"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Company Code:</label>
                        <div class="controls">
                            <asp:TextBox ID="CompanyCodeTextBox" runat="server" MaxLength="8" CssClass="span6" ValidationGroup="999"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CompanyCodeTextBox" ErrorMessage="Enter a Company Code" ValidationGroup="999"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Add Company" />--%>
                            <button id="addCompany" runat="server" class="btn btn-primary" ValidationGroup="999"><i class="icon-ok"></i>Add Company</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Company List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls portlet-scroll-1" style="height:500px;border: 2px solid grey;">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CompanyCode" DataSourceID="CompanySqlDataSource" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" UpdateText="Save" />
                                    <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" ReadOnly="True" SortExpression="CompanyCode" />
                                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" ReadOnly="True" />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" ReadOnly="True" />
                                    <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" ReadOnly="True" />
                                    <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" ReadOnly="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
    <%-----------------------------DATA SOURCES-----------------------------%>
    <asp:SqlDataSource ID="CompanySqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Companies] WHERE [CompanyCode] = @CompanyCode" InsertCommand="INSERT INTO Companies(CompanyCode, CompanyName, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy) VALUES (@CompanyCode, @CompanyName, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy)" SelectCommand="SELECT * FROM [Companies]" UpdateCommand="UPDATE Companies SET CompanyName = @CompanyName, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy WHERE (CompanyCode = @CompanyCode)">
        <DeleteParameters>
            <asp:Parameter Name="CompanyCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="CompanyCodeTextBox" Name="CompanyCode" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="CompanyNameTextBox" Name="CompanyName" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="CreatedDate" SessionField="dtn" />
            <asp:SessionParameter Name="CreatedBy" SessionField="Username" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" />
            <asp:SessionParameter Name="ModifiedDate" SessionField="ModifiedDate" />
            <asp:SessionParameter Name="ModifiedBy" SessionField="adminUserName" />
            <asp:Parameter Name="CompanyCode" />
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

