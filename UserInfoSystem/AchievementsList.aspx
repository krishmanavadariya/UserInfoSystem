<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AchievementsList.aspx.cs" Inherits="UserInfoSystem.AchievementsList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Achievements</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .container { max-width: 900px; margin: auto; }
        .gridview { width: 100%; border-collapse: collapse; margin-top: 20px; }
        .gridview th, .gridview td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .gridview th { background-color: #f2f2f2; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>My Achievements</h2>
            <p>
                <asp:HyperLink NavigateUrl="~/Profile.aspx" runat="server">Back to Profile</asp:HyperLink> |
                <asp:HyperLink NavigateUrl="~/AddAchievement.aspx" runat="server">Add New Achievement</asp:HyperLink>
            </p>
            
            <asp:GridView ID="gvAchievements" runat="server" 
                AutoGenerateColumns="False" 
                CssClass="gridview"
                OnRowCommand="gvAchievements_RowCommand"
                DataKeyNames="AchievementId">
                <Columns>
                    <asp:BoundField DataField="AchievementType" HeaderText="Type" />
                    <asp:BoundField DataField="InstitutionName" HeaderText="Institution" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:BoundField DataField="YearOfCompletion" HeaderText="Year" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <!-- This uses a Query String to pass the ID -->
                            <asp:HyperLink runat="server" 
                                NavigateUrl='<%# Eval("AchievementId", "UpdateAchievement.aspx?id={0}") %>'
                                Text="Update" />
                            
                            <asp:LinkButton runat="server"
                                CommandName="DeleteAchievement" 
                                CommandArgument='<%# Eval("AchievementId") %>'
                                Text="Delete" 
                                OnClientClick="return confirm('Are you sure you want to delete this?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
