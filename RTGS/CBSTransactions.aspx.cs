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
using RTGS.DAC;

namespace RTGS
{
    public partial class CBSTransactions : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string RoleCD = Request.Cookies["RoleCD"].Value;
            if (RoleCD != "RTAD")
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.Text = "";
            if (!Page.IsPostBack)
            {
                BindBranch();
            }
        }
        private void BindBranch()
        {
            BranchesDB db = new BranchesDB();
            BranchList.DataSource = db.GetSendBranches();
            BranchList.DataBind();
            BranchList.Items.Add(new ListItem("All", "0"));
            BranchList.SelectedValue = "0";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            CBSTransactionDB db = new CBSTransactionDB();
            MyDataGrid.DataSource = db.GetCBSTransaction(ddlClearingType.SelectedValue, BranchList.SelectedValue, FormList.SelectedValue);
            MyDataGrid.DataBind();
        }

        protected void ReverseBtn_Click(object sender, EventArgs e)
        {
            RTGSWS.Service1 ws = new RTGSWS.Service1();
            string UserName = Request.Cookies["UserName"].Value;
            string IPAddress = HttpContext.Current.Request.UserHostAddress;
            for (int i = 0; i < MyDataGrid.Rows.Count; i++)
            {
                if (((CheckBox)(MyDataGrid.Rows[i].FindControl("chkActive"))).Checked)
                {
                    string TransID = MyDataGrid.DataKeys[i].Value.ToString();
                    //ws.ReverseTransaction(TransID, UserName, IPAddress);
                    //Msg.Text = Msg.Text + " - " + FormID.ToString();
                }
            }
            BindData();
        }
    }

}