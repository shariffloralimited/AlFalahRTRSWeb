using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08ShortMaker : System.Web.UI.Page
    {
        FloraSoft.BankSettings bs;
        
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
            FloraSoft.BankSettingsDB  db0 = new FloraSoft.BankSettingsDB();
            bs = db0.GetBankSettings();

            if (bs.SkipCBS == true)
            {
                ActNameDiv.Visible = true;
                btnGetInfo.Visible = false;
            }
            else
            {
                ActNameDiv.Visible = false;
                btnGetInfo.Visible = true;
            }

            if (Request.Cookies["RoleCD"].Value != "RTMK") 
            {
                Response.Redirect("../AccessDenied.aspx");
            }

            if(!IsPostBack)
            {
                BindTransType();
                BindSendBranch();
                BindBanks();
                BindBranches(ddListReceivingBank.SelectedValue);
            }

            lblMsg.Text = "";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db0.GetBankSettings();

            if (bs.SkipCBS != true)
            {
                bool validated = false;
                switch (Request.Cookies["RoutingNo"].Value.Substring(0, 3))
                {
                    case "020":
                        validated = ValidateMYSISAccount();
                        break;
                    case "245":
                        validated = ValidateUBSAccount();
                        break;
                    case "290":
                        validated = ValidateUBSAccount();
                        break;
                }
                if (!validated)
                {
                    return;
                }
            }

            if ((ddlCtgyPurpPrtry.SelectedValue != "031") && (ddlCtgyPurpPrtry.SelectedItem.Value != "041"))
            {
                CCYDB dbccy = new CCYDB();
                decimal minlimit = dbccy.GetMinLimit(ddlCurrency.SelectedValue, "pacs.008");
                decimal sttlmmtAmt = Decimal.Parse(txtSettlmentAmount.Text);

                if (sttlmmtAmt < minlimit)
                {
                    lblMsg.Text = "Sending amount is less then Minimum Limit";
                    return;
                }

                if (sttlmmtAmt > (decimal)10000000000.00)
                {
                    lblMsg.Text = "Maximum Amount: 1000 Crore.";
                    return;
                }
            }
            else
            {
                if (!ChkChargeWaived.Checked)
                {
                    lblMsg.Text = "Charges must be waived for Goverment Payment And Customs Duty Payments.";
                    return;
                }
            }


            RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();
            string Credt = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            pacs.FrBICFI            = bs.BIC;
            pacs.ToBICFI            = "BBHOBDDHRTG";
            pacs.MsgDefIdr          = "pacs.008.001.04";
            pacs.BizSvc             = "RTGS";
            pacs.CreDt              = Credt + "Z";
            pacs.CreDtTm            = Credt;
            pacs.BtchBookg          = "false";
            pacs.NbOfTxs            = 1;
            pacs.ClrChanl           = "RTGS";
            pacs.SvcLvlPrtry        = 75;
            pacs.LclInstrmPrtry     = "RTGS_SSCT";
            pacs.CtgyPurpPrtry      = ddlCtgyPurpPrtry.SelectedValue;
            pacs.Ccy                = ddlCurrency.SelectedValue;
            pacs.IntrBkSttlmAmt     = Decimal.Parse(txtSettlmentAmount.Text);
            pacs.IntrBkSttlmDt      = System.DateTime.Today.ToString("yyyy-MM-dd");
            pacs.ChrgBr             = radioChargeBearer1.SelectedValue;
            pacs.InstgAgtBICFI      = bs.BIC;
            pacs.InstgAgtNm         = bs.BIC;
            pacs.InstgAgtBranchId   = ddlSendBranch.SelectedValue;
            pacs.InstdAgtBICFI      = ddListReceivingBank.SelectedValue;
            pacs.InstdAgtNm         = ddListReceivingBank.SelectedValue;
            pacs.InstdAgtBranchId   = ddListBranch.SelectedValue;


            if (bs.SkipCBS != true)
            {
                pacs.DbtrNm = lblAccountName.Text;
            }
            else
            {
                pacs.DbtrNm = txtAccountName.Text;
            }
            pacs.DbtrAcctOthrId     = txtAccountNo.Text;
            pacs.DbtrAgtBICFI       = bs.BIC;
            pacs.DbtrAgtNm          = bs.BIC;
            pacs.DbtrAgtBranchId    = ddlSendBranch.SelectedValue;
            pacs.CdtrAgtBICFI       = ddListReceivingBank.SelectedValue;
            pacs.CdtrAgtNm          = ddListReceivingBank.SelectedValue;
            pacs.CdtrAgtBranchId    = ddListBranch.SelectedValue;
            pacs.CdtrNm             = txtReceiverName.Text;
            pacs.CdtrAcctOthrId     = txtReceiverAccountNo.Text;
            pacs.Ustrd              = txtReasonForPayment.Text;
            pacs.DeptId             = Int32.Parse(Request.Cookies["DeptID"].Value);
            pacs.Maker              = Request.Cookies["UserName"].Value;
            pacs.MakerIP            = HttpContext.Current.Request.UserHostAddress;
            pacs.BrnchCD            = Request.Cookies["BranchCD"].Value;
            pacs.ChargeWaived       = ChkChargeWaived.Checked;

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            string OutwardID = db.InsertOutward008(pacs);

            Response.Redirect("Outward08LongMaker.aspx?OutwardID=" + OutwardID);
        }
        protected void ddListReceivingBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranches(ddListReceivingBank.SelectedValue);
        }
        protected void ddListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoutingNo.Text = ddListBranch.SelectedValue;
        }
        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            CustomerInfo ci = new CustomerInfo();
            decimal amnt = 0;
            try
            {
                amnt = Decimal.Parse(txtSettlmentAmount.Text);
            }
            catch { }

            RTGSWS.Service1 ws = new RTGSWS.Service1();
            string str = ws.GetAccountInfo(txtAccountNo.Text, amnt, ddlCurrency.SelectedValue);

            DataTable dt = ci.GetCustomerTable(str);
            AccountInfoGrid.DataSource = dt;
            AccountInfoGrid.DataBind();

            if (dt.Rows.Count > 4)
            {
                lblAccountNo.Text = dt.Rows[0][1].ToString();
                lblAccountName.Text = dt.Rows[1][1].ToString();
                lblCCY.Text = dt.Rows[2][1].ToString();
                lblCurrentBalance.Text = dt.Rows[3][1].ToString();

                if (Request.Cookies["RoutingNo"].Value.Substring(0, 3) == "020")
                {
                    lblSuccess.Text = dt.Rows[4][1].ToString();
                    lblBlocked.Text = dt.Rows[5][1].ToString();
                    lblDormant.Text = dt.Rows[6][1].ToString();
                    lblClosed.Text = dt.Rows[7][1].ToString();
                    lblDeceased.Text = dt.Rows[8][1].ToString();

                    if (txtAccountNo.Text.EndsWith("050"))
                    {
                        lblAccountName.Text = dt.Rows[10][1].ToString(); 
                    }
                }

            }
            dt.Dispose();
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
                lblAmount.Text = conv.GetAmountInWords(txtSettlmentAmount.Text.Replace(",",""));
            }
            catch { }
        }
        
        private bool ValidateMYSISAccount()
        {
            if (lblAccountName.Text == "")
            {
                lblMsg.Text = "Account Verification Needed.";
                return false;
            }

            Decimal balance       = Decimal.Parse(lblCurrentBalance.Text);
            Decimal sendingamount = Decimal.Parse(txtSettlmentAmount.Text);

            sendingamount = GetBalNeeded(sendingamount, ChkChargeWaived.Checked, ddlCtgyPurpPrtry.SelectedValue, bs.Chrg, bs.VAT);

            if (sendingamount > balance)
            {
                lblMsg.Text = "Insufficient Balance.";
                return false;
            }

            if (lblSuccess.Text !="Yes")
            {
                lblMsg.Text = "Account Verification Needed.";
                return false;
            }
            if (lblBlocked.Text != "No")
            {
                lblMsg.Text = "Account Blocked";
                return false;
            }
            if (lblDormant.Text != "No")
            {
                lblMsg.Text = "Account Dormant.";
                return false;
            }
            if (lblClosed.Text != "No")
            {
                lblMsg.Text = "Account Closed.";
                return false;
            }
            if (lblDeceased.Text != "No")
            {
                lblMsg.Text = "Account Deceased.";
                return false;
            }


            return true;
        }
        private bool ValidateUBSAccount()
        {
            string branchCD = Request.Cookies["BranchCD"].Value;
            string AcctNo = txtAccountNo.Text.Trim().Substring(0, 3);
            string CCY = ddlCurrency.SelectedValue;

            if ((CCY != "BDT") && (branchCD != AcctNo))
            {
                lblMsg.Text = "Foreign Currency transaction is not allowed from this Branch";
                return false;
            }
            if (lblCCY.Text == "")
            {
                lblMsg.Text = "Account Verification Needed.";
                return false;
            }
            if (lblAccountNo.Text != txtAccountNo.Text)
            {
                lblMsg.Text = "Account Verification Needed.";
                return false;
            }
            if (lblCCY.Text != ddlCurrency.SelectedValue)
            {
                lblMsg.Text = "Wrong Currency.";
                return false;
            }
            Decimal balance = Decimal.Parse(lblCurrentBalance.Text);
            Decimal sendingamount = Decimal.Parse(txtSettlmentAmount.Text);
            if (sendingamount > balance)
            {
                lblMsg.Text = "Insufficient Balance.";
                return false;
            }
            return true;
        }
        private void BindBanks()
        {
            BanksDB bankDB = new BanksDB();
            ddListReceivingBank.DataSource = bankDB.GetSendBanks();
            ddListReceivingBank.DataBind();
        }
        private void BindSendBranch()
        {
            BranchesDB db = new BranchesDB();
            ddlSendBranch.DataSource = db.GetSendBranches();
            ddlSendBranch.DataBind();
            if (Request.Cookies["AllBranch"].Value != "False")
            {
                ddlSendBranch.SelectedValue = "0";
            }
            else
            {
                ddlSendBranch.SelectedValue = Request.Cookies["RoutingNo"].Value;
                ddlSendBranch.Enabled = false;
            }
        }
        private void BindTransType()
        {
            TransCodeDB db = new TransCodeDB();
            ddlCtgyPurpPrtry.DataSource = db.GetTransCode("Pacs08");
            ddlCtgyPurpPrtry.DataBind();
        }
        private void BindBranches(string BIC)
        {
            BranchesDB db = new BranchesDB();
            ddListBranch.DataSource = db.GetBranchesByBIC(BIC);
            ddListBranch.DataBind();
            txtRoutingNo.Text = ddListBranch.SelectedValue;
        }

        private decimal GetBalNeeded(decimal sttlmAmnt, bool ChargeWaived, string CtgyPurpPrtry, decimal Chrg, decimal VAT)
        {
            if (CtgyPurpPrtry == "031")
                return sttlmAmnt;
            if (ChargeWaived)
                return sttlmAmnt + VAT;
            return sttlmAmnt + Chrg + VAT;
        }
    }
}