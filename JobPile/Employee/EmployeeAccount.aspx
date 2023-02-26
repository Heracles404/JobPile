<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeAccount.aspx.cs" Inherits="JobPile.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3><asp:Label ID ="efirstlbl" runat="server"/> &nbsp <asp:Label ID ="elastlbl" runat="server"/></h3>
    <asp:Button ID="editaccbtn" runat="server" Text="Edit Account Information" PostBackUrl="~/EditEmpAccounts"/>
    <br />
    Username:
    <asp:Label ID="userlbl" runat="server" />
    <br />
    Password:
    <asp:Label ID="passlbl" runat="server" />
    <br />
    Mobile Number:
    <asp:Label ID="mobilelbl" runat="server" />
    <br />
    Age:
    <asp:Label ID="agelbl" runat="server" />
    <br />
    Birthday:
    <asp:Label ID="birthdaylbl" runat="server" />
    <br />
    Gender:
    <asp:Label ID="genderlbl" runat="server" />
    <br />
    Biography:
    <asp:Label ID="biolbl" runat="server" />
    <br />
</asp:Content>
