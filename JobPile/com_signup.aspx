<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="com_signup.aspx.cs" Inherits="JobPile.com_signup" %>

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
        <div class="row py-3 px-3">
            <div class="container-fluid col-6">
                <div class="input-group">
                    <img src="assets/logo/big-jobpile.png" class="logo" />
                </div>
            </div>
            <div class="content container-fluid col-5">
                <div class="personal-info p-4">
                    <div class="input-group">
                        <span class="input-group-text">Company</span>
                        <asp:TextBox ID="company" runat="server" CssClass="form-control" Required="True"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Email</span>
                        <asp:TextBox ID="email" ReadOnly="true" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Contact #</span>
                        <asp:TextBox ID="contact" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Password</span>
                        <asp:TextBox ID="pass" runat="server" CssClass="form-control" Required="True" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Re-password</span>
                        <asp:TextBox ID="repass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="input-group big">
                        <span class="input-group-text">About</span>
                        <asp:TextBox ID="about" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="input-group big">
                        <span class="input-group-text">Mission</span>
                        <asp:TextBox ID="missiontxt" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="input-group big">
                        <span class="input-group-text">Vision</span>
                        <asp:TextBox ID="visiontxt" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Official Website</span>
                        <asp:TextBox ID="website" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
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
