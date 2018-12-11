<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="ViewInvoice.aspx.vb" Inherits="ssiFinal.ViewInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSourceSelectInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT Id, CompanyName, DateRange, DateRange + ' / ' + CompanyName AS CompanyDetails FROM InvoiceList ORDER BY Id DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceInsertInvoice" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceList] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceList] ([CompanyName], [DateRange]) VALUES (@CompanyName, @DateRange) SET @InvoiceId = SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [InvoiceList]" UpdateCommand="UPDATE [InvoiceList] SET [CompanyName] = @CompanyName, [DateRange] = @DateRange WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="CompanyName" SessionField="CompanyName" Type="String" />
            <asp:SessionParameter Name="DateRange" SessionField="DateRange" Type="String" />
            <asp:Parameter Name="InvoiceId" Type="Int32" Direction="Output" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="DateRange" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <div class="controls">
        <asp:Label ID="Label1" runat="server" Text="Select Company:"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSourceCompany" DataTextField="CompanyName" DataValueField="CompanyCode">
    </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="From:"></asp:Label>
    <asp:TextBox ID="TextBoxFrom" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="To:"></asp:Label>
    <asp:TextBox ID="TextBoxTo" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonGenerateInvoice" runat="server" Text="Generate" CssClass="btn btn-primary" />
    </div>
    <div class="controls">
        <asp:GridView ID="GridView4" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSourceSelectInvoice" CssClass="table table-striped table-bordered table-advance table-hover" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" Visible="False" />
            <asp:BoundField DataField="DateRange" HeaderText="DateRange" SortExpression="DateRange" Visible="False" />
            <asp:BoundField DataField="CompanyDetails" HeaderText="CompanyDetails" ReadOnly="True" SortExpression="CompanyDetails" />
        </Columns>
    </asp:GridView>
    </div>
    
    <br />
    <br />

    <div class="controls">
        <div class="text-center">
             Invoice Detail (Summary) Transaction Period from <asp:Label ID="TransactionPeriodLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="controls">
        <div class="text-center">
             <asp:Label ID="CompanyNameLabel" runat="server" Text=""></asp:Label>  
        </div>
    </div>
    <div class="controls">
        <h3>Monthly Storage Fee</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceStorageFee" ShowFooter="True" CssClass="table table-striped table-bordered table-advance table-hover">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
            <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
            <asp:BoundField DataField="Item" SortExpression="Item" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
             <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
        </Columns>
    </asp:GridView>
    </div>
    <div class="controls">

    </div>

    <asp:SqlDataSource ID="SqlDataSourceCompany" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CompanyCode], [CompanyName] FROM [Companies]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSourceDateRange" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [InvoiceList] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView4" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    
    <br />
    <asp:Label ID="LabelStorage" runat="server" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSourceStorageFee" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT Id, InvoiceId, ItemType, Item, Quantity, Rate, Total FROM InvoiceItems WHERE (InvoiceId = @InvoiceId) AND (ItemType = @ItemType)" UpdateCommand="UPDATE [InvoiceItems] SET [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="InvoiceId" Type="Int32" />
            <asp:Parameter Name="ItemType" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView4" Name="InvoiceId" PropertyName="SelectedValue" />
            <asp:QueryStringParameter DefaultValue="MonthlyStorageFee" Name="ItemType" QueryStringField="ItemType" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Item Handling<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handling In<br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceHandlingIn" ShowFooter="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
            <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
            <asp:BoundField DataField="Item" SortExpression="Item" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceHandlingIn" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE [InvoiceItems] SET  [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="GridView4" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="ItemType" PropertyName="SelectedValue" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView4" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="ItemHandling_HandlingIn" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:ControlParameter ControlID="GridView4" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handling Out<br />
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceHandlingOut" ShowFooter="True">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
            <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
            <asp:BoundField DataField="Item" SortExpression="Item" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceHandlingOut" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE [InvoiceItems] SET [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="InvoiceId" Type="Int32" />
            <asp:Parameter Name="ItemType" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView4" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="ItemHandling_HandlingOut" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:ControlParameter ControlID="GridView4" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:Label ID="LabelItemHandling" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    Others<br />
    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceOthers">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" SortExpression="InvoiceId" Visible="False" />
            <asp:BoundField DataField="ItemType" HeaderText="ItemType" SortExpression="ItemType" Visible="False" />
            <asp:BoundField DataField="Item" SortExpression="Item" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
            <asp:TemplateField HeaderText="Total" SortExpression="Total">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSourceOthers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate], [Total]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate, @Total)" SelectCommand="SELECT * FROM [InvoiceItems] WHERE (([InvoiceId] = @InvoiceId) AND ([ItemType] = @ItemType))" UpdateCommand="UPDATE [InvoiceItems] SET  [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="InvoiceId" Type="Int32" />
            <asp:Parameter Name="ItemType" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView4" Name="InvoiceId" PropertyName="SelectedValue" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="Others" Name="ItemType" QueryStringField="ItemType" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
            <asp:ControlParameter ControlID="GridView4" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Add Item In Item:<br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="ItemHandling_HandlingIn">Handling In</asp:ListItem>
        <asp:ListItem Value="ItemHandling_HandlingOut">Handling Out</asp:ListItem>
        <asp:ListItem Value="MonthlyStorageFee">Monthly Storage</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
    </asp:DropDownList>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSourceHandlingIn" DefaultMode="Insert">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            InvoiceId:
            <asp:TextBox ID="InvoiceIdTextBox" runat="server" Text='<%# Bind("InvoiceId") %>' />
            <br />
            ItemType:
            <asp:TextBox ID="ItemTypeTextBox" runat="server" Text='<%# Bind("ItemType") %>' />
            <br />
            Item:
            <asp:TextBox ID="ItemTextBox" runat="server" Text='<%# Bind("Item") %>' />
            <br />
            Quantity:
            <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
            <br />
            Rate:
            <asp:TextBox ID="RateTextBox" runat="server" Text='<%# Bind("Rate") %>' />
            <br />
            Total:
            <asp:TextBox ID="TotalTextBox" runat="server" Text='<%# Bind("Total") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Item Name:
            <asp:TextBox ID="ItemTextBox" runat="server" Text='<%# Bind("Item") %>' />
            <br />
            Quantity:
            <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
            <br />
            Rate:
            <asp:TextBox ID="RateTextBox" runat="server" Text='<%# Bind("Rate") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Add Item" />
&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            InvoiceId:
            <asp:Label ID="InvoiceIdLabel" runat="server" Text='<%# Bind("InvoiceId") %>' />
            <br />
            ItemType:
            <asp:Label ID="ItemTypeLabel" runat="server" Text='<%# Bind("ItemType") %>' />
            <br />
            Item:
            <asp:Label ID="ItemLabel" runat="server" Text='<%# Bind("Item") %>' />
            <br />
            Quantity:
            <asp:Label ID="QuantityLabel" runat="server" Text='<%# Bind("Quantity") %>' />
            <br />
            Rate:
            <asp:Label ID="RateLabel" runat="server" Text='<%# Bind("Rate") %>' />
            <br />
            Total:
            <asp:Label ID="TotalLabel" runat="server" Text='<%# Bind("Total") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <br />


</asp:Content>
