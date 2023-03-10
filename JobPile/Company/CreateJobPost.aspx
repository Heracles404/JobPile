<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="CreateJobPost.aspx.cs" Inherits="JobPile.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/style/com-master.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row mt-4">
    <div class="row">
        <div class="content container-fluid col-5">
            <div class="px-4 py-0 m-0">
                <div class="input-group">
                    <!--Job Title Textbox-->
                    <span class="input-group-text">Job Title</span>
                    <asp:TextBox ID="jobtitleTXT" CssClass="form-control" runat="server" Required="true"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Salary Textbox-->
                    <span class="input-group-text">Salary</span>
                    <asp:TextBox ID="salaryTXT" CssClass="form-control" runat="server" required="true" TextMode="number"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Shift DropDown-->
                    <span class="input-group-text">Shift</span>
                    <asp:DropDownList ID="DDLShift" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Day Shift" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Night Shift" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group">
                    <!-- Job Type -->
                    <span class="input-group-text">Job Type</span>
                    <asp:DropDownList ID="DDLType" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select Requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Full Time" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part Time" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group">
                    <!--Location Textbox-->
                    <span class="input-group-text">Location</span>
                    <asp:TextBox ID="locationTXT" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                </div>

                <div class="input-group">
                    <!--Skills Textbox-->
                    <span class="input-group-text">Skills</span>
                    <asp:TextBox ID="skillsTXT" runat="server" CssClass="form-control" required="true" AutoPostBack="true"></asp:TextBox>
                </div>

                <div class="input-group">
                    <span class="input-group-text">Experience</span>
                    <!--Experience DropDown-->
                    <asp:DropDownList ID="DDLExperience" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Select requirement" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="No Experience" Value="1"></asp:ListItem>
                        <asp:ListItem Text="1-2 Years Experience" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3-5 Years Experience" Value="3"></asp:ListItem>
                        <asp:ListItem Text="5+ Years Experience" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="input-group big">
                    <span class="input-group-text">Job Description</span>

                    <!--Job Description Textbox-->
                    <asp:TextBox ID="jobdescTXT" runat="server" required="true" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="input-group">
                    <span class="input-group-text">Status</span>
                    <!--Status DropDown-->
                    <asp:DropDownList ID="DDLStatus" CssClass="form-control" runat="server">
                        <asp:ListItem Enabled="true" Text="Active" Value="1"></asp:ListItem>
                        

                    </asp:DropDownList>
                </div>
                <div class="input-group">
                    <!--Post Button-->
                    <asp:Button ID="Postbtn" runat="server" Text="Post Job" OnClick="Postbtn_Click" CssClass="btn btn-primary form-control" />
                    <asp:HyperLink ID="Back" runat="server" NavigateUrl="~/JobPosts" Text="Back" CssClass="btn btn-secondary form-control"></asp:HyperLink>
                </div>
                <div class="m-0 p-0">
                    <!-- Validators -->
                    <table>
                        <tr>
                            <td>
                                <asp:CompareValidator ControlToValidate="DDLShift" ID="compareshift" CssClass="text-danger" ErrorMessage="Please select a shift!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:CompareValidator ControlToValidate="DDLType" ID="comparetype" CssClass="text-danger" ErrorMessage="Please select a type!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CompareValidator ControlToValidate="DDLExperience" CssClass="text-danger" ID="compareexperience" ErrorMessage="Please select an experience range!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CompareValidator ControlToValidate="DDLStatus" CssClass="text-danger" ID="comparestatus" ErrorMessage="Please select a status!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="input-group">
                    <!-- Validators -->
                    <asp:RequiredFieldValidator ID="rqJobTitle" runat="server" ErrorMessage="*" ControlToValidate="jobtitleTXT"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="regexsalary" runat="server" ErrorMessage="Numbers only and must have more than 3 digits!" ControlToValidate="salaryTXT" ValidationExpression="^[0-9]{3,10}$">
                    </asp:RegularExpressionValidator>
                    <br />
                    <asp:CompareValidator ControlToValidate="DDLShift" ID="CompareValidator1" ErrorMessage="Please select a shift!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                    <br />
                    <asp:CompareValidator ControlToValidate="DDLType" ID="CompareValidator2" ErrorMessage="Please select a type!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                    <br />
                    <asp:RequiredFieldValidator ID="reqlocation" runat="server" ErrorMessage="*" ControlToValidate="locationTXT"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="reqskills" runat="server" ErrorMessage="*" ControlToValidate="skillsTXT"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ControlToValidate="DDLExperience" ID="CompareValidator3" ErrorMessage="Please select an experience range!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                    <br />
                    <asp:RequiredFieldValidator ID="reqjobdesc" runat="server" ErrorMessage="*" ControlToValidate="jobdescTXT"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ControlToValidate="DDLStatus" ID="CompareValidator4" ErrorMessage="Please select a status!" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="-1" Type="Integer" />
                    <br />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
