using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Inward08Long : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
                FloraSoft.BankSettings bs = new FloraSoft.BankSettings();
                FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
                bs = db.GetBankSettings();

                if (bs.SkipCBS)
                {
                    btnTransfer.Visible = false;
                    btnApprove.Visible  = true;
                }
                else
                {
                    btnTransfer.Visible = false;
                    btnApprove.Visible = true;
                }            
            }

           
        }
        private void LoadData()
        { 
            string InwardID = Request.Params["InwardID"];

            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            RTGSImporter.Pacs008 pacs = db.GetSingleInward08(InwardID);
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
            lblUstrd.Text = pacs.Ustrd;
            lblPmntRsn.Text = pacs.PmntRsn;
            lblCBSResponse.Text = pacs.CBSResponse;

            string RoleCD = Request.Cookies["RoleCD"].Value;
            if (((RoleCD == "RTMK") && (pacs.StatusID == 3))||(RoleCD == "RTAM"))
            {
                ButtonPanel.Visible = true;
            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentReturn.aspx?FormName=Pacs.008&InwardID=" + Request.Params["InwardID"]);
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../InwardList.aspx");
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            string InwardID = Request.Params["InwardID"];

            db.RetryInwardCBS(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
            string InwardID = Request.Params["InwardID"];

            db.ApproveInward08(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");       
        }

        protected void btnT24_Click(object sender, EventArgs e)
        {            
            string CdtrAcctOthrId = lblCdtrAcctOthrId.Text;
            string CdtrAgtBranchId = lblCdtrAgtBranchId.Text;

            Response.Redirect("../T24AccountInfo.aspx?AccountNo=" + CdtrAcctOthrId + "&RoutingNo=" + CdtrAgtBranchId);


        }

    }
}