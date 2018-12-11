<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/rein-DevelopementAdmin/Site2.Master" CodeBehind="TransactionRePickup.aspx.vb" Inherits="ssiFinal.TransactionRePickup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceTransactionRepickup">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="CompanyCode" HeaderText="CompanyCode" SortExpression="CompanyCode"></asp:BoundField>
            <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department"></asp:BoundField>
            <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"></asp:BoundField>
            <asp:BoundField DataField="BoxNumber" HeaderText="BoxNumber" SortExpression="BoxNumber"></asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:BoundField DataField="LocationCode" HeaderText="LocationCode" SortExpression="LocationCode"></asp:BoundField>
            <asp:BoundField DataField="DestructionDate" HeaderText="DestructionDate" SortExpression="DestructionDate"></asp:BoundField>
            <asp:BoundField DataField="StockReceipt_id" HeaderText="StockReceipt_id" SortExpression="StockReceipt_id"></asp:BoundField>
            <asp:BoundField DataField="QRCode" HeaderText="QRCode" SortExpression="QRCode"></asp:BoundField>
            <asp:BoundField DataField="Retention" HeaderText="Retention" SortExpression="Retention"></asp:BoundField>
            <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy"></asp:BoundField>
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate"></asp:BoundField>
            <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy"></asp:BoundField>
            <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceTransactionRepickup" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [MasterList] WHERE (([Status] = @Status) AND ([CompanyCode] = @CompanyCode))">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="OUT" Name="Status" QueryStringField="Status" Type="String" />
            <asp:SessionParameter Name="CompanyCode" SessionField="CompanyCode" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
