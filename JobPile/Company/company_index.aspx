<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="company_index.aspx.cs" Inherits="JobPile.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="grid col-3">
            <!--Create Job Post Button-->
            <asp:Button ID="Button1" CssClass="postBTN btn btn-primary button-content" runat="server" Text="Post a Job!" PostBackUrl="~/CreatePost" />

            <!--Edit Job Post Button-->
            <asp:Button ID="Button2" CssClass="postBTN btn btn-primary button-content" runat="server" Text="Edit a Job Post" PostBackUrl="~/EditPosts" />
            <br />
        </div>
        <div class="col-8">
            <!--Shows every Job Posts-->
            <asp:GridView ID="applicantGrid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="jptitle" HeaderText="Job Title" />
                    <asp:BoundField DataField="jpseekers" HeaderText="Number of Applicants" />
                    <asp:BoundField DataField="jpstatus" HeaderText="Status" />
                    <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString="~/JobPosts/{0}" DataNavigateUrlFields="jpID" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
