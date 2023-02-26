<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emp_signup.aspx.cs" Inherits="JobPile.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up - JobPile</title>
    <!-- Tab Icon -->
    <link rel="icon" href="assets/logo/small-jp.png" />

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <!-- Custom CSS -->
    <link href="assets/style/sign-up.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="row emp py-3 px-3">
            <div class="container-fluid col-5">
                <div class="input-group">
                    <img src="assets/logo/big-jobpile.png" class="logo" />
                </div>
            </div>
            <div class="content container-fluid col-5">
                <div class="personal-info">
                    <div class="input-group">
                        <span class="input-group-text">Username</span>
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Email</span>
                        <asp:TextBox ID="email" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Mobile</span>
                        <asp:TextBox ID="mobile" runat="server" TextMode="Number" CssClass="form-control" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Firstname</span>
                        <asp:TextBox ID="firstname" runat="server" CssClass="form-control" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Lastname</span>
                        <asp:TextBox ID="lastname" runat="server" CssClass="form-control" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Password</span>
                        <asp:TextBox ID="pass" runat="server" CssClass="form-control" TextMode="Password" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Re-password</span>
                        <asp:TextBox ID="repass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Birthday</span>
                        <asp:TextBox ID="birthday" runat="server" CssClass="form-control" TextMode="Date" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Gender</span>
                        <asp:DropDownList ID="genderChoose" CssClass="form-control" runat="server">
                            <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-group big">
                        <span class="input-group-text">Bio (Optional)</span>
                        <asp:TextBox ID="bioTxt" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <asp:Button ID="register" CssClass="btn btn-primary form-control" OnClick="Register" runat="server" Text="Register" />
                        <asp:Button ID="cancel" CssClass="btn btn-secondary form-control" runat="server" Text="Cancel" />
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
