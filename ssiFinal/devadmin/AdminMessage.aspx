<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="AdminMessage.aspx.vb" Inherits="ssiFinal.AdminMessage" %>

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
    <!--<div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        Contact Us
                    </h4>
                </div>
                <div class="widget-body">
                        <div class="control-group">
                            <label class="control-label">Subject</label>
                            <div class="controls">
                                <asp:TextBox ID="SubjectTextBox" runat="server" CssClass="span6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SubjectTextBox" ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Message</label>
                            <div class="controls">
                                <asp:TextBox ID="BodyTextBox" runat="server" TextMode="MultiLine" CssClass="span12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BodyTextBox" ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls">
                                <asp:Button ID="SendButton" runat="server" Text="Send" CssClass="btn btn-success" ValidationGroup="1" />
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>-->

    <div class="row-fluid">
        <div class="span12">
            <div class="widget green">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        Messages
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls">
                                <div class="pull-right">
                                    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                                    <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" />
                                    <asp:Button ID="RefreshButton" runat="server" Text="Refresh" CssClass="btn btn-primary" />
                                </div>
                                <asp:Label ID="LabelException" runat="server" Text="[Label]" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="control-group">
                            <div class="controls portlet-scroll-1">
                                <asp:GridView ID="MessagesGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-advance table-hover" DataKeyNames="Id" DataSourceID="SqlDataSourceInsertConversation" AllowPaging="true">
                                    <Columns>
                                        <asp:CommandField SelectText="View Conversation" ShowSelectButton="True" />
                                        <asp:BoundField DataField="Id" HeaderText="MessageID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                        <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" />
                                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                                        <asp:BoundField DataField="DateCreated" HeaderText="Date" SortExpression="DateCreated" DataFormatString="{0:d}" />
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
                        Conversation
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <label id="subjectLabel" runat="server"></label>
                        <div class="controls portlet-scroll-1" style="height: 500px">
                            <asp:Panel ID="Panel1" runat="server" CssClass="row-fluid" Height="300px" ScrollBars="Auto">
                                <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSourceViewMessages">
                                    <ItemTemplate>
                                        <span style="">
                                            <strong>Sender:
                                                        <asp:Label ID="SenderLabel" runat="server" Text='<%# Eval("Sender") %>' /></strong>
                                            <br />
                                            Date:
                                                        <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                                            <br />
                                            <br />
                                            <strong>Message:</strong><br />
                                            <asp:Label ID="MessageLabel" runat="server" Text='<%# Eval("Message").Replace(Environment.NewLine, "<br />") %>' />
                                            <br />
                                            <br />
                                            <br />
                                            <hr />
                                        </span>
                                    </ItemTemplate>
                                </asp:ListView>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:TextBox ID="ReplyTextBox" runat="server" TextMode="MultiLine" CssClass="span12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="ReplyTextBox" ValidationGroup="2"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <asp:Button ID="ReplyButton" runat="server" Text="Reply" CssClass="btn btn-success" ValidationGroup="2" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSourceInsertConversation" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Conversation] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Conversation] ([Sender], [Subject], [DateCreated]) VALUES (@Sender, @Subject, @DateCreated) SET @ConvoId = SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [Conversation]" UpdateCommand="UPDATE [Conversation] SET [Sender] = @Sender, [Subject] = @Subject, [DateCreated] = @DateCreated WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="Sender" SessionField="clientUserName" Type="String" />
            <asp:ControlParameter ControlID="SubjectTextBox" Name="Subject" PropertyName="Text" Type="String" />
            <asp:SessionParameter DbType="Date" Name="DateCreated" SessionField="DateCreated" />
            <asp:Parameter Name="ConvoId" Type="Int32" Direction="Output" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Sender" Type="String" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="DateCreated" DbType="Date" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceViewMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Messages] WHERE ([ConvoId] = @ConvoId) ORDER BY [Id] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="MessagesGridView" Name="ConvoId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceInsertMessage" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Messages] WHERE [Id] = @Id" InsertCommand="INSERT INTO Messages(ConvoId, Sender, Message, DateCreated, Status) VALUES (@ConvoId, @Sender, @Message, @DateCreated, @Status)" SelectCommand="SELECT * FROM [Messages]" UpdateCommand="UPDATE [Messages] SET [ConvoId] = @ConvoId, [Sender] = @Sender, [Message] = @Message, [DateCreated] = @DateCreated WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="ConvoId" SessionField="ConvoId" Type="Int32" />
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" Type="String" />
            <asp:ControlParameter ControlID="BodyTextBox" Name="Message" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="DateCreated" SessionField="DateSend" Type="DateTime" />
            <asp:Parameter DefaultValue="1" Name="Status" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ConvoId" Type="Int32" />
            <asp:Parameter Name="Sender" Type="String" />
            <asp:Parameter Name="Message" Type="String" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceReply" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Messages] WHERE [Id] = @Id" InsertCommand="INSERT INTO Messages(ConvoId, Sender, Message, DateCreated, Status, Receiver) VALUES (@ConvoId, @Sender, @Message, @DateCreated, @Status, @Receiver)" SelectCommand="SELECT * FROM [Messages]" UpdateCommand="UPDATE [Messages] SET [ConvoId] = @ConvoId, [Sender] = @Sender, [Message] = @Message, [DateCreated] = @DateCreated WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="ConvoId" SessionField="ViewConvoId" Type="Int32" />
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" Type="String" />
            <asp:ControlParameter ControlID="ReplyTextBox" Name="Message" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="DateCreated" SessionField="DateCreated" Type="DateTime" />
            <asp:Parameter DefaultValue="1" Name="Status" />
            <asp:SessionParameter Name="Receiver" SessionField="Receiver" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ConvoId" Type="Int32" />
            <asp:Parameter Name="Sender" Type="String" />
            <asp:Parameter Name="Message" Type="String" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
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
    <asp:SqlDataSource ID="SqlDataSourceMessages" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, ConvoId, Sender, Message, DateCreated, Status FROM Messages WHERE (Sender &lt;&gt; @Sender) AND (Status = 1) ORDER BY Id DESC" UpdateCommand="UPDATE Messages SET Status = 0 WHERE (ConvoId = @InboxID) AND (Receiver = @Receiver) AND (Status = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ADMIN" Name="Sender" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="InboxID" SessionField="InboxID" />
            <asp:Parameter DefaultValue="ADMIN" Name="Receiver" />
            <asp:Parameter DefaultValue="1" Name="Status" />
        </UpdateParameters>
    </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="SqlDataSourceUserLoginAlert" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id, [User], DateLogin, Alerts FROM UserLogins WHERE (Alerts = @Alerts) ORDER BY DateLogin DESC" DataSourceMode="DataReader">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="1" Name="Alerts" />
                                            </SelectParameters>
                                     </asp:SqlDataSource>

                                 </asp:Content>
