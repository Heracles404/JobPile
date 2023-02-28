<%@ Page Title="" Language="C#" MasterPageFile="~/admin-dom/admin.Master" AutoEventWireup="true" CodeBehind="companylist.aspx.cs" Inherits="JobPile.admin_dom.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .del {
            width: 10vw;
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row p-0 m-0">
        <div class="col-9 mx-auto p-4">
            <asp:GridView ID="compGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="col-12 text-center rounded-5 mt-4" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Company ID" />
                    <asp:BoundField DataField="companyName" HeaderText="Company Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="website" HeaderText="Website" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="compdelete" runat="server" CssClass="btn btn-primary del" Text="Delete" OnClick="compdelete_Click" />
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
