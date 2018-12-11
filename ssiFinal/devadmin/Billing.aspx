<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/devadmin/MasterPage.Master" CodeBehind="Billing.aspx.vb" Inherits="ssiFinal.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MessagesPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AlertsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Select Company:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceCompany" DataTextField="CompanyName" DataValueField="CompanyCode">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSourceCompany" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CompanyCode], [CompanyName] FROM [Companies]"></asp:SqlDataSource>
    <asp:Label ID="Label2" runat="server" Text="From:"></asp:Label>
    <asp:TextBox ID="TextBoxFrom" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="To:"></asp:Label>
    <asp:TextBox ID="TextBoxTo" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonGenerateInvoice" runat="server" Text="Generate" />

   
    <%--<asp:GridView ID="GridViewMonthlyStorage" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMonthlyStorage" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department"></asp:BoundField>
            <asp:BoundField DataField="Expr1" HeaderText="No. of Boxes" ReadOnly="True" SortExpression="Column1"></asp:BoundField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:Label ID="LabelCurrency" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                    <asp:TextBox ID="TextBoxRate" runat="server" BorderStyle="None" Text="11" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    X
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <FooterTemplate>
                    Php
                    <asp:Label ID="LabelTotal" runat="server" Text="Label"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                            <asp:Label ID="LabelCurrency2" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                            <asp:TextBox ID="TextBoxLineTotal" runat="server" BorderStyle="None"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" />--%>


    <asp:SqlDataSource ID="SqlDataSourceMonthlyStorage" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Department, COUNT(Department) AS Expr1 FROM MasterList WHERE (CompanyCode = @CompanyCode) AND (CreatedDate BETWEEN @From AND @To ) GROUP BY Department" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="TextBoxFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBoxTo" Name="To" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourcePickupBoxNewStorage" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DataSourceMode="DataReader" SelectCommand="SELECT COUNT(PickUps.Status) AS BoxCount FROM PickUps INNER JOIN TransactionHeaders ON PickUps.TransactionHeaders_id = TransactionHeaders.Id WHERE (PickUps.Status = @Status) AND (PickUps.ModifiedDate BETWEEN @From AND @To ) AND (TransactionHeaders.CompanyCode = @CompanyCode) GROUP BY PickUps.Status, TransactionHeaders.CompanyCode">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:ControlParameter ControlID="TextBoxFrom" DefaultValue="" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBoxTo" Name="To" PropertyName="Text" />
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

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

    <asp:SqlDataSource ID="SqlDataSourceHandlingIn" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TransactionHeaders.isRush, COUNT(Repickup.TransactionHeaders_id) AS BoxCount FROM TransactionHeaders INNER JOIN Repickup ON TransactionHeaders.Id = Repickup.TransactionHeaders_id WHERE (Repickup.Status = @Status) AND (TransactionHeaders.ModifiedDate BETWEEN @From AND @To ) AND (TransactionHeaders.CompanyCode = @CompanyCode) GROUP BY TransactionHeaders.isRush, Repickup.Status, TransactionHeaders.CompanyCode" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBoxTo" Name="To" PropertyName="Text" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceHandlingOut" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT TransactionHeaders.isRush, COUNT(Retrievals.TransactionHeaders_id) AS BoxCount FROM TransactionHeaders INNER JOIN Retrievals ON TransactionHeaders.Id = Retrievals.TransactionHeaders_id WHERE (TransactionHeaders.ModifiedDate BETWEEN @From AND @To ) AND (TransactionHeaders.CompanyCode = @CompanyCode) AND (TransactionHeaders.Status = @Status) GROUP BY TransactionHeaders.isRush, TransactionHeaders.CompanyCode" DataSourceMode="DataReader">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxFrom" Name="From" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBoxTo" Name="To" PropertyName="Text" />
            <asp:QueryStringParameter DefaultValue="PROCESSED" Name="Status" QueryStringField="Status" />
            <asp:ControlParameter ControlID="DropDownList1" Name="CompanyCode" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSourceInsertItem" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [InvoiceItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [InvoiceItems] ([InvoiceId], [ItemType], [Item], [Quantity], [Rate]) VALUES (@InvoiceId, @ItemType, @Item, @Quantity, @Rate)" SelectCommand="SELECT * FROM [InvoiceItems]" UpdateCommand="UPDATE [InvoiceItems] SET [InvoiceId] = @InvoiceId, [ItemType] = @ItemType, [Item] = @Item, [Quantity] = @Quantity, [Rate] = @Rate, [Total] = @Total WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="InvoiceId" SessionField="InvoiceId" Type="Int32" />
            <asp:SessionParameter Name="ItemType" SessionField="ItemType" Type="String" />
            <asp:SessionParameter Name="Item" SessionField="Item" Type="String" />
            <asp:SessionParameter Name="Quantity" SessionField="Quantity" Type="Int32" />
            <asp:SessionParameter Name="Rate" SessionField="Rate" Type="Double" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="InvoiceId" Type="Int32" />
            <asp:Parameter Name="ItemType" Type="String" />
            <asp:Parameter Name="Item" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="Rate" Type="Double" />
            <asp:Parameter Name="Total" Type="Double" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <br />
    <br />

    <br />

   <%-- <asp:GridView ID="GridViewHandlingIn" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceHandlingIn" Width="647px" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="isRush" HeaderText="" SortExpression="isRush" />
            <asp:BoundField DataField="BoxCount" HeaderText="No. of Boxes" ReadOnly="True" SortExpression="BoxCount" />
            <asp:TemplateField HeaderText="Rate Per Box">
                <ItemTemplate>
                    <asp:Label ID="LabelCurrency" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                    <asp:TextBox ID="TextBoxRate" runat="server" BorderStyle="None" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    X
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <FooterTemplate>
                    Php
                    <asp:Label ID="LabelTotal" runat="server" Text="Label"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                            <asp:Label ID="LabelCurrency2" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                            <asp:TextBox ID="TextBoxLineTotal" runat="server" BorderStyle="None"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

    <br />
    <asp:GridView ID="GridViewHandlingOut" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceHandlingOut" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="isRush" HeaderText="" SortExpression="isRush" />
            <asp:BoundField DataField="BoxCount" HeaderText="No. of Boxes" ReadOnly="True" SortExpression="BoxCount" />
             <asp:TemplateField HeaderText="Rate Per Box">
                <ItemTemplate>
                    <asp:Label ID="LabelCurrency" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                    <asp:TextBox ID="TextBoxRate" runat="server" BorderStyle="None" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    X
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <FooterTemplate>
                    Php
                    <asp:Label ID="LabelTotal" runat="server" Text="Label"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                            <asp:Label ID="LabelCurrency2" runat="server" Text="Php" style="vertical-align: central;"></asp:Label>
                            <asp:TextBox ID="TextBoxLineTotal" runat="server" BorderStyle="None"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />--%>

    </asp:Content>
