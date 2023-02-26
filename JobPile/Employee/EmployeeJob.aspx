<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="EmployeeJob.aspx.cs" Inherits="JobPile.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<<<<<<< HEAD
    <style>
        .btn.apply {
            width: 10rem;
        }

        td{
            padding: 0;
            margin: 0;  
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--Job Title Search-->
    <div class="row">
        <div class="personal-info py-4">
            <div class="col-7 mx-auto">
                <div class="input-group">
                    <span class="input-group-text px-4">Job Title / Position</span>
                    <asp:TextBox ID="empsearchtxt" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button CssClass="btn btn-primary rounded-1" ID="empsearchbtn" runat="server" Text="Search" OnClick="empsearchbtn_Click" />
                </div>
            </div>
        </div>
    </div>



    <!-- All Job List -->
    <div class="row">
        <div class="mx-auto col-7">
            <h2 class="overflow-hidden">Listings:</h2>
            <asp:GridView CssClass="col-12 text-center p-0 my-2" ID="empGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="jptitle,jpseekers" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="jptitle" HeaderText="Job Title" />
                    <asp:BoundField DataField="jptype" HeaderText="Job Type" />
                    <asp:BoundField DataField="jpshift" HeaderText="Time" />
                    <asp:BoundField DataField="jplocation" HeaderText="Location" />
                    <asp:BoundField DataField="jpsalary" HeaderText="Salary" />
                    <asp:HyperLinkField Text="Job Info" DataNavigateUrlFormatString="~/EmpPost/{0}" DataNavigateUrlFields="jptitle" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Apply" CssClass="btn apply btn-primary" runat="server" OnClick="empGridView_Button_Click" OnClientClick="this.disabled=true;" />
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

=======
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
>>>>>>> defcc4714ee1b51c41a61c765718ca7e0f50bea8
</asp:Content>
