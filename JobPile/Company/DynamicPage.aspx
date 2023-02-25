<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="DynamicPage.aspx.cs" Inherits="JobPile.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row m-5">
        <div class="col-4 my-5">
            <!--Shows information based on passed jobTitle from hyperlink-->
            <h3 class="overflow-hidden">
                <asp:Label ID="jobTitlelbl" runat="server" CssClass="no-flow"/>
            </h3>
            Salary:
            <asp:Label ID="salarylbl" runat="server" />
            <br />

            Shift:
            <asp:Label ID="shiftlbl" runat="server" />
            <br />

            Type:
            <asp:Label ID="typelbl" runat="server" />
            <br />

            Location:
            <asp:Label ID="locationlbl" runat="server" />
            <br />

            Skills:
            <asp:Label ID="skillslbl" runat="server" />
            <br />

            Experience:
            <asp:Label ID="experiencelbl" runat="server" />
            <br />

            Job Description:
            <asp:Label ID="jobDesclbl" runat="server" />
            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="btn btn-primary mx-0" PostBackUrl="~/JobPosts" />

        </div>

        <div class="col-8 mx-0 px-0">
            <asp:Label ID="datelbl" Text="Set Date of Interview:" runat="server" /><asp:TextBox ID="datetxt" TextMode="Date" runat="server" CssClass="mx-2 py-1 px-3 rounded-1"></asp:TextBox>
            <!--Shows candidates based on jobTitle-->
            <asp:GridView ID="GridView1" CssClass="text-center col-12 p-3 my-3"  runat="server" AutoGenerateColumns="False" DataKeyNames="JobTitle,ID" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Candidate" HeaderText="Candidate" />
                    <asp:BoundField DataField="ID" HeaderText="Employee ID" />
                    <asp:HyperLinkField Text="Employee Info" DataNavigateUrlFormatString="~/Candidates/{0}" DataNavigateUrlFields="ID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="approvebtn" runat="server" CssClass="btn btn-primary approve" Text="Approve" OnClick="approve_Click" />
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
