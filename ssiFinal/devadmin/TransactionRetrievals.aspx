﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="TransactionRetrievals.aspx.vb" Inherits="ssiFinal.TransactionRetrievals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Retrieval
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
                                <asp:ListItem>Pick List Number</asp:ListItem>
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
                                <asp:GridView ID="TransactionRetrievalGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceRetrievalGrid" CssClass="table table-striped table-bordered table-advance table-hover" AllowSorting="True" AllowPaging="true">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="Pick List #" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="Company Code" SortExpression="CompanyCode" />
                                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" Visible="false" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="PickUpDate" HeaderText="Delivery Date" SortExpression="PickUpDate" />
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
                                        <asp:BoundField DataField="TotalBoxes" HeaderText="Total Boxes" SortExpression="TotalBoxes" />
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
                        <i class="icon-reorder"></i>
                        Client Details
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <div class="table-responsive">
                                <asp:DetailsView ID="TransactionRetrievalDetailsView" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSourceRetrievalDetails"  Height="50px" Width="329px" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Fields>
                                        <asp:BoundField DataField="Id" HeaderText="Pick List #" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="PickUpDate" HeaderText="PickUpDate" SortExpression="PickUpDate" />
                                        <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" SortExpression="RequestDate" />
                                        <asp:BoundField DataField="DepartmentCode" HeaderText="DepartmentCode" SortExpression="DepartmentCode" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" SortExpression="ContactNumber" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                        <asp:BoundField DataField="isRush" HeaderText="Rush" SortExpression="isRush" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="False" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="False" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="False" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="False" />
                                        <asp:BoundField DataField="filepathPDF" HeaderText="filepathPDF" SortExpression="filepathPDF" Visible="False" />
                                        <asp:BoundField DataField="filepathBarCode" HeaderText="filepathBarCode" SortExpression="filepathBarCode" Visible="False" />
                                        <asp:BoundField DataField="Alerts" HeaderText="Alerts" SortExpression="Alerts" Visible="False" />
                                        <asp:BoundField DataField="filepathQrCode" HeaderText="filepathQrCode" SortExpression="filepathQrCode" Visible="False" />
                                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                                        <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode" Visible="False" />
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
                        <i class="icon-reorder"></i>
                        Options
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="ButtonPickList" runat="server" Text="Download Pick List" CssClass="btn btn-primary" />
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
                        Retrieval Items
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
                                                    <asp:Button ID="EditBtn" runat="server" Text="Edit Mode" CssClass="btn btn-primary" ValidationGroup="99"/>
                                                    <asp:Button ID="SaveBtn" runat="server" Text="Save Changes" CssClass="btn btn-primary" Enabled="False" ValidationGroup="99"/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                    <div class="control-group">
                        <div class="controls portlet-scroll-1" style="height:500px;border: 2px solid grey;">
                                <asp:GridView ID="TransactionRetrievalItemsGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceRetrievalItems" CssClass="table table-striped table-bordered table-advance table-hover" AllowSorting="True">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" UpdateText="Save" />
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ValidationCheckBox" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="TransactionHeaders_id" HeaderText="TransactionHeaders_id" SortExpression="TransactionHeaders_id" Visible="false" />
                                        <asp:TemplateField HeaderText="Barcode" SortExpression="BarCode">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="BarcodeTxtbox" runat="server" Text='<%# Bind("BarCode") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="BarcodeLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("BarCode") %>'></asp:Label>
                                                <asp:TextBox ID="BarcodeTxtbox" runat="server" Visible="<%# IsInEditMode%>" Text='<%# Bind("BarCode") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="QR Code" SortExpression="QRCode">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="QRCodeTxtbox" runat="server" Text='<%# Bind("QRCode") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="QRCodeLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("QRCode") %>'></asp:Label>
                                                <asp:TextBox ID="QRCodeTxtbox" runat="server" Visible="<%# IsInEditMode%>" Text='<%# Bind("QRCode") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department" SortExpression="Department">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="DepartmentTxtBox" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="DepartmentLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("Department") %>'></asp:Label>
                                                <asp:TextBox ID="DepartmentTxtBox" runat="server" Visible="<%# IsInEditMode%>" Text='<%# Bind("Department")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Box Number" SortExpression="BoxNumber">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="BoxNumberTxtbox" runat="server" Text='<%# Bind("BoxNumber") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="BoxNumberLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("BoxNumber") %>'></asp:Label>
                                                <asp:TextBox ID="BoxNumberTxtbox" runat="server" Visible="<%# IsInEditMode%>" Text='<%# Bind("BoxNumber")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="DescriptionTxtbox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="DescriptionLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("Description") %>'></asp:Label>
                                                <asp:TextBox ID="DescriptionTxtbox" runat="server"  Visible="<%# IsInEditMode%>" Text='<%# Bind("Description")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Retention" SortExpression="Retention" Visible="False">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="RetentionTxtBox" runat="server" Text='<%# Bind("Retention") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="RetentionLbl" runat="server" Visible="<%# Not IsInEditMode%>" Text='<%# Bind("Retention") %>'></asp:Label>
                                                <asp:TextBox ID="RetentionTxtBox" runat="server" Visible="<%# IsInEditMode%>" Text='<%# Bind("Retention") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate> 
                                                <asp:Label ID="StatusLbl" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="MasterList_Id" HeaderText="Masterlist ID" SortExpression="MasterList_Id" ReadOnly="True" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="false" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" Visible="false" />
                                        <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" Visible="false" />
                                        <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" Visible="false" />
                                        <asp:BoundField DataField="LocationCode" HeaderText="Location Code" ReadOnly="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="ReceiveButton" runat="server" Text="Receive" CssClass="btn btn-primary" OnClientClick="this.disabled = true; this.value = 'Receiving ...';" UseSubmitBehavior="false"/>
                            <asp:Button ID="CancelBtn" runat="server" Text="Cancel"  CssClass="btn btn-primary"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <asp:SqlDataSource ID="SqlDataSourceRetrievalGrid" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT TH.Id, TH.ContactName, TH.username, TH.Address, TH.PickUpDate, TH.RequestDate, TH.DepartmentCode, TH.ContactNumber, TH.Status, TH.Type, TH.isRush, TH.CompanyCode, TH.CreatedBy, TH.CreatedDate, TH.ModifiedBy, TH.ModifiedDate, TH.filepathPDF, TH.filepathBarCode, TH.Alerts, COUNT(R.Id) AS TotalBoxes FROM TransactionHeaders AS TH LEFT OUTER JOIN Retrievals AS R ON TH.Id = R.TransactionHeaders_id WHERE (TH.Type = @Type) AND (TH.Status = @Status) GROUP BY TH.Id, TH.ContactName, TH.username, TH.Address, TH.PickUpDate, TH.RequestDate, TH.DepartmentCode, TH.ContactNumber, TH.Status, TH.Type, TH.isRush, TH.CompanyCode, TH.CreatedBy, TH.CreatedDate, TH.ModifiedBy, TH.ModifiedDate, TH.filepathPDF, TH.filepathBarCode, TH.Alerts ORDER BY TH.Status, TH.Id DESC" DeleteCommand="DELETE FROM TransactionHeaders WHERE (Id = @Id)">
        <DeleteParameters>
            <asp:ControlParameter ControlID="TransactionRetrievalGridView" Name="Id" PropertyName="SelectedValue" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="RETRIEVAL" Name="Type" QueryStringField="Type" Type="String" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceReadMasterList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, CompanyCode, Department, BarCode, BoxNumber, Description, Status, LocationCode, DestructionDate, StockReceipt_id, QRCode, Retention, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM MasterList WHERE (StockReceipt_id = @StockReceipt_id)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="StockReceipt_id" SessionField="StockID" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
   
    <asp:SqlDataSource ID="SqlDataSourceRetrievalDetails" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([ContactName], [username], [Address], [PickUpDate], [RequestDate], [DepartmentCode], [ContactNumber], [Status], [Type], [isRush], [CompanyCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [filepathPDF]) VALUES (@ContactName, @username, @Address, @PickUpDate, @RequestDate, @DepartmentCode, @ContactNumber, @Status, @Type, @isRush, @CompanyCode, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @filepathPDF)" SelectCommand="SELECT TransactionHeaders.Id, TransactionHeaders.ContactName, TransactionHeaders.username, TransactionHeaders.Address, TransactionHeaders.PickUpDate, TransactionHeaders.RequestDate, TransactionHeaders.DepartmentCode, TransactionHeaders.ContactNumber, TransactionHeaders.Status, TransactionHeaders.Type, TransactionHeaders.isRush, TransactionHeaders.CreatedBy, TransactionHeaders.CreatedDate, TransactionHeaders.ModifiedBy, TransactionHeaders.ModifiedDate, TransactionHeaders.filepathPDF, TransactionHeaders.filepathBarCode, TransactionHeaders.Alerts, TransactionHeaders.filepathQrCode, Companies.CompanyName, TransactionHeaders.CompanyCode FROM TransactionHeaders INNER JOIN Companies ON TransactionHeaders.CompanyCode = Companies.CompanyCode WHERE (TransactionHeaders.Id = @Id)" UpdateCommand="UPDATE [TransactionHeaders] SET [ContactName] = @ContactName, [username] = @username, [Address] = @Address, [PickUpDate] = @PickUpDate, [RequestDate] = @RequestDate, [DepartmentCode] = @DepartmentCode, [ContactNumber] = @ContactNumber, [Status] = @Status, [Type] = @Type, [isRush] = @isRush, [CompanyCode] = @CompanyCode, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate, [ModifiedBy] = @ModifiedBy, [ModifiedDate] = @ModifiedDate, [filepathPDF] = @filepathPDF WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ContactName" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter DbType="Date" Name="PickUpDate" />
            <asp:Parameter Name="RequestDate" Type="DateTime" />
            <asp:Parameter Name="DepartmentCode" Type="Int32" />
            <asp:Parameter Name="ContactNumber" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="isRush" Type="Int32" />
            <asp:Parameter Name="CompanyCode" Type="Int32" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="String" />
            <asp:Parameter Name="filepathPDF" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionRetrievalGridView" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ContactName" Type="String" />
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter DbType="Date" Name="PickUpDate" />
            <asp:Parameter Name="RequestDate" Type="DateTime" />
            <asp:Parameter Name="DepartmentCode" Type="Int32" />
            <asp:Parameter Name="ContactNumber" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="isRush" Type="Int32" />
            <asp:Parameter Name="CompanyCode" Type="Int32" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="String" />
            <asp:Parameter Name="filepathPDF" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceRetrievalItems" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Retrievals.Id, Retrievals.TransactionHeaders_id, Retrievals.BarCode, Retrievals.QRCode, Retrievals.Department, Retrievals.BoxNumber, Retrievals.Description, Retrievals.Retention, Retrievals.Status, Retrievals.MasterList_Id, Retrievals.CreatedBy, Retrievals.CreatedDate, Retrievals.ModifiedBy, Retrievals.ModifiedDate, MasterList.LocationCode FROM Retrievals INNER JOIN MasterList ON Retrievals.MasterList_Id = MasterList.Id WHERE (Retrievals.TransactionHeaders_id = @TransactionHeaders_id) AND (Retrievals.Status = @Status)" DeleteCommand="DELETE FROM Retrievals WHERE (TransactionHeaders_id = @Id)" InsertCommand="INSERT INTO [Retrievals] ([TransactionHeaders_id], [BarCode], [QRCode], [Department], [BoxNumber], [Description], [Retention], [Status], [MasterList_Id], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (@TransactionHeaders_id, @BarCode, @QRCode, @Department, @BoxNumber, @Description, @Retention, @Status, @MasterList_Id, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate)" UpdateCommand="UPDATE Retrievals SET BarCode = @BarCode, QRCode = @QRCode, Department = @Department, BoxNumber = @BoxNumber, Description = @Description, Retention = @Retention WHERE (Id = @Id)">
        <DeleteParameters>
            <asp:ControlParameter ControlID="TransactionRetrievalGridView" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TransactionHeaders_id" Type="Int32" />
            <asp:Parameter Name="BarCode" Type="String" />
            <asp:Parameter Name="QRCode" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="BoxNumber" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Retention" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="MasterList_Id" Type="Int32" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TransactionRetrievalGridView" Name="TransactionHeaders_id" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="NEW" Name="Status" QueryStringField="Status" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="BarCode" />
            <asp:Parameter Name="QRCode" />
            <asp:Parameter Name="Department" />
            <asp:Parameter Name="BoxNumber" />
            <asp:Parameter Name="Description" />
            <asp:Parameter Name="Retention" />
            <asp:Parameter Name="Id" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceUpdateMasterList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, Status, StockReceipt_id FROM MasterList" DeleteCommand="DELETE FROM [MasterList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MasterList] ([Status]) VALUES (@Status)" UpdateCommand="UPDATE MasterList SET Status = @Status, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy, StockReceipt_id = @StockReceipt, Retrieval = Retrieval + 1, LocationCode = @LocationCode WHERE (Id = @Id) SET @masterID = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime"/>
            <asp:Parameter Name="ModifiedBy" Type="String"/>
            <asp:ControlParameter ControlID="TransactionRetrievalGridView" Name="StockReceipt" PropertyName="SelectedValue" />
            <asp:Parameter Name="masterID" Type="Int32" Direction="Output" />
            <asp:Parameter Name="LocationCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceUpdateRetrievalItem" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Retrievals] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Retrievals] ([Status]) VALUES (@Status)" SelectCommand="SELECT Id, Status, ModifiedDate, ModifiedBy FROM Retrievals" UpdateCommand="UPDATE Retrievals SET Status = @Status, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy WHERE (Id = @Id)">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Status" Type="String" DefaultValue="PROCESSED" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="ModifiedDate" Type="DateTime"/>
            <asp:Parameter Name="ModifiedBy" Type="String"/>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceUpdateRetrieval" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([Status]) VALUES (@Status)" SelectCommand="SELECT [Id], [Status] FROM [TransactionHeaders]" UpdateCommand="UPDATE [TransactionHeaders] SET [Status] = @Status WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Status" Type="String" DefaultValue="ACCEPTED" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceUpdateTransactionRetrieval" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [TransactionHeaders] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TransactionHeaders] ([Status]) VALUES (@Status)" SelectCommand="SELECT Id, Status, ModifiedDate, ModifiedBy FROM TransactionHeaders" UpdateCommand="UPDATE TransactionHeaders SET Status = @Status, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy, Alerts = @Alerts WHERE (Id = @Id)">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
        <UpdateParameters>
             <asp:Parameter Name="Alerts" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="ModifiedBy" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
   <asp:SqlDataSource ID="SqlDataSourceAlerts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, ContactName, username, Address, PickUpDate, RequestDate, DepartmentCode, ContactNumber, Status, Type, isRush, CompanyCode, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, filepathPDF, filepathBarCode, Alerts, filepathQrCode FROM TransactionHeaders WHERE (Type = @Type) AND (Status = @Status) AND (Alerts = 1)" DataSourceMode="DataReader" UpdateCommand="UPDATE TransactionHeaders SET Alerts = 0 WHERE (Type = @Type) AND (Status = 'NEW')">
        <SelectParameters>
            <asp:SessionParameter Name="Type" SessionField="AlertType" Type="String" />
            <asp:Parameter DefaultValue="NEW" Name="Status" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="Type" SessionField="Type" />
        </UpdateParameters>
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
   <asp:SqlDataSource ID="SqlDataSourceHistory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [History] WHERE [Id] = @Id" InsertCommand="INSERT INTO History(MasterListId, Barcode Description, CreatedBy, CreatedDate) VALUES (@MasterListId, @Barcode, @Description, @CreatedBy, @CreatedDate)" SelectCommand="SELECT * FROM [History]" UpdateCommand="UPDATE [History] SET [MasterListId] = @MasterListId, [Description] = @Description, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="MasterListId" SessionField="HistoryMasterListId" Type="Int32" />
            <asp:SessionParameter Name="Description" SessionField="HistoryDesc" Type="String" />
            <asp:SessionParameter Name="CreatedBy" SessionField="HistoryCreatedBy" Type="String" />
            <asp:SessionParameter Name="CreatedDate" SessionField="HistoryCreatedDate" Type="DateTime" />
            <asp:SessionParameter Name="Barcode" SessionField="_Barcode" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MasterListId" Type="Int32" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="CreatedBy" Type="String" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlDataSourceGetId" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT [CompanyCode] FROM [MasterList] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:SessionParameter Name="Id" SessionField="HistoryMasterListId" Type="Int32" />
        </SelectParameters>
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