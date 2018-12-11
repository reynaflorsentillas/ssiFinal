<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="scanner.aspx.vb" Inherits="ssiFinal.scanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Name:<asp:TextBox ID="TextBox2" runat="server" Width="433px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        Batch Name:<asp:TextBox ID="TextBox3" runat="server" Width="393px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        Barcodes:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="616px" TextMode="MultiLine" Width="100%"></asp:TextBox>
        <br />
    
    </div>
        <asp:Button ID="Button1" runat="server" Text="Submit" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [ScannedBarcodesBatch] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ScannedBarcodesBatch] ([BatchName], [SubmittedDate], [Name]) VALUES (@BatchName, @SubmittedDate, @Name) SET @NewParameter=SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [ScannedBarcodesBatch]" UpdateCommand="UPDATE [ScannedBarcodesBatch] SET [BatchName] = @BatchName, [SubmittedDate] = @SubmittedDate, [Name] = @Name WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="TextBox3" Name="BatchName" PropertyName="Text" Type="String" />
                <asp:SessionParameter DbType="Date" Name="SubmittedDate" SessionField="DateNowScan" />
                <asp:ControlParameter ControlID="TextBox2" Name="Name" PropertyName="Text" Type="String" />
                <asp:parameter Name="NewParameter" Type="Int32" Direction="Output" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="BatchName" Type="String" />
                <asp:Parameter DbType="Date" Name="SubmittedDate" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />

            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [ScannedBarcodes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ScannedBarcodes] ([BarcodeBatchId], [Barcode]) VALUES (@BarcodeBatchId, @Barcode)" SelectCommand="SELECT * FROM [ScannedBarcodes]" UpdateCommand="UPDATE [ScannedBarcodes] SET [BarcodeBatchId] = @BarcodeBatchId, [Barcode] = @Barcode WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:SessionParameter Name="BarcodeBatchId" SessionField="LastInsertID" Type="Int32" />
                <asp:SessionParameter Name="Barcode" SessionField="brRow" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="BarcodeBatchId" Type="Int32" />
                <asp:Parameter Name="Barcode" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
