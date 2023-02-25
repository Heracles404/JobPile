<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EditEmpAccount.aspx.cs" Inherits="JobPile.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    First Name:
    <asp:Label ID="efirstlbl" runat="server" />
    <asp:TextBox ID="efirsttxt" runat="server"></asp:TextBox>
    <br />
    Last Name:
    <asp:Label ID="elastlbl" runat="server" />
    <asp:TextBox ID="elasttxt" runat="server"></asp:TextBox>
    <br />
    Username:
    <asp:Label ID="userlbl" runat="server" />
    <asp:TextBox ID="usertxt" runat="server"></asp:TextBox>
    <br />
    Password:
    <asp:Label ID="passlbl" runat="server" />
    <asp:TextBox ID="passtxt" runat="server"></asp:TextBox>
    <br />
    Mobile Number:
    <asp:Label ID="mobilelbl" runat="server" />
    <asp:TextBox ID="mobiletxt" runat="server"></asp:TextBox>
    <br />
    Age:
    <asp:Label ID="agelbl" runat="server" />
    <asp:TextBox ID="agetxt" runat="server"></asp:TextBox>
    <br />
    Birthday:
    <asp:Label ID="birthdaylbl" runat="server" />
    <asp:TextBox ID="birthdaytxt" runat="server"></asp:TextBox>
    <br />
    Gender:
    <asp:Label ID="genderlbl" runat="server" />
    <asp:TextBox ID="gendertxt" runat="server"></asp:TextBox>
    <br />
    Biography:
    <asp:Label ID="biolbl" runat="server" />
    <asp:TextBox ID="biotxt" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="cmdSave" runat="server" OnClick="cmdSave_Click" Text="Save" />

</asp:Content>
