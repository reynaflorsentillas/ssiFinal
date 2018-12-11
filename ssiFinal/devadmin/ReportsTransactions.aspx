<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ReportsTransactions.aspx.vb" Inherits="ssiFinal.ReportsTransactions" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--                            <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>--%>
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
                        Transactions Document Report:
                    </h4>
                </div>
                <div class="widget-body" runat="server">


                    <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="Select Transaction Type">
                        <asp:ListItem>Pickup Transactions</asp:ListItem>
                        <asp:ListItem>Repickup Transactions</asp:ListItem>
                        <asp:ListItem>Retrieval Transactions</asp:ListItem>
                        <asp:ListItem>Destruction Transactions</asp:ListItem>
                        <asp:ListItem>All Transactions</asp:ListItem>
                    </asp:DropDownList>



                    <%--<asp:ScriptManager ID="smMain" runat="server" />--%>

                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" CausesValidation="True">
                        <asp:ListItem Text="NEW" Value="NEW" Enabled="true">NEW</asp:ListItem>
                        <asp:ListItem Text="PROCESSED" Value="PROCESSED" Enabled="true">PROCESSED</asp:ListItem>
                        <asp:ListItem Text="ALL" Value="ALL" Enabled="true">ALL</asp:ListItem>
                    </asp:DropDownList>

                    <%--                            <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>--%>
                    <asp:TextBox ID="txtFrom" runat="server" placeholder="From Date"></asp:TextBox>
                    <%--                            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>--%>
                    <asp:TextBox ID="txtTo" runat="server" placeholder="To Date"></asp:TextBox>
                    <asp:Button ID="ButtonViewReport" runat="server" Text="View Report" CssClass="btn btn-primary" />


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
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="850px" Width="100%" BorderStyle="None" GroupTreeImagesFolderUrl="" HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="300px" BestFitPage="False" EnableTheming="True" HasDrilldownTabs="False" HasDrillUpButton="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" HasExportButton="False" HasPrintButton="False" Visible="False" />

                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="devadmin\ReportsTransactionsCR.rpt">
                        </Report>
                    </CR:CrystalReportSource>


                    <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="Alerts" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                    <div class="row-fluid">
                        <h4><asp:Label ID="LabelTransactionCount" runat="server" Text="Label" Visible="False"></asp:Label></h4>
                        <asp:Label ID="LabelQuery" runat="server" Text="Label" Visible="False"></asp:Label>
                        <div class="control-group">
                            <div class="controls">
                                <div class="pull-right">
                                    <asp:Button ID="ButtonExportReport" runat="server" Text="Download PDF" CssClass="btn btn-primary" Visible="False" />
                                    <asp:Button ID="ButtonExportReportExcel" runat="server" Text="Download EXCEL" CssClass="btn btn-primary" Visible="False" />
                                </div>
                            </div>
                        </div>
                        <asp:GridView ID="GridViewTransactions" runat="server" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="False">
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <script>
        $(function () {
            $(<%= txtFrom.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>

    <script>
        $(function () {
            $(<%= txtTo.ClientID%>).datepicker();
                $("#anim").change(function () {
                    $("#datepicker").datepicker("option", "showAnim", $(this).val());
                });
            });
    </script>
</asp:Content>
