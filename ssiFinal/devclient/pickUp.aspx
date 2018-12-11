<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devclient/Site1.Master" CodeBehind="pickUp.aspx.vb" Inherits="ssiFinal.WebForm1" %>

<%@ Register Assembly="Spire.Barcode" Namespace="Spire.Barcode.WebUI" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        Request for Pick Up
                    </h4>
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
                            <asp:TextBox ID="CompanyNameTextBox" runat="server" CssClass="span6" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Department:</label>
                        <div class="controls">
                            <asp:TextBox ID="DepartmentTextBox" runat="server" CssClass="span6" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Contact Name:</label>
                        <div class="controls">
                            <asp:TextBox ID="contactNameTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="contactNameTextBox" ErrorMessage="Required Field" ValidationGroup="1" ViewStateMode="Inherit"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Contact Number:</label>
                        <div class="controls">
                            <asp:TextBox ID="contactNumberTextBox" runat="server" CssClass="span6" ></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="contactNumberTextBox" ErrorMessage="Required Field" ValidationGroup="1" ViewStateMode="Inherit"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Pick Up Address:</label>
                        <div class="controls">
                            <asp:TextBox ID="pickUpAddressTextBox" runat="server" Height="69px" TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pickUpAddressTextBox" ErrorMessage="Required Field" ValidationGroup="1" ViewStateMode="Inherit"></asp:RequiredFieldValidator></span>--%>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label">Pick Up Date:</label>
                        <div class="controls">
                            <asp:TextBox ID="pickUpDateTextBox" runat="server" CssClass="span6"></asp:TextBox>
                            <span class="help-inline">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pickUpDateTextBox" ErrorMessage="Required Field" ValidationGroup="1" ViewStateMode="Inherit"></asp:RequiredFieldValidator></span>--%>
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
                        Add Items
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <label class="control-label">
                            <asp:Button ID="ButtonDownloadTemplate" runat="server" Text="Download Template" CssClass="btn btn-primary" />
                        </label>
                        <div class="controls">
                            <div class="control-group row-fluid">
                                <div class="controls span12">
                                    <div class="control-group span3">
                                        <div class="form-inline">
                                            <label class="control-label">Box Number:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                <span class="help-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="Required Field" ValidationGroup="2"></asp:RequiredFieldValidator></span>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="control-group span3">
                                        <div class="form-inline">
                                            <label class="control-label">Description:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                <span class="help-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8" ErrorMessage="Required Field" ValidationGroup="2"></asp:RequiredFieldValidator></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group span3">
                                        <div class="form-inline">
                                            <label class="control-label">Department:</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceGetDepartments" DataTextField="DepartmentCode" DataValueField="DepartmentCode"></asp:DropDownList>
                                                <span class="help-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Required Field" ValidationGroup="2"></asp:RequiredFieldValidator></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group span3">
                                        <div class="form-inline">
                                            <label class="control-label">Retention:</label>
                                            <div class="controls">
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="control-group">
                                <div class="controls">
                                    <asp:Button ID="Button2" runat="server" Text="Add Item" CssClass="btn btn-primary" ValidationGroup="2" />
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
                        <i class="icon-reorder"></i>
                        Pickup Items
                    </h4>
                </div>
                <div class="widget-body">

                    <div class="control-group row-fluid">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn blue" /><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="3" CssClass="btn btn-medium btn-primary" />
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-advance table-hover" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="RemoveAllButton" runat="server" AutoPostBack="true" OnClick="RemoveAllButton_Click" Text="Remove All" />
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="RemoveButton" runat="server" CommandName="RemoveFromList" CommandArgument="<%# Container.DataItemIndex %>" Text="Remove" />
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
            <%--<asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="1" CssClass="btn btn-primary" OnClientClick="saved = true;"/>--%>
            <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="1" CssClass="btn btn-primary" OnClientClick="this.disabled = true; this.value = 'Submitting...';" UseSubmitBehavior="false"/>
        </div>
    </div>
    

    <asp:HiddenField ID="HiddenFieldDate" runat="server" />

                    
    <script>
        $(function () {
            $(<%= pickUpDateTextBox.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>
    <script>
        $(function () {
            $(<%= TextBox2.ClientID%>).datepicker();
            $("#anim").change(function () {
                $("#datepicker").datepicker("option", "showAnim", $(this).val());
            });
        });
    </script>

    


    <%------------------------------DATA SOURCES-------------------------%>

    <asp:SqlDataSource ID="SqlDataSourceGetCompany" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT CompanyCode, CompanyName, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy FROM Companies WHERE (CompanyCode = @CompanyCode)" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetClientInfo" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, username, DepartmentCode, FirstName, LastName, email, address, ContactNumber, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, isAdmin, CompanyCode FROM ClientUsers WHERE (username = @username)">
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
            <asp:Parameter DefaultValue="PICKUP" Name="Type" Type="String" />
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
    <asp:SqlDataSource ID="SqlDataSourceInsertPickupItems" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" DeleteCommand="DELETE FROM [PickUps] WHERE [Id] = @Id" InsertCommand="INSERT INTO PickUps(TransactionHeaders_id, BarCode, QRCode, Department, BoxNumber, Description, Retention, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) VALUES (@TransactionHeaders_id, @BarCode, @QRCode, @Department, @BoxNumber, @Description, @Retention, @Status, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate)" SelectCommand="SELECT * FROM [PickUps]" UpdateCommand="UPDATE [PickUps] SET [TransactionHeaders_id] = @TransactionHeaders_id, [BarCode] = @BarCode, [QRCode] = @QRCode, [Department] = @Department, [BoxNumber] = @BoxNumber, [Description] = @Description, [Retention] = @Retention, [Status] = @Status, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="TransactionHeaders_id" SessionField="transactionID" Type="Int32" />
            <asp:SessionParameter Name="BarCode" SessionField="BarCode" Type="String" />
            <asp:SessionParameter Name="QRCode" SessionField="QRCode" Type="String" />
            <asp:SessionParameter Name="Department" SessionField="Department" Type="String" />
            <asp:SessionParameter Name="BoxNumber" SessionField="BoxNumber" Type="String" />
            <asp:SessionParameter Name="Description" SessionField="Description" Type="String" />
            <asp:SessionParameter Name="Retention" SessionField="Retention" Type="String"/>
            <asp:Parameter Name="Status" Type="String" DefaultValue="NEW" />
            <asp:SessionParameter DefaultValue="" Name="CreatedBy" SessionField="clientUserName" Type="String" />
            <%--<asp:ControlParameter ControlID="TextBoxRequestDate" Name="CreatedDate" PropertyName="Text" Type="DateTime" />--%>
            <asp:SessionParameter Name="CreatedDate" SessionField="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TransactionHeaders_id" Type="Int32" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Retention" DbType="Date" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceReadPickUpItems" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [PickUps] WHERE ([TransactionHeaders_id] = @TransactionHeaders_id)">
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
    <asp:SqlDataSource ID="SqlDataSourceBarCodeDups" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [PickUps] WHERE ([BarCode] = @BarCode)">
        <SelectParameters>
            <asp:SessionParameter Name="BarCode" SessionField="BarCodeDups" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</span></span></span></span>
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
    <ul id="messagesNotif" class="dropdown-menu extended inbox" runat="server">
        
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
