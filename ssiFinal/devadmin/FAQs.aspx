<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="FAQs.aspx.vb" Inherits="ssiFinal.FAQs" %>
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
            <div class="widget red">
                <div class="widget-title">
                    <h4>
                        <i class="icon-reorder"></i>
                        FAQs
                    </h4>
                </div>
                <div class="widget-body">
                    <div class="control-group">
                        <div class="controls">
                            Select Available Sections: <asp:DropDownList ID="DropDownListFaqs" runat="server" DataSourceID="SqlDataSourceSections" DataTextField="FAQSection" DataValueField="Id" AutoPostBack="True" ViewStateMode="Enabled"></asp:DropDownList> or add a new Section: <asp:TextBox ID="TextBoxSectionName" placeholder="Enter Section Name..." runat="server"></asp:TextBox> <asp:Button ID="ButtonAddSection" runat="server" Text="Add" CssClass="btn btn-primary" />
                        </div>
                        <div class="controls">
                            <label class="control-label">Add Answered Questions:</label>
                            Question: <asp:TextBox ID="TextBoxQuestion" runat="server" CssClass="span12"></asp:TextBox>
                        </div>
                        <div class="controls">
                            Your Answer: <asp:TextBox ID="TextBoxAnswer" runat="server" CssClass="span12"></asp:TextBox>
                        </div>
                        <div class="controls">
                            <asp:Button ID="ButtonAddAnswer" runat="server" Text="Add Answered Question" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <h3 class="control-label">FAQs</h3>
                            <asp:GridView ID="GridViewAnwers" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceAnswers" CssClass="table table-striped table-bordered table-advance table-hover">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButtonDeleteAll" runat="server" OnClick="LinkButtonDeleteAll_Click">Delete All</asp:LinkButton>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="SectionId" HeaderText="SectionId" SortExpression="SectionId" ReadOnly="true" Visible="False" />
                                    <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                                    <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="ButtonDleteSection" runat="server" Text="Delete This Section" class="btn btn-primary popovers"  data-trigger="hover" data-placement="right" data-content="A section can be deleted only if it has no 'Answered Questions'. If you wish to delete a section containing 'Answered Questions', you must delete all 'Answered Questions' first." data-original-title="Note:" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

<asp:SqlDataSource ID="SqlDataSourceSections" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [FAQs] WHERE [Id] = @Id" InsertCommand="INSERT INTO [FAQs] ([FAQSection]) VALUES (@FAQSection)" SelectCommand="SELECT * FROM [FAQs]" UpdateCommand="UPDATE [FAQs] SET [FAQSection] = @FAQSection WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:ControlParameter ControlID="DropDownListFaqs" Name="Id" PropertyName="SelectedValue" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:ControlParameter ControlID="TextBoxSectionName" Name="FAQSection" PropertyName="Text" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="FAQSection" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceAnswers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [FAQAnswers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [FAQAnswers] ([SectionId], [Question], [Answer]) VALUES (@SectionId, @Question, @Answer)" SelectCommand="SELECT * FROM [FAQAnswers] WHERE ([SectionId] = @SectionId)" UpdateCommand="UPDATE [FAQAnswers] SET  [Question] = @Question, [Answer] = @Answer WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="DropDownListFaqs" Name="SectionId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxQuestion" Name="Question" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBoxAnswer" Name="Answer" PropertyName="Text" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListFaqs" Name="SectionId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Question" Type="String" />
            <asp:Parameter Name="Answer" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceDeleteAllAnswers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [FAQAnswers] WHERE [SectionId] = @Id" InsertCommand="INSERT INTO [FAQAnswers] ([SectionId], [Question], [Answer]) VALUES (@SectionId, @Question, @Answer)" SelectCommand="SELECT * FROM [FAQAnswers]" UpdateCommand="UPDATE [FAQAnswers] SET [SectionId] = @SectionId, [Question] = @Question, [Answer] = @Answer WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:ControlParameter ControlID="DropDownListFaqs" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SectionId" Type="Int32" />
            <asp:Parameter Name="Question" Type="String" />
            <asp:Parameter Name="Answer" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="SectionId" Type="Int32" />
            <asp:Parameter Name="Question" Type="String" />
            <asp:Parameter Name="Answer" Type="String" />
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

</asp:Content>
