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
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if ((Request.Cookies["RoleCD"].Value != "RTAD") && (Request.Cookies["RoleCD"].Value != "RTFM"))
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindSettingsData();
            BindCCYData();
            BindHeadOfficeRoutingNo();
        }
        private void BindSettingsData()
        {
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            FloraSoft.BankSettings bs = db.GetBankSettings();

            txtAutoMXAmnt.Text                  = bs.AutoMXAmnt.ToString("F2");
            txtCamtInterval.Text                = bs.CamtInterval.ToString();
            chkSkipCBS.Checked                  = bs.SkipCBS;
            txtOutParkingGL.Text                = bs.OutParkingGL;
            MorningCutOffHrList.SelectedValue   = bs.MorCutOffHr.ToString();
            MorningCutOffMinList.SelectedValue  = bs.MorCutOffMin.ToString();
            AfternoonCutOffHrList.SelectedValue = bs.AftrCutOffHr.ToString();
            AfternoonCutOffMinList.SelectedValue= bs.AftrCutOffMin.ToString();
        }

        private void BindCCYData()
        {
            CCYDB db = new CCYDB();
            MyDataGrid.DataSource = db.GetCCYList();
            MyDataGrid.DataBind();

            MyDataGrid.Items[0].Cells[2].Enabled = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            FloraSoft.BankSettingsDB db = new FloraSoft.BankSettingsDB();
            try
            {
                decimal AutoMXAmnt = 0;
                try
                {
                    AutoMXAmnt = decimal.Parse(txtAutoMXAmnt.Text);
                }
                catch { }
                int CamtInterval = 0;
                try
                {
                    CamtInterval = Int32.Parse(txtCamtInterval.Text);
                }
                catch { }

                bool SkipCBS = chkSkipCBS.Checked;
                string OutParkingGL = txtOutParkingGL.Text;

                int MorningCutOffHr = Int32.Parse(MorningCutOffHrList.SelectedValue);
                int MorningCutOffMin = Int32.Parse(MorningCutOffMinList.SelectedValue);

                int AfternoonCutOffHr = Int32.Parse(AfternoonCutOffHrList.SelectedValue);
                int AfternoonCutOffMin = Int32.Parse(AfternoonCutOffMinList.SelectedValue);

                db.UpdateBankSettings(AutoMXAmnt, CamtInterval, SkipCBS, OutParkingGL, MorningCutOffHr, MorningCutOffMin,  AfternoonCutOffHr, AfternoonCutOffMin);
                Msg.Text = "Succesfully saved.";
            }
            catch (Exception ex)
            {
                Msg.Text = "Invalid Data: " + ex.Message;
            }

        }

        protected void MyDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            CCYDB db = new CCYDB();
            if (e.CommandName == "Cancel")
            {
                MyDataGrid.EditItemIndex = -1;
            }
            if (e.CommandName == "Edit")
            {
                MyDataGrid.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "Update")
            {
                string CCY = (string) MyDataGrid.DataKeys[e.Item.ItemIndex];

                TextBox txtRate = (TextBox)e.Item.FindControl("Rate");
                TextBox txtPacs8 = (TextBox)e.Item.FindControl("Pacs08MinLimit");
                TextBox txtPacs9 = (TextBox)e.Item.FindControl("Pacs09MinLimit");

                decimal rate = 0;
                try
                {
                    rate = decimal.Parse(txtPacs8.Text);
                }
                catch { }
                if (rate != 0)
                {
                    db.UpdateRate(CCY, decimal.Parse(txtRate.Text), decimal.Parse(txtPacs8.Text), decimal.Parse(txtPacs9.Text));
                    lblMsg.Text = "Updated successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblMsg.Text = "Invalid rate";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                MyDataGrid.EditItemIndex = -1;
            }
        }

        protected void btnRtnNoSave_Click(object sender, EventArgs e)
        {
             SettingsDB db = new SettingsDB();
             db.UpdateHeadOfficeRoutingNo(txtMRn.Text, txtARn1.Text, txtARn2.Text, txtARn3.Text, txtARn4.Text, txtARn5.Text, txtARn6.Text, txtARn7.Text, txtARn8.Text, txtARn9.Text, txtARn10.Text);
            Label2.Text = "Succesfully saved.";
            Label2.ForeColor = System.Drawing.Color.Blue;
        }

        private void BindHeadOfficeRoutingNo()
        {
            SettingsDB db = new SettingsDB();
            setttings bd = db.getHeadOfficeRoutingNo();

            txtMRn.Text    =bd.MainRoutingNo.ToString();
            txtARn1.Text = bd.AdditionalRoutingNo1.ToString();
            txtARn2.Text = bd.AdditionalRoutingNo2.ToString();
            txtARn3.Text = bd.AdditionalRoutingNo3.ToString();
            txtARn4.Text = bd.AdditionalRoutingNo4.ToString();
            txtARn5.Text = bd.AdditionalRoutingNo5.ToString();
            txtARn6.Text = bd.AdditionalRoutingNo6.ToString();
            txtARn7.Text = bd.AdditionalRoutingNo7.ToString();
            txtARn8.Text = bd.AdditionalRoutingNo8.ToString();
            txtARn9.Text = bd.AdditionalRoutingNo9.ToString();
            txtARn10.Text = bd.AdditionalRoutingNo10.ToString();



        }



    }
}
