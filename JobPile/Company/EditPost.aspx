<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="JobPile.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/style/com-master.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="content container-fluid  col-5">
            <div class="px-4 py-0 mx-0 mt-3">
                <div class="input-group">
                    <!--Job Title Search-->
                    <span class="input-group-text">Job Title</span>
                    <asp:TextBox ID="searchjobtitletxt" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Button ID="cmdSearch" runat="server" CssClass="form-control input-group-text btn btn-primary srch" OnClick="cmdSearch_Click" Text="Search" />
                    <asp:Button ID="deletebtn" runat="server" CssClass="form-control input-group-text btn btn-danger srch" OnClick="deletebtn_Click" Text="Delete" />
                </div>


                <div class="input-group">
                    <!--Job Title Textbox-->
                    <span class="input-group-text">Job Title</span>
                    <asp:TextBox ID="jobtitleTXT" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Salary Textbox-->
                    <span class="input-group-text">Salary
                    </span>
                    <asp:TextBox ID="salaryTXT" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Shift DropDown-->
                    <span class="input-group-text">Shift
                    </span>
                    <asp:DropDownList ID="DDLShift" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Day Shift" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Night Shift" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group">
                    <!-- Job Type -->
                    <span class="input-group-text">Job Type
                    </span>
                    <asp:DropDownList ID="DDLType" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Full Time" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part Time" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group">
                    <!--Location Textbox-->
                    <span class="input-group-text">Location
                    </span>
                    <asp:TextBox ID="locationTXT" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Skills Textbox-->
                    <span class="input-group-text">Skills
                    </span>
                    <asp:TextBox ID="skillsTXT" runat="server" CssClass="form-control" OnTextChanged="skillsTXT_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Button ID="resourcefulbtn" runat="server" Text="Resourceful" CssClass="px-2 skills btn-light" OnClick="resourcebtn_Click" CausesValidation="False" />
                    <asp:Button ID="efficientbtn" runat="server" Text="Efficient" CssClass="px-2 skills btn-light" OnClick="efficientbtn_Click" CausesValidation="False" />
                </div>

                <div class="input-group">
                    <span class="input-group-text">Experience
                    </span>
                    <!--Experience DropDown-->
                    <asp:DropDownList ID="DDLExperience" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="No Experience" Value="1"></asp:ListItem>
                        <asp:ListItem Text="1-2 Years Experience" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3-5 Years Experience" Value="3"></asp:ListItem>
                        <asp:ListItem Text="5+ Years Experience" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group big">
                    <span class="input-group-text">Job Description
                    </span>

                    <!--Job Description Textbox-->
                    <asp:TextBox ID="jobdescTXT" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="input-group">
                    <span class="input-group-text">Status
                    </span>
                    <!--Status DropDown-->
                    <asp:DropDownList ID="DDLStatus" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="On Hold" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group">
                    <!--Save Button-->
                    <asp:Button ID="cmdSave" runat="server" Visible="true" OnClick="cmdSave_Click" CssClass="btn btn-primary form-control" Text="Save" />
                    <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="False" CssClass="btn btn-secondary form-control" PostBackUrl="~/JobPosts" />
                </div>


            </div>
        </div>
    </div>
</asp:Content>
