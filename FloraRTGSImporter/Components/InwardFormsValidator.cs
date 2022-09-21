using System;
using System.Text;
using System.Xml;
using System.Configuration;

namespace RTGSImporter
{
    class InwardFormsValidator
    {
        string BIC = ConfigurationManager.AppSettings["BIC"];

        public string Validate08(Pacs008 pacs)
        {
            string errlist = "";
            if (pacs.FrBICFI != "BBHOBDDHRTG")
            {
                errlist = errlist +  "Did not come from BBHOBDDHRTG,";
            }
            if (pacs.ToBICFI != BIC)
            {
                errlist = errlist + "Sent to wrong BICFI,";
            }
            if (pacs.IntrBkSttlmDt != System.DateTime.Now.ToString("yyyy-MM-dd"))
            {
                errlist = errlist + "Settlement Date is not today,";
            }
            if (pacs.IntrBkSttlmAmt  == (decimal) 0)
            {
                errlist = errlist + "Invalid Settlement Amount,";
            }
            if ("BDT,USD,GBP,EUR,CAD,YEN".IndexOf(pacs.Ccy) == -1)
            {
                errlist = errlist + "Wrong Currency Code,";
            }

            if (pacs.MsgId == "")
            {
                errlist = errlist + "Missing Message ID,";
            }
            if (pacs.CreDtTm == "")
            {
                errlist = errlist + "Missing Creating Date Time,";
            }
            if (pacs.NbOfTxs == 0)
            {
                errlist = errlist + "Missing Number of transactions,";
            }
            if (pacs.NbOfTxs == 0)
            {
                errlist = errlist + "Missing Number of transactions,";
            }
            if (pacs.NbOfTxs == 0)
            {
                errlist = errlist + "Missing Number of transactions,";
            }
            if (pacs.NbOfTxs == 0)
            {
                errlist = errlist + "Missing Number of transactions,";
            }
            if (pacs.NbOfTxs == 0)
            {
                errlist = errlist + "Missing Number of transactions,";
            }
            return errlist;
        }
    }
}
