<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devclient/Site1.Master" CodeBehind="PendingForApproval.aspx.vb" Inherits="ssiFinal.PendingForApproval" %>
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
                        Transaction List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                    <div class="control-group">
                        <div class="controls">
                            <div class="pull-right">
                            <asp:DropDownList ID="SearchDropDownList" runat="server">
                                <asp:ListItem>Contact Name</asp:ListItem>
                                <asp:ListItem>Packing List Number</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="SearchTextbox" runat="server"></asp:TextBox>
                            <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />

                            <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                    </div>
                    
                    <div class="control-group">
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:GridView ID="TransactionPickupsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceSelectTransactions" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" Visible="false" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="PickUpDate" HeaderText="PickUp Date" SortExpression="PickUpDate" />
                                        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate" />
                                        <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" SortExpression="DepartmentCode" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="isRush" HeaderText="Rush?" SortExpression="isRush" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" Visible="false" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />
                                        <asp:BoundField DataField="filepathPDF" HeaderText="filepathPDF" SortExpression="filepathPDF" Visible="false" />
                                    </Columns>
                                </asp:GridView>
                            </div>
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
                        Details
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:DetailsView ID="TransactionPickupDetailsView" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSourceSelectTransactionsDetails" Height="50px" Width="329px" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Fields>
                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" ReadOnly="true"/>
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" Visible="false" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="PickUpDate" HeaderText="PickUp Date" SortExpression="PickUpDate" />
                                        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate" />
                                        <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" SortExpression="DepartmentCode" ReadOnly="true" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="true" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" ReadOnly="true" />
                                        <asp:BoundField DataField="isRush" HeaderText="Rush?" SortExpression="isRush" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />
                                        <asp:BoundField DataField="filepathPDF" HeaderText="filepathPDF" SortExpression="filepathPDF" Visible="false" />
                                        <asp:CommandField ShowEditButton="True" />
                                    </Fields>
                                </asp:DetailsView>
                            </div>
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
                        Boxes
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                           
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:GridView ID="TransactionPickupItemsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-striped table-bordered table-advance table-hover" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="TransactionHeaders_id" HeaderText="TransactionHeaders_id" SortExpression="TransactionHeaders_id" Visible="False" />
                                        <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode" />
                                        <asp:BoundField DataField="QRCode" HeaderText="QR Code" SortExpression="QRCode" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="BoxNumber" HeaderText="Box Number" SortExpression="BoxNumber" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="Retention" HeaderText="Retention" SortExpression="Retention" Visible="False" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="False" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="False" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="False" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="False" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="ReceiveButton" runat="server" Text="Accept" CssClass="btn btn-primary" OnClientClick="this.disabled = true; this.value = 'Accepting...';" UseSubmitBehavior="false"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSourceSelectTransactions" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([ContactName], [username], [Address], [PickUpDate], [RequestDate], [DepartmentCode], [ContactNumber], [Status], [Type], [isRush], [CompanyCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [filepathPDF], [filepathBarCode], [Alerts], [filepathQrCode]) VALUES (@ContactName, @username, @Address, @PickUpDate, @RequestDate, @DepartmentCode, @ContactNumber, @Status, @Type, @isRush, @CompanyCode, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @filepathPDF, @filepathBarCode, @Alerts, @filepathQrCode)" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (CompanyCode = @CompanyCode) AND (Status = @Status) ORDER BY Id DESC" UpdateCommand="UPDATE TransactionHeaders SET Status = @Status, RequestDate = @RequestDate WHERE (Id = @Id)">
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
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
            <asp:Parameter DefaultValue="FORAPPROVAL" Name="Status" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter DefaultValue="NEW" Name="Status" />
            <asp:Parameter Name="RequestDate" />
            <asp:ControlParameter ControlID="TransactionPickupsGridView" DefaultValue="" Name="Id" PropertyName="SelectedValue" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSelectTransactionsDetails" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [TransactionHeaders] WHERE ([Id] = @Id)" UpdateCommand="UPDATE TransactionHeaders SET ContactName = @ContactName, Address = @Address, PickUpDate = @PickUpDate, RequestDate = @RequestDate, ContactNumber = @ContactNumber, isRush = @isRush WHERE (Id = @Id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ContactName" />
            <asp:Parameter Name="Address" />
            <asp:Parameter Name="PickUpDate" />
            <asp:Parameter Name="RequestedDate" />
            <asp:Parameter Name="ContactNumber" />
            <asp:Parameter Name="isRush" />
            <asp:Parameter Name="Id" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceBoxesPickUp" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [PickUps] WHERE ([TransactionHeaders_id] = @TransactionHeaders_id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="TransactionHeaders_id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRepickup" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Repickup] WHERE ([TransactionHeaders_id] = @TransactionHeaders_id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="TransactionHeaders_id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDestruction" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Destructions] WHERE ([TransactionHeaders_Id] = @TransactionHeaders_Id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="TransactionHeaders_Id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceBoxesRetrival" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Retrievals] WHERE ([TransactionHeaders_id] = @TransactionHeaders_id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="TransactionHeaders_id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [ClientUsers] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSourceUpdateTransaction" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([Status]) VALUES (@Status)" SelectCommand="SELECT [Id], [Status] FROM [TransactionHeaders] WHERE ([Id] = @Id)" UpdateCommand="UPDATE [TransactionHeaders] SET [Status] = @Status WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Status" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="TransactionPickupsGridView" Name="Id" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="Status" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
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
    <asp:SqlDataSource ID="SqlDataSourceAlertUpdate" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [TransactionHeaders] WHERE ([username] = @username)" UpdateCommand="UPDATE TransactionHeaders SET Alerts = @Alerts WHERE (username = @username) AND (Status &lt;&gt; @Status) AND (Type = @Type)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" />
            <asp:Parameter DefaultValue="NEW" Name="Status" />
            <asp:SessionParameter DefaultValue="" Name="Type" SessionField="AlertType" />
            <asp:Parameter DefaultValue="0" Name="Alerts" />
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
