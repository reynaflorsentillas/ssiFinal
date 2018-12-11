<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="MasterlistHistory.aspx.vb" Inherits="ssiFinal.MasterlistHistory" %>
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
                        Master List History:
                    </h4>
                </div>
                <div class="widget-body">

                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls">
                                <div class="pull-right">
                                    <asp:DropDownList ID="SearchDropDownList" runat="server">
                                        <asp:ListItem>Masterlist ID</asp:ListItem>
                                        <asp:ListItem>Barcode</asp:ListItem>
                                        <asp:ListItem>Modified By</asp:ListItem>
                                        <%--<asp:ListItem>Modified Date</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                                    <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />
                                    <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row-fluid">
                             <div class="control-group">
                                 <div class="controls portlet-scroll-1" style="height: 700px; border: 2px solid grey;">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1"  CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True" PageSize="20" AllowSorting="True">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                                    <asp:BoundField DataField="MasterlistId" HeaderText="MasterlistId" SortExpression="MasterlistId" />
                                                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" SortExpression="Barcode" />
                                                    <asp:BoundField DataField="Details" HeaderText="Details" SortExpression="Details" />
                                                    <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" />
                                                    <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [MasterlistHistory] ORDER BY [ModifiedDate] DESC"></asp:SqlDataSource>

                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
                                            </SelectParameters>
                                     </asp:SqlDataSource>

                                 </div>
                             </div>
                         </div>

                </div>
            </div>
        </div>
    </div>

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
     
    
</asp:Content>
