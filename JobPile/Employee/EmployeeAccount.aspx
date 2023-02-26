<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeAccount.aspx.cs" Inherits="JobPile.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3><asp:Label ID ="efirstlbl" runat="server"/> &nbsp <asp:Label ID ="elastlbl" runat="server"/></h3>
<<<<<<< HEAD
    <asp:Button ID="editaccbtn" runat="server" Text="Edit Account Information" PostBackUrl="~/EditEmpAccounts"/>
=======
    <asp:Button ID="editaccbtn" runat="server" Text="Edit Account Information" PostBackUrl="~/EditEmployeeAccount"/>
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
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
<<<<<<< HEAD
=======
    Education:
    <asp:Label ID="educationlbl" runat="server" />
    <br />
    Experience:
    <asp:Label ID="experiencelbl" runat="server" />
    <br />
    Skills:
    <asp:Label ID="skillslbl" runat="server" />
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
</asp:Content>
