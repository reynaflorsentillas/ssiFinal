<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ProcessedDestructionTransactions.aspx.vb" Inherits="ssiFinal.ProcessedDestructionTransactions" %>
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
             <!-- ERROR MESSAGES -->
            <div id="ErrMsgs">
                <% 
                    If errMsg <> "" Then
                        Response.Write(errMsg)
                    End If

                    %>
            </div>
            <!-- END ERROR MESSAGES -->
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Destruction
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                    <div class="control-group">
                        <div class="controls">
                            <div class="pull-right">
                            <asp:DropDownList ID="SearchDropDownList" runat="server">
                                <asp:ListItem>Department Code</asp:ListItem>
                                <asp:ListItem>Contact Name</asp:ListItem>
                                <asp:ListItem>Company ID</asp:ListItem>
                                <asp:ListItem>Request Date</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="SearchTextbox" runat="server"></asp:TextBox>
                            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />
                            <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />
                        </div>
                        </div>
                    </div>
                    </div>
                    
                    <div class="control-group">
                        <div class="controls portlet-scroll-1" style="height:500px;border: 2px solid grey;">
                                <asp:GridView ID="GridViewDestruction" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceTransactionDestructionGrid" CssClass="table table-striped table-bordered table-advance table-hover" AllowSorting="True" AllowPaging="True">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Pick List #" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" />
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" Visible="false" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="PickUpDate" HeaderText="PickUp Date" SortExpression="PickUpDate" Visible="False" />
                                        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate" />
                                        <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" SortExpression="DepartmentCode" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="isRush" HeaderText="Rush?" SortExpression="isRush" />
                                        <%--<asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" Visible="false" />--%>
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />
                                        <asp:BoundField DataField="filepathPDF" HeaderText="filepathPDF" SortExpression="filepathPDF" Visible="false" />
                                        <asp:BoundField DataField="filepathBarCode" HeaderText="filepathBarCode" SortExpression="filepathBarCode" Visible="false" />
                                        <asp:BoundField DataField="TotalBoxes" HeaderText="Total Boxes" SortExpression="TotalBoxes" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceTransactionDestructionGrid" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT TH.Id, TH.ContactName, TH.username, TH.Address, TH.PickUpDate, TH.RequestDate, TH.DepartmentCode, TH.ContactNumber, TH.Status, TH.Type, TH.isRush, TH.CompanyCode, TH.CreatedBy, TH.CreatedDate, TH.ModifiedBy, TH.ModifiedDate, TH.filepathPDF, TH.filepathBarCode, TH.Alerts, TH.filepathQrCode, COUNT(CASE D.Status WHEN 'PROCESSED' THEN 1 ELSE NULL END) AS TotalBoxes FROM TransactionHeaders AS TH LEFT OUTER JOIN Destructions AS D ON TH.Id = D.TransactionHeaders_Id WHERE (TH.Type = @Type) AND (TH.Status = @Status) GROUP BY TH.Id, TH.ContactName, TH.username, TH.Address, TH.PickUpDate, TH.RequestDate, TH.DepartmentCode, TH.ContactNumber, TH.Status, TH.Type, TH.isRush, TH.CompanyCode, TH.CreatedBy, TH.CreatedDate, TH.ModifiedBy, TH.ModifiedDate, TH.filepathPDF, TH.filepathBarCode, TH.Alerts, TH.filepathQrCode ORDER BY TH.Id DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="DESTRUCTION" Name="Type" QueryStringField="Type" Type="String" />
                                        <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
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
                        Client Details
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSourceTransactionDestructionDetails" Height="50px" Width="300px" CssClass="table table-striped table-bordered table-advance table-hover">
                                <Fields>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                                    <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                    <asp:BoundField DataField="PickUpDate" HeaderText="PickUpDate" SortExpression="PickUpDate" />
                                    <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" SortExpression="RequestDate" />
                                    <asp:BoundField DataField="DepartmentCode" HeaderText="DepartmentCode" SortExpression="DepartmentCode" />
                                    <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" SortExpression="ContactNumber" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                    <asp:BoundField DataField="isRush" HeaderText="Rush?" SortExpression="isRush" />
                                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                                </Fields>
                            </asp:DetailsView>
                            <asp:SqlDataSource ID="SqlDataSourceTransactionDestructionDetails" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([ContactName], [username], [Address], [PickUpDate], [RequestDate], [DepartmentCode], [ContactNumber], [Status], [Type], [isRush], [CompanyCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [filepathPDF], [filepathBarCode], [Alerts], [filepathQrCode]) VALUES (@ContactName, @username, @Address, @PickUpDate, @RequestDate, @DepartmentCode, @ContactNumber, @Status, @Type, @isRush, @CompanyCode, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @filepathPDF, @filepathBarCode, @Alerts, @filepathQrCode)" SelectCommand="SELECT TransactionHeaders.Id, TransactionHeaders.ContactName, TransactionHeaders.username, TransactionHeaders.Address, TransactionHeaders.PickUpDate, TransactionHeaders.RequestDate, TransactionHeaders.DepartmentCode, TransactionHeaders.ContactNumber, TransactionHeaders.Status, TransactionHeaders.Type, TransactionHeaders.isRush, TransactionHeaders.CompanyCode, TransactionHeaders.CreatedBy, TransactionHeaders.CreatedDate, TransactionHeaders.ModifiedBy, TransactionHeaders.ModifiedDate, TransactionHeaders.filepathPDF, TransactionHeaders.filepathBarCode, TransactionHeaders.Alerts, TransactionHeaders.filepathQrCode, Companies.CompanyName FROM TransactionHeaders INNER JOIN Companies ON TransactionHeaders.CompanyCode = Companies.CompanyCode WHERE (TransactionHeaders.Id = @Id)" UpdateCommand="UPDATE [TransactionHeaders] SET [ContactName] = @ContactName, [username] = @username, [Address] = @Address, [PickUpDate] = @PickUpDate, [RequestDate] = @RequestDate, [DepartmentCode] = @DepartmentCode, [ContactNumber] = @ContactNumber, [Status] = @Status, [Type] = @Type, [isRush] = @isRush, [CompanyCode] = @CompanyCode, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate, [filepathPDF] = @filepathPDF, [filepathBarCode] = @filepathBarCode, [Alerts] = @Alerts, [filepathQrCode] = @filepathQrCode WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ContactName" Type="String" />
                                    <asp:Parameter Name="username" Type="String" />
                                    <asp:Parameter Name="Address" Type="String" />
                                    <asp:Parameter Name="PickUpDate" Type="String" />
                                    <asp:Parameter Name="RequestDate" Type="String" />
                                    <asp:Parameter Name="DepartmentCode" Type="String" />
                                    <asp:Parameter Name="ContactNumber" Type="String" />
                                    <asp:Parameter Name="Status" Type="String" />
                                    <asp:Parameter Name="Type" Type="String" />
                                    <asp:Parameter Name="isRush" Type="String" />
                                    <asp:Parameter Name="CompanyCode" Type="String" />
                                    <asp:Parameter Name="CreatedBy" Type="String" />
                                    <asp:Parameter Name="CreatedDate" Type="String" />
                                    <asp:Parameter Name="ModifiedBy" Type="String" />
                                    <asp:Parameter Name="ModifiedDate" Type="String" />
                                    <asp:Parameter Name="filepathPDF" Type="String" />
                                    <asp:Parameter Name="filepathBarCode" Type="String" />
                                    <asp:Parameter Name="Alerts" Type="String" />
                                    <asp:Parameter Name="filepathQrCode" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="GridViewDestruction" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ContactName" Type="String" />
                                    <asp:Parameter Name="username" Type="String" />
                                    <asp:Parameter Name="Address" Type="String" />
                                    <asp:Parameter Name="PickUpDate" Type="String" />
                                    <asp:Parameter Name="RequestDate" Type="String" />
                                    <asp:Parameter Name="DepartmentCode" Type="String" />
                                    <asp:Parameter Name="ContactNumber" Type="String" />
                                    <asp:Parameter Name="Status" Type="String" />
                                    <asp:Parameter Name="Type" Type="String" />
                                    <asp:Parameter Name="isRush" Type="String" />
                                    <asp:Parameter Name="CompanyCode" Type="String" />
                                    <asp:Parameter Name="CreatedBy" Type="String" />
                                    <asp:Parameter Name="CreatedDate" Type="String" />
                                    <asp:Parameter Name="ModifiedBy" Type="String" />
                                    <asp:Parameter Name="ModifiedDate" Type="String" />
                                    <asp:Parameter Name="filepathPDF" Type="String" />
                                    <asp:Parameter Name="filepathBarCode" Type="String" />
                                    <asp:Parameter Name="Alerts" Type="String" />
                                    <asp:Parameter Name="filepathQrCode" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
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
                        Options
                    </h4>
                </div>
                <div class="widget-body">
                    <%--<div class="control-group">
                        <div class="controls">
                            <asp:FileUpload ID="FileUpload2" AllowMultiple="true" runat="server" CssClass="btn blue" />
                            <asp:Button ID="UploadQrButton" runat="server" Text="Upload QrCode Image" CssClass="btn btn-primary" />
                            </div>
                        </div>--%>
                    <div class="control-group">
                        <div class="controls">
                             <%--<asp:Button ID="Button1" runat="server" Text="Download Pick List" CssClass="btn btn-primary" />--%>
                            <asp:Button ID="Button2" runat="server" Text="Download Pull Out Receipt" CssClass="btn btn-primary" />                            
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
                        Destruction Items
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                                        <div class="control-group">
                                            <label class="control-label"></label>
                                            <div class="controls">
                                                <div class="pull-right">
                                                    <asp:DropDownList ID="DropDownListSearch" runat="server" ValidationGroup="99">
                                                        <asp:ListItem>Barcode</asp:ListItem>
                                                        <asp:ListItem>Description</asp:ListItem>
                                                        <asp:ListItem>Box Number</asp:ListItem>
                                                        <asp:ListItem>Department</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="TextBoxSearch" runat="server" ValidationGroup="99"></asp:TextBox>
                                                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn btn-primary" ValidationGroup="99" />
                                                    <asp:Button ID="ButtonRefresh" runat="server" Text="Refresh" CssClass="btn btn-primary" ValidationGroup="99" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                    <div class="control-group">
                        <div class="controls portlet-scroll-1" style="height:500px;border: 2px solid grey;">
                                <asp:GridView ID="GridViewDestructionItems" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceTransactionDestructionItems" CssClass="table table-striped table-bordered table-advance table-hover" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="TransactionHeaders_Id" HeaderText="TransactionHeaders_Id" SortExpression="TransactionHeaders_Id" Visible="false" />
                                        <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode" />
                                        <asp:BoundField DataField="QRCode" HeaderText="QRCode" SortExpression="QRCode" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="BoxNumber" HeaderText="Box Number" SortExpression="BoxNumber" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Retention" HeaderText="Retention" SortExpression="Retention" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="MasterList_Id" HeaderText="MasterList ID" SortExpression="MasterList_Id"/>
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />

                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceTransactionDestructionItems" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Destructions] WHERE (([Status] = @Status) AND ([TransactionHeaders_Id] = @TransactionHeaders_Id))">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" Type="String" />
                                        <asp:ControlParameter ControlID="GridViewDestruction" Name="TransactionHeaders_Id" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSourceReadMasterList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, CompanyCode, Department, BarCode, BoxNumber, Description, Status, LocationCode, DestructionDate, StockReceipt_id, QRCode, Retention, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM MasterList WHERE (StockReceipt_id = @StockReceipt_id) AND (Status = 'DESTROYED')">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="GridViewDestruction" Name="StockReceipt_id" PropertyName="SelectedValue" />
                                    </SelectParameters>
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

                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
