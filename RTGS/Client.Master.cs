using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RTGS
{
    public partial class Client : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["ChangePwdNow"].Value.ToUpper() == "TRUE")
            {
                Response.Redirect("../ChangePassword.aspx");
            }
        }
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

            BindData();
        }
        private void BindData()
        {
            MessageDB db = new MessageDB();
            DataTable dt = db.GetBranchMessages(Request.Cookies["RoutingNo"].Value);
            NotificationList.DataSource = dt;
            NotificationList.DataBind();

            MsgCount.Text = dt.Rows.Count.ToString();
            dt.Dispose();
            NotificationList.Dispose();
        }
    }
}