<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="DynamicCandidatePage.aspx.cs" Inherits="JobPile.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .back {
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
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Resumé Link:</span>
                    <asp:TextBox ID="resume" CssClass="form-control fw-semibold" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Button ID="Button1" CssClass="btn btn-primary m-0 back" runat="server" Text="Back" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
