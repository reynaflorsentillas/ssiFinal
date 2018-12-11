<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devclient/Site1.Master" CodeBehind="RePickup.aspx.vb" Inherits="ssiFinal.RePickup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div id="ErrMsgs">
                <% 
                    If errMsg <> "" Then
                        Response.Write(errMsg)
                    End If

                    %>
            </div>
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Request for Pick Up
                    </h4>
                    <%-- <span class="tools">
                        <a class="icon-chevron-down" href="javascript:;"></a>
                        <a class="icon-remove" href="javascript:;"></a>
                    </span>--%>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <label class="control-label">Request Date:</label>
                        <div class="controls">
                            <asp:TextBox ID="TextBoxRequestDate" runat="server" Enabled="False" CssClass="span6"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Company Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="CompanyNameTextBox" runat="server" Enabled="False" CssClass="span6"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Department:</label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownListDepartment" runat="server" DataSourceID="SqlDataSourceGetDepartments" DataTextField="DepartmentName" DataValueField="DepartmentName" CssClass="span6" Enabled="False"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Contact Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="contactNameTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="contactNameTextBox" ErrorMessage="Required Field" ValidationGroup="1"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Contact Number:</label>
                        <div class="controls">
                            <asp:TextBox ID="contactNumberTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="contactNumberTextBox" ErrorMessage="Required Field" ValidationGroup="1"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Pick Up Address:</label>
                        <div class="controls">
                            <asp:TextBox ID="pickUpAddressTextBox" runat="server" Height="69px" TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pickUpAddressTextBox" ErrorMessage="Required Field" ValidationGroup="1"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Pick Up Date:</label>
                        <div class="controls">
                            <asp:TextBox ID="pickUpDateTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pickUpDateTextBox" ErrorMessage="Required Field" ValidationGroup="1"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Rush?:</label>
                        <div class="controls">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Checked = Yes / Unchecked = No" />
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
                        Available for RePick-Up
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                        <div class="control-group">
                            <label class="control-label"></label>
                            <div class="controls">
                                <div class="pull-right">
                                    <asp:DropDownList ID="SearchDropDownList" runat="server" ValidationGroup="99">
                                        <asp:ListItem>Barcode</asp:ListItem>
                                        <asp:ListItem>Description</asp:ListItem>
                                        <asp:ListItem>Box Number</asp:ListItem>
                                        <asp:ListItem>Department</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="SearchTextbox" runat="server" ValidationGroup="99"></asp:TextBox>
                                    <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" ValidationGroup="99" />
                                    <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" ValidationGroup="99" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="control-group row-fluid">
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-advance table-hover" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceReadMasterlist" AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="addToRepickupCheckBox" runat="server" OnCheckedChanged="addToRepickupCheckBox_CheckedChanged"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="MasterList ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode" Visible="False" />
                                        <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode" />
                                        <asp:BoundField DataField="QRCode" HeaderText="QRCode" SortExpression="QRCode" />
                                        <asp:BoundField DataField="BoxNumber" HeaderText="BoxNumber" SortExpression="BoxNumber" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                        <asp:BoundField DataField="DestructionDate" HeaderText="Retention" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="AddToRepickupButton" runat="server" Text="Add To Repickup List" CssClass="btn btn-primary" />
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
                        Repickup List:
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <label class="control-label"></label>
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="RemoveAllButton" runat="server" AutoPostBack="true" OnClick="RemoveAllButton_Click" Text="Remove All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="RemoveButton" runat="server" CommandName="RemoveFromList" CommandArgument="<%# Container.DataItemIndex %>" Text="Remove" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Retention" Visible="False">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxRetention" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="control-group">
        <div class="controls">
            <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="1" CssClass="btn btn-primary" OnClientClick="this.disabled = true; this.value = 'Submitting...';" UseSubmitBehavior="false"/>
        </div>
    </div>





    <script>
        $(function () {
            $(<%= pickUpDateTextBox.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>

    <%------------------------------DATA SOURCES-------------------------%>

    <asp:SqlDataSource ID="SqlDataSourceGetCompany" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Companies] WHERE ([CompanyCode] = @CompanyCode)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [ClientUsers] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceGetDepartments" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT DepartmentCode, DepartmentName, CompanyCode, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate FROM Departments WHERE (CompanyCode = @CompanyCode) AND (DepartmentCode = @DepartmentCode)">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
            <asp:SessionParameter Name="DepartmentCode" SessionField="DepartmentCode" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceTransHeader" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([ContactName], [username], [Address], [PickUpDate], [RequestDate], [DepartmentCode], [ContactNumber], [Status], [Type], [isRush], [CompanyCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [filepathPDF], [filepathBarCode], [Alerts]) VALUES (@ContactName, @username, @Address, @PickUpDate, @RequestDate, @DepartmentCode, @ContactNumber, @Status, @Type, @isRush, @CompanyCode, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @filepathPDF, @filepathBarCode, @Alerts) SET @transID = SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [TransactionHeaders]" UpdateCommand="UPDATE TransactionHeaders SET filepathPDF = @filepathPDF, filepathBarCode = @filepathBarCode, filepathQrCode = @filepathQrCode WHERE (Id = @transID)">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="contactNameTextBox" Name="ContactName" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
            <asp:ControlParameter ControlID="pickUpAddressTextBox" Name="Address" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="pickUpDateTextBox" Name="PickUpDate" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBoxRequestDate" Name="RequestDate" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="DepartmentCode" SessionField="DepartmentCode" Type="String" />
            <asp:ControlParameter ControlID="contactNumberTextBox" Name="ContactNumber" PropertyName="Text" Type="String" />
            <asp:SessionParameter DefaultValue="NEW" Name="Status" SessionField="Status" Type="String" />
            <asp:Parameter DefaultValue="REPICKUP" Name="Type" Type="String" />
            <asp:Parameter Name="isRush" Type="String" />
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
            <asp:SessionParameter Name="CreatedBy" SessionField="clientUserName" Type="String" />
            <asp:ControlParameter ControlID="TextBoxRequestDate" Name="CreatedDate" PropertyName="Text" Type="String" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="String" />
            <asp:Parameter Name="filepathPDF" Type="String" />
            <asp:Parameter Name="filepathBarCode" Type="String" />
            <asp:Parameter Name="Alerts" Type="String" DefaultValue="1" />
            <asp:Parameter Name="transID" Type="Int32" Direction="Output" />
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="filepathPDF" SessionField="filepathPDF" />
            <asp:SessionParameter Name="transID" SessionField="transID" />
            <asp:SessionParameter Name="filepathBarCode" SessionField="filepathBarCode" />
            <asp:SessionParameter Name="filepathQrCode" SessionField="filepathQrCode" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceInsertPickupItems" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" DeleteCommand="DELETE FROM [Repickup] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Repickup] ([TransactionHeaders_id], [BarCode], [QRCode], [Department], [BoxNumber], [Description], [Retention], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [filepath], [MasterList_Id]) VALUES (@TransactionHeaders_id, @BarCode, @QRCode, @Department, @BoxNumber, @Description, @Retention, @Status, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @filepath, @MasterList_Id)" SelectCommand="SELECT * FROM [Repickup]" UpdateCommand="UPDATE [Repickup] SET [TransactionHeaders_id] = @TransactionHeaders_id, [BarCode] = @BarCode, [QRCode] = @QRCode, [Department] = @Department, [BoxNumber] = @BoxNumber, [Description] = @Description, [Retention] = @Retention, [Status] = @Status, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate, [filepath] = @filepath, [MasterList_Id] = @MasterList_Id WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TransactionHeaders_id" Type="Int32" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter type="String" Name="Retention" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:SessionParameter DefaultValue="" Name="CreatedBy" SessionField="clientUserName" Type="String" />
            <%--<asp:ControlParameter ControlID="TextBoxRequestDate" Name="CreatedDate" PropertyName="Text" Type="DateTime" />--%>
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="filepath" Type="String" />
            <asp:Parameter Name="MasterList_Id" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TransactionHeaders_id" Type="Int32" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Retention" type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="filepath" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceReadPickUpItems" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [Repickup] WHERE ([TransactionHeaders_id] = @TransactionHeaders_id)">
        <SelectParameters>
            <asp:SessionParameter Name="TransactionHeaders_id" SessionField="transactionID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (username = @username) AND (Status = @Status) AND (Alerts = @Alerts)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="clientUserName" Type="String" />
            <asp:Parameter DefaultValue="PROCESSED" Name="Status" Type="String" />
            <asp:Parameter DefaultValue="2" Name="Alerts" Type="String" />
        </SelectParameters>
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
    <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status, Receiver FROM Messages WHERE (Status = 1) AND (Receiver = @Receiver) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status = 0 WHERE (ConvoId = @InboxID) AND (Receiver = @Receiver)">
        <SelectParameters>
            <asp:SessionParameter Name="Receiver" SessionField="clientUserName" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:SessionParameter Name="Receiver" SessionField="clientUserName" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceReadMasterlist" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, CompanyCode, Department, BarCode, BoxNumber, Description, Status, LocationCode, DestructionDate, StockReceipt_id, QRCode, Retention, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM MasterList WHERE (CompanyCode = @CompanyCode) AND (Status = @Status) ORDER By Id DESC">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
            <asp:Parameter DefaultValue="OUT" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

<asp:Content ID="myAlerts" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown">
        <i class="icon-bell-alt"></i>
        <span id="TotalCount" runat="server" class="badge badge-warning"></span>
    </a>
    <ul class="dropdown-menu extended notification portlet-scroll-1" id="Notifications" runat="server">
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <i class="icon-envelope-alt"></i>
        <span id="TotalMessages" runat="server" class="badge badge-warning"></span>
    </a>
    <ul id="messagesNotif" class="dropdown-menu extended inbox portlet-scroll-1" runat="server">
    </ul>
    
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
