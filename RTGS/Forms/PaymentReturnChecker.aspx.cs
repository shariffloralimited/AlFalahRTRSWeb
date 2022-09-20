using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class PaymentReturnChecker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {           
                BindData();
            }
        }

        private void BindData()
        {
            string OutwardID = Request.QueryString["OutwardID"];

            //FloraSoft.BankSettings bs = new FloraSoft.BankSettings();
            //FloraSoft.BankSettingsDB dbs = new FloraSoft.BankSettingsDB();
            //bs = dbs.GetBankSettings();

          
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            RTGSImporter.Pacs004 pacs = db.GetSingleOutward04(OutwardID);

            lblSendingBranch.Text       = pacs.ToBranch;
            lblAccountNo.Text           = pacs.CdtrAcctId;
            lblSettlmentAmount.Text     = string.Format("{0:N}", pacs.TxRefIntrBkSttlmAmt);
            lblCCY.Text                 = pacs.TxRefIntrBkSttlmCcy;
            lblReceivingBank.Text       = pacs.ToBank;
            lblReceiverName.Text        = pacs.DbtrNm;
            lblReceiverAccountNo.Text   = pacs.DbtrAcctId;
            lblReturnReason.Text        = pacs.RtrRsnPrtry + ": " + pacs.RtrRsnAddtlInf;

            lblMsg.Text = "<a target=\"_new\" href=\"Inward08Long.aspx?InwardID=" + pacs.InwardID + "\">REVERSAL OF " + pacs.OrgnlMsgId + "</a>";
            
            string RoleCD = Request.Cookies["RoleCD"].Value;
            Decimal TransLimit = Decimal.Parse(Request.Cookies["TransLimit"].Value);

            CCYDB ccdb = new CCYDB();
            string ccy = pacs.RtrdIntrBkSttlmCcy;
            if(ccy == "")
            {
                ccy = pacs.TxRefIntrBkSttlmCcy;
            }
            Decimal Rate = ccdb.GetCCYRate(ccy);

            Decimal ApprovalLimit = TransLimit / Rate;



            //bool OnTime = true;

            ////DateTime dt1 = DateTime.Today.AddHours(bs.MorCutOffHr).AddMinutes(bs.MorCutOffMin);
            //DateTime dt2 = DateTime.Today.AddHours(bs.AftrCutOffHr).AddMinutes(bs.AftrCutOffMin);

            //if (DateTime.Now > dt2)
            //{
            //    OnTime = false;
            //}

            if ((RoleCD == "RTCK") && (pacs.StatusID == 2) )
            {
                ButtonPanel.Visible = true;
            }
            if ((RoleCD == "RTAU") && (pacs.StatusID == 3) )
            {
                ButtonPanel.Visible = true;
            }
            if (ApprovalLimit < pacs.TxRefIntrBkSttlmAmt)
            {
                ButtonPanel.Visible = false;
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string OutwardID = Request.Params["OutwardID"];
            string RoleCD = Request.Cookies["RoleCD"].Value;

            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            if (RoleCD == "RTCK")
            {
                db.ApproveOutward04(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (RoleCD == "RTAU")
            {
                db.AuthOutward04(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            Response.Redirect("../OutwardListChecker.aspx");
        }
        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListChecker.aspx");
        }
        protected void btnRejectTransaction_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            db.RejectOutward04(Request.QueryString["OutwardID"], Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../OutwardListChecker.aspx");
        }
    }
}