using RTGS.DAC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTGS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AccountNumber = Request.QueryString["AccountNo"];
                string RoutingNo = Request.QueryString["RoutingNo"];

                RTGSImporter.TeamRedDB db = new RTGSImporter.TeamRedDB();
                string ActNo = db.GetT24Info(AccountNumber, RoutingNo);
                //string AccountNumber = "2500090513";
                TextBox1.Text = ActNo;
                string CBSAccountNumber = TextBox1.Text;
                //SignatureImage.Src = null;


            }


        }

        protected void btnGetInfo_Click(object sender, EventArgs e)
        {
            CustomerInfo ci = new CustomerInfo();
            //decimal amnt = 0;
            OutwardDB db = new OutwardDB();
            bool SignatureExists = db.InsertAccountNo(TextBox1.Text);

            //try
            //{
            //    amnt = Decimal.Parse(txtSettlmentAmount.Text);
            //}
            //catch { }

            RTGSWS.Service1 ws = new RTGSWS.Service1();
            RTGSWS.AccountInfo ai = ws.GetAccountInfo(TextBox1.Text);
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

            SqlDataReader dr = db.GetAccountSignature(TextBox1.Text);

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
    }
}