<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="AddItemToMasterList.aspx.vb" Inherits="ssiFinal.AddItemToMasterList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
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
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Add Items to MasterList:
                    </h4>
                </div>
                <div class="widget-body">

                         <%--<asp:Label ID="MessageLabel" runat="server" Text="Message" Visible="False"></asp:Label>
                            <br />
                            <br />--%>

                             <div class="control-group">
                                <label class="control-label">Company Code</label>
                                <div class="controls">
                                     <%--<asp:TextBox ID="CompanyCodeTextBox" runat="server" CssClass="span6"></asp:TextBox>--%>
                                     <asp:DropDownList ID="DropDownListCompanyCode" runat="server" DataSourceID="SqlDataSourceGetCompany" DataTextField="CompanyName" DataValueField="CompanyCode" CssClass="span6" AutoPostBack="true">
                                     </asp:DropDownList>
                                     <asp:SqlDataSource ID="SqlDataSourceGetCompany" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
                                </div>
                            </div>


                            <div class="control-group">
                                <label class="control-label">Department</label>
                                <div class="controls">
                                    <%--<asp:TextBox ID="DepartmentTextBox" runat="server" CssClass="span6"></asp:TextBox>--%>
                                    <asp:DropDownList ID="DropDownListDepartmentCode" runat="server" DataSourceID="SqlDataSourceGetDepartment" DataTextField="DepartmentName" DataValueField="DepartmentCode" CssClass="span6" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceGetDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Departments] WHERE ([CompanyCode] = @CompanyCode)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownListCompanyCode" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>


                            <div class="control-group">
                                <label class="control-label">Barcode</label>
                                <div class="controls">
                                    <asp:TextBox ID="BarCodeTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>


                            <div class="control-group">
                                <label class="control-label">QR Code</label>
                                <div class="controls">
                                     <asp:TextBox ID="QRCodeTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>


                           <div class="control-group">
                                <label class="control-label">Box Number</label>
                                <div class="controls">
                                     <asp:TextBox ID="BoxNumberTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                 
                            <div class="control-group">
                                <label class="control-label">Description</label>
                                <div class="controls">
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>


                           <div class="control-group">
                                <label class="control-label">Status</label>
                                <div class="controls">
                                    <%--<asp:TextBox ID="StatusTextBox" runat="server" CssClass="span6"></asp:TextBox>--%>
                                    <asp:DropDownList ID="StatusList" runat="server">
                                        <asp:ListItem>IN</asp:ListItem>
                                        <asp:ListItem>OUT</asp:ListItem>
                                        <asp:ListItem>DESTROYED</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                           <div class="control-group">
                                <label class="control-label">Location Code</label>
                                <div class="controls">
                                    <asp:TextBox ID="LocationCodeTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>


                            <div class="control-group">
                                <label class="control-label">Destruction Date</label>
                                <div class="controls">
                                    <asp:TextBox ID="DestructionDateTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>


                            <div class="control-group">
                                <label class="control-label">Document ID</label>
                                <div class="controls">
                                    <asp:TextBox ID="StockReceiptIdTextBox" runat="server" CssClass="span6" placeholder="Optional"></asp:TextBox>
                                </div>
                            </div>

                             <div class="control-group">
                                <div class="controls">
                                        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-primary" />
                                    <asp:Button ID="ClearButton" runat="server" Text="Clear" CssClass="btn btn-primary" />
                                </div>
                             </div>
                            

                </div>
            </div>
        </div>
    </div>




   

    <asp:SqlDataSource ID="SqlDataSourceAddItemToMasterList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [MasterList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterList] ([CompanyCode], [Department], [BarCode], [BoxNumber], [Description], [Status], [LocationCode], [DestructionDate], [StockReceipt_id], [QRCode], [Retention], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (@CompanyCode, @Department, @BarCode, @BoxNumber, @Description, @Status, @LocationCode, @DestructionDate, @StockReceipt_id, @QRCode, @Retention, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate)" SelectCommand="SELECT * FROM [MasterList]" UpdateCommand="UPDATE [MasterList] SET [CompanyCode] = @CompanyCode, [Department] = @Department, [BarCode] = @BarCode, [BoxNumber] = @BoxNumber, [Description] = @Description, [Status] = @Status, [LocationCode] = @LocationCode, [DestructionDate] = @DestructionDate, [StockReceipt_id] = @StockReceipt_id, [QRCode] = @QRCode, [Retention] = @Retention, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CompanyCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="LocationCode" Type="String" />
            <asp:Parameter Name="DestructionDate" Type="String" />
            <asp:Parameter Name="StockReceipt_id" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Retention" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="LocationCode" Type="String" />
            <asp:Parameter Name="DestructionDate" Type="String" />
            <asp:Parameter Name="StockReceipt_id" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Retention" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
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
                            <asp:SqlDataSource ID="SqlDataSourceGetRack" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, Length, Width, SqInch, Sqm, Remarks FROM Rack WHERE (RackCode = @RackCode)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
                                </SelectParameters>
    </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSourceGetBay" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, BayCode FROM Bay WHERE (BayCode = @BayCode) AND (RackCode = @RackCode)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="BayCode" SessionField="BayCode" />
                                    <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
                                </SelectParameters>
    </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSourceGetLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, LevelNumber FROM Level WHERE (LevelNumber = @LevelNumber) AND (RackCode = @RackCode)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="LevelNumber" SessionField="LevelNumber" />
                                    <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
                                </SelectParameters>
    </asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSourceGetBarcode" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT [BarCode], [QRCode] FROM [MasterList] WHERE (([BarCode] = @BarCode) AND ([QRCode] = @QRCode))">
            <SelectParameters>
                <asp:SessionParameter Name="BarCode" SessionField="BarCode" Type="String" />
                <asp:SessionParameter Name="QRCode" SessionField="QRCode" Type="String" />
            </SelectParameters>
    </asp:SqlDataSource>
                
                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
                                            </SelectParameters>
                                     </asp:SqlDataSource>

                                 </asp:Content>

