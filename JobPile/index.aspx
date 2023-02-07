<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="JobPile.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>JobPile</title>
    <!-- StyleSheet -->
    <link href="assets/style/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <img src="assets/logo/big-jobpile.png" class="img-logo" />

        <!-- Search Bar -->
        <div class="input-group search-bar container-fluid row">
            <asp:DropDownList ID="type" CssClass="btn btn-outline-primary text-light col-sm-8" runat="server">
                <asp:ListItem Value="1">Jobs</asp:ListItem>
                <asp:ListItem Value="2">People</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="txtSearch" type="text" class="form-control col-sm-11" />
            <asp:Button runat="server" ID="search" type="button" class="btn btn-outline-primary text-white col-sm-8" Text="Search" />
        </div>
    </div>
</asp:Content>
