<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserInfoSystem.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .form-container { width: 350px; margin: 100px auto; padding: 20px; border: 1px solid #ccc; border-radius: 8px; }
        .form-group { margin-bottom: 15px; }
        .form-group label { display: block; margin-bottom: 5px; font-weight: bold; }
        .form-group input { width: 95%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Log In</h2>
            <p>Please enter your username and password.</p>
            
            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div class="form-group">
                <asp:Label For="txtUsername" runat="server">Username</asp:Label>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" Required="true" />
            </div>
            <div class="form-group">
                <asp:Label For="txtPassword" runat="server">Password</asp:Label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" Required="true" />
            </div>
            <div class="form-group">
                <asp:CheckBox runat="server" ID="chkRememberMe" Text=" Remember me?" />
            </div>
            <div class="form-group">
                <asp:Button runat="server" OnClick="btnLogin_Click" Text="Log in" />
            </div>
            <p>Don't have an account? <a href="Register.aspx">Register</a></p>
        </div>
    </form>
</body>
</html>
