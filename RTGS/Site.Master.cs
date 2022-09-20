using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RTGS
{
    public partial class SiteMaster : MasterPage
    {
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    string PrevPage = "";
        //    try
        //    {
        //        PrevPage = Request.Cookies["PrevPageURL"].Value;
        //    }
        //    catch { }
        //    if (PrevPage.IndexOf("RTGS") == -1)
        //    {
        //        Response.Redirect("LogOut.aspx");
        //    }
        //    Response.Cookies["PrevPageURL"].Value = HttpContext.Current.Request.Url.AbsolutePath;

        //    if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
        //    {
        //        Response.Redirect("ChangePassword.aspx");
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();


            string UserName = Request.Cookies["UserName"].Value; 
            if (Request.Cookies["RoleName"] != null)
            {
                UserName = UserName + " (" + Request.Cookies["RoleName"].Value + ")";
            }

            LblUserName.Text = UserName;

            try
            {
                string RoutingNo = Request.Cookies["RoutingNo"].Value;
                BindData(RoutingNo);
            }
            catch
            { }
        }
        private void BindData(string RoutingNo)
        {
            MessageDB db = new MessageDB();
            DataTable dt = db.GetBranchMessages(RoutingNo);
            NotificationList.DataSource = dt;
            NotificationList.DataBind();

            MsgCount.Text = dt.Rows.Count.ToString();
            dt.Dispose();
            NotificationList.Dispose();
        }
    }
}