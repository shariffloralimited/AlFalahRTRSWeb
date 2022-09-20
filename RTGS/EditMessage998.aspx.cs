using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace RTGS
{
    public partial class EditMessage998 : System.Web.UI.Page
    {
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            MessageDB db = new MessageDB();

            //DateTimeFormatInfo format = CultureInfo.InvariantCulture.DateTimeFormat;

            FloraSoft.BankSettingsDB db0 = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db0.GetBankSettings();

            string MsgId = bs.BIC.Substring(0, 4) + "98" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");

            RTGSImporter.camt998 camt = new RTGSImporter.camt998();

            camt.FrBICFI        = bs.BIC;
            camt.ToBICFI        = bs.BBBIC;
            camt.BizMsgIdr      = MsgId;
            camt.MsgDefIdr      = "camt.998.001.02";
            camt.BizSvc         = "RTGS";
            camt.CreDt          = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "Z";
            camt.PrtryMsgIdRef  = MsgId;
            camt.PrtryDataTp    = "UserTextMessage";
            camt.PrtryDataText  = MessageText.Text;
            camt.PrtryDataRcvr  = Request.QueryString["OthrBankBIC"];
            camt.Maker          = Request.Cookies["UserName"].Value;
            camt.MakerIP        = HttpContext.Current.Request.UserHostAddress;


            try
            {
                RTGSImporter.TeamBlueDB data = new RTGSImporter.TeamBlueDB();
                data.InsertCamt998(camt);
            }
            catch(Exception ex)
            {
                MessageText.Text = "Error inserting 998: "+ex.Message;
            } 
            try
            {
                FloraSoft.CamtGenerator cgen = new FloraSoft.CamtGenerator();
                cgen.GenCam998(camt);

                Response.Redirect("DailyTransactions.aspx");
            }
            catch(Exception ex)
            {
                MessageText.Text = "Error Generating 998: " + ex.Message;
            } 
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DailyTransactions.aspx");
        }
    }
}
