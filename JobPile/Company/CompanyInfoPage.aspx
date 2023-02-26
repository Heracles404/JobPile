<%@ Page Title="" Language="C#" MasterPageFile="../company.Master" AutoEventWireup="true" CodeBehind="CompanyInfoPage.aspx.cs" Inherits="JobPile.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .info{
            width: 10rem !important;
            height: 2.5rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Shows information based on passed jobTitle from hyperlink-->
    <div class="row mt-5 pt-3">
        <div class="content container-fluid  col-5">
            <div class="px-4 py-0 mx-0 mt-3">
                <div class="input-group">
                    <span class="input-group-text">Company</span>
                    <asp:TextBox ID="cname" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Email</span>
                    <asp:TextBox ID="emailTXT" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Website</span>
                    <asp:TextBox ID="website" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Contact Number</span>
                    <asp:TextBox ID="contact" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">About Us</span>
                    <asp:TextBox ID="about" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Mission</span>
                    <asp:TextBox ID="mission" CssClass="form-control" TextMode="MultiLine" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="input-group">
                    <span class="input-group-text">Vision</span>
                    <asp:TextBox ID="vision" CssClass="form-control" TextMode="MultiLine" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:Button ID="editinfobtn" runat="server" CssClass="btn info btn-primary" Text="Edit Info Page" PostBackUrl="~/EditCompanyInfo" />
            </div>
        </div>
        


    </div>

</asp:Content>
