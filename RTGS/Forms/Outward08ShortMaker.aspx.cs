using RTGS.DAC;
using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                //ActNameDiv.Visible = true;
                btnGetInfo.Visible = false;
                CheckSLNoSignatureDiv.Visible = false;
                CBSAccSigInfoDiv.Visible = false;
            }
            else
            {
                //ActNameDiv.Visible = false;
                btnGetInfo.Visible = true;
                CheckSLNoSignatureDiv.Visible = true;
                CBSAccSigInfoDiv.Visible = true;
            }

            if ((Request.Cookies["RoleCD"].Value != "RTMK"))
            {
                Response.Redirect("../AccessDenied.aspx");
            }

            if(!IsPostBack)
            {
                BindTransType();
                BindSendBranch();
                BindBanks();
                BindBranches(ddListReceivingBank.SelectedValue);
                CustomDutyPanel.Visible = false;
                UnstructDiv.Visible = true;
                SignatureImage.Src = null;

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


            if ((ddlCtgyPurpPrtry.SelectedValue != "031") && (ddlCtgyPurpPrtry.SelectedItem.Value != "041") && (ddlCtgyPurpPrtry.SelectedItem.Value != "040"))
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
                    lblMsg.Text = "Charges must be waived for Govt Payment, Custom Duty Payment, TAX Payment And VAT Payment";
                    return;
                }
            }
            
            if(!bs.SkipCBS)
                if (!ValidateAccount())
                    return;
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
            




            pacs.DbtrNm = txtAccountName.Text;

            pacs.DbtrAcctOthrId     = txtAccountNo.Text;
            pacs.DbtrAgtBICFI       = bs.BIC;
            pacs.DbtrAgtNm          = bs.BIC;
            pacs.DbtrAgtBranchId    = ddlSendBranch.SelectedValue;
            pacs.CdtrAgtBICFI       = ddListReceivingBank.SelectedValue;
            pacs.CdtrAgtNm          = ddListReceivingBank.SelectedValue;
            pacs.CdtrAgtBranchId    = ddListBranch.SelectedValue;
            pacs.CdtrNm             = txtReceiverName.Text;
            pacs.CdtrAcctOthrId     = txtReceiverAccountNo.Text;
            //pacs.Ustrd              = txtReasonForPayment.Text;
            pacs.CheckSLNo = txtCheckSLNo.Text;
            if (pacs.CtgyPurpPrtry == "041")
            {
                pacs.Ustrd = txtCustomOfficeCD.Text + " " + txtRegYr.Text + " " + txRegNumber.Text + " " + txtDeclarantCD.Text + " " + txtCustomerMobile.Text;
            }
            else
            {
                pacs.Ustrd = txtReasonForPayment.Text;
            }
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
            OutwardDB db = new OutwardDB();
            bool SignatureExists = db.InsertAccountNo(txtAccountNo.Text);

            try
            {
                amnt = Decimal.Parse(txtSettlmentAmount.Text);
            }
            catch { }

            RTGSWS.Service1 ws = new RTGSWS.Service1();
            RTGSWS.AccountInfo ai = ws.GetAccountInfo(txtAccountNo.Text);
            accountNoField.Text = ai.AccountNo;
            workingBalanceField.Text = ai.WorkingBalance;
            currencyField.Text = ai.Currency;
            branchCodeField.Text = ai.BranchCode;
            activeInactiveField.Text = ai.ActiveInactive;
            accountTitleField.Text = ai.AccountTile;
            accountPostingRestrictField.Text = ai.AccountPostingRestrict;
            customerPostingRestrictField.Text = ai.CustomerPostingRestrict;
            errorMsgField.Text = ai.ErrorMsg;
            if (ai.AccountTile != "")
            {
                SignatureImage.Alt = "Getting image from server. Please wait 5 seconds and click Get Signature.";
            }
            else
            {
                SignatureImage.Alt = "No data found.";
            }

            SignatureImage.Src = null;

            if (SignatureExists)
            {
                GetSignature();
            }
        }
        protected void btnGetSignature_Click(object sender, EventArgs e)
        {
            GetSignature();
        }

        private void GetSignature()
        {
            OutwardDB db = new OutwardDB();
            SignatureImage.Src = null;

            SqlDataReader dr = db.GetAccountSignature(txtAccountNo.Text);

            try
            {
                while (dr.Read())
                {
                    byte[] ImageData;
                    ImageData = (byte[])dr["Signature"];

                    var base64 = Convert.ToBase64String(ImageData);
                    SignatureImage.Src = String.Format("data:image/gif;base64,{0}", base64);
                    SignatureImage.Alt = (string)dr["ErrMessage"];
                    SignatureImage.Width = 450;
                }
            }
            finally
            {
                dr.Close();
                dr.Dispose();
            }
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
        private bool ValidateAccount()
        {
            string branchCD = Request.Cookies["BranchCD"].Value;
            string AcctNo = txtAccountNo.Text.Trim().Substring(0, 3);
            string CCY = ddlCurrency.SelectedValue;

            if (workingBalanceField.Text == "")
            {
                lblMsg.Text = "Insufficient Balance.";
                return false;
            }

            Decimal balance = Decimal.Parse(workingBalanceField.Text);
            Decimal sendingamount = Decimal.Parse(txtSettlmentAmount.Text);
            

            sendingamount = GetBalNeeded(sendingamount, ChkChargeWaived.Checked, ddlCtgyPurpPrtry.SelectedValue, bs.Chrg, bs.VAT);

            if (sendingamount > balance)
            {
                if (ChkChargeWaived.Checked)
                {
                    lblMsg.Text = "Insufficient Balance.";
                }
                else
                {
                    lblMsg.Text = "Insufficient Balance (Required Balance:"+ sendingamount.ToString("0.00") + ").";
                }
                return false;
            }

            //if ((CCY != "BDT") && (branchCD != AcctNo))
            //{
            //    lblMsg.Text = "Foreign Currency transaction is not allowed from this Branch";
            //    return false;
            //}
            if (currencyField.Text == "")
            {
                lblMsg.Text = "Account Verification Needed.";
                return false;
            }
            if (currencyField.Text != ddlCurrency.SelectedValue)
            {
                lblMsg.Text = "Wrong Currency.";
                return false;
            }
            // added new uzzal 20210407
            if (activeInactiveField.Text != "Active")
            {
                lblMsg.Text = "Account InActive.";
                return false;
            }

            if (accountPostingRestrictField.Text != "No Restriction")
            {
                lblMsg.Text = "Account Posting Restricted.";
                return false;
            }


            if (customerPostingRestrictField.Text != "No Restriction")
            {
                lblMsg.Text = "Customer Posting Restricted.";
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
            if (CtgyPurpPrtry != "001")
                return sttlmAmnt;
            if (ChargeWaived)
                return sttlmAmnt;

            return sttlmAmnt + Chrg + VAT;
        }

        protected void ddlCtgyPurpPrtry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCtgyPurpPrtry.SelectedValue == "041")
            {
                CustomDutyPanel.Visible = true;
                UnstructDiv.Visible = false;
                ddListReceivingBank.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBankBIC"];
                BindBranches(ddListReceivingBank.SelectedValue);
                ddListBranch.SelectedValue = ConfigurationManager.AppSettings["CustomDutyReceivingBranch"];
                txtReceiverName.Text = ConfigurationManager.AppSettings["CustomDutyReceiverName"];
                txtReceiverAccountNo.Text = ConfigurationManager.AppSettings["CustomDutyReceiverAccountNo"];
            }
            else
            {
                CustomDutyPanel.Visible = false;
                UnstructDiv.Visible = true;
                ddListReceivingBank.SelectedIndex = 0;
                BindBranches(ddListReceivingBank.SelectedValue);
                txtReceiverName.Text = "";
                txtReceiverAccountNo.Text = "";
            }

        }
    }
}