<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="DynamicCandidatePage.aspx.cs" Inherits="JobPile.WebForm7" %>
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
</asp:Content>
