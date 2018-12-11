<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devclient/Site1.Master" CodeBehind="ClientTransactionHistory.aspx.vb" Inherits="ssiFinal.ClientTransactionHistory" %>
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
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Transaction History:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                    <div class="control-group">
                        <div class="controls">
                            <div class="pull-right">
                            <asp:DropDownList ID="SearchDropDownList" runat="server">
                                <asp:ListItem>Date</asp:ListItem>
                                <asp:ListItem>Description</asp:ListItem>
                                <asp:ListItem>Created By</asp:ListItem>
                                <asp:ListItem>MasterList ID</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />
                            <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                    </div>
                    
                    <div class="control-group">
                        <div class="controls">
                            <div class="table-responsive portlet-scroll-1" style="height:500px">
                                <asp:GridView ID="MasterListGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-advance table-hover" DataKeyNames="Id" DataSourceID="SqlDataSourceHistory" AllowPaging="True">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                        <asp:BoundField DataField="MasterListId" HeaderText="Masterlist ID" SortExpression="MasterListId" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="CreatedBy" Visible="False" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" DataFormatString="{0:d}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceHistory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, CompanyCode, MasterListId, Description, CreatedBy, CreatedDate FROM History WHERE (CompanyCode = @CompanyCode) ORDER BY Id DESC">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" />
        </SelectParameters>
    </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (username = @username) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
            <asp:Parameter DefaultValue="PROCESSED" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="2" Name="Alerts" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [ClientUsers] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
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