<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAchievement.aspx.cs" Inherits="UserInfoSystem.UpdateAchievement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Achievement</title>
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
            <h2>Update Achievement</h2>
            
            <asp:Literal runat="server" ID="ltlMessage" EnableViewState="false" />

            <div class="form-group">
                <asp:Label For="ddlAchievementType" runat="server">Achievement Type:</asp:Label>
                <asp:DropDownList ID="ddlAchievementType" runat="server">
                    <asp:ListItem>SSC</asp:ListItem>
                    <asp:ListItem>HSC</asp:ListItem>
                    <asp:ListItem>UG</asp:ListItem>
                    <asp:ListItem>PG</asp:ListItem>
                    <asp:ListItem>Certification</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label For="txtInstitution" runat="server">Institution:</asp:Label>
                <asp:TextBox ID="txtInstitution" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtGrade" runat="server">Grade/Percentage:</asp:Label>
                <asp:TextBox ID="txtGrade" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label For="txtYear" runat="server">Year of Completion:</asp:Label>
                <asp:TextBox ID="txtYear" runat="server" TextMode="Number" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                <asp:HyperLink ID="btnCancel" NavigateUrl="~/AchievementsList.aspx" runat="server">Cancel</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
