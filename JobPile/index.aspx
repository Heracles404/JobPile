<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="JobPile.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JobPile</title>
    <!-- Tab Icon -->
    <link rel="icon" href="assets/logo/big-jp.png" />

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <!-- Custom CSS -->
    <link href="assets/style/index.css" rel="stylesheet" />
    <link href="assets/style/master.css" rel="stylesheet" />

    <style>
        .button {
            background-color: #f8f9fa;
            color: #141414;
            font-size: 1.25rem;
            width: 5vw;
            margin: 0 1rem;
            padding: .5rem 0;
            border: none;
            transition: ease-in-out .5s;
        }

        .button:hover {
            background-color: #3884c2;
            color: #f8f9fa;
            margin: 0;
            width: 8.25vw;
            padding: .5rem 1rem;
            border-radius: 2px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="container">
            <div id="main">
                <!-- NavBar -->
                <nav class="navbar navbar-expand-lg bg-body-tertiary p-0 m-0">
                    <div class="container-fluid nav">

                        <!-- Logo -->
                        <a class="navbar-brand m-0 p-0" href="#">
                            <span class="col-12">
                                <img src="assets/logo/small-jobpile.png" class="nav-icon" />
                            </span>
                        </a>

                        <!-- Log-in/signup -->
                        <div class="d-flex" role="search">
                            <button type="button" class="button" data-bs-toggle="modal" data-bs-target="#login-form">
                                Log in
                            </button>
                            <button type="button" class="button" data-bs-toggle="modal" data-bs-target="#signupForm">Sign up</button>
                        </div>
                    </div>
                </nav>

                <!-- Log in Modal -->
                <div class="modal fade container-fluid" id="login-form" tabindex="-1" aria-labelledby="log-in modal" aria-hidden="true" role="dialog">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5">
                                    <img src="assets/logo/small-jp.png" class="img-icon" />Log In
                                </h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body row px-4">
                                <img src="assets/logo/big-jp.png" class="jp-logo" />
                                <div class="input-group p-3">
                                    <asp:Label ID="Label1" CssClass="input-group-text d-flex" runat="server" Text="Email or Username: "></asp:Label>
                                    <asp:TextBox ID="email" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                                </div>
                                <div class="input-group p-3 pt-0">
                                    <asp:Label ID="Label2" CssClass="input-group-text px-5 d-flex" runat="server" Text="Password: "></asp:Label>
                                    <asp:TextBox ID="pw" type="password" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                                </div>
                                <div class="form-check mx-0 my-0 py-0 ">
                                    <asp:CheckBox ID="isSeeker" CssClass="" runat="server" />
                                    <label class="form-check-label" for="isSeeker">
                                        I am a job seeker
                                    </label>
                                </div>
                                <div class="input-group px-3 pt-0 py-0 my-0">
                                    <asp:Label ID="errLbl" CssClass="input-group-text px-3 py-2 m-0 d-flex alert alert-danger" runat="server" Text="Invalid email or password." Visible="False"></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary mx-3" Text="Log In" OnClick="login" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Sign up Modal -->
                <div class="modal fade container-fluid" id="signupForm" tabindex="-1" aria-labelledby="log-in modal" aria-hidden="true" role="dialog">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5">
                                    <img src="assets/logo/small-jp.png" class="img-icon" />Sign Up
                                </h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body row px-4">
                                <img src="assets/logo/big-jobpile.png" class="jobpile-logo" />
                                <div class="input-group p-3">
                                    <asp:Label ID="Label3" CssClass="input-group-text verify" runat="server" Text="E-mail: "></asp:Label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="d-flex flex-fill p-2 right-input" AutoPostBack="True" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3 px-3">
                                    <asp:Button ID="verify" CssClass="input-group-text verify" autopostback="false" runat="server" Text="Send OTP" OnClick="OTP"></asp:Button>
                                    <asp:TextBox ID="txtOTP" runat="server" CssClass="d-flex flex-fill p-2 right-input"></asp:TextBox>
                                </div>
                                <div class="input-group px-3 pt-0 py-0 my-0">
                                    <asp:Label ID="sent" CssClass="input-group-text py-2 m-0 d-flex alert alert-success" runat="server" Text="Check your email, including your spam." Visible="false"></asp:Label>
                                    <asp:Label ID="errOTP" CssClass="input-group-text py-2 m-0 d-flex alert alert-danger" runat="server" Text="Invalid OTP." Visible="false"></asp:Label>

                                </div>
                            </div>
                            <div class="input-group px-3 pt-0 py-0 my-0">
                            </div>
                            <div class="modal-footer">
                                <div class="form-check mx-0 my-0 py-0 ">
                                    <asp:CheckBox ID="empChk" CssClass="" runat="server" />
                                    <label class="form-check-label" for="isSeeker">
                                        I am a job seeker
                                    </label>
                                </div>
                                <asp:Button ID="btnSignup" runat="server" CssClass="btn btn-primary mx-3 verify" Text="Verify Email" OnClick="ver" />
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                <br />
                <br />
                <br />
                <br />


                <div class="content">
                    <img src="assets/logo/big-jobpile.png" class="img-logo" />

                    <!-- Search Bar -->
                    <div class="input-group search-bar container-fluid row ">
                        <asp:DropDownList ID="type" CssClass="btn btn-outline-primary text-light col-sm-8" runat="server">
                            <asp:ListItem Value="1">Jobs</asp:ListItem>
                            <asp:ListItem Value="2">People</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtSearch" type="text" class="form-control col-sm-11" />
                        <Button ID="search" type="button" class="btn btn-outline-primary text-white col-sm-8" data-bs-toggle="modal" data-bs-target="#login-form">Search</Button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Footer -->


        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
    </form>

</body>
</html>
