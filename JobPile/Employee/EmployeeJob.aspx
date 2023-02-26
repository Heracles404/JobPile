<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeJob.aspx.cs" Inherits="JobPile.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Job Title Search-->
    Search Job Title: <asp:TextBox ID="empsearchtxt" runat="server"></asp:TextBox>
    <asp:Button ID="empsearchbtn" runat="server" Text="Search" OnClick="empsearchbtn_Click" />
    <hr />
    <!--
    <asp:GridView ID="searchGridView" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No Job Found" AutoGenerateColumns="false" DataKeyNames="jptitle">
         <Columns>
             <asp:BoundField DataField="jptitle" HeaderText="Job Title"/>
             <asp:BoundField DataField="jptype" HeaderText="Job Type"/>
             <asp:BoundField DataField="jpshift" HeaderText="Time"/>
             <asp:BoundField DataField="jplocation" HeaderText="Location"/>
             <asp:BoundField DataField="jpsalary" HeaderText="Salary"/>
             <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString = "~/EmployeePost/{0}" DataNavigateUrlFields = "jptitle" /> 
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button Text="Submit Application" runat="server" OnClick="empGridView_Button_Click"/>
                  </ItemTemplate>
              </asp:TemplateField>
             </Columns>
        </asp:GridView>-->

    <!-- All Job List -->
    <h2>Job Lists</h2>
    <asp:GridView ID="empGridView" runat="server" AutoGenerateColumns="false" DataKeyNames="jpID,jpseekers" >
         <Columns>
             <asp:BoundField DataField="jptitle" HeaderText="Job Title"/>
             <asp:BoundField DataField="jptype" HeaderText="Job Type"/>
             <asp:BoundField DataField="jpshift" HeaderText="Time"/>
             <asp:BoundField DataField="jplocation" HeaderText="Location"/>
             <asp:BoundField DataField="jpsalary" HeaderText="Salary"/>
             <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString = "~/EmployeePost/{0}" DataNavigateUrlFields = "jpID" /> 
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button Text="Submit Application" runat="server" OnClick="empGridView_Button_Click"/>
                  </ItemTemplate>
              </asp:TemplateField>
             </Columns>
        </asp:GridView>
</asp:Content>
