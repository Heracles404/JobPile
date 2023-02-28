<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeAccount.aspx.cs" Inherits="JobPile.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .edit{
            width: 15rem;
            margin-left: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row emp py-5 px-3">
        <div class="content container-fluid col-4">
            <div class="personal-info">
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Resumé Link</span>
                    <asp:TextBox ID="resume" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Name</span>
                    <asp:TextBox ID="nametxt" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Username</span>
                    <asp:TextBox ID="uname" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Mobile Number</span>
                    <asp:TextBox ID="num" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Age</span>
                    <asp:TextBox ID="age" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Birthday</span>
                    <asp:TextBox ID="bday" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Gender</span>
                    <asp:TextBox ID="gender" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Biography</span>
                    <asp:TextBox ID="bio" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Education</span>
                    <asp:TextBox ID="educ" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Degree</span>
                    <asp:TextBox ID="degr" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Experience</span>
                    <asp:TextBox ID="exp" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Skills</span>
                    <asp:TextBox ID="skills" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <asp:Button ID="editaccbtn" CssClass="btn btn-primary mx-0 px-3 edit" runat="server" Text="Edit Account Information" PostBackUrl="~/EditEmployeeAccount" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
