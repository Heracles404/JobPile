<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmpDynamic.aspx.cs" Inherits="JobPile.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Shows information based on passed jobTitle from hyperlink-->
    <h3><asp:Label ID="jobTitlelbl" runat="server" /></h3>
    Salary:
    <asp:Label ID="salarylbl" runat="server" />
    <br />
    Shift:
    <asp:Label ID="shiftlbl" runat="server" />
    <br />
    Type:
    <asp:Label ID="typelbl" runat="server" />
    <br />
    Location:
    <asp:Label ID="locationlbl" runat="server" />
    <br />
    Skills:
    <asp:Label ID="skillslbl" runat="server" />
    <br />
    Experience:
    <asp:Label ID="experiencelbl" runat="server" />
    <br />
    Job Description:
    <asp:Label ID="jobDesclbl" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Back"  PostBackUrl="~/EmployeeJobLists" />
</asp:Content>
