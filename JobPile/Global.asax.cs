using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace JobPile
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("JobPost", "JobPosts", "~/Company/company_index.aspx");
            routes.MapPageRoute("CreatePost", "CreatePost", "~/Company/CreateJobPost.aspx");
            routes.MapPageRoute("EditPost", "EditPosts", "~/Company/EditPost.aspx");
            routes.MapPageRoute("CompanyInfo", "CompanyInfo", "~/Company/CompanyInfoPage.aspx");
            routes.MapPageRoute("EditInfoPage", "EditCompanyInfo", "~/Company/EditCompanyInfoPage.aspx");
            routes.MapPageRoute("DynamicPage", "JobPosts/{jpID}", "~/Company/DynamicPage.aspx");
            routes.MapPageRoute("CandidatePage", "Candidates/{ID}", "~/Company/DynamicCandidatePage.aspx");

            routes.MapPageRoute("EmpJobList", "EmployeeJobLists", "~/Employee/EmployeeJob.aspx");
            routes.MapPageRoute("EmpAccount", "EmployeeAccounts", "~/Employee/EmployeeAccount.aspx");
            routes.MapPageRoute("EmpDynamicPage", "EmployeePost/{jpID}", "~/Employee/EmpDynamic.aspx");
            routes.MapPageRoute("EditAccount", "EditEmployeeAccount", "~/Employee/EditEmpAccount.aspx");


            routes.MapPageRoute("MainPage", "Main", "~/index.aspx");
        }
    }
}