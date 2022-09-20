using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace RTGS
{
    public partial class SelectUserRole : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
            {
                Response.Redirect("ChangePassword.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetNoStore();

            if(Context.User.Identity.Name == "")
            {
                Response.Redirect("Login.aspx");
            }
            if(!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindUserRole();
            }
        }

        private void BindUserRole()
        {
            RoleDB Role = new RoleDB();

            ddluserrole.DataSource = Role.GetUserRoles(Int32.Parse(Context.User.Identity.Name));
            ddluserrole.DataBind();
        }

     
        protected void Login_Click(object sender, EventArgs e)
        {
            string SelectedRole = ddluserrole.SelectedItem.Value;
            string[] a = SelectedRole.Split(',');
            string RoleID = a[0];
            string RoleCD = a[1];
            string TransLimit = a[2];

            Response.Cookies["RoleID"].Value = RoleID;
            Response.Cookies["RoleCD"].Value = RoleCD;
            Response.Cookies["TransLimit"].Value = TransLimit;

            Response.Cookies["RoleName"].Value = ddluserrole.SelectedItem.Text;

            if (RoleCD == "RTMK")
            {
                Response.Redirect("BranchMessages.aspx");
            }
            if (RoleCD == "RTCK")
            {
                Response.Redirect("BranchMessages.aspx");
            }
            if (RoleCD == "RTAD")
            {
                Response.Redirect("Default.aspx");
            }
            if (RoleCD == "RTFM")
            {
                Response.Redirect("Default.aspx");
            }
            if (RoleCD == "RTRV")
            {
                Response.Redirect("ReportViewerMenu.aspx");
            }
            if (RoleCD == "RTAU")
            {
                Response.Redirect("BranchMessages.aspx");
            }

            if (RoleCD == "RTAC") 
            {
                Response.Redirect("BranchMessages.aspx");
            }

            if (RoleCD == "RTAM")
            {
                Response.Redirect("BranchMessages.aspx");
            }

        }
    }
}
