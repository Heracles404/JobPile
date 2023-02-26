<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="DynamicCandidatePage.aspx.cs" Inherits="JobPile.WebForm7" %>
<<<<<<< HEAD

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .back{
            width: 10rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Shows information based on passed jobTitle from hyperlink-->
    <div class="row mt-5 pt-3">
        <div class="content container-fluid  col-5">
            <div class="px-4 py-0 mx-0 mt-3">
                <div class="input-group">
                    <span class="input-group-text">Name</span>
                    <asp:TextBox ID="nameTXT" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Age</span>
                    <asp:TextBox ID="age" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Birthday</span>
                    <asp:TextBox ID="bday" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Gender</span>
                    <asp:TextBox ID="gender" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Skills</span>
                    <asp:TextBox ID="skills" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Experience</span>
                    <asp:TextBox ID="exp" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Biography</span>
                    <asp:TextBox ID="bio" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Button ID="Button1" CssClass="btn btn-primary m-0 back" runat="server" Text="Back" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>

=======
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Shows information based on passed jobTitle from hyperlink-->
    <h3><asp:Label ID="namelbl" runat="server" /></h3>
    Age:
    <asp:Label ID="agelbl" runat="server" />
    <br />
    Birthday:
    <asp:Label ID="birthdaylbl" runat="server" />
    <br />
    Gender:
    <asp:Label ID="genderlbl" runat="server" />
    <br />
    Skills:
    <asp:Label ID="skillslbl" runat="server" />
    <br />
    Experience:
    <asp:Label ID="experiencelbl" runat="server" />
    <br />
    Biography:
    <asp:Label ID="biolbl" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"/>
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
</asp:Content>
