<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ReportsTransactionGraph.aspx.vb" Inherits="ssiFinal.ReportsTransactionGraph" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <%--<script src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
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
                        Transactions Graph Report:
                    </h4>
                </div>
                <div class="widget-body">

                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Pickup Transactions</asp:ListItem>
                        <asp:ListItem>Repickup Transactions</asp:ListItem>
                        <asp:ListItem>Retrieval Transactions</asp:ListItem>
                        <asp:ListItem>Destruction Transactions</asp:ListItem>
                        <asp:ListItem>All Transactions</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtFrom" runat="server" placeholder="From Date"></asp:TextBox>
                    <asp:TextBox ID="txtTo" runat="server" placeholder="To Date"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="View Report" CssClass="btn btn-primary" />
                    <%--<asp:Button ID="ButtonExportPdf" runat="server" Text="Download PDF" CssClass="btn btn-primary" />
                    <asp:Button ID="ButtonExportExcel" runat="server" Text="Download EXCEL" CssClass="btn btn-primary" />--%>

                    <br />
                    <br />

                    <asp:Chart ID="Chart1" runat="server" Width="962px" Palette="SeaGreen" Height="669px">
                        <series>
                                <asp:Series Name="Transactions" ChartType="Column">
                                    <Points>
                                       <%-- <asp:DataPoint AxisLabel="New Pickup Request" YValues="10" />
                                        <asp:DataPoint AxisLabel="Processed Pickup Request" YValues="10" />
                                        <asp:DataPoint AxisLabel="Total Pickup Request" YValues="10" />--%>
                                    </Points>
                                </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>

                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSourcePickupsNEW" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From ) AND (RequestDate &lt;= @To )" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="PICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePickupsPROCESSED" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From ) AND (RequestDate &lt;= @To )" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="PICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourcePickupALL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status &lt;&gt; @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="PICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="FORAPPROVAL" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>

    <br />
    <asp:SqlDataSource ID="SqlDataSourceRetrievalNEW" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="RETRIEVAL" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRetrievalPROCESSED" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="RETRIEVAL" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRetrievalALL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status &lt;&gt; @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="RETRIEVAL" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="FORAPPROVAL" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSourceDestructionNew" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="DESTRUCTION" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDestructionPROCESSED" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="DESTRUCTION" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDestructionALL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status &lt;&gt; @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="DESTRUCTION" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="FORAPPROVAL" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSourceRepickupNEW" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="REPICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRepickupPROCESSED" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="REPICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRepickupALL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status &lt;&gt; @Status) AND (RequestDate &gt;= @From) AND (RequestDate &lt;= @To)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="REPICKUP" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="FORAPPROVAL" Name="Status" QueryStringField="Status" Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtTo" Name="To" PropertyName="Text" />
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

                        
    <script>
        $(function () {
            $(<%= txtTo.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>


</asp:Content>
