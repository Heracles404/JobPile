<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="CompanyInfoPage.aspx.cs" Inherits="JobPile.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .info{
            width: 15rem !important;
            height: 3.5rem;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid">
        <!--Shows information based on passed jobTitle from hyperlink-->
        <h3>
            <asp:Label ID="cnamelbl" runat="server" /></h3>
        <asp:Button ID="editinfobtn" runat="server" CssClass="btn info btn-primary p-3" Text="Edit Info Page" PostBackUrl="~/EditCompanyInfo" />
        <br />
        Email:
        <asp:Label ID="emaillbl" runat="server" />
        <br />
        Website:
        <asp:Label ID="websitelbl" runat="server" />
        <br />
        Contact Number:
        <asp:Label ID="numlbl" runat="server" />
        <br />
        About Us:
        <asp:Label ID="aboutuslbl" runat="server" />
        <br />
        Mission:
        <asp:Label ID="missionlbl" runat="server" />
        <br />
        Vision:
        <asp:Label ID="visionlbl" runat="server" />
        <br />
    </div>
</asp:Content>
