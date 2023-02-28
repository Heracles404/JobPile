<%@ Page Title="" Language="C#" MasterPageFile="~/admin-dom/admin.Master" AutoEventWireup="true" CodeBehind="adminlist.aspx.cs" Inherits="JobPile.admin_dom.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .del {
            width: 10vw;
            margin: 0;
        }

        .create {
            width: 12vw;
        }

        .err {
            width: 13.5vw;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row p-0 my-1 mx-auto">
        <div class="col-3 mx-0 grid mt-5">
            <button type="button" class="btn btn-primary create" data-bs-toggle="modal" data-bs-target="#create-admin">
                New Admin
            </button>
        </div>
        <div class="col-8 mx-5">
            <asp:GridView ID="adminGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CssClass="col-12 text-center rounded-5 mt-4" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Admin ID" />
                    <asp:BoundField DataField="username" HeaderText="Admin Username" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="admindelete" runat="server" CssClass="btn btn-primary del p-0 m-0" Text="Delete" OnClick="admindelete_Click" />
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

    <!-- New Admin Modal -->
    <div class="modal fade container-fluid" id="create-admin" tabindex="-1" aria-labelledby="create-admin modal" aria-hidden="true" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content mx-auto">
                <div class="modal-header">
                    <h1 class="modal-title fs-5">
                        <img src="assets/logo/small-jp.png" class="img-icon" /> Create New Admin
                    </h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body row px-4">
                    <img src="assets/logo/big-jp.png" class="jp-logo" />
                    <div class="input-group px-3 pb-2 pt-4">
                        <asp:Label ID="Label1" CssClass="input-group-text" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="username" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                    </div>
                    <div class="input-group px-3 py-2 pt-0">
                        <asp:Label ID="Label2" CssClass="input-group-text" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="pw" type="password" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                    </div>
                    <div class="input-group px-3 py-2 pt-0">
                        <asp:Label ID="Label3" CssClass="input-group-text" runat="server" Text="Re-Password"></asp:Label>
                        <asp:TextBox ID="repw" type="password" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                    </div>
                    <div class="input-group px-3 pt-0 py-0 my-0">
                        <asp:Label ID="errLbl" CssClass="px-3 py-2 m-0 d-flex alert alert-danger err" runat="server" Text="Passwords do not match" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-primary mx-3 create" Text="Create Admin" OnClick="newAdmin_Click"/>
                </div>
            </div>
        </div>
    </div>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
</asp:Content>
