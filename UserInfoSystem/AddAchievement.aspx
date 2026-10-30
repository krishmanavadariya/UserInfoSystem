<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAchievement.aspx.cs" Inherits="UserInfoSystem.AddAchievement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Achievement</title>
    <!-- Minimal styles, consistent with your request -->
    <style>
        body { font-family: sans-serif; margin: 20px; }
        .form-group { margin-bottom: 10px; }
        .form-group label {
            display: inline-block;
            width: 150px;
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="number"],
        .form-group select {
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
            <h2>Add New Achievement</h2>
            <hr />

            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div class="form-group">
                <label for="ddlAchievementType">Achievement Type:</label>
                <asp:DropDownList ID="ddlAchievementType" runat="server">
                    <asp:ListItem Value="">-- Select Type --</asp:ListItem>
                    <asp:ListItem Value="SSC">SSC</asp:ListItem>
                    <asp:ListItem Value="HSC">HSC</asp:ListItem>
                    <asp:ListItem Value="UG">Undergraduate</asp:ListItem>
                    <asp:ListItem Value="PG">Postgraduate</asp:ListItem>
                    <asp:ListItem Value="Certification">Certification</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtInstitutionName">Institution Name:</label>
                <asp:TextBox ID="txtInstitutionName" runat="server" Required="true" />
            </div>
            <div class="form-group">
                <label for="txtGrade">Grade/Percentage:</label>
                <asp:TextBox ID="txtGrade" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtYearOfCompletion">Year of Completion:</label>
                <asp:TextBox ID="txtYearOfCompletion" runat="server" TextMode="Number" />
            </div>
            
            <div class="buttons">
                <asp:Button ID="btnSave" runat="server" Text="Save Achievement" OnClick="btnSave_Click" />
                <asp:HyperLink ID="btnCancel" NavigateUrl="~/AchievementsList.aspx" runat="server">Cancel</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
