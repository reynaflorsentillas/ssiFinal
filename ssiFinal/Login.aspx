<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="ssiFinal.ssiFinal.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
   <title>Login to Continue</title>
   <meta content="width=device-width, initial-scale=1.0" name="viewport" />
   <meta content="" name="description" />
   <meta content="" name="author" />
   <link href="theme/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
   <link href="theme/assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
   <link href="theme/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
   <link href="theme/css/style.css" rel="stylesheet" />
   <link href="theme/css/style-responsive.css" rel="stylesheet" />
   <link href="theme/css/style-default.css" rel="stylesheet" id="style_color" />
</head>
<body class="lock">
    <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" DataSourceMode="DataReader" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [ClientUsers] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="username" SessionField="loginUsername" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <form id="form1" runat="server">
    <div class="lock-header" style="padding-bottom:100px">
        <!-- BEGIN LOGO -->
        <a class="center" id="logo" href="#">
            <img class="center" alt="logo" src="theme/img/STORAGE.png" style="height:300px;width:300px;" />
        </a>
        <!-- END LOGO -->
    </div>
    <div class="login-wrap">
        <div class="metro single-size red">
            <div class="locked">
                <i class="icon-lock"></i>
                <span>Login</span>
            </div>
        </div>
        <div class="metro double-size green">
            
                <div class="input-append lock-input">
                    <input id="usernameTextBox1" runat="server" type="text" placeholder="USERNAME" />
                </div>
            
        </div>
        <div class="metro double-size yellow">
            
                <div class="input-append lock-input">
                   
                     <input id="passwordTextBox1" runat="server" type="password" placeholder="PASSWORD" />
                </div>
            
        </div>
        <div class="metro single-size terques login">
            <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn login-btn"/>             
        </div>
        
        <div class="login-footer">
            <div class="remember-hint pull-left" visible="False">
                <asp:Label ID="Label1" runat="server" Text="Incorrect email or Password" Visible="False"></asp:Label>
            </div>
            
        </div>
    </div>
    </form>

     
</body>
</html>

