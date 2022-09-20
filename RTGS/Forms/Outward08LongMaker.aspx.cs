using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Outward08LongMaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.Cookies["RoleCD"].Value != "RTMK") && (Request.Cookies["RoleCD"].Value != "RTAM")) 
            {
                Response.Redirect("../AccessDenied.aspx");
            }
            if(!IsPostBack)
            {
                LoadData();
                if (Request.Cookies["AllBranch"].Value == "False")
                {
                    TxtDbtrAgtBranchId.Enabled = false;
                }
                TxtDbtrAgtBICFI.Enabled = false;
            }

            if (Request.Cookies["RoleCD"].Value == "RTAM")
            {
                btnSend.Visible = false;
                btnDelete.Visible = false;
                btnCancelTrans.Visible = false;
            }
            
        }
        private void LoadData()
        {
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.Pacs008 pacs = db.GetSingleOutward08(OutwardID);
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

            TxtFrBICFI.Text = pacs.FrBICFI ;
            TxtToBICFI.Text = pacs.ToBICFI;
            TxtBizMsgIdr.Text = pacs.BizMsgIdr;
            TxtMsgDefIdr.Text = pacs.MsgDefIdr;
            TxtBizSvc.Text = pacs.BizSvc;
            TxtCreDt.Text = pacs.CreDt;
            TxtMsgId.Text = pacs.MsgId;
            TxtCreDtTm.Text = pacs.CreDtTm;
            if (pacs.BtchBookg == "")
                pacs.BtchBookg = "false";
            ChkBtchBookg.Checked = bool.Parse(pacs.BtchBookg);
            TxtNbOfTxs.Text = pacs.NbOfTxs.ToString();
            TxtInstrId.Text = pacs.InstrId;
            TxtEndToEndId.Text = pacs.EndToEndId;
            TxtTxId.Text = pacs.TxId;
            TxtClrChanl.Text = pacs.ClrChanl;
            TxtSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
            TxtLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
            TxtCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;
            LblSettlementCurrency.Text = pacs.Ccy;
            //TxtCcy.Text = pacs.Ccy ;
            LblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            LblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.IntrBkSttlmAmt, 2).ToString());
            TxtIntrBkSttlmDt.Text = pacs.IntrBkSttlmDt;
            radioChargeBearer.SelectedValue = pacs.ChrgBr;
            //TxtChrgBr.Text = pacs.ChrgBr;
            TxtInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
            TxtInstgAgtNm.Text = pacs.InstgAgtNm;
            TxtInstgAgtBranchId.Text = pacs.InstgAgtBranchId;
            TxtInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
            TxtInstdAgtNm.Text = pacs.InstdAgtNm;
            TxtInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
            TxtDbtrNm.Text = pacs.DbtrNm;
            TxtDbtrPstlAdr.Text = pacs.DbtrPstlAdr;
            TxtDbtrStrtNm.Text = pacs.DbtrStrtNm;
            TxtDbtrTwnNm.Text = pacs.DbtrTwnNm;
            TxtDbtrAdrLine.Text = pacs.DbtrAdrLine;
            TxtDbtrCtry.Text = pacs.DbtrCtry;
            lblDbtrAcctOthrId.Text = pacs.DbtrAcctOthrId ;
            TxtDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
            TxtDbtrAgtNm.Text = pacs.DbtrAgtNm;
            TxtDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
            TxtDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctOthrId;
            TxtDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
            TxtCdtrAgtBICFI.Text    = pacs.CdtrAgtBICFI;
            TxtCdtrAgtNm.Text       = pacs.CdtrAgtNm;
            TxtCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
            TxtCdtrAgtAcctOthrId.Text= pacs.CdtrAgtAcctOthrId;
            TxtCdtrAgtAcctPrtry.Text= pacs.CdtrAgtAcctPrtry;
            TxtCdtrNm.Text          = pacs.CdtrNm;
            TxtCdtrPstlAdr.Text     = pacs.CdtrPstlAdr;
            TxtCdtrStrtNm.Text      = pacs.CdtrStrtNm;
            TxtCdtrTwnNm.Text       = pacs.CdtrTwnNm;
            TxtCdtrAdrLine.Text     = pacs.CdtrAdrLine;
            TxtCdtrCtry.Text        = pacs.CdtrCtry;
            TxtCdtrAcctOthrId.Text  = pacs.CdtrAcctOthrId;
            TxtCdtrAcctPrtry.Text   = pacs.CdtrAcctPrtry;
            TxtInstrInf.Text        = pacs.InstrInf;
            TxtUstrd.Text           = pacs.Ustrd;
            //TxtPmntRsn.Text       = pacs.PmntRsn;
            LblReturnReason.Text    = pacs.ReturnReason;
            ChkChargerWaived.Checked = pacs.ChargeWaived;
            lblCBSResponse.Text     = pacs.CBSResponse;

            //TxtMaker.Text = pacs.Maker;
            //TxtMakeTime.Text = pacs.MakeTime;
            //TxtMakerIP.Text = pacs.MakerIP;
            //TxtStatusID.Text = pacs.StatusID;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.Pacs008 pacs = new RTGSImporter.Pacs008();

            pacs.PacsID = OutwardID;
            pacs.FrBICFI = TxtFrBICFI.Text;
            pacs.ToBICFI = TxtToBICFI.Text;
            pacs.BizMsgIdr = TxtBizMsgIdr.Text;
            pacs.MsgDefIdr = TxtMsgDefIdr.Text;
            pacs.BizSvc = TxtBizSvc.Text;
            pacs.CreDt = TxtCreDt.Text;
            pacs.MsgId = TxtMsgId.Text;
            pacs.CreDtTm = TxtCreDtTm.Text;
            pacs.BtchBookg = ChkBtchBookg.Checked.ToString();
            pacs.NbOfTxs = Int32.Parse(TxtNbOfTxs.Text);
            pacs.InstrId = TxtInstrId.Text;
            pacs.EndToEndId = TxtEndToEndId.Text;
            pacs.TxId = TxtTxId.Text;
            pacs.ClrChanl = TxtClrChanl.Text;
            pacs.SvcLvlPrtry = Int32.Parse(TxtSvcLvlPrtry.Text);
            pacs.LclInstrmPrtry = TxtLclInstrmPrtry.Text;
            pacs.CtgyPurpPrtry = TxtCtgyPurpPrtry.Text;
            pacs.Ccy = LblSettlementCurrency.Text;
            pacs.IntrBkSttlmAmt = decimal.Parse(LblIntrBkSttlmAmt.Text);
            pacs.IntrBkSttlmDt = TxtIntrBkSttlmDt.Text;
            pacs.ChrgBr = radioChargeBearer.SelectedValue;
            pacs.InstgAgtBICFI = TxtInstgAgtBICFI.Text;
            pacs.InstgAgtNm = TxtInstgAgtNm.Text;
            pacs.InstgAgtBranchId = TxtInstgAgtBranchId.Text;
            pacs.InstdAgtBICFI = TxtInstdAgtBICFI.Text;
            pacs.InstdAgtNm = TxtInstdAgtNm.Text;
            pacs.InstdAgtBranchId = TxtInstdAgtBranchId.Text;
            pacs.DbtrNm = TxtDbtrNm.Text;
            pacs.DbtrPstlAdr = TxtDbtrPstlAdr.Text;
            pacs.DbtrStrtNm = TxtDbtrStrtNm.Text;
            pacs.DbtrTwnNm = TxtDbtrTwnNm.Text;
            pacs.DbtrAdrLine = TxtDbtrAdrLine.Text;
            pacs.DbtrCtry = TxtDbtrCtry.Text;
            pacs.DbtrAcctOthrId = lblDbtrAcctOthrId.Text;
            pacs.DbtrAgtBICFI = TxtDbtrAgtBICFI.Text;
            pacs.DbtrAgtNm = TxtDbtrAgtNm.Text;
            pacs.DbtrAgtBranchId = TxtDbtrAgtBranchId.Text;
            pacs.DbtrAgtAcctOthrId = TxtDbtrAgtAcctOthrId.Text;
            pacs.DbtrAgtAcctPrtry = TxtDbtrAgtAcctPrtry.Text;
            pacs.CdtrAgtBICFI = TxtCdtrAgtBICFI.Text;
            pacs.CdtrAgtNm = TxtCdtrAgtNm.Text;
            pacs.CdtrAgtBranchId = TxtCdtrAgtBranchId.Text;
            pacs.CdtrAgtAcctOthrId = TxtCdtrAgtAcctOthrId.Text;
            pacs.CdtrAgtAcctPrtry = TxtCdtrAgtAcctPrtry.Text;
            pacs.CdtrNm = TxtCdtrNm.Text;
            pacs.CdtrPstlAdr = TxtCdtrPstlAdr.Text;
            pacs.CdtrStrtNm = TxtCdtrStrtNm.Text;
            pacs.CdtrTwnNm = TxtCdtrTwnNm.Text;
            pacs.CdtrAdrLine = TxtCdtrAdrLine.Text;
            pacs.CdtrCtry = TxtCdtrCtry.Text;
            pacs.CdtrAcctOthrId = TxtCdtrAcctOthrId.Text;
            pacs.CdtrAcctPrtry = TxtCdtrAcctPrtry.Text;
            pacs.InstrInf = TxtInstrInf.Text;
            //change for FCY
            pacs.OrginatorACType = txtOrginatorACType.Text;
            pacs.ReceiverACType = txtRecieverACType.Text;
            pacs.PurposeOfTransaction = txtTransactionPurpose.Text;
            pacs.OtherInfo = txtOtherInf.Text;

             //end
            pacs.Ustrd = TxtUstrd.Text;
            //pacs.PmntRsn = TxtPmntRsn.Text;
            pacs.Maker = Request.Cookies["UserName"].Value;
            pacs.MakerIP = HttpContext.Current.Request.UserHostAddress;

            db.UpdateOutward008(pacs);
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OutwardListMaker.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string OutwardID = Request.Params["OutwardID"];

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            db.DeleteOutward08(OutwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../OutwardListMaker.aspx");
        }

    }
}