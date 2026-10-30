<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="UserInfoSystem.UpdateProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Profile</title>
    <!-- Minimal styles, consistent with your request for Profile.aspx -->
    <style>
        body { font-family: sans-serif; margin: 20px; }
        .form-group { margin-bottom: 10px; }
        .form-group label {
            display: inline-block;
            width: 120px;
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="date"],
        .form-group input[type="email"] {
            width: 250px;
            padding: 4px;
        }
        .buttons { margin-top: 20px; }
        .buttons a { margin-left: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Update Your Profile</h2>
            <hr />

            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div class="form-group">
                <label>Username:</label>
                <!-- Username is not editable -->
                <asp:Literal ID="ltlUsername" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtFirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <label for="txtLastName">Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <label for="rblGender">Gender:</label>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label for="txtBirthdate">Birthdate:</label>
                <asp:TextBox ID="txtBirthdate" runat="server" TextMode="Date" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Required="true" />
            </div>
            <div class="form-group">
                <label for="txtPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtCity">City:</label>
                <asp:TextBox ID="txtCity" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtState">State:</label>
                <asp:TextBox ID="txtState" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtPincode">Pincode:</label>
                <asp:TextBox ID="txtPincode" runat="server" />
            </div>

            <div class="buttons">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
                <asp:HyperLink ID="btnCancel" NavigateUrl="~/Profile.aspx" runat="server">Cancel</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
