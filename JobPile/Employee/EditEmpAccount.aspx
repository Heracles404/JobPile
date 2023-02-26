<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EditEmpAccount.aspx.cs" Inherits="JobPile.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .edit{
            width: 10rem;
            margin-left: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row emp py-5 px-3">
        <div class="content container-fluid col-4">
            <div class="personal-info">
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">First Name</span>
                    <asp:TextBox ID="fname" CssClass="form-control fw-semibold" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Last Name</span>
                    <asp:TextBox ID="lname" CssClass="form-control fw-semibold" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Username</span>
                    <asp:TextBox ID="uname" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Password</span>
                    <asp:TextBox ID="pw" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Re-password</span>
                    <asp:TextBox ID="repw" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Mobile Number</span>
                    <asp:TextBox ID="num" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Age</span>
                    <asp:TextBox ID="age" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Birthday</span>
                    <asp:TextBox ID="bday" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Gender</span>
                        <asp:DropDownList ID="gender" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="M" Value="M"></asp:ListItem>
                        <asp:ListItem Text="F" Value="F"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Biography</span>
                    <asp:TextBox ID="bio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Education</span>
                    <asp:TextBox ID="educ" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Experience</span>
                    <asp:TextBox ID="exp" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Skills</span>
                    <asp:TextBox ID="skills" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <asp:Button ID="editaccbtn" CssClass="btn btn-primary px-3 edit" runat="server" Text="Save Changes" OnClick="cmdSave_Click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
