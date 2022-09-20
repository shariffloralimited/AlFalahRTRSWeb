using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS.Forms
{
    public partial class Inward04Long : System.Web.UI.Page
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
                    btnRetry.Visible = false;
                }
                else
                {
                    btnRetry.Visible = true;
                }  
            }
           
        }
        private void LoadData()
        { 
            string InwardID = Request.Params["InwardID"];

            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            RTGSImporter.Pacs004 pacs = db.GetSingleInward04(InwardID);
            FMPS.BLL.NumberToWordConverter conv = new FMPS.BLL.NumberToWordConverter();

            lblFrBICFI.Text = pacs.FrBICFI;
            lblToBICFI.Text = pacs.ToBICFI;
            lblBizMsgIdr.Text = pacs.BizMsgIdr;
            lblMsgDefIdr.Text = pacs.MsgDefIdr;
            lblBizSvc.Text = pacs.BizSvc;
            lblCreDt.Text = pacs.CreDt;
            lblMsgId.Text = pacs.MsgId;
            lblCreDtTm.Text = pacs.CreDtTm;
            //lblNbOfTxs.Text = pacs.NbOfTxs.ToString();
            lblOrgnlMsgId.Text = pacs.OrgnlMsgId;
            lblInstrId.Text = pacs.OrgnlInstrId;
            lblOrgnlMsgNmId.Text = pacs.OrgnlMsgNmId;
            lblOrgnlCreDtTm.Text = pacs.OrgnlCreDtTm;

            lblEndToEndId.Text = pacs.OrgnlEndToEndId;
            lblTxId.Text = pacs.OrgnlTxId;

            //lblClrChanl.Text = pacs.;
            lblSvcLvlPrtry.Text = pacs.SvcLvlPrtry.ToString();
            lblLclInstrmPrtry.Text = pacs.LclInstrmPrtry.ToString();
            lblCtgyPurpPrtry.Text = pacs.CtgyPurpPrtry;

            lblCcy.Text = pacs.TxRefIntrBkSttlmCcy;
            lblIntrBkSttlmAmt.Text = Utilities.ToMoney(Math.Round(pacs.TxRefIntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmAmt.ToolTip = conv.GetAmountInWords(Math.Round(pacs.TxRefIntrBkSttlmAmt, 2).ToString());
            lblIntrBkSttlmDt.Text = pacs.TxRefIntrBkSttlmDt;
            lblChrgBr.Text = pacs.ChrgBr;
            lblInstgAgtBICFI.Text = pacs.InstgAgtBICFI;
            //lblInstgAgtNm.Text = pacs.Instg;
            //lblInstgAgtBranchId.Text = pacs.Instg;
            lblInstdAgtBICFI.Text = pacs.InstdAgtBICFI;
            //lblInstdAgtNm.Text = pacs.InstdAgtNm;
            //lblInstdAgtBranchId.Text = pacs.InstdAgtBranchId;
            lblDbtrNm.Text = pacs.DbtrNm;
            lblDbtrPstlAdr.Text = pacs.DbtrNmPstlAdr;
            lblDbtrStrtNm.Text = pacs.DbtrNmStrtNm;
            lblDbtrTwnNm.Text = pacs.DbtrNmTwnNm;
            lblDbtrAdrLine.Text = pacs.DbtrNmAdrLine;
            lblDbtrCtry.Text = pacs.DbtrNmCtry;
            lblDbtrAcctOthrId.Text = pacs.DbtrAcctId ;
            lblDbtrAgtBICFI.Text = pacs.DbtrAgtBICFI;
            //lblDbtrAgtNm.Text = pacs.DbtrAgtNm;
            lblDbtrAgtBranchId.Text = pacs.DbtrAgtBranchId;
            lblDbtrAgtAcctOthrId.Text = pacs.DbtrAgtAcctId;
            lblDbtrAgtAcctPrtry.Text = pacs.DbtrAgtAcctPrtry;
            lblCdtrAgtBICFI.Text = pacs.CdtrAgtBICFI;
            lblCdtrAgtNm.Text = pacs.CdtrAgtNm;
            lblCdtrAgtBranchId.Text = pacs.CdtrAgtBranchId;
            lblCdtrAgtAcctOthrId.Text = pacs.CdtrAgtAcctId;
            lblCdtrAgtAcctPrtry.Text = pacs.CdtrAgtAcctTpPrtry;
            lblCdtrNm.Text = pacs.CdtrNm;
            //lblCdtrPstlAdr.Text = pacs.CdtrCdtrPstlAdr;
            //lblCdtrStrtNm.Text = pacs.CdtrStrtNm;
            //lblCdtrTwnNm.Text = pacs.CdtrTwnNm;
            lblCdtrAdrLine.Text = pacs.CdtrAdrLine;
            //lblCdtrCtry.Text = pacs.CdtrCtry;
            lblCdtrAcctOthrId.Text = pacs.CdtrAcctId;
            lblCdtrAcctPrtry.Text = pacs.CdtrAcctTpPrtry;

            lblRtrRsnPrtry.Text = pacs.RtrRsnPrtry;
            lblRtrRsnAddtInf.Text = pacs.RtrRsnAddtlInf;

            //lblInstrInf.Text = pacs.;
            //lblUstrd.Text = pacs.Ustrd;
            //lblPmntRsn.Text = pacs.PmntRsn;
            //lblCBSResponse.Text = pacs.CBSResponse;

            string RoleCD = Request.Cookies["RoleCD"].Value;
            if((RoleCD == "RTMK")&&(pacs.StatusID == 3))
            {
                ButtonPanel.Visible = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            db.ApproveInward04(Request.Params["InwardID"],Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");
        }

        protected void btnCancelTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("../InwardList.aspx");
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            RTGSImporter.TeamGreenDB db = new RTGSImporter.TeamGreenDB();
            string InwardID = Request.Params["InwardID"];
            db.RetryInwardCBS(InwardID, Request.Cookies["UserName"].Value, HttpContext.Current.Request.UserHostAddress);
            Response.Redirect("../InwardList.aspx");
        }

    }
}