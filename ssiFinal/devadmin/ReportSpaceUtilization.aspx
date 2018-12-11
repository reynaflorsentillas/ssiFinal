<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ReportSpaceUtilization.aspx.vb" Inherits="ssiFinal.ReportSpaceUtilization" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media print {

            #non-print *, img, .non-print {
                display: none;
            }

            #printable * {
                visibility: visible !important;
                margin: 0px 0px 0px 0px;
            }
        }

        .auto-style1 {
            font-size: large;
        }
    </style>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID%>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="theme/assets/uniform/css/uniform.default.css" /><link href="theme/assets/font-awesome/css/font-awesome.css" rel="stylesheet" /><link href="theme/css/style.css" rel="stylesheet" /><link href="theme/css/style-default.css" rel="stylesheet" id="style_color" /><link href="theme/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" /><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
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
                        Space Utilization Monthly Report 
                    </h4>
                </div>
                <div class="widget-body">

                    <div class="control-group">
                        <asp:LinkButton ID="lnkPrint" runat="server" ToolTip="Click to Print All Records" Text="Print Report" OnClientClick="return PrintPanel();" CssClass="btn-link" Visible="false"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="DownloadReportSpaceUtilization" runat="server" CssClass="btn-link" Text="Download Report PDF"></asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="DownloadReportSpaceUtilizationEXCEL" runat="server" CssClass="btn-link" Text="Download Report EXCEL"></asp:LinkButton>
                        <%--<asp:Button ID="lnkPrint" runat="server" Text="Print Report" OnClientClick="return PrintPanel();" CssClass="btn btn-primary" />--%>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/devadmin/ssilogo.jpg" CssClass="center" Height="67px" Width="75px" Visible="false" />
                            <br />
                            <strong><span id="ssi" class="auto-style1">
                                <asp:Label ID="ReportLabel" runat="server" Text=""></asp:Label></span><span class="auto-style1">&nbsp; </span></strong>
                            <br />
                            <h4>Summary</h4>
                            <%--<asp:LinkButton ID="DownloadSpaceUtilizationReportSummary" runat="server" CssClass="btn-link" Text="Download Report"></asp:LinkButton>--%>
                            <div class="controls">
                                <asp:Table ID="TableSummary" runat="server" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell Text="Space Utilization Monthly Report"></asp:TableHeaderCell>
                                        <asp:TableHeaderCell ID="MonthandYear" Text="Month and Year" runat="server"></asp:TableHeaderCell>
                                    </asp:TableHeaderRow>

                                    <asp:TableRow>
                                        <asp:TableCell TabIndex="0">
                                            <asp:Label ID="Label1" runat="server" Text="Total No. of Bin Location"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell TabIndex="1">
                                            <asp:Label ID="LabelTotalBinLoc" runat="server" Text="0"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                    <asp:TableRow>
                                        <asp:TableCell TabIndex="0">
                                            <asp:Label ID="Label2" runat="server" Text="Total No. of Utilized  Bin Location"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell TabIndex="1">
                                            <asp:Label ID="LabelUtilizedBin" runat="server" Text="0"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                    <asp:TableRow>
                                        <asp:TableCell TabIndex="0">
                                            <asp:Label ID="Label3" runat="server" Text="Total No. of Empty  Bin Location"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell TabIndex="1">
                                            <asp:Label ID="LabelEmptyBin" runat="server" Text="0"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                    <asp:TableRow>
                                        <asp:TableCell TabIndex="0">
                                            <asp:Label ID="Label4" runat="server" Text="Total Number of BAYS Installed"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell TabIndex="1">
                                            <asp:Label ID="LabelTotalBay" runat="server" Text="0"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                    <asp:TableRow>
                                        <asp:TableCell TabIndex="0">
                                            <asp:Label ID="Label5" runat="server" Text="Average Boxes per BIN "></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell TabIndex="1">
                                            <asp:Label ID="LabelAverageBoxes" runat="server" Text="0"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>

                                </asp:Table>
                            </div>

                            <h4>RACK #</h4>
                            <%--<asp:LinkButton ID="DownloadReportRack" runat="server" CssClass="btn-link" Text="Download Report"></asp:LinkButton>--%>
                            <div class="controls">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceBinLocation" ShowFooter="True" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="RackCode" HeaderText="RackCode" SortExpression="RackCode" />
                                        <asp:BoundField DataField="TotalBay" HeaderText="TotalBay" ReadOnly="True" SortExpression="TotalBay" />
                                        <asp:BoundField DataField="TotalLevel" HeaderText="TotalLevel" ReadOnly="True" SortExpression="TotalLevel" />
                                        <asp:BoundField DataField="TotalBin" HeaderText="TotalBin" ReadOnly="True" SortExpression="TotalBin" />
                                        <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                                        <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                                        <asp:BoundField DataField="SqInch" HeaderText="SqInch" SortExpression="SqInch" />
                                        <asp:BoundField DataField="Sqm" HeaderText="Sqm" SortExpression="Sqm" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceBinLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT RackCode, COUNT(RackCode) AS TotalBay, COUNT(RackCode) AS TotalLevel, COUNT(RackCode) AS TotalBin, Length, Width, SqInch, Sqm, Remarks FROM Rack GROUP BY RackCode, Length, Width, SqInch, Sqm, Remarks ORDER BY RackCode"></asp:SqlDataSource>
                            </div>

                            <h4>Space Allocation</h4>
                            <div class="controls">
                                <asp:GridView ID="GridViewSpaceutilization" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceGetBayGrid" CssClass="table table-striped table-bordered table-advance table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false" />
                                        <asp:BoundField DataField="RackCode" HeaderText="Rack Code" SortExpression="RackCode" />
                                        <asp:BoundField DataField="BayCode" HeaderText="Bay Code" SortExpression="BayCode" />
                                        <asp:TemplateField HeaderText="Level 1">
                                            <ItemTemplate>
                                                <asp:Textbox ID="LabelLevel1" Text="0" runat="server"></asp:Textbox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level 2">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelLevel2" Text="0" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level 3">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelLevel3" Text="0" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level 4">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelLevel4" Text="0" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level 5">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelLevel5" Text="0" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>

                    </div>
                </div>
            </div>
        </div>
    </div>









    <asp:SqlDataSource ID="SqlDataSourceTotalBay" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, BayCode FROM Bay WHERE (RackCode = @RackCode)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceTotalLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, LevelNumber FROM Level WHERE (RackCode = @RackCode)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceGetRack" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, Length, Width, SqInch, Sqm, Remarks FROM Rack WHERE (RackCode = @RackCode)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetBay" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, BayCode FROM Bay WHERE (BayCode = @BayCode) AND (RackCode = @RackCode) ORDER BY RackCode">
        <SelectParameters>
            <asp:SessionParameter Name="BayCode" SessionField="BayCode" />
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, LevelNumber FROM Level WHERE (RackCode = @RackCode) AND (LevelNumber = @LevelNumber)">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
            <asp:SessionParameter Name="LevelNumber" SessionField="LevelNumber" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSourceGetBayGrid" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, RackCode, BayCode FROM Bay ORDER BY RackCode"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT LocationCode FROM MasterList WHERE (LocationCode IS NOT NULL)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetUtilizedBin" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT SUBSTRING(LocationCode, 1, 10) AS SubStr, COUNT(SUBSTRING(LocationCode, 6, 5)) AS Count FROM MasterList WHERE (LocationCode IS NOT NULL) GROUP BY SUBSTRING(LocationCode, 1, 10)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceGetSpaceUtilization" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT LocationCode FROM MasterList WHERE (LocationCode LIKE '%' + @RackCode + '%') AND (LocationCode LIKE '%' + @BayCode + '%') AND (LocationCode LIKE '%' + @LevelCode + '%')">
        <SelectParameters>
            <asp:SessionParameter Name="RackCode" SessionField="RackCode" />
            <asp:SessionParameter Name="BayCode" SessionField="BayCode" />
            <asp:SessionParameter Name="LevelCode" SessionField="LevelCode" />
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

                                 



</asp:Content>
