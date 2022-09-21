using RTGS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward09LongMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["RoleCD"].Value != "RTMK") 
            {
                Response.Redirect("../AccessDenied.aspx");
            }
            if (!IsPostBack)
            {
                TransCodeDB tr = new TransCodeDB();
                ddlCtgyPurpPrtry.DataSource = tr.GetTransCode("Pacs09");
                ddlCtgyPurpPrtry.DataBind();

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
                lblMsg.Text = pacs.PacsID;
            }

            txtFrBICFI.Text = pacs.FrBICFI;
            txtToBICFI.Text = pacs.ToBICFI;
            txtBizMsgIdr.Text = pacs.BizMsgIdr;
            txtMsgDefIdr.Text = pacs.MsgDefIdr;
            txtBizSvc.Text = pacs.BizSvc;
            txtCreDt.Text = pacs.CreDt;
            txtMsgId.Text = pacs.MsgId;
            txtCreDtTm.Text = pacs.CreDtTm;
            txtNbOfTxs.Text = pacs.NbOfTxs.ToString();
            txtInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
            txtInstgAgtNm.Text = pacs.InstgAgtNm;
            txtInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
            txtInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
            txtInstdAgtNm.Text = pacs.InstdAgtNm;
            txtInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
            txtIntrmyAgt1BICFI.Text = pacs.IntrmyAgt1BICFI;
            txtIntrmyAgt1Nm.Text = pacs.IntrmyAgt1Nm;
            txtIntrmyAgt1BranchId.Text = pacs.IntrmyAgt1BranchId;
            txtIntrmyAgt1AcctId.Text = pacs.IntrmyAgt1AcctId;
            txtIntrmyAgt1AcctTp.Text = pacs.IntrmyAgt1AcctTp;
            txtLclInstrmPrtry.Text = pacs.LclInstrmPrtry;
            txtSvcLvlPrtry.Text = pacs.SvcLvlPrtry;
            ddlCtgyPurpPrtry.SelectedValue = pacs.CtgyPurpPrtry;
            txtInstrId.Text = pacs.InstrId;
            txtTxId.Text = pacs.TxId;
            txtEndToEndId.Text = pacs.EndToEndId;
            lblSettlementCurrency.Text = pacs.IntrBkSttlmCcy;
            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            txtIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
            txtDbtrBICFI.Text = pacs.DbtrBICFI;
            txtDbtrNm.Text = pacs.DbtrNm;
            txtDbtrBranchId.Text = pacs.DbtrBranchId;
            lblDbtrAcctId.Text = pacs.DbtrAcctId;
            txtDbtrAcctTp.Text = pacs.DbtrAcctTp;
            txtCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
            txtCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
            txtCdtrAgtAcctId.Text = pacs.CdtrAgtAcctId;
            txtCdtrAgtAcctTp.Text = pacs.CdtrAgtAcctTp;
            txtCdtrBICFI.Text = pacs.CdtrBICFI;
            txtCdtrNm.Text = pacs.CdtrNm;
            txtCdtrBranchId.Text = pacs.CdtrBranchId;
            lblCdtrAcctId.Text = pacs.CdtrAcctId;
            txtCdtrAcctTp.Text = pacs.CdtrAcctTp;
            txtInstrInf.Text = pacs.InstrInf;
            if (lblSettlementCurrency.Text != "BDT")
            {
                txtInstrInfBillNumber.Text = pacs.InstrInfBillNumber;
                txtInstrInfLCNumber.Text = pacs.InstrInfLCNumber;
                txtInstrInfPartyName.Text = pacs.InstrInfPartyName;
                txtInstrInfBranchID.Text = pacs.InstrInfBranchID;
                txtInstrInfOthersInformation.Text = pacs.InstrInfOthersInformation;
            }
            //txtPmntRsn.Text = pacs.PmntRsn;
            LblReturnReason.Text = pacs.ReturnReason;
            ChkNoCBS.Checked = pacs.NoCBS;
            lblCBSResponse.Text = pacs.CBSResponse;
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            RTGSImporter.Pacs009 pacs = new RTGSImporter.Pacs009();

            pacs.PacsID =  Request.Params["OutwardID"];

            pacs.FrBICFI = txtFrBICFI.Text;
            pacs.ToBICFI = txtToBICFI.Text;
            pacs.BizMsgIdr = txtBizMsgIdr.Text;
            pacs.MsgDefIdr = txtMsgDefIdr.Text;
            pacs.BizSvc = txtBizSvc.Text;
            pacs.CreDt = txtCreDt.Text;
            pacs.MsgId = txtMsgId.Text;
            pacs.CreDtTm = txtCreDtTm.Text;
            pacs.NbOfTxs = Int32.Parse(txtNbOfTxs.Text);

            pacs.InstgAgtBICFI = txtInstgAgtBICFI.Text;
            pacs.InstgAgtNm = txtInstgAgtNm.Text;
            pacs.InstgAgtBranchId = txtInstgAgtBranchId.Text;

            pacs.InstdAgtBICFI = txtInstdAgtBICFI.Text;
            pacs.InstdAgtNm = txtInstdAgtNm.Text;
            pacs.InstdAgtBranchId = txtInstdAgtBranchId.Text;

            pacs.IntrmyAgt1BICFI = txtIntrmyAgt1BICFI.Text;
            pacs.IntrmyAgt1Nm = txtIntrmyAgt1Nm.Text;
            pacs.IntrmyAgt1BranchId = txtIntrmyAgt1BranchId.Text;
            pacs.IntrmyAgt1AcctId = txtIntrmyAgt1AcctId.Text;
            pacs.IntrmyAgt1AcctTp = txtIntrmyAgt1AcctTp.Text;

            pacs.LclInstrmPrtry = txtLclInstrmPrtry.Text;
            pacs.SvcLvlPrtry = txtSvcLvlPrtry.Text;
            pacs.CtgyPurpPrtry = ddlCtgyPurpPrtry.SelectedValue;
            pacs.InstrId = txtInstrId.Text;
            pacs.TxId = txtTxId.Text;
            pacs.EndToEndId = txtEndToEndId.Text;
            pacs.IntrBkSttlmCcy = lblSettlementCurrency.Text;
            pacs.IntrBkSttlmAmt = decimal.Parse(lblIntrBkSttlmAmt.Text);
            pacs.IntrBkSttlmDt = txtIntrBkSttlmDt.Text;

            pacs.DbtrBICFI = txtDbtrBICFI.Text;
            pacs.DbtrNm = txtDbtrNm.Text;
            pacs.DbtrBranchId = txtDbtrBranchId.Text;
            pacs.DbtrAcctId = lblDbtrAcctId.Text;
            pacs.DbtrAcctTp = txtDbtrAcctTp.Text;

            pacs.CdtrAgtBICFI = txtCdtrAgtBICFI.Text;
            pacs.CdtrAgtBranchId = txtCdtrAgtBranchId.Text;
            pacs.CdtrAgtAcctId = txtCdtrAgtAcctId.Text;
            pacs.CdtrAgtAcctTp = txtCdtrAgtAcctTp.Text;

            pacs.CdtrBICFI = txtCdtrBICFI.Text;
            pacs.CdtrNm = txtCdtrNm.Text;
            pacs.CdtrBranchId = txtCdtrBranchId.Text;
            pacs.CdtrAcctId = lblCdtrAcctId.Text;
            pacs.CdtrAcctTp = txtCdtrAcctTp.Text;

            pacs.InstrInf = txtInstrInf.Text;
            if (lblSettlementCurrency.Text != "BDT")
            {
                pacs.InstrInfBillNumber = txtInstrInfBillNumber.Text;
                pacs.InstrInfLCNumber = txtInstrInfLCNumber.Text;
                pacs.InstrInfPartyName = txtInstrInfPartyName.Text;
                pacs.InstrInfBranchID = txtInstrInfBranchID.Text;
                pacs.InstrInfOthersInformation = txtInstrInfOthersInformation.Text;
            }
            pacs.PmntRsn = lblMsg.Text;
           

            //pacs.PmntRsn = txtPmntRsn.Text;
            pacs.NoCBS = ChkNoCBS.Checked;

            pacs.Maker = Request.Cookies["UserName"].Value;
            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;


            db.UpdateOutward009(pacs);
            Response.Redirect("../OutwardListMaker.aspx");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamBlueDB db = new RTGSImporter.TeamBlueDB();
            db.DeleteOutward09(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }
    }
}