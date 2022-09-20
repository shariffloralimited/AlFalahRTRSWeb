//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Globalization;

//namespace RTGS
//{
//    public partial class DailyOperations : System.Web.UI.Page
//    {
//        protected void Page_Init(object sender, EventArgs e)
//        {
//            if ((Request.Cookies["RoleCD"].Value != "RTAD") && (Request.Cookies["RoleCD"].Value != "RTFM"))
//            {
//                Response.Redirect("AccessDenied.aspx");
//            }
//            if (!Page.IsPostBack)
//            {
//                CCYDB db = new CCYDB();
//                ddlCurrency.DataSource = db.GetCCYList();
//                ddlCurrency.DataBind();
//            }
//        }
//        protected void BtnSave_Click(object sender, EventArgs e)
//        {
//            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
//            try
//            {

//            }
//            catch (Exception ex)
//            {
//                Msg.Text = "Invalid Data: " + ex.Message;
//            }

//        }
//    }
//}


using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace RTGS
{
    public partial class DailyOperations : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((Request.Cookies["RoleCD"].Value != "RTAD") && (Request.Cookies["RoleCD"].Value != "RTFM"))
            {
                Response.Redirect("AccessDenied.aspx");
            }
            if (!Page.IsPostBack)
            {
                CCYDB db = new CCYDB();
                ddlCurrency.DataSource = db.GetCCYList();
                ddlCurrency.DataBind();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            FloraSoft.BankSettingsDB bsdb = new FloraSoft.BankSettingsDB();
            CBSTransactionDB db = new CBSTransactionDB();
            CBSTranData data = new CBSTranData();
            try
            {
                data.SLNo = "RG" + ddlType.SelectedItem.Text.Substring(0, 2) + System.DateTime.Now.ToString("yyMMddHHmmss");
                data.TransType = ddlType.SelectedItem.Text;
                data.AcctId = txtAccountNo.Text;
                data.SttlmAmt = Decimal.Parse(txtAmount.Text);
                data.Ccy = ddlCurrency.SelectedValue;
                data.RoutingNo = Request.Cookies["RoutingNo"].Value;
                data.BranchCD = Request.Cookies["BranchCD"].Value;
                data.EntryDesc = txtEntryDesc.Text;

                db.InsertCBSTransaction(data);
                Msg.Text = "Transaction Submitted.";
                ResetData();
            }
            catch (Exception ex)
            {
                Msg.Text = "Invalid Data: " + ex.Message;
            }
        }

        private void ResetData()
        {
            txtAccountNo.Text = "";
            txtAmount.Text = "";
            txtEntryDesc.Text = "";
        }
    }
}
