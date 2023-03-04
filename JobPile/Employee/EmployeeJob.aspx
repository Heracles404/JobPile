<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeJob.aspx.cs" Inherits="JobPile.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn.apply {
            width: 11rem;
        }


        td {
            padding: 0;
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Job Title Search-->
    <div class="row">
        <div class="personal-info mt-4">
            <div class="col-5 mx-auto">
                <div class="input-group container-fluid">
                    <span class="input-group-text">Job Title / Position</span>
                    <asp:TextBox ID="empsearchtxt" runat="server" CssClass="form-control search-bar"></asp:TextBox>
                    <asp:Button runat="server" ID="Button1" type="button" class="btn btn-outline-primary text-white search" OnClick="empsearchbtn_Click" Text="Search" />
                </div>
            </div>
        </div>
    </div>

    <asp:CheckBoxList ID="ChkByList" CssClass="mx-5 my-0" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Check_Clicked"></asp:CheckBoxList>

    <!-- All Job List -->
    <div class="row">
        <div class="mx-auto col-6">
            <div class="row mx-auto mt-0">
                <div class="col-6 float-start">
                    <h2 class="overflow-hidden">Listings:</h2>
                </div>
                <div class="col-6 float-end">
                    <asp:Button ID="appliedbtn" Text="Current Applications" CssClass="btn apply btn-primary float-end text-center" runat="server" OnClick="appliedbtn_Click" />
                    <asp:Button ID="historybtn" Text="Applied History" CssClass="btn apply btn-primary float-end" runat="server" OnClick="historybtn_Click" />

                </div>
            </div>


            <asp:GridView CssClass="col-12 text-center p-0 my-2" ID="empGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="jpID,jpseekers,com_id,jptitle" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="jptitle" HeaderText="Job Title" />
                    <asp:BoundField DataField="jptype" HeaderText="Job Type" />
                    <asp:BoundField DataField="jpshift" HeaderText="Time" />
                    <asp:BoundField DataField="jplocation" HeaderText="Location" />
                    <asp:BoundField DataField="jpsalary" HeaderText="Salary" />
                    <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString="~/EmployeePost/{0}" DataNavigateUrlFields="jpID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Apply" CssClass="btn apply btn-primary border-0" runat="server" OnClick="empGridView_Button_Click" />
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
