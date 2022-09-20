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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;

using FloraSoft;

namespace RTGS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!Global.cancontinue)
                {
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {
                HttpContext.Current.Response.End();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Buffer = true;
                //Response.CacheControl = "no-cache";
                //Response.AddHeader("Pragma", "no-cache");
                //Response.Expires = -1441;

                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();

                SignOut();
            }
        }

        public bool IsAuthenticated(string srvr, string usr, string pwd)
        {
            bool authenticated = false;
            try
            {
                using (PrincipalContext Context = new PrincipalContext(ContextType.Domain, srvr))
                {
                    if (Context == null)
                    {
                        authenticated = false;
                        MyMessage.Text = "Login failed: Please try again (hsbcAD)";
                    }
                    else
                    {
                        authenticated = Context.ValidateCredentials(usr, pwd);
                        //authenticated = true;
                    }
                    MyMessage.Text = "";
                }
            }
            catch (DirectoryServicesCOMException cex)
            {
                MyMessage.Text = "Error: " + cex.Message;
            }
            catch (Exception ex)
            {
                MyMessage.Text = "Error: " + ex.Message;
            }
            return authenticated;
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            string UserID     = "0";

            UserDB db       = new UserDB();
            UserInfo uinfo  = new UserInfo();

            //Checking if Bank is using AD Login or not.

            string ADLogin = ConfigurationManager.AppSettings["ADLogin"].ToUpper();
            if (ADLogin != "TRUE")
            {
                uinfo = db.Login(UserName.Text, Pass.Text);
                UserID = uinfo.UserID;
            }
            else
            {
                if (IsAuthenticated(ConfigurationManager.AppSettings["ADServer"], UserName.Text, Pass.Text))
                {
                    uinfo = db.ADLogin(UserName.Text);
                    UserID = uinfo.UserID;
                }
            }
            // if login failed.
            if (UserID == "0")
            {
                string LoginTries = Tried.Value;
                if (LoginTries == "")
                {
                    LoginTries = "0";
                }
                int NewVal = Int32.Parse(LoginTries) + 1;
                Tried.Value = NewVal.ToString();
                if (NewVal > 2)
                {
                    db.LockUser(UserName.Text.Trim());
                    MyMessage.Text = UserName.Text + " account has been locked.";
                }
                else
                {
                    MyMessage.Text = uinfo.ExpMsg;
                }
            }
            else
            {
                // when login is successfull.
                FormsAuthentication.SetAuthCookie(UserID, false);

                Response.Cookies["RoleID"].Value = "";
                Response.Cookies["RoleName"].Value = "";

                Response.Cookies["RoleCount"].Value = uinfo.RoleID;
                Response.Cookies["UserName"].Value      = uinfo.UserName;
                Response.Cookies["DeptID"].Value        = uinfo.DeptID;
                Response.Cookies["RoutingNo"].Value     = uinfo.RoutingNo;
                Response.Cookies["BranchCD"].Value      = uinfo.BranchCD;
                Response.Cookies["AllBranch"].Value     = uinfo.AllBranch.ToString();  //False
                Response.Cookies["DeptName"].Value      = uinfo.DeptName;
                Response.Cookies["BranchName"].Value    = uinfo.BranchName;
                Response.Cookies["BankName"].Value      = uinfo.BankName;
                Response.Cookies["DaysRemaining"].Value = uinfo.DaysRemaining.ToString();
                Response.Cookies["ChangePwdNow"].Value  = uinfo.ChangePwdNow.ToString();
                Response.Cookies["ExpMsg"].Value        = uinfo.ExpMsg;
                Response.Cookies["PrevPageURL"].Value   = HttpContext.Current.Request.Url.AbsolutePath;

                BankSettingsDB bs = new BankSettingsDB();
                BankSettings settings = bs.GetBankSettings();
                Response.Cookies["DeptBanking"].Value       = settings.DeptBanking.ToString();
                Response.Cookies["AuthorizerEnabled"].Value = settings.AuthorizerEnabled.ToString();

                if (uinfo.ChangePwdNow.ToString() == "TRUE")
                {
                    Response.Redirect("ChangePassword.aspx");
                }

                if (uinfo.RoleCount != "1")
                {
                    Response.Redirect("SelectRole.aspx");
                }
                else
                {
                    Response.Cookies["RoleID"].Value    = uinfo.RoleID;
                    Response.Cookies["RoleCD"].Value    = uinfo.RoleCD;
                    Response.Cookies["RoleName"].Value  = uinfo.RoleName;
                    Response.Cookies["TransLimit"].Value= uinfo.TransLimit.ToString();
                }

                if (uinfo.RoleCD == "RTRV")
                {
                    Response.Redirect("ReportViewerMenu.aspx");
                }

                if ((uinfo.RoleCD == "RTMK") || (uinfo.RoleCD == "RTCK") || (uinfo.RoleCD == "RTAU"))
                {
                    Response.Redirect("BranchMessages.aspx");
                }

                if ((uinfo.RoleCD == "RTAD") || (uinfo.RoleCD == "RTFM"))
                {
                    Response.Redirect("Default.aspx");
                }
                uinfo = null;
            }
        }

        private void SignOut()
        {
            try
            {
                UserDB db = new UserDB();
                int UserID = Int32.Parse(Context.User.Identity.Name);
                db.LogOut(UserID);
            }
            catch { }

            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            MyMessage.Text = System.DateTime.Now.ToLongTimeString();
        }
    }
}

