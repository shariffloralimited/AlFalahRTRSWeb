using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using FloraSoft;

namespace RTGSImporter
{
    class XMLGenerator
    {
        public void GenerateCamt060(string CCY)
        {
            RTGS.BankAccountsDB dbo = new RTGS.BankAccountsDB();
            string AcctId = dbo.GetSingleBankAccount(CCY);

            BankSettingsDB db = new BankSettingsDB();
            BankSettings bs = db.GetBankSettings();

            string MsgId = bs.BIC.Substring(0, 4) + "60" + System.DateTime.Today.ToString("MMdd") + System.DateTime.Now.ToString("HHmmss");
            string CreDtTm = System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            //string QryNm = "STAT";
            string OrgIdAnyBIC = bs.BIC;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<Saa:DataPDU xmlns:Saa=\"urn:swift:saa:xsd:saa.2.0\" xmlns:Sw=\"urn:swift:snl:ns.Sw\" xmlns:SwGbl=\"urn:swift:snl:ns.SwGbl\" xmlns:SwInt=\"urn:swift:snl:ns.SwInt\" xmlns:SwSec=\"urn:swift:snl:ns.SwSec\">");
            sb.Append("<Saa:Body>");
            sb.Append("<AppHdr xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:head.001.001.01\">");
            sb.Append("<Fr><FIId><FinInstnId><BICFI>"+ bs.BIC+"</BICFI></FinInstnId></FIId></Fr>");
            sb.Append("<To><FIId><FinInstnId><BICFI>BBHOBDDHRTG</BICFI></FinInstnId></FIId></To>");
            sb.Append("<BizMsgIdr>" + MsgId + "</BizMsgIdr>");
            sb.Append("<MsgDefIdr>camt.060.001.03</MsgDefIdr>");
            sb.Append("<BizSvc>RTGS</BizSvc>");
            sb.Append("<CreDt>" + CreDtTm + "Z" + "</CreDt>");
            sb.Append("</AppHdr>");
            sb.Append("<Document xmlns:auto-ns1=\"urn:swift:saa:xsd:saa.2.0\" xmlns=\"urn:iso:std:iso:20022:tech:xsd:camt.060.001.03\">");
            sb.Append("<AcctRptgReq>");
            sb.Append("<GrpHdr>");
            sb.Append("<MsgId>" + MsgId + "</MsgId>");
            sb.Append("<CreDtTm>" + CreDtTm  + "</CreDtTm>");
            sb.Append("</GrpHdr>");
            sb.Append("<RptgReq>");
            sb.Append("<Id>" + MsgId + "</Id>");
            sb.Append("<ReqdMsgNmId>camt.052.001.04</ReqdMsgNmId>");
            sb.Append("<Acct>");
            sb.Append("<Id>");
            sb.Append("<Othr>");
            sb.Append("<Id>" + AcctId + "</Id>");
            sb.Append("</Othr>");
            sb.Append("</Id>");
            sb.Append("</Acct>");
            sb.Append("<AcctOwnr>");
            sb.Append("<Agt>");
            sb.Append("<FinInstnId>");
            sb.Append("<BICFI>" + bs.BIC + "</BICFI>");
            sb.Append("</FinInstnId>");
            sb.Append("</Agt>");
            sb.Append("</AcctOwnr>");
            sb.Append("</RptgReq>");
            sb.Append("</AcctRptgReq>");
            sb.Append("</Document>");
            sb.Append("</Saa:Body>");
            sb.Append("</Saa:DataPDU>");

            string FolderName = ConfigurationManager.AppSettings["LocalPath"] +  "\\Export\\MX\\";

            string FileName = MsgId + ".xml";
            string Path = FolderName + FileName;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            doc.Save(Path);

            string[] lines = File.ReadAllLines(Path);
            File.WriteAllLines(Path, lines);

        }
    }
}
