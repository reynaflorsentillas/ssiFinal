<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="BoxHistory.aspx.vb" Inherits="ssiFinal.BoxHistory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--    <div class="row-fluid">
        <div class="span12">
            <ul class="breadcrumb">
                <li class="pull-right search-wrap">
                    <div class="input-append search-input-area">
                    </div>
                </li>
            </ul>
        </div>
    </div>--%>
    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Master List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls">
                                <div class="pull-right">
                                    <asp:DropDownList ID="SearchDropDownList" runat="server">
                                        <asp:ListItem>Barcode</asp:ListItem>
                                        <asp:ListItem>QR Code</asp:ListItem>
                                        <asp:ListItem>Box Number</asp:ListItem>
                                        <asp:ListItem>Location Code</asp:ListItem>
                                        <asp:ListItem>Document ID</asp:ListItem>
                                        <asp:ListItem>Masterlist ID</asp:ListItem>
                                        <asp:ListItem>Description</asp:ListItem>
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
                            <div class="controls">
                                <div class="pull-right">
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls portlet-scroll-1" style="height: 500px; border: 2px solid grey;">

                                <asp:GridView ID="MasterListGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceMasterlist" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode" />
                                        <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="Accepted" HeaderText="Accepted" SortExpression="Accepted" ReadOnly="True" />
                                        <asp:BoundField DataField="Retrieved" HeaderText="Retrieved" SortExpression="Retrieved" />
                                        <asp:TemplateField HeaderText="Destroyed" SortExpression="Destroyed">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Destroyed")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle Width="10px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="space20"></div>
                    <h3>Details:</h3>
                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls" style="height: 500px; border: 2px solid grey;">
                                <asp:GridView ID="GridViewDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDetails" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:BoundField DataField="MasterListId" HeaderText="MasterListId" SortExpression="MasterListId" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" SortExpression="CreatedDate" />
                                    </Columns>
                                    <EditRowStyle Width="10px" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>


    <%--    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Masterlist Details
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSourceMasterListDetails" Height="50px" Width="876px" CssClass="table table-striped table-bordered table-advance table-hover">
                                <Fields>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
                                    <asp:BoundField DataField="CompanyCode" HeaderText="Client Code" SortExpression="CompanyCode" />
                                    <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                    <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode"  />
                                    <asp:BoundField DataField="QRCode" HeaderText="QR Code" SortExpression="QRCode"  />
                                    <asp:BoundField DataField="BoxNumber" HeaderText="Box Number" SortExpression="BoxNumber" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                    <asp:BoundField DataField="Retention" HeaderText="Retention" SortExpression="Retention" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="LocationCode" HeaderText="Location Code" SortExpression="LocationCode" />
                                    <asp:BoundField DataField="DestructionDate" HeaderText="Destruction Date" SortExpression="DestructionDate" />
                                    <asp:BoundField DataField="StockReceipt_id" HeaderText="StockReceipt_id" SortExpression="StockReceipt_id" Visible="false" />
                                    <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" Visible="false" />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                    <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                    <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                    <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />
                                    <asp:CommandField ShowEditButton="True" />
                                </Fields>
                            </asp:DetailsView>
                            <asp:SqlDataSource ID="SqlDataSourceMasterListDetails" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [MasterList] WHERE ([Id] = @Id)" UpdateCommand="UPDATE MasterList SET Status = @Status, LocationCode = @LocationCode, DestructionDate = @DestructionDate, Retention = @Retention, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate, Department = @Department, BarCode = @BarCode, BoxNumber = @BoxNumber, Description = @Description, QRCode = @QRCode WHERE (Id = @Id)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="MasterListGridView" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:SessionParameter Name="Status" SessionField="Status" />
                                    <asp:SessionParameter Name="LocationCode" SessionField="LocationCode" />
                                    <asp:SessionParameter Name="DestructionDate" SessionField="DestructionDate" />
                                    <asp:SessionParameter Name="Retention" SessionField="Retention" />
                                    <asp:SessionParameter Name="ModifiedBy" SessionField="adminUserName" />
                                    <asp:SessionParameter Name="ModifiedDate" SessionField="ModifiedDate" />
                                    <asp:SessionParameter Name="Id" SessionField="Id" />
                                    <asp:SessionParameter Name="Department" SessionField="Department" />
                                    <asp:SessionParameter Name="BarCode" SessionField="BarCode" />
                                    <asp:SessionParameter Name="BoxNumber" SessionField="BoxNumber" />
                                    <asp:SessionParameter Name="Description" SessionField="Description" />
                                    <asp:SessionParameter Name="QRCode" SessionField="QRCode" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                        </div>  
                    </div>
                </div>
            </div>
        </div>
    </div>--%>


    <%-----------------------------DATA SOURCES-----------------------------%>
    <asp:SqlDataSource ID="SqlDataSourceMasterlist" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, CompanyCode, BarCode, Department, Pickup + Repickup AS Accepted, Retrieval AS Retrieved, Destruction AS Destroyed FROM MasterList ORDER BY Id DESC" DeleteCommand="DELETE FROM [MasterList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterList] ([CompanyCode], [Department], [BarCode], [BoxNumber], [Description], [Status], [LocationCode], [DestructionDate], [StockReceipt_id], [QRCode], [Retention], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (@CompanyCode, @Department, @BarCode, @BoxNumber, @Description, @Status, @LocationCode, @DestructionDate, @StockReceipt_id, @QRCode, @Retention, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate)" UpdateCommand="UPDATE [MasterList] SET [CompanyCode] = @CompanyCode, [Department] = @Department, [BarCode] = @BarCode, [BoxNumber] = @BoxNumber, [Description] = @Description, [Status] = @Status, [LocationCode] = @LocationCode, [DestructionDate] = @DestructionDate, [StockReceipt_id] = @StockReceipt_id, [QRCode] = @QRCode, [Retention] = @Retention, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate WHERE [Id] = @Id">
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
    <asp:SqlDataSource ID="SqlDataSourceDetails" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [MasterListId], [Description], [CreatedDate] FROM [History] WHERE ([MasterListId] = @MasterListId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="MasterListGridView" Name="MasterListId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="Alerts" />
        </SelectParameters>
    </asp:SqlDataSource>

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
