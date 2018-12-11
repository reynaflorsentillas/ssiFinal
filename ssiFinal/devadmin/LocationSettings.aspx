<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="LocationSettings.aspx.vb" Inherits="ssiFinal.LocationSettings" %>
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
                        Add New Rack:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">

                            <div class="control-group">
                                <label class="control-label">Rack Code::</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxRackCode" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Length:</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxLength" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Width:</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxWidth" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">SqInch:</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxSqInch" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Sqm:</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxSqm" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Remarks:</label>
                                <div class="controls">
                                    <asp:TextBox ID="TextBoxRemarks" runat="server" CssClass="span6"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <div class="controls">
                                    <asp:Button ID="ButtonCreate" runat="server" Text="Create" CssClass="btn btn-primary"/>
                                    <asp:SqlDataSource ID="SqlDataSourceGetRackCode" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [Rack] WHERE ([RackCode] = @RackCode)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="TextBoxRackCode" Name="RackCode" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
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
                        Rack List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                                   
                                    <asp:SqlDataSource ID="SqlDataSourceGetRack" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Rack]" DeleteCommand="DELETE FROM [Rack] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Rack] ([RackCode], [Length], [Width], [SqInch], [Sqm], [Remarks]) VALUES (@RackCode, @Length, @Width, @SqInch, @Sqm, @Remarks)" UpdateCommand="UPDATE [Rack] SET [RackCode] = @RackCode, [Length] = @Length, [Width] = @Width, [SqInch] = @SqInch, [Sqm] = @Sqm, [Remarks] = @Remarks WHERE [Id] = @Id">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Id" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="RackCode" Type="String" />
                                            <asp:Parameter Name="Length" Type="String" />
                                            <asp:Parameter Name="Width" Type="String" />
                                            <asp:Parameter Name="SqInch" Type="String" />
                                            <asp:Parameter Name="Sqm" Type="String" />
                                            <asp:Parameter Name="Remarks" Type="String" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="RackCode" Type="String" />
                                            <asp:Parameter Name="Length" Type="String" />
                                            <asp:Parameter Name="Width" Type="String" />
                                            <asp:Parameter Name="SqInch" Type="String" />
                                            <asp:Parameter Name="Sqm" Type="String" />
                                            <asp:Parameter Name="Remarks" Type="String" />
                                            <asp:Parameter Name="Id" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceGetRack" CssClass="table table-striped table-bordered table-advance table-hover">
                                        <Columns>
                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                            <asp:BoundField DataField="RackCode" HeaderText="RackCode" SortExpression="RackCode" />
                                            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                                            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                                            <asp:BoundField DataField="SqInch" HeaderText="SqInch" SortExpression="SqInch" />
                                            <asp:BoundField DataField="Sqm" HeaderText="Sqm" SortExpression="Sqm" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        </Columns>
                                    </asp:GridView>
                                    
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
                        Select Rack:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">

                                     <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceGetRack" DataTextField="RackCode" DataValueField="RackCode" AutoPostBack="true" CssClass="span6">
                                    </asp:DropDownList>

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
                        Bays:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                                <asp:TextBox ID="TextBoxAddBay" runat="server" CssClass="span6"></asp:TextBox>
                                <asp:Button ID="ButtonAddBay" runat="server" Text="Add Bay" CssClass="btn btn-primary"/>
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceGetBay" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="RackCode" HeaderText="RackCode" SortExpression="RackCode" />
                                        <asp:BoundField DataField="BayCode" HeaderText="BayCode" SortExpression="BayCode" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceGetBay" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Bay] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Bay] ([RackCode], [BayCode]) VALUES (@RackCode, @BayCode)" SelectCommand="SELECT * FROM [Bay] WHERE ([RackCode] = @RackCode)" UpdateCommand="UPDATE [Bay] SET [RackCode] = @RackCode, [BayCode] = @BayCode WHERE [Id] = @Id">
                                    <DeleteParameters>
                                        <asp:Parameter Name="Id" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="RackCode" Type="String" />
                                        <asp:Parameter Name="BayCode" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList1" Name="RackCode" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="RackCode" Type="String" />
                                        <asp:Parameter Name="BayCode" Type="String" />
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
                        Levels:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                                <asp:TextBox ID="TextBoxAddLevel" runat="server" CssClass="span6"></asp:TextBox>
                                <asp:Button ID="ButtonAddLevel" runat="server" Text="Add Level" CssClass="btn btn-primary"/>
                                <br />
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceGetLevel" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="RackCode" HeaderText="RackCode" SortExpression="RackCode" />
                                        <asp:BoundField DataField="LevelNumber" HeaderText="LevelNumber" SortExpression="LevelNumber" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceGetLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Level] WHERE ([RackCode] = @RackCode)" DeleteCommand="DELETE FROM [Level] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Level] ([RackCode], [LevelNumber]) VALUES (@RackCode, @LevelNumber)" UpdateCommand="UPDATE [Level] SET [RackCode] = @RackCode, [LevelNumber] = @LevelNumber WHERE [Id] = @Id">
                                    <DeleteParameters>
                                        <asp:Parameter Name="Id" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="RackCode" Type="String" />
                                        <asp:Parameter Name="LevelNumber" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DropDownList1" Name="RackCode" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="RackCode" Type="String" />
                                        <asp:Parameter Name="LevelNumber" Type="String" />
                                        <asp:Parameter Name="Id" Type="Int32" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
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

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
