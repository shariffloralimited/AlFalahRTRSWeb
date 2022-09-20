using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08LongChecker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.Pacs008 pacs = db.GetSingleOutward08(OutwardID);
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

            lblFrBICFI.Text = pacs.FrBICFI ;
            lblToBICFI.Text = pacs.ToBICFI;
            lblBizMsgIdr.Text = pacs.BizMsgIdr;
            lblMsgDefIdr.Text = pacs.MsgDefIdr;
            lblBizSvc.Text = pacs.BizSvc;
            lblCreDt.Text = pacs.CreDt;
            lblMsgId.Text = pacs.MsgId;
            lblCreDtTm.Text = pacs.CreDtTm;
            lblBtchBookg.Text = pacs.BtchBookg;
            lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
            lblInstrId.Text = pacs.InstrId;
            lblEndToEndId.Text = pacs.EndToEndId;
            lblTxId.Text = pacs.TxId;
            lblClrChanl.Text = pacs.ClrChanl;
            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
            lblCcy.Text = pacs.Ccy;
            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
            lblChrgBr.Text = pacs.ChrgBr;
            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
            lblInstgAgtNm.Text = pacs.InstgAgtNm;
            lblInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
            lblInstdAgtNm.Text = pacs.InstdAgtNm;
            lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
            lblDbtrNm.Text = pacs.DbtrNm;
            lblDbtrPstlAdr.Text = pacs.DbtrPstlAdr;
            lblDbtrStrtNm.Text = pacs.DbtrStrtNm;
            lblDbtrTwnNm.Text = pacs.DbtrTwnNm;
            lblDbtrAdrLine.Text = pacs.DbtrAdrLine;
            lblDbtrCtry.Text = pacs.DbtrCtry;
            lblDbtrAcctOthrId.Text = pacs.DbtrAcctOthrId ;
            lblChequeSLNo.Text = pacs.CheckSLNo;
            lblDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
            lblDbtrAgtNm.Text = pacs.DbtrAgtNm;
            lblDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
            lblDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctOthrId;
            lblDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
            lblCdtrAgtNm.Text = pacs.CdtrAgtNm;
            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
            lblCdtrAgtAcctOthrId.Text = pacs.CdtrAgtAcctOthrId;
            lblCdtrAgtAcctPrtry.Text = pacs.CdtrAgtAcctPrtry;
            lblCdtrNm.Text = pacs.CdtrNm;
            lblCdtrPstlAdr.Text = pacs.CdtrPstlAdr;
            lblCdtrStrtNm.Text = pacs.CdtrStrtNm;
            lblCdtrTwnNm.Text = pacs.CdtrTwnNm;
            lblCdtrAdrLine.Text = pacs.CdtrAdrLine;
            lblCdtrCtry.Text = pacs.CdtrCtry;
            lblCdtrAcctOthrId.Text = pacs.CdtrAcctOthrId;
            lblCdtrAcctPrtry.Text = pacs.CdtrAcctPrtry;
            lblInstrInf.Text = pacs.InstrInf;
            //update for FCY
            this.txtOrginatorACType.Text = pacs.OrginatorACType;
            this.txtRecieverACType.Text = pacs.ReceiverACType;
            this.txtTransactionPurpose.Text = pacs.PurposeOfTransaction;
            this.txtOtherInf.Text = pacs.OtherInfo;


            //end
            lblUstrd.Text = pacs.Ustrd;
            ChkChargerWaived.Checked = pacs.ChargeWaived;

            lblCBSResponse.Text = pacs.CBSResponse;
            //lblPmntRsn.Text = pacs.PmntRsn;

            string RoleCD       = Request.Cookies["RoleCD"].Value;
            Decimal TransLimit  = Decimal.Parse(Request.Cookies["TransLimit"].Value);

            FloraSoft.BankSettingsDB bsdb = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = bsdb.GetBankSettings();
            DateTime cuttoffDate = System.DateTime.Today.AddHours((double) bs.AftrCutOffHr).AddMinutes((double) bs.AftrCutOffMin);

            CCYDB ccdb = new CCYDB();
            Decimal Rate = ccdb.GetCCYRate(pacs.Ccy);
            Decimal ApprovalLimit = TransLimit / Rate;

            if ((RoleCD == "RTCK") && (pacs.StatusID == 2))
            {
                ButtonPanel.Visible = true;
            }
            if ((RoleCD == "RTAU") && (pacs.StatusID == 3))
            {
                ButtonPanel.Visible = true;
            }

            if ((RoleCD == "RTCK") && (pacs.StatusID == 254))
            {
                //buttonCBSfailed.Visible = true;
                ButtonPanel.Visible = true;
                btnSend.Visible = false;
            }
            if ((RoleCD == "RTAU") && (pacs.StatusID == 254))
            {
                //buttonCBSfailed.Visible = true;
                ButtonPanel.Visible = true;
                btnSend.Visible = false;
            }

            if (ApprovalLimit < pacs.IntrBkSttlmAmt)
            {
                ButtonPanel.Visible = false;
            }

            if (cuttoffDate < System.DateTime.Now)
            {
                ButtonPanel.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string OutwardID = Request.Params["OutwardID"];
            string RoleCD = Request.Cookies["RoleCD"].Value;


            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            if (RoleCD == "RTCK")
            {
                db.ApproveOutward08(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (RoleCD == "RTAU")
            {
                db.AuthOutward08(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }

            Response.Redirect("../OutwardListChecker.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtReturnReason.Text.Trim() != "")
            {
                string OutwardID = Request.Params["OutwardID"];

                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
                db.ReturnOutward08(OutwardID, txtReturnReason.Text, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);

                Response.Redirect("../OutwardListChecker.aspx");
            }
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListChecker.aspx");
        }


        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string OutwardID = Request.Params["OutwardID"];

        //    RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
        //    db.DeleteOutward08(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
        //    Response.Redirect("../OutwardListMaker.aspx");
        //}
    }
}