using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09ShortMaker : System.Web.UI.Page
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
            if (Request.Cookies["RoleCD"].Value != "RTMK") 
            {
                Response.Redirect("../AccessDenied.aspx");
            }
            if (!IsPostBack)
            {
                Banks();
                BindBranches(ddListReceivingBank.SelectedValue);
            }
            lblMsg.Text = "";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindAcctNos();
            string InwardID = Request.Params["InwardID"];
            if ((InwardID != null) && (InwardID != ""))
            {
                LoadData(InwardID);
            }
        }
        private void LoadData(string InwardID)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.Pacs009 pacs = db.GetSingleInward09(InwardID);

            ddlCurrency.SelectedValue = pacs.IntrBkSttlmCcy;
            txtAccountNo.Text = pacs.CdtrAcctId;

            txtSettlmentAmount.Text = pacs.IntrBkSttlmAmt.ToString();
            ddListReceivingBank.SelectedValue = pacs.FrBankBIC;
            BindBranches(ddListReceivingBank.SelectedValue);

            ddListBranch.SelectedValue = pacs.FrBranchID;

            txtReceiverAccountNo.Text = pacs.DbtrAcctId;
            txtReasonForPayment.Text = pacs.InstrInf;

            ddlCurrency.Enabled = false;
            txtSettlmentAmount.Enabled = false;
            ddListReceivingBank.Enabled = false;

            ddListBranch.Enabled = false;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;

            string InwardID ="";
            if ((Request.Params["InwardID"] != null) && (Request.Params["InwardID"] != ""))
            {
                InwardID = Request.Params["InwardID"];
            }
            if (!ValidateForm())
                return;
            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db0.GetBankSettings();

            RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();

            string Credt = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            decimal sttlmmtAmt = Decimal.Parse(txtSettlmentAmount.Text); 
            
            CCYDB dbccy = new CCYDB();
            decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.009");

            if (sttlmmtAmt < minlimit)
            {
                lblMsg.Text = "Sending amount is less then Minimum Limit";
                return;
            }

            //pacs.PacsID = ;
            //pacs.SLNo = ;
            //pacs.DetectTime = ;
            pacs.FrBICFI = bs.BIC;
            pacs.ToBICFI = "BBHOBDDHRTG";

            //pacs.BizMsgIdr = ;
            pacs.MsgDefIdr = "pacs.009.001.04";
            if (InwardID != "")
            {
                pacs.BizSvc = "RTGS_RETN";
            }
            else
            {
                pacs.BizSvc = "RTGS_FICT";
            }
            pacs.CreDt = Credt + "Z";
            //pacs.MsgId = ;
            pacs.CreDtTm = Credt;
            pacs.BtchBookg = "false";
            pacs.NbOfTxs = 1;
            pacs.TtlIntrBkSttlmAmt = sttlmmtAmt;

            pacs.InstgAgtBICFI = bs.BIC;
            pacs.InstgAgtNm = bs.BankName;
            pacs.InstgAgtBranchId = Request.Cookies["RoutingNo"].Value;

            pacs.InstdAgtBICFI = ddListReceivingBank.SelectedValue;
            pacs.InstdAgtNm = ddListReceivingBank.SelectedValue;
            //pacs.InstdAgtBranchId = ;

            //pacs.IntrmyAgt1BICFI = ;
            //pacs.IntrmyAgt1Nm = ;
            //pacs.IntrmyAgt1BranchId = ;
            //pacs.IntrmyAgt1AcctId = ;
            //pacs.IntrmyAgt1AcctTp = ;

            pacs.LclInstrmPrtry = "RTGS_FICT";
            pacs.SvcLvlPrtry = "75";
            pacs.CtgyPurpPrtry = "001";
            //pacs.InstrId = "MT103/006";
            //pacs.TxId = "202-002-SHS";
            //pacs.EndToEndId = "MT103/001";
            pacs.IntrBkSttlmCcy = ddlCurrency.SelectedValue;
            pacs.IntrBkSttlmAmt = sttlmmtAmt;
            pacs.IntrBkSttlmDt = System.DateTime.Today.ToString("yyyy-MM-dd");

            pacs.DbtrBICFI = bs.BIC;
            pacs.DbtrNm = bs.BIC;
            pacs.DbtrBranchId = Request.Cookies["RoutingNo"].Value;
            pacs.DbtrAcctId = txtAccountNo.Text;
            pacs.DbtrAcctTp = "1";

            //pacs.CdtrAgtBICFI = ;
            //pacs.CdtrAgtBranchId = ;
            //pacs.CdtrAgtAcctId = ;
            //pacs.CdtrAgtAcctTp = ;

            pacs.CdtrBICFI = ddListReceivingBank.SelectedValue;
            pacs.CdtrNm = ddListReceivingBank.SelectedValue;
            pacs.CdtrBranchId = ddListBranch.SelectedValue;
            pacs.CdtrAcctId = txtReceiverAccountNo.Text;
            pacs.CdtrAcctTp = "1";

            pacs.InstrInf = txtReasonForPayment.Text;
            pacs.PmntRsn = InwardID;
            pacs.DeptId = Int32.Parse(Request.Cookies["DeptID"].Value);
            pacs.Maker = Request.Cookies["UserName"].Value;
            //pacs.MakeTime = ;
            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;

            pacs.BrnchCD = Request.Cookies["BranchCD"].Value;
            pacs.NoCBS = ChkNoCBS.Checked;
            //pacs.Checker = ;
            //pacs.CheckTime = ;
            //pacs.CheckerIP = ;
            //pacs.Admin = ;
            //pacs.AdminTime = ;
            //pacs.AdminIP = ;
            //pacs.DeletedBy = ;
            //pacs.DeleteTime = ;
            //pacs.CBSResponse = ;
            //pacs.CBSTime = ;
            //pacs.StatusID = ;

            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            string OutwardID = db.InsertOutward009(pacs);

            if ((InwardID != null) && (InwardID != ""))
            {
                db.ReturnInward09(InwardID, Int32.Parse(Request.Cookies["DeptID"].Value), pacs.Maker, pacs.MakerIP);
            }

            Response.Redirect("Outward09LongMaker.aspx?OutwardID=" + OutwardID);
        }
        private bool ValidateForm()
        {
            CCYDB dbccy = new CCYDB();
            decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.009");

            Decimal amt = 0;
            bool ret = true;
            if (txtAccountNo.Text == "")
                ret = false;
            if (txtSettlmentAmount.Text == "")
                ret = false;
            try
            {
                amt = Decimal.Parse(txtSettlmentAmount.Text);
            }
            catch
            {
                ret = false;
            }
            if (amt < minlimit)
            {
                lblMsg.Text = "Sending amount is less then Minimum Limit";
                ret = false;
            }
            if (amt > 10000000000)
            {
                lblMsg.Text = "Max 10000 crore";
                ret = false;
            }

            if (txtReceiverAccountNo.Text == "")
                ret = false;
            if (txtReasonForPayment.Text == "")
                ret = false;

            if ((txtAccountNo.Text == "000000000")||(txtReceiverAccountNo.Text == "000000000"))
            {
                lblMsg.Text = "Account No do not exists in the database.";
                ret = false;
            }

            return ret;
        }
        private void Banks()
        {
            BanksDB bankDB = new BanksDB();
            ddListReceivingBank.DataSource = bankDB.GetSendBanks();
            ddListReceivingBank.DataBind();
        }
        private void BindBranches(string BIC)
        {
            BranchesDB db = new BranchesDB();
            ddListBranch.DataSource = db.GetBranchesPacs9ByBIC(BIC);
            ddListBranch.DataBind();
            txtRoutingNo.Text = ddListBranch.SelectedValue;
        }
        private void BindAcctNos()
        {
            BankAccountsDB db = new BankAccountsDB();
            string SendingActNo = db.GetSingleBankAccount(ddlCurrency.SelectedValue);
            string RecievingActNo = db.GetOtherBankAccount(ddlCurrency.SelectedValue, ddListReceivingBank.SelectedValue);

            txtAccountNo.Text = SendingActNo;
            txtReceiverAccountNo.Text = RecievingActNo; 
        }
        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void txtSettlmentAmount_txtChanged(object sender, EventArgs e)
        {
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();
            try
            {
                lblAmount.Text = conv.GetAmountInWords(txtSettlmentAmount.Text.Replace(",", ""));
            }
            catch { }
        }
        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranches(ddListReceivingBank.SelectedValue);
        }

        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoutingNo.Text = ddListBranch.SelectedValue;
        }
    }
}