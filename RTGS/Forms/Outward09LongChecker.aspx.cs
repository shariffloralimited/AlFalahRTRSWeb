using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09LongChecker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.Pacs009 pacs = db.GetSingleOutward09(OutwardID);
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

            if (pacs.PmntRsn != "")
            {
                lblMsg.Text = "<a target=\"_new\" href=\"Inward09Long.aspx?InwardID=" + pacs.PmntRsn + "\">REVERSAL OF " + pacs.MsgId + "</a>";
            }

            lblFrBICFI.Text = pacs.FrBICFI;
            lblToBICFI.Text = pacs.ToBICFI;
            lblBizMsgIdr.Text = pacs.BizMsgIdr;
            lblMsgDefIdr.Text = pacs.MsgDefIdr;
            lblBizSvc.Text = pacs.BizSvc;
            lblCreDt.Text = pacs.CreDt;
            lblMsgId.Text = pacs.MsgId;
            lblCreDtTm.Text = pacs.CreDtTm;
            lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
            lblInstgAgtNm.Text = pacs.InstgAgtNm;
            lblInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
            lblInstdAgtNm.Text = pacs.InstdAgtNm;
            lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
            lblIntrmyAgt1BICFI.Text = pacs.IntrmyAgt1BICFI;
            lblIntrmyAgt1Nm.Text = pacs.IntrmyAgt1Nm;
            lblIntrmyAgt1BranchId.Text = pacs.IntrmyAgt1BranchId;
            lblIntrmyAgt1AcctId.Text = pacs.IntrmyAgt1AcctId;
            lblIntrmyAgt1AcctTp.Text = pacs.IntrmyAgt1AcctTp;
            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry;
            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry;
            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
            lblInstrId.Text = pacs.InstrId;
            lblTxId.Text = pacs.TxId;
            lblEndToEndId.Text = pacs.EndToEndId;
            lblIntrBkSttlmCcy.Text = pacs.IntrBkSttlmCcy;
            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
            lblDbtrBICFI.Text = pacs.DbtrBICFI;
            lblDbtrNm.Text = pacs.DbtrNm;
            lblDbtrBranchId.Text = pacs.DbtrBranchId;
            lblDbtrAcctId.Text = pacs.DbtrAcctId;
            lblDbtrAcctTp.Text = pacs.DbtrAcctTp;
            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
            lblCdtrAgtAcctId.Text = pacs.CdtrAgtAcctId;
            lblCdtrAgtAcctTp.Text = pacs.CdtrAgtAcctTp;
            lblCdtrBICFI.Text = pacs.CdtrBICFI;
            lblCdtrNm.Text = pacs.CdtrNm;
            lblCdtrBranchId.Text = pacs.CdtrBranchId;
            lblCdtrAcctId.Text = pacs.CdtrAcctId;
            lblCdtrAcctTp.Text = pacs.CdtrAcctTp;
            lblInstrInf.Text = pacs.InstrInf;

            lblInstrInfBillNumber.Text = pacs.InstrInfBillNumber;
            lblInstrInfLcNumber.Text = pacs.InstrInfLCNumber;
            lblInstrInfPartyName.Text = pacs.InstrInfPartyName;
            lblInstrInfBranchID.Text = pacs.InstrInfBranchID;
            lblInstrInfOthersInfo.Text = pacs.InstrInfOthersInformation;

            //lblPmntRsn.Text = pacs.PmntRsn;
            ChkNoCBS.Checked = pacs.NoCBS;
            lblCBSResponse.Text = pacs.CBSResponse;


            FloraSoft.BankSettingsDB bsdb = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = bsdb.GetBankSettings();
            DateTime cuttoffDate = System.DateTime.Today.AddHours((double)bs.AftrCutOffHr).AddMinutes((double)bs.AftrCutOffMin);

            string RoleCD = Request.Cookies["RoleCD"].Value;
            Decimal TransLimit = Decimal.Parse(Request.Cookies["TransLimit"].Value);

            CCYDB ccdb = new CCYDB();
            Decimal Rate = ccdb.GetCCYRate(pacs.IntrBkSttlmCcy);

            Decimal ApprovalLimit = TransLimit / Rate;

            if ((RoleCD == "RTCK") && (pacs.StatusID == 2))
            {
                ButtonPanel.Visible = true;
            }
            if ((RoleCD == "RTAU") && (pacs.StatusID == 3))
            {
                ButtonPanel.Visible = true;
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
            string RoleCD    = Request.Cookies["RoleCD"].Value;

            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

            if (RoleCD == "RTCK")
            {
                db.ApproveOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }
            if (RoleCD == "RTAU")
            {
                db.AuthOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            }

            Response.Redirect("../OutwardListChecker.aspx");
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtReturnReason.Text != "")
            {
                string OutwardID = Request.Params["OutwardID"];
                RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();

                if (lblMsg.Text == "")
                {
                    db.ReturnOutward09(OutwardID, txtReturnReason.Text, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
                }
                else
                {
                    db.RejectOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
                }
                Response.Redirect("../OutwardListChecker.aspx");
            }
        }
        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListChecker.aspx");
        }
    }
}