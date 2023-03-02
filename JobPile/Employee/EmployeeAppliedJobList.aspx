<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeAppliedJobList.aspx.cs" Inherits="JobPile.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="col-12 text-center p-0 my-2" ID="jobpostList" runat="server" AutoGenerateColumns="False" DataKeyNames="jpID, jpseekers" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="jptitle" HeaderText="Job Title" />
            <asp:BoundField DataField="jptype" HeaderText="Job Type" />
            <asp:BoundField DataField="jpshift" HeaderText="Time" />
            <asp:BoundField DataField="jplocation" HeaderText="Location" />
            <asp:BoundField DataField="jpsalary" HeaderText="Salary" />
            <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString="~/EmployeePost/{0}" DataNavigateUrlFields="jpID"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Unapply" CssClass="btn apply btn-primary" runat="server" OnClick="jobpostList_Button_Click" />
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
    <asp:Button Text="Back" CssClass="btn apply btn-primary" runat="server" OnClick="back_Click" />
</asp:Content>
