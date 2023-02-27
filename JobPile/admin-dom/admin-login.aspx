<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin-login.aspx.cs" Inherits="JobPile.admin_dom.admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - JobPile</title>
    <link href="../assets/style/index.css" rel="stylesheet" />
    <link href="../assets/style/master.css" rel="stylesheet" />
    <!-- Tab Icon -->
    <link rel="icon" href="../assets/logo/big-jp.png" />

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Log in Modal -->
            <div class="row my-5 py-5 px-4">
                <div class="col-4 my-4 mx-auto center">
                    <div class="row">
                        <img src="../assets/logo/big-jp.png" class="jp-logo mx-auto col-6" />
                    </div>
                    <div class="input-group p-3">
                        <asp:Label ID="Label1" CssClass="input-group-text d-flex px-4" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="email" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                    </div>
                    <div class="input-group p-3 pt-0">
                        <asp:Label ID="Label2" CssClass="input-group-text px-4 d-flex" runat="server" Text="Password: "></asp:Label>
                        <asp:TextBox ID="pw" type="password" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                    </div>
                    <div class="input-group px-3 pt-0 py-0 my-0">
                        <asp:Label ID="errLbl" CssClass="input-group-text px-3 py-2 m-0 d-flex alert alert-danger" runat="server" Text="Invalid email or password." Visible="False"></asp:Label>
                    </div>
                    <div class="mt-3">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary mx-3" Text="Log In" OnClick="login"/>
                    </div>
                </div>
            </div>

        </div>
        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
    </form>
</body>
</html>
