<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ReportSalesRevenue.aspx.vb" Inherits="ssiFinal.ReportSalesRevenue" %>

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
    </style>
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

    <%--        <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Monthly Box Overview:
                    </h4>
                </div>
                <div class="widget-body">

                    <div class="control-group">--%>

    <h4>Monthly Box Overview</h4>
    <%--Select format:
    <asp:DropDownList ID="DropDownListSelectFormat" runat="server" AutoPostBack="True">
        <asp:ListItem>PDF</asp:ListItem>
        <asp:ListItem>EXCEL</asp:ListItem>
    </asp:DropDownList>--%>
    <asp:LinkButton ID="DownloadMonthlyBoxOverview" runat="server" CssClass="btn-link" Text="Download Report PDF"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="DownloadMonthlyBoxOverviewEXCEL" runat="server" CssClass="btn-link" Text="Download Report EXCEL"></asp:LinkButton>
                            <div class="controls ">

                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceSalesRevenue" CssClass="table table-striped table-bordered table-advance table-hover" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode" />
                                        <asp:BoundField DataField="January" HeaderText="January" ReadOnly="True" SortExpression="January" />
                                        <asp:BoundField DataField="Feburary" HeaderText="Feburary" ReadOnly="True" SortExpression="Feburary" />
                                        <asp:BoundField DataField="March" HeaderText="March" ReadOnly="True" SortExpression="March" />
                                        <asp:BoundField DataField="April" HeaderText="April" ReadOnly="True" SortExpression="April" />
                                        <asp:BoundField DataField="May" HeaderText="May" ReadOnly="True" SortExpression="May" />
                                        <asp:BoundField DataField="June" HeaderText="June" ReadOnly="True" SortExpression="June" />
                                        <asp:BoundField DataField="July" HeaderText="July" ReadOnly="True" SortExpression="July" />
                                        <asp:BoundField DataField="August" HeaderText="August" ReadOnly="True" SortExpression="August" />
                                        <asp:BoundField DataField="September" HeaderText="September" ReadOnly="True" SortExpression="September" />
                                        <asp:BoundField DataField="October" HeaderText="October" ReadOnly="True" SortExpression="October" />
                                        <asp:BoundField DataField="November" HeaderText="November" ReadOnly="True" SortExpression="November" />
                                        <asp:BoundField DataField="December" HeaderText="December" ReadOnly="True" SortExpression="December" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceSalesRevenue" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT CompanyCode, COUNT(CASE WHEN MONTH(CreatedDate) = 1 THEN 1 ELSE NULL END) AS January, COUNT(CASE WHEN MONTH(CreatedDate) = 2 THEN 1 ELSE NULL END) AS Feburary, COUNT(CASE WHEN MONTH(CreatedDate) = 3 THEN 1 ELSE NULL END) AS March, COUNT(CASE WHEN MONTH(CreatedDate) = 4 THEN 1 ELSE NULL END) AS April, COUNT(CASE WHEN MONTH(CreatedDate) = 5 THEN 1 ELSE NULL END) AS May, COUNT(CASE WHEN MONTH(CreatedDate) = 6 THEN 1 ELSE NULL END) AS June, COUNT(CASE WHEN MONTH(CreatedDate) = 7 THEN 1 ELSE NULL END) AS July, COUNT(CASE WHEN MONTH(CreatedDate) = 8 THEN 1 ELSE NULL END) AS August, COUNT(CASE WHEN MONTH(CreatedDate) = 9 THEN 1 ELSE NULL END) AS September, COUNT(CASE WHEN MONTH(CreatedDate) = 10 THEN 1 ELSE NULL END) AS October, COUNT(CASE WHEN MONTH(CreatedDate) = 11 THEN 1 ELSE NULL END) AS November, COUNT(CASE WHEN MONTH(CreatedDate) = 12 THEN 1 ELSE NULL END) AS December FROM MasterList WHERE (YEAR(CreatedDate) = @Year) GROUP BY CompanyCode">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Year" SessionField="Year" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
    <br />
    <%--                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <%--<div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Monthly Box Overview:
                    </h4>
                </div>
                <div class="widget-body">--%>
    <%--                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls">
                                <div class="pull-right">--%>
    <div id="non-print">
        <asp:Label ID="Label1" runat="server" Text="Select Start Date"></asp:Label>
        <asp:DropDownList ID="DropDownListFrom" runat="server" AutoPostBack="true">
            <asp:ListItem Value="1/26">January 26</asp:ListItem>
            <asp:ListItem Value="2/26">February 26</asp:ListItem>
            <asp:ListItem Value="3/26">March 26</asp:ListItem>
            <asp:ListItem Value="4/26">April 26</asp:ListItem>
            <asp:ListItem Value="5/26">May 26</asp:ListItem>
            <asp:ListItem Value="6/26">June 26</asp:ListItem>
            <asp:ListItem Value="7/26">July 26</asp:ListItem>
            <asp:ListItem Value="8/26">August 26</asp:ListItem>
            <asp:ListItem Value="9/26">September 26</asp:ListItem>
            <asp:ListItem Value="10/26">October 26</asp:ListItem>
            <asp:ListItem Value="11/26">November 26</asp:ListItem>
            <asp:ListItem Value="12/26">December 26</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYear" runat="server" Enabled="False">
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="To"></asp:Label>
        <asp:DropDownList ID="DropDownListTo" runat="server" AutoPostBack="true" Enabled="False">
            <asp:ListItem Value="1/26">January 25</asp:ListItem>
            <asp:ListItem Value="2/26">February 25</asp:ListItem>
            <asp:ListItem Value="3/26">March 25</asp:ListItem>
            <asp:ListItem Value="4/26">April 25</asp:ListItem>
            <asp:ListItem Value="5/26">May 25</asp:ListItem>
            <asp:ListItem Value="6/26">June 25</asp:ListItem>
            <asp:ListItem Value="7/26">July 25</asp:ListItem>
            <asp:ListItem Value="8/26">August 25</asp:ListItem>
            <asp:ListItem Value="9/26">September 25</asp:ListItem>
            <asp:ListItem Value="10/26">October 25</asp:ListItem>
            <asp:ListItem Value="11/26">November 25</asp:ListItem>
            <asp:ListItem Value="12/26">December 25</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYear2" runat="server" Enabled="False">
        </asp:DropDownList>

        <asp:Button ID="ButtonGenerate" runat="server" Text="Generate Report" CssClass="btn btn-primary" />
        <br />
        <asp:LinkButton ID="DownloadMonthlyBoxOverviewDetails" runat="server" CssClass="btn-link" Text="Download Report PDF" Visible="False"></asp:LinkButton>&nbsp;
        <asp:LinkButton ID="DownloadMonthlyBoxOverviewDetailsExcel" runat="server" CssClass="btn-link" Text="Download Report EXCEL" Visible="False"></asp:LinkButton>
    </div>

    <%--                            </div>
                                
                            </div>
                        </div>
                    </div>--%>

    <div class="control-group">
        <div class="controls">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceSalesRevenue2" ShowFooter="True" CssClass="table table-striped table-bordered table-advance table-hover">
                <Columns>
                    <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode" />
                    <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" SortExpression="Month" />
                    <%--<asp:TemplateField>
                                        <FooterTemplate>
                                            <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <br />

            <asp:SqlDataSource ID="SqlDataSourceSalesRevenue2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT CompanyCode, COUNT(CreatedDate) AS Month FROM MasterList WHERE (CreatedDate &gt;= @From ) AND (CreatedDate &lt;= @To ) GROUP BY CompanyCode">
                <SelectParameters>
                    <asp:SessionParameter Name="From" SessionField="@From" />
                    <asp:SessionParameter Name="To" SessionField="@To" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />

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


        </div>
    </div>

    <%--                </div>
            </div>
        </div>
    </div>
    --%>
</asp:Content>
