<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="masterList.aspx.vb" Inherits="ssiFinal.masterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .ui-autocomplete {
            max-height: 100px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }
        /* IE 6 doesn't support max-height
   * we use height instead, but this forces the menu to always be this tall
   */
        * html .ui-autocomplete {
            height: 100px;
        }
    </style>
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

    <script>
        $(function () {
            var a = <%= locCode%>;
            $(".LocationCode").autocomplete({
                source: a
            });
        });
    </script>

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
                                        <asp:ListItem>Client Code</asp:ListItem>
                                        <asp:ListItem>Department</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                                    <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />
                                    <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />

                                </div>
                                <asp:HiddenField ID="HiddenFieldSelectedRack" runat="server" />
                                <asp:HiddenField ID="HiddenFieldSelectedBay" runat="server" />
                                <asp:SqlDataSource ID="SqlDataSourceGetLoc" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Rack.RackCode + ':' + Bay.BayCode + ':' + Level.LevelNumber + ':' AS LocationCode FROM Rack INNER JOIN Bay ON Rack.Id = Bay.Id CROSS JOIN Level"></asp:SqlDataSource>
                                <asp:HiddenField ID="HiddenFieldSelectedLevel" runat="server" />
                                <%--<asp:Label ID="LabelRack" runat="server" Text="Rack"></asp:Label>
                            <asp:Label ID="LabelBay" runat="server" Text="Bay"></asp:Label>
                            <asp:Label ID="LabelLevel" runat="server" Text="Level"></asp:Label>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls">

                                <div class="pull-right">
                                    <asp:DropDownList ID="DropDownListExport" runat="server" DataSourceID="SqlDataSourceExportToExcel" DataTextField="CompanyName" DataValueField="CompanyCode"></asp:DropDownList>
                                    <asp:Button ID="ExportToExcel" runat="server" Text="Export To Excel" CssClass="btn btn-primary" />
                                    <%--<asp:Button ID="ButtonFilter" runat="server" Text="Filter" CssClass="btn btn-primary" />--%>
                                </div>
                                <asp:Button ID="AddNewItemToMasterlist" runat="server" Text="Add New Item To Masterlist" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>

                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls portlet-scroll-1" style="height: 700px; border: 2px solid grey;">

                                <asp:GridView ID="MasterListGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceMasterlist" CssClass="table table-striped table-bordered table-advance table-hover" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" CausesValidation="False" UpdateText="Save" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this from the master list? Once deleted, you cannot roll back changes.');">Delete </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Masterlist ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="Client Code" SortExpression="CompanyCode" ReadOnly="True" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" ReadOnly="True" />
                                        <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode" ReadOnly="True" />
                                        <asp:BoundField DataField="QRCode" HeaderText="QR Code" SortExpression="QRCode" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Box Number" SortExpression="BoxNumber">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("BoxNumber") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("BoxNumber") %>'></asp:Label>
                                                <asp:TextBox ID="TextBox3" Visible="<%# IsInEditMode%>" runat="server" Text='<%# Bind("BoxNumber") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("Description") %>'></asp:Label>
                                                <asp:TextBox ID="TextBox4" Visible="<%# IsInEditMode%>" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="Location Code" SortExpression="LocationCode">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBoxLocationCode" CssClass="LocationCode" runat="server" Text='<%# Bind("LocationCode") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("LocationCode") %>'></asp:Label>
                                                <asp:TextBox Visible="<%# IsInEditMode%>" CssClass="LocationCode" ID="TextBoxLocationCode" runat="server" Text='<%# Bind("LocationCode") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Destruction Date" SortExpression="DestructionDate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DestructionDate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("DestructionDate") %>'></asp:Label>
                                                <asp:TextBox Visible="<%# IsInEditMode%>" ID="TextBox1" runat="server" Text='<%# Bind("DestructionDate") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Retention" SortExpression="Retention">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBoxRetention" runat="server" Text='<%# Bind("Retention") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="LabelRetention" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("Retention") %>'></asp:Label>
                                                <asp:TextBox Visible="<%# IsInEditMode%>" ID="TextBoxRetention" runat="server" Text='<%# Bind("Retention") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Document ID" SortExpression="StockReceipt_id">
                                            <EditItemTemplate>
                                                <asp:Label ID="TextBox0" runat="server" Text='<%# Bind("StockReceipt_id")%>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("StockReceipt_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" ReadOnly="True" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" ReadOnly="True" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="False" ReadOnly="True" />
                                    </Columns>
                                    <EditRowStyle Width="10px" />
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:Button ID="EditBtn" runat="server" Text="Edit Mode" CssClass="btn btn-primary" />
                        <asp:Button ID="SaveBtn" runat="server" Text="Save Changes" CssClass="btn btn-primary" Enabled="False" />
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
    <asp:SqlDataSource ID="SqlDataSourceMasterlist" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [MasterList] ORDER BY [Id] DESC" DeleteCommand="DELETE FROM [MasterList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterList] ([CompanyCode], [Department], [BarCode], [BoxNumber], [Description], [Status], [LocationCode], [DestructionDate], [StockReceipt_id], [QRCode], [Retention], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (@CompanyCode, @Department, @BarCode, @BoxNumber, @Description, @Status, @LocationCode, @DestructionDate, @StockReceipt_id, @QRCode, @Retention, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate)" UpdateCommand="UPDATE MasterList SET BoxNumber = @BoxNumber, Description = @Description, LocationCode = @LocationCode, DestructionDate = @DestructionDate WHERE (Id = @Id)">
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
            <asp:Parameter Name="BoxNumber" />
            <asp:Parameter Name="Description" />
            <asp:Parameter Name="LocationCode" />
            <asp:Parameter Name="Id" />
            <asp:Parameter Name="DestructionDate" />
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
    <asp:SqlDataSource ID="SqlDataSourceExportToExcel" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceExportThisData" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id AS MasterlistId, CompanyCode, Department, BarCode, BoxNumber, Description, Status, LocationCode, DestructionDate, StockReceipt_id, QRCode, Retention, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM MasterList WHERE (CompanyCode = @CompanyCode)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListExport" Name="CompanyCode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
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
    <br />
    <asp:SqlDataSource ID="SqlDataSourceSelectRack" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [RackCode] FROM [Rack]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSelectBay" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [RackCode], [BayCode] FROM [Bay] WHERE ([RackCode] = @RackCode)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceSelectLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [LevelNumber], [RackCode] FROM [Level] WHERE ([RackCode] = @RackCode)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceMasterlistHistory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [MasterlistHistory] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterlistHistory] ([MasterlistId], [Barcode], [Details], [ModifiedBy], [ModifiedDate]) VALUES (@MasterlistId, @Barcode, @Details, @ModifiedBy, @ModifiedDate)" SelectCommand="SELECT * FROM [MasterlistHistory]" UpdateCommand="UPDATE [MasterlistHistory] SET [MasterlistId] = @MasterlistId, [Barcode] = @Barcode, [Details] = @Details, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="MasterlistId" SessionField="MasterlistID" Type="Int32" />
            <asp:SessionParameter Name="Barcode" SessionField="Barcode" Type="String" />
            <asp:Parameter Name="Details" Type="String" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MasterlistId" Type="Int32" />
            <asp:Parameter Name="Barcode" Type="String" />
            <asp:Parameter Name="Details" Type="String" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

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
