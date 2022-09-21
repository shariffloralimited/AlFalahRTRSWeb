using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Inward09Long : System.Web.UI.Page
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
            string InwardID = Request.Params["InwardID"];

            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.Pacs009 pacs = db.GetSingleInward09(InwardID);
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();


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

            lblPmntRsn.Text = pacs.PmntRsn;

            string RoleCD = Request.Cookies["RoleCD"].Value;
            if ((RoleCD == "RTMK") && (pacs.StatusID == 3))
            {
                ButtonPanel.Visible = true;
            }
            if (pacs.BizSvc == "RTGS_RETN")
            {
                btnRetry.Visible = true;
            }
            if (pacs.LclInstrmPrtry == "RTGS_NCLS")
            {
                btnRetry.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("Outward09ShortMaker.aspx?FormName=Pacs.009&InwardID=" + Request.Params["InwardID"]);
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../InwardList.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            string InwardID = Request.Params["InwardID"];

            db.ApproveInward09(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");

        }

        protected void btnRetry_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            string InwardID = Request.Params["InwardID"];

            db.RetryInwardCBS(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");
        }

    }
}