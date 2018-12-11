<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="BoxCountPerDepartment.aspx.vb" Inherits="ssiFinal.BoxCountPerDepartment" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media print {

            #non-print *, img, .non-print {
                display: none;
            }

            #printable * {
                visibility: visible !important;
                margin: 0px 0px 0px 0px;
            }
        }

        .auto-style1 {
            font-size: large;
        }
    </style>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID%>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="theme/assets/uniform/css/uniform.default.css" /><link href="theme/assets/font-awesome/css/font-awesome.css" rel="stylesheet" /><link href="theme/css/style.css" rel="stylesheet" /><link href="theme/css/style-default.css" rel="stylesheet" id="style_color" /><link href="theme/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" /><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
     <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-envelope-alt"></i>
        <span id="TotalMessages" runat="server" class="badge badge-warning"></span>
    </a>
    <ul id="messagesNotif" class="dropdown-menu extended inbox portlet-scroll-1" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-bell-alt"></i>
        <span id="TotalCount" runat="server" class="badge badge-warning"></span>
    </a>
    <ul class="dropdown-menu extended notification" id="Notifications" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Box Count Per Department:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <div class="control-group">
                                <div class="controls">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCompanyList" DataTextField="CompanyName" DataValueField="CompanyCode" CssClass="span6">
                                    </asp:DropDownList>
                                    <div class="pull-right">
                                        <asp:Label ID="DateLabel" runat="server">Date:</asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="pull-right">
                                <asp:LinkButton ID="lnkPrint" runat="server" ToolTip="Click to Print All Records" Text="Print Report" OnClientClick="return PrintPanel();" CssClass="btn-link" Visible="false"></asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="DownloadReportBoxCount" runat="server" CssClass="btn-link" Text="Download Report PDF"></asp:LinkButton>
                                &nbsp;
                            <asp:LinkButton ID="DownloadReportBoxCountEXCEL" runat="server" CssClass="btn-link" Text="Download Report EXCEL"></asp:LinkButton>
                            </div>

                            <asp:Panel ID="Panel1" runat="server">
                                <%--<div id="logo" runat="server">
                                     <asp:Image ID="Image1" runat="server" ImageUrl="~/devadmin/ssilogo.jpg" CssClass="center" Height="67px" Width="75px"/><strong><span id="ssi" class="auto-style1">SSI Storage Solutions Inc.</span><span class="auto-style1">&nbsp; </span></strong>
                                 </div>--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/devadmin/ssilogo.jpg" CssClass="center" Height="67px" Width="75px" Visible="false" />
                                <br />
                                <strong><span id="ssi" class="auto-style1">
                                    <asp:Label ID="ReportLabel" runat="server" Text=""></asp:Label></span><span class="auto-style1">&nbsp; </span></strong>
                                <br />
                                <strong><span id="ssi2" class="auto-style1">
                                    <asp:Label ID="LabelCompany" runat="server" Text=""></asp:Label></span><span class="auto-style1">&nbsp; </span></strong>
                                <br />
                                <div class="controls">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DepartmentCode" DataSourceID="SqlDataSourceDepartmentList" CssClass="table table-striped table-bordered table-advance table-hover" ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" SortExpression="DepartmentCode" ReadOnly="True" />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName" />
                                            <asp:TemplateField HeaderText="Total Boxes">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelTotal" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </asp:Panel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <%-----------------------------DATA SOURCES-----------------------------%>
    <asp:SqlDataSource ID="SqlDataSourceCompanyList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDepartmentList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Departments] WHERE [DepartmentCode] = @DepartmentCode" InsertCommand="INSERT INTO [Departments] ([DepartmentCode], [DepartmentName], [CompanyCode], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate]) VALUES (@DepartmentCode, @DepartmentName, @CompanyCode, @CreatedBy, @ModifiedBy, @CreatedDate, @ModifiedDate)" SelectCommand="SELECT DepartmentCode, DepartmentName FROM Departments WHERE (CompanyCode = @CompanyCode)" UpdateCommand="UPDATE Departments SET DepartmentName = @DepartmentName, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE (DepartmentCode = @DepartmentCode)">
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

    <asp:SqlDataSource ID="SqlDataSourceAlerts0" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="Type" SessionField="AlertType" Type="String" />
            <asp:Parameter DefaultValue="NEW" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="1" Name="Alerts" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMessages0" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status FROM Messages WHERE (Sender &lt;&gt; @Sender) AND (Status = 1) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status =0 WHERE (ConvoId = @InboxID) AND (Status = 1) AND (Receiver = @Receiver)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:SessionParameter Name="Receiver" SessionField="AdminUserName" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
