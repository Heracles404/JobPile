<%@ Page Title="" Language="C#" MasterPageFile="~/admin-dom/admin.Master" AutoEventWireup="true" CodeBehind="adminlist.aspx.cs" Inherits="JobPile.admin_dom.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="adminGrid" runat="server" AutoGenerateColumns="False" DataKeynames="ID" CssClass="col-12 text-center rounded-5 mt-4" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Admin ID" />
            <asp:BoundField DataField="username" HeaderText="Admin Username" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="admindelete" runat="server" CssClass="btn btn-primary approve" Text="Delete" OnClick="admindelete_Click" />
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
</asp:Content>
