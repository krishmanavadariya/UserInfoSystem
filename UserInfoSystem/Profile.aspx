<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="UserInfoSystem.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Profile</title>
    <!-- Minimal styles as requested -->
    <style>
        body { font-family: sans-serif; margin: 20px; }
        h1, h2, h3 { margin-top: 15px; }
        .profile-photo {
            width: 100px;
            height: 100px;
            object-fit: cover;
            border: 1px solid #777;
            margin-right: 15px;
            float: left; /* Basic layout */
        }
        .profile-info strong { 
            display: inline-block; 
            width: 100px; 
            font-weight: bold; 
        }
        .action-links { margin-top: 25px; }
        .action-links a { margin-right: 15px; }
        
        /* Simple header layout */
        .header-bar { overflow: auto; /* Clearfix */ }
        .header-bar h2 { float: left; }
        .btn-logout { 
            float: right; 
            margin-top: 25px; 
            color: #c00; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header-bar">
                <h2>User Profile</h2>
                <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CssClass="btn-logout">Logout</asp:LinkButton>
            </div>
            
            <hr />

            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div>
                <div>
                    <asp:Image ID="imgProfilePhoto" runat="server" CssClass="profile-photo" />
                    <div>
                        <h1><asp:Literal ID="ltlFullName" runat="server" /></h1>
                        <p><asp:Literal ID="ltlUsername" runat="server" /></p>
                    </div>
                </div>

                <div style="clear:both; padding-top: 20px;">
                    <div>
                        <h3>Contact Information</h3>
                        <div class="profile-info">
                            <p><strong>Email:</strong> <asp:Literal ID="ltlEmail" runat="server" /></p>
                            <p><strong>Phone:</strong> <asp:Literal ID="ltlPhone" runat="server" /></p>
                            <p><strong>Address:</strong> <asp:Literal ID="ltlAddress" runat="server" /></p>
                        </div>
                    </div>
                    
                    <div>
                        <h3>Personal Details</h3>
                        <div class="profile-info">
                            <p><strong>Birthdate:</strong> <asp:Literal ID="ltlBirthdate" runat="server" /></p>
                            <p><strong>Gender:</strong> <asp:Literal ID="ltlGender" runat="server" /></p>
                        </div>
                    </div>

                    <div class="action-links">
                        <a href="UpdateProfile.aspx">Update Profile</a>
                        <a href="AchievementsList.aspx">Manage Achievements</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

