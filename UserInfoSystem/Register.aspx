<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UserInfoSystem.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <!-- Simple styling for a cleaner look -->
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .form-container { max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 8px; }
        .form-group { margin-bottom: 15px; }
        .form-group label { display: block; margin-bottom: 5px; font-weight: bold; }
        .form-group input, .form-group select { width: 95%; padding: 8px; border: 1px solid #ddd; border-radius: 4px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>User Registration</h2>
            
            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div class="form-group">
                <asp:Label For="txtFirstName" runat="server">First Name:</asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <asp:Label For="txtLastName" runat="server">Last Name:</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <asp:Label For="rblGender" runat="server">Gender:</asp:Label>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label For="txtBirthdate" runat="server">Birthdate:</asp:Label>
                <asp:TextBox ID="txtBirthdate" runat="server" TextMode="Date" />
            </div>
            <div class="form-group">
                <asp:Label For="filePhoto" runat="server">Photograph:</asp:Label>
                <asp:FileUpload ID="filePhoto" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtEmail" runat="server">Email:</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Required="true" />
            </div>
            <div class="form-group">
                <asp:Label For="txtPhoneNumber" runat="server">Phone Number:</asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtAddress" runat="server">Address:</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtCity" runat="server">City:</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtState" runat="server">State:</asp:Label>
                <asp:TextBox ID="txtState" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtPincode" runat="server">Pincode:</asp:Label>
                <asp:TextBox ID="txtPincode" runat="server" />
            </div>
            <hr />
            <div class="form-group">
                <asp:Label For="txtUsername" runat="server">Username:</asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <asp:Label For="txtPassword" runat="server">Password:</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Required="true" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </div>
            <p>Already have an account? <a href="Login.aspx">Log In</a></p>
        </div>
    </form>
</body>
</html>
