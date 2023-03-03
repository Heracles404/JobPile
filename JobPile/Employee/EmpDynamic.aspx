<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmpDynamic.aspx.cs" Inherits="JobPile.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Shows information based on passed jobTitle from hyperlink-->
    <div class="row emp py-3 px-3">
        <div class="content container-fluid col-4">
            <div class="personal-info">
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Job</span>
                    <asp:TextBox ID="job" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Salary</span>
                    <asp:TextBox ID="salary" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Shift</span>
                    <asp:TextBox ID="shift" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Type</span>
                    <asp:TextBox ID="type" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Location</span>
                    <asp:TextBox ID="location" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Skills</span>
                    <asp:TextBox ID="skills" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Experience</span>
                    <asp:TextBox ID="exp" CssClass="form-control fw-semibold" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <span class="input-group-text">Job Desctiption</span>
                    <asp:TextBox ID="jobdesc" CssClass="form-control fw-semibold" textmode="MultiLine" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
                <div class="input-group px-2 py-1 m-0">
                    <asp:Button ID="Button1" CssClass="btn btn-primary m-0" runat="server" Text="Back" PostBackUrl="~/EmployeeJobLists" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
