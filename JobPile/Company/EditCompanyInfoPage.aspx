<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="EditCompanyInfoPage.aspx.cs" Inherits="JobPile.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="10: url=~/CompanyInfo"? />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row emp py-3 px-3">
        <div class="content container-fluid col-4">
            <div class="personal-info">
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">Company Name</span>
                    <!--Company Name Textbox-->
                    <asp:TextBox ID="nametxt" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">Email</span>
                    <!--Email Textbox-->
                    <asp:TextBox ID="emailtxt" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">Website</span>
                    <!--Website Textbox-->
                    <asp:TextBox ID="websitetxt" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">Contact No.</span>
                    <!--Contact Num Textbox-->
                    <asp:TextBox ID="numtxt" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">About Us</span>
                    <!--About Us Textbox-->
                    <asp:TextBox ID="aboutustxt" runat="server" CssClass="form-control big" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">Mission</span>
                    <!--Mission Textbox-->
                    <asp:TextBox ID="missiontxt" runat="server" CssClass="form-control big" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <span class="input-group-text">VIsion</span>
                    <!--Mission Textbox-->
                    <asp:TextBox ID="visiontxt" runat="server" CssClass="form-control big" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="input-group p-2 m-0">
                    <!--Save Button-->
                    <asp:Button ID="cmdSave" runat="server" CssClass="form-control btn btn-primary" OnClick="cmdSave_Click" Text="Save" />
                </div>
            </div>
        </div>
    </div>


  



</asp:Content>
