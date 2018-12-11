<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devclient/Site1.Master" CodeBehind="Dashboard.aspx.vb" Inherits="ssiFinal.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-envelope-alt"></i>
        <span id="TotalMessages" runat="server" class="badge badge-warning"></span>
    </a>
    <ul id="messagesNotif" class="dropdown-menu extended inbox portlet-scroll-1" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="myAlerts" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown">
        <i class="icon-bell-alt"></i>
        <span id="TotalCount" runat="server" class="badge badge-warning"></span>
    </a>
    <ul class="dropdown-menu extended notification portlet-scroll-1" id="Notifications" runat="server">
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
    <div class="row-fluid" runat="server" id="supervisorDiv">
        <!--BEGIN METRO STATES-->
        <h2>Supervisor Access</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-deep-red double">
                <a data-original-title="" href="PendingForApproval.aspx">
                    <i class=" icon-check-sign"></i>
                    <div class="info">Request Approval</div>
                    <div class="status">Approve Requests</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <!--BEGIN METRO STATES-->
        <h2>My Transactions</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-orange">
                <a data-original-title="" href="masterListClient.aspx">
                    <i class=" icon-list-alt"></i>
                    <div class="info">MasterList</div>
                    <div class="status">View MasterList</div>
                </a>
            </div>
            <div class="metro-nav-block nav-olive">
                <a data-original-title="" href="transactionsClient.aspx">
                    <i class="icon-book"></i>
                    <div class="info">Transactions</div>
                    <div class="status">View Transactions</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-grey">
                <a data-original-title="" href="ClientInvoice.aspx">
                    <i class="icon-file"></i>
                    <div class="info">Invoice</div>
                    <div class="status">View Invoices</div>
                </a>
            </div>
            <div class="metro-nav-block nav-deep-thistle">
                <a data-original-title="" href="ClientTransactionHistory.aspx">
                    <i class="icon-reorder"></i>
                    <div class="info">History</div>
                    <div class="status">View Transaction History</div>
                </a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <h2>Make A Request</h2>
        <div class="metro-nav">
            <div class="metro-nav-block nav-block-yellow">
                <a data-original-title="" href="pickUp.aspx">
                    <i class="icon-arrow-up"></i>
                    <div class="info">Pick Up</div>
                    <div class="status">Request for Pick Up</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-green">
                <a data-original-title="" href="retrieval.aspx">
                    <i class="icon-arrow-down"></i>
                    <div class="info">Retrieval</div>
                    <div class="status">Request for Retrieval</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-red">
                <a data-original-title="" href="RePickup.aspx">
                    <i class="icon-reply"></i>
                    <div class="info">Repick Up</div>
                    <div class="status">Request for Repick Up</div>
                </a>
            </div>
            <div class="metro-nav-block nav-block-blue">
                <a data-original-title="" href="destruction.aspx">
                    <i class="icon-remove"></i>
                    <div class="info">Destruction</div>
                    <div class="status">Request for Destruction</div>
                </a>
            </div>
            <div class="metro-nav">
                <div class="metro-nav-block nav-light-purple">
                    <a data-original-title="" href="ClientMessage.aspx">
                        <i class="icon-comment"></i>
                        <div class="info">Support</div>
                        <div class="status">Contact Our Support</div>
                    </a>
                </div>
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
                                        <li class="active"><a href="#tab_4_1" data-toggle="tab">Creating Pickup Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Creating Retrieval Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Creating Repickup Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Creating Destruction Requests</a></li>
                                        <li><a href="#tab_4_1" data-toggle="tab">Tutorial Overview</a></li>
                                    </ul>
                                    <script type="text/javascript">
                                        $('#tutnavigation li').click(function () {
                                            var nav = $(this).find('a').html();
                                            switch (nav) {
                                                case 'Creating Pickup Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/qMeNOESwsYQ');
                                                    break;
                                                case 'Creating Retrieval Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/pE6hliMTjDk');
                                                    break;
                                                case 'Creating Repickup Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/2nD0k_u1ES8');
                                                    break;
                                                case 'Creating Destruction Requests':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/mqD7BOTfo9s');
                                                    break;
                                                case 'Tutorial Overview':
                                                    $('#tutframe').attr('src', 'https://www.youtube.com/embed/BTZ6I0DhS38');
                                                    break;

                                            }
                                        });
                                    </script>
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="tab_4_1">
                                            <iframe id="tutframe" width="854" height="510" src="https://www.youtube.com/embed/qMeNOESwsYQ" frameborder="0" allowfullscreen></iframe>
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
    <div class="row-fluid">
        <div class="span12">
            <div class="widget red">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        FAQs
                    </h4>
                </div>
                <div class="widget-body">
                    <h4 class="title grey">FAQ Sections</h4>
                    <div class="tabbable custom-tab tabs-left">
                        <ul class="nav nav-tabs tabs-left" runat="server" id="sectionsFaqs">
                        </ul>
                        <div class="tab-content" runat="server" id="tabContent">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="space20"></div>
    <div class="space20"></div>
    <div class="space20"></div>
    <div class="space20"></div>

    <asp:SqlDataSource ID="SqlDataSourceLoadSections" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, FAQSection FROM FAQs" DataSourceMode="DataReader"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceLoadAnswers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [FAQAnswers] WHERE ([SectionId] = @SectionId)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="SectionId" SessionField="SectionId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (username = @username) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
            <asp:Parameter DefaultValue="PROCESSED" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="2" Name="Alerts" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status, Receiver FROM Messages WHERE (Status = 1) AND (Receiver = @Receiver) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status = 0 WHERE (ConvoId = @InboxID) AND (Receiver = @Receiver)">
        <SelectParameters>
            <asp:SessionParameter Name="Receiver" SessionField="clientUserName" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:SessionParameter Name="Receiver" SessionField="clientUserName" />
        </UpdateParameters>
    </asp:SqlDataSource>

     <%-- CHAT INFORMATION --%>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT FirstName, LastName, email FROM ClientUsers WHERE (username = @username)">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="LoggedUser" Type="String" />
            </SelectParameters>
    </asp:SqlDataSource>

    <asp:HiddenField ID="hdUserFullName" runat="server" />
    <asp:HiddenField ID="hdUserEmail" runat="server" />


    <script type="text/javascript" src="https://mylivechat.com/chatinline.aspx?hccid=88188563"></script>
    <%--<script type="text/javascript" src='https://mylivechat.com/chatbutton.aspx?hccid=68268000'></script>--%>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    alert($("#hfServerValue").val());

        MyLiveChat_SetUserName("<%=hdUserFullName.Value%>");
        MyLiveChat_SetEmail("<%=hdUserEmail.Value%>");
        //MyLiveChat_SetDepartment("Default");
        //MyLiveChat_SetQuestion("test question");
        //MyLiveChat_SetContextData("This is VIP");
        //MyLiveChat_SetProductName("Sample Product");
        //MyLiveChat_SetProductKey("Sample_7065");
        //});

    </script>
    
    <%-- CHAT INFORMATION --%>


</asp:Content>

