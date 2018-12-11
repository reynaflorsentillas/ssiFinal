<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="Dashboard.aspx.vb" Inherits="ssiFinal.Dashboard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <h3 class="page-title">Dashboard
            </h3>
        </div>
    </div>
    <hr />
    <div class="row-fluid">
        <div class="span4">
            <div class="widget-body">
                <h3>Total Boxes</h3>
                <div id="TotalBoxes" class="chart"></div>
                <div class="controls pull-right">
                    <h4>Total Boxes IN : <strong><%= boxesIn%></strong></h4>
                    <h4>Total Boxes OUT : <strong><%= boxesOut%></strong></h4>
                    <h4>Total Boxes DESTROYED : <strong><%= boxesDestroyed%></strong></h4>
                </div>
            </div>
        </div>
        <div class="span4">
            <div class="widget-body">
                <h3>Total NEW Transactions</h3>
                <div id="TransactionsPie" class="chart"></div>
                <div class="controls pull-right">
                    <h4>Total Pick Up : <strong><%= newPickup%></strong></h4>
                    <h4>Total Retrieval : <strong><%= newRetrieval%></strong></h4>
                    <h4>Total Repick Up : <strong><%= newRepickup%></strong></h4>
                    <h4>Total Destruction : <strong><%= newDestruction%></strong></h4>
                </div>
            </div>
        </div>
        <div class="span4">
            <div class="widget-body">
                <h3>Total Processed Transactions</h3>
                <div id="TransactionsPie2" class="chart"></div>
                <div class="controls pull-right">
                    <h4>Total Pick Up : <strong><%= procPickup%></strong></h4>
                    <h4>Total Retrieval : <strong><%= procRetrieval%></strong></h4>
                    <h4>Total Repick Up : <strong><%= procRepickup%></strong></h4>
                    <h4>Total Destruction : <strong><%= procDestruction%></strong></h4>
                </div>
            </div>
        </div>
    </div>
    <div class="row-fluid" runat="server" id="adminPanel">
        <h2>ADMIN Panel</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-green double">
                <a data-original-title="" href="addClient.aspx">
                    <i class="icon-user"></i>
                    <div class="info">User</div>
                    <div class="status">Add New User</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-red double">
                <a data-original-title="" href="changePassword.aspx">
                    <i class="icon-key"></i>
                    <div class="info">Password</div>
                    <div class="status">Change Password</div>
                </a>
            </div>
            <div class="metro-nav">
                <div class="metro-nav-block nav-light-purple double">
                    <a data-original-title="" href="AdminMessage.aspx">
                        <i class="icon-comment"></i>
                        <div class="info">Messages</div>
                        <div class="status">View Client Messages</div>
                    </a>
                </div>
                <div class="metro-nav-block nav-deep-gray double">
                    <a data-original-title="" href="FAQs.aspx">
                        <i class="icon-lightbulb"></i>
                        <div class="info">FAQs</div>
                        <div class="status">View or Add new FAQs</div>
                    </a>
                </div>
                <div class="metro-nav-block nav-deep-thistle double">
                    <a data-original-title="" href="LocationSettings.aspx">
                        <i class="icon-gear"></i>
                        <div class="info">Location Settings</div>
                        <div class="status">Change Location Settings</div>
                    </a>
                </div>
                <div class="metro-nav-block nav-light-blue double">
                    <a data-original-title="" target="_blank" href="https://www.mylivechat.com/webconsole/?from=subsite">
                        <i class="icon-comments-alt"></i>
                        <div class="info">Chat</div>
                        <div class="status">Log into Chat</div>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <!--BEGIN METRO STATES-->
        <h2>Request and Transactions</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-grey double">
                <a data-original-title="" href="TransactionPickups.aspx">
                    <i class="icon-arrow-up"></i>
                    <div class="info">Pick Up</div>
                    <div class="status">View New Pick Up Requests</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-green double">
                <a data-original-title="" href="ProcessedPickupTransactions.aspx">
                    <i class="icon-ok-sign"></i>
                    <div class="info">Pick Up</div>
                    <div class="status">View Processed Pick Up Transactions</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-grey double">
                <a data-original-title="" href="TransactionRetrievals.aspx">
                    <i class="icon-arrow-down"></i>
                    <div class="info">Retrieval</div>
                    <div class="status">View New Retrieval Requests</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-green double">
                <a data-original-title="" href="ProcessedRetrievalTransactions.aspx">
                    <i class="icon-ok-sign"></i>
                    <div class="info">Retrieval</div>
                    <div class="status">View Processed Retrieval Transactions</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-grey double">
                <a data-original-title="" href="TransactionRepickups.aspx">
                    <i class="icon-reply"></i>
                    <div class="info">Repick Up</div>
                    <div class="status">View New Repick Up Requests</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-green double">
                <a data-original-title="" href="ProcessedRepickupTransactions.aspx">
                    <i class="icon-ok-sign"></i>
                    <div class="info">Repick Up</div>
                    <div class="status">View Processed Repick Up Transactions</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-grey double">
                <a data-original-title="" href="TransactionDestructions.aspx">
                    <i class="icon-remove"></i>
                    <div class="info">Destruction</div>
                    <div class="status">View New Destruction Requests</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-green double">
                <a data-original-title="" href="ProcessedDestructionTransactions.aspx">
                    <i class="icon-ok-sign"></i>
                    <div class="info">Destruction</div>
                    <div class="status">View Processed Destruction Transactions</div>
                </a>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <!--BEGIN METRO STATES-->
        <h2>Clients</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-orange">
                <a data-original-title="" href="masterList.aspx">
                    <i class=" icon-list-alt"></i>
                    <div class="info">MasterList</div>
                    <div class="status">View MasterList</div>
                </a>
            </div>
            <div class="metro-nav-block nav-olive">
                <a data-original-title="" href="clientOverview.aspx">
                    <i class="icon-group"></i>
                    <div class="info">Clients</div>
                    <div class="status">View Clients Overview</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-blue">
                <a data-original-title="" href="addCompanies.aspx">
                    <i class="icon-building"></i>
                    <div class="info">Company</div>
                    <div class="status">Add New Company</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-yellow">
                <a data-original-title="" href="addDepartment.aspx">
                    <i class="icon-briefcase"></i>
                    <div class="info">Department</div>
                    <div class="status">Add New Department</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <!--BEGIN METRO STATES-->
        <h2>Reporting</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-deep-thistle">
                <a data-original-title="" href="ReportsTransactions.aspx">
                    <i class="icon-file"></i>
                    <div class="info">Documents</div>
                    <div class="status">View Document Reports</div>
                </a>
            </div>
            <div class="metro-nav-block nav-deep-terques ">
                <a data-original-title="" href="ReportsTransactionGraph.aspx">
                    <i class="icon-bar-chart"></i>
                    <div class="info">Graphs</div>
                    <div class="status">View Graph Reports</div>
                </a>
            </div>
            <div class="metro-nav-block nav-light-brown">
                <a data-original-title="" href="ReportSalesRevenue.aspx">
                    <i class="icon-archive"></i>
                    <div class="info">Boxes</div>
                    <div class="status">View Monthly Box Overview</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-purple">
                <a data-original-title="" href="ReportSpaceUtilization.aspx">
                    <i class="icon-tasks"></i>
                    <div class="info">Utilization</div>
                    <div class="status">View Space Utilization Report</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-green">
                <a data-original-title="" href="Invoice.aspx">
                    <i class="icon-file"></i>
                    <div class="info">Invoice</div>
                    <div class="status">Create and View Invoice</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="metro-nav">
                <h2>Tutorial Videos</h2>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-body">
                                <h4>Tutorial List:</h4>
                                <div class="tabbable custom-tab tabs-left">
                                    <!-- Only required for left/right tabs -->
                                    <ul id="tutnavigation" class="nav nav-tabs tabs-right">
                                        <li class="active"><a href="#tab_4_1" data-toggle="tab">Accepting Pickup Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Accepting Retrieval Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Accepting Repickup Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Accepting Destruction Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Creating Invoices</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Reports Tutorial</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Location Settings</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Create New User</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Create FAQS</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Masterlist Tutorial</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Other Features</a></li>
                                    </ul>
                                    <script type="text/javascript">
                                        $('#tutnavigation li').click(function () {
                                            var nav = $(this).find('a').html();
                                            switch (nav) {
                                                case 'Accepting Pickup Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/iwh2k-2CBcA');
                                                    break;
                                                case 'Accepting Retrieval Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/nDpvHWUS3vg');
                                                    break;
                                                case 'Accepting Repickup Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/3tiAkxBQLS8');
                                                    break;
                                                case 'Accepting Destruction Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/aNNJ9jvFzso');
                                                    break;
                                                case 'Creating Invoices':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/FY7PxKO6kIE');
                                                    break;
                                                case 'Reports Tutorial':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/-1iNOJ3UbsQ');
                                                    break;
                                                case 'Location Settings':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/yTcBiaYjmpw');
                                                    break;
                                                case 'Create New User':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/dxTlC1LxWRk');
                                                    break;
                                                case 'Create FAQS':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/nThyAq9p5L4');
                                                    break;
                                                case 'Masterlist Tutorial':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/B8cpwuUbDHo');
                                                    break;
                                                case 'Other Features':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/tSsFqVtpPzI');
                                                    break;

                                            }
                                        });
                                    </script>
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="tab_4_1">
                                            <iframe id="tutframe" width="854" height="510" src="https://www.youtube.com/embed/iwh2k-2CBcA" frameborder="0" allowfullscreen></iframe>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--END METRO STATES-->
    </div>
    <div class="space20"></div>
     <!--Chart for Total Boxes -->
    <script type="text/javascript">
        var data = [
        { label: "Boxes OUT", data: <%= boxesOut%>, color: "#4572A7" },
        { label: "Boxes DESTROYED", data: <%= boxesDestroyed%>, color: "#AA4643" },
        { label: "Boxes IN", data: <%= boxesIn%>, color: "#89A54E" },
        ];

        $(document).ready(function () {
            $.plot($("#TotalBoxes"), data, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 1,
                            formatter: function (label, series) {
                                return '<div style="font-size:11px; text-align:center; padding:2px; color:white;">' + label + '<br/>' + (series.percent).toFixed(2) + '%</div>';
                            },
                            background: {
                                opacity: 0.8
                            }
                        }
                    }
                },
                legend: {
                    show: false
                }
            });
        });

        var data2 = [
        { label: "Pick Up",  data: <%= newPickup%>, color: "#80699B"},
        { label: "Retrieval",  data: <%= newRetrieval%>, color: "#AA4643"},
        { label: "Repick Up",  data: <%= newRepickup%>, color: "#4572A7"},
        { label: "Destruction",  data: <%= newDestruction%>, color: "#3D96AE"}
        ];

        $(document).ready(function () {
            $.plot($("#TransactionsPie"), data2, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 1,
                            formatter: function (label, series) {
                                return '<div style="font-size:11px; text-align:center; padding:2px; color:white;">' + label + '<br/>' + (series.percent).toFixed(2) + '%</div>';
                            },
                            background: {
                                opacity: 0.8
                            }
                        }
                    }
                },
                legend: {
                    show: false
                }
            });
        });

        var data3 = [
        { label: "Pick Up",  data: <%= procPickup%>, color: "#80699B"},
        { label: "Retrieval",  data: <%= procRetrieval%>, color: "#AA4643"},
        { label: "Repick Up",  data: <%= procRepickup%>, color: "#4572A7"},
        { label: "Destruction",  data: <%= procDestruction%>, color: "#3D96AE"}
        ];

        $(document).ready(function () {
            $.plot($("#TransactionsPie2"), data3, {
                series: {
                    pie: {
                        show: true,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 1,
                            formatter: function (label, series) {
                                return '<div style="font-size:11px; text-align:center; padding:2px; color:white;">' + label + '<br/>' + (series.percent).toFixed(2) + '%</div>';
                            },
                            background: {
                                opacity: 0.8
                            }
                        }
                    }
                },
                legend: {
                    show: false
                }
            });
        });
    </script>
    <asp:SqlDataSource ID="SqlDataSourceGetBoxesCount" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Status, COUNT(Status) AS Count FROM MasterList GROUP BY Status"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceTransactions" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Type, Status, COUNT(*) AS Count FROM TransactionHeaders GROUP BY Type, Status"></asp:SqlDataSource>
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
