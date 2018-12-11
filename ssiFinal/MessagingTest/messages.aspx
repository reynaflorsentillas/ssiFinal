<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MessagingTest/Site3.Master" CodeBehind="messages.aspx.vb" Inherits="ssiFinal.messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    Recipient:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    
    
    
    <br />
    Subject:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    Message:<br />
    <asp:TextBox ID="TextBox3" runat="server" Height="170px" TextMode="MultiLine" Width="271px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Send" />
    <br />
    
    
    
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" DeleteCommand="DELETE FROM [Conversation] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Conversation] ([Sender], [Recipient]) VALUES (@Sender, @Recipient) SET @ConvoId = SCOPE_IDENTITY()" SelectCommand="SELECT * FROM [Conversation]" UpdateCommand="UPDATE [Conversation] SET [Sender] = @Sender, [Recipient] = @Recipient WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="Sender" SessionField="username" Type="String" />
            <asp:ControlParameter ControlID="TextBox1" Name="Recipient" PropertyName="Text" Type="String" />
            <asp:Parameter Name="ConvoId" Direction="Output" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Sender" Type="String" />
            <asp:Parameter Name="Recipient" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ssitestConnectionString1 %>" SelectCommand="SELECT * FROM [Messages]" DeleteCommand="DELETE FROM [Messages] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Messages] ([ConvoId], [Sender], [Recipient], [Subject], [Body], [DateCreated]) VALUES (@ConvoId, @Sender, @Recipient, @Subject, @Body, @DateCreated)" UpdateCommand="UPDATE [Messages] SET [ConvoId] = @ConvoId, [Sender] = @Sender, [Recipient] = @Recipient, [Subject] = @Subject, [Body] = @Body, [DateCreated] = @DateCreated WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="ConvoId" SessionField="ConvoId" Type="Int32" />
            <asp:SessionParameter Name="Sender" SessionField="username" Type="String" />
            <asp:ControlParameter ControlID="TextBox1" Name="Recipient" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBox2" Name="Subject" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBox3" Name="Body" PropertyName="Text" Type="String" />
            <asp:SessionParameter Name="DateCreated" SessionField="DateCreated" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ConvoId" Type="Int32" />
            <asp:Parameter Name="Sender" Type="String" />
            <asp:Parameter Name="Recipient" Type="String" />
            <asp:Parameter Name="Subject" Type="String" />
            <asp:Parameter Name="Body" Type="String" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
