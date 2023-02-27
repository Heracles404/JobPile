<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="PendingInterview.aspx.cs" Inherits="JobPile.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="grid col-3">
            <!--Create Job Post Button-->
            <asp:Button ID="backbtn" CssClass="postBTN btn btn-primary button-content mt-5" Text="Back" runat="server" OnClick="backbtn_Click" />
        </div>
        <div class="col-8">
            <asp:GridView ID="applicantGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="interviewID" CssClass="col-12 text-center rounded-5 mt-4" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Candidate" HeaderText="Candidate" />
                    <asp:BoundField DataField="jobtitle" HeaderText="Job Post" />
                    <asp:BoundField DataField="interviewDate" HeaderText="Date of Interview" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Approve" runat="server" CssClass="btn btn-primary approve" OnClick="applicantGrid_Button_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
