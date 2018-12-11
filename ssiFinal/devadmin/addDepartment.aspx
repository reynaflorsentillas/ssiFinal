<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="addDepartment.aspx.vb" Inherits="ssiFinal.addDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Add Client Departments:
                    </h4>
                </div>
                <div class="widget-body">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Visible="False" />
                    <div class="control-group">
                        <label class="control-label">Company:</label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCompanyList" DataTextField="CompanyName" DataValueField="CompanyCode" CssClass="span6">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Department Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="span6" MaxLength="50"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter a Department Name"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Department Code:</label>
                        <div class="controls">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="span6" MaxLength="8"></asp:TextBox>
                            <span class="help-inline">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter a Department Code"></asp:RequiredFieldValidator></span>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <%--<asp:Button ID="Button1" runat="server" Text="Add Department" />--%>
                            <button id="addDepartment" runat="server" class="btn btn-primary"><i class="icon-ok"></i>Add Department</button>
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
                        Department List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DepartmentCode" DataSourceID="SqlDataSourceDepartmentList" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True" AllowSorting="True" ShowFooter="True">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CausesValidation="False" UpdateText="Save" />
                                    <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" ReadOnly="True"/>
                                    <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" SortExpression="DepartmentCode" ReadOnly="True" />
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName" />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="CreatedBy" ReadOnly="True" />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="CreatedDate" ReadOnly="True" />
                                    <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="ModifiedBy" ReadOnly="True" />
                                    <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" SortExpression="ModifiedDate" ReadOnly="True"/>
                                   <%-- <asp:TemplateField HeaderText="Total Boxes">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelTotal" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <%-----------------------------DATA SOURCES-----------------------------%>
    <asp:SqlDataSource ID="SqlDataSourceCompanyList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDepartmentList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Departments] WHERE [DepartmentCode] = @DepartmentCode" InsertCommand="INSERT INTO [Departments] ([DepartmentCode], [DepartmentName], [CompanyCode], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (@DepartmentCode, @DepartmentName, @CompanyCode, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)" SelectCommand="SELECT * FROM [Departments] WHERE ([CompanyCode] = @CompanyCode)" UpdateCommand="UPDATE Departments SET DepartmentName = @DepartmentName, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE (DepartmentCode = @DepartmentCode)">
        <DeleteParameters>
            <asp:Parameter Name="DepartmentCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="TextBox2" Name="DepartmentCode" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBox1" Name="DepartmentName" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
            <asp:SessionParameter Name="CreatedBy" SessionField="Username" Type="String" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:SessionParameter Name="CreatedDate" SessionField="dtn" Type="DateTime" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="DepartmentName" SessionField="DepartmentName" />
            <asp:SessionParameter Name="ModifiedBy" SessionField="ModifiedBy" />
            <asp:SessionParameter Name="ModifiedDate" SessionField="ModifiedDate" />
            <asp:SessionParameter Name="DepartmentCode" SessionField="DepartmentCode" />
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
    <br />
    <asp:SqlDataSource ID="SqlDataSourceTotalBoxes" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [MasterList] WHERE (([CompanyCode] = @CompanyCode) AND ([Department] = @Department))" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
            <asp:SessionParameter Name="Department" SessionField="Department" Type="String" />
        </SelectParameters>
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