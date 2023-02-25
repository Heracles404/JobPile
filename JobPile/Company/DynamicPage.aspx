<%@ Page Title="" Language="C#" MasterPageFile="~/company.Master" AutoEventWireup="true" CodeBehind="DynamicPage.aspx.cs" Inherits="JobPile.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--Shows information based on passed jobTitle from hyperlink-->
    <h3><asp:Label ID="jobTitlelbl" runat="server" /></h3>
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
    <asp:Label ID="datelbl" text="Set Date of Interview:" runat="server"/><asp:TextBox ID="datetxt" textmode="Date" runat="server"></asp:TextBox>
    <!--<asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="datetxt" 
    ErrorMessage="Please enter a valid date.">
</asp:CompareValidator>-->
    <!--Shows candidates based on jobTitle-->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="JobTitle, ID">
        <Columns>
            <asp:BoundField DataField="Candidate" HeaderText="Candidate"/>
            <asp:BoundField DataField="ID" HeaderText="Employee ID"/>
            <asp:HyperLinkField Text="Employee Info" DataNavigateUrlFormatString = "~JobPosts/{jptitle}/{ID}" DataNavigateUrlFields = "ID,JobTitle" /> 
             <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="approvebtn" runat="server" Text="Approve"  onclick="approve_Click" />
                  </ItemTemplate>
              </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Back" PostBackUrl="~/JobPosts"/>
</asp:Content>
