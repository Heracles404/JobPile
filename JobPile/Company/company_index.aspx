<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="company_index.aspx.cs" Inherits="JobPile.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/style/data-table.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="grid col-3">
            <!--Create Job Post Button-->
            <asp:Button ID="Button1" CssClass="postBTN btn btn-primary button-content mt-4" runat="server" Text="Post a Job!" PostBackUrl="~/CreatePost" />

            <!--Edit Job Post Button-->
            <asp:Button ID="Button2" CssClass="postBTN btn btn-primary button-content mt-2" runat="server" Text="Edit a Job Post" PostBackUrl="~/EditPosts" />
            <br />
        </div>
        <div class="col-8">
            <!--Shows every Job Posts-->
            <asp:GridView ID="applicantGrid" runat="server" AutoGenerateColumns="False" CssClass="col-12 text-center rounded-5 mt-4" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="jptitle" HeaderText="Job Title" />
                    <asp:BoundField DataField="jpseekers" HeaderText="Number of Applicants" />
                    <asp:BoundField DataField="jpstatus" HeaderText="Status" />
                    <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString="~/JobPosts/{0}" DataNavigateUrlFields="jptitle" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
