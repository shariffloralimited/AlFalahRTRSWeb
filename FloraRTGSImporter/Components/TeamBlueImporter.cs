using System;
using System.Xml;
using System.IO;

namespace RTGSImporter
{
    class TeamBlueImporter
    {
        public void LoadPacs009(string FileName, string xmlstr)
        {
            Pacs009 pacs    = new Pacs009();
            TeamBlueDB data = new TeamBlueDB();
            XmlDocument doc = new XmlDocument();
          
            doc.LoadXml(xmlstr);
            
            pacs.FileName = FileName;

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elem1 = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);
                if (elem1.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.FrBICFI = elem1.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("To").Count > 0)
            {
                XmlElement elem2 = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elem2.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.ToBICFI = elem2.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("BizMsgIdr").Count > 0)
            {
                pacs.BizMsgIdr = doc.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("MsgDefIdr").Count > 0)
            {
                pacs.MsgDefIdr = doc.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("BizSvc").Count > 0)
            {
                pacs.BizSvc = doc.GetElementsByTagName("BizSvc").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDt").Count > 0)
            {
                pacs.CreDt = doc.GetElementsByTagName("CreDt").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                pacs.MsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDtTm").Count > 0)
            {
                pacs.CreDtTm = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("BtchBookg").Count > 0)
            {
                pacs.BtchBookg = doc.GetElementsByTagName("BtchBookg").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("TtlIntrBkSttlmAmt").Count > 0)
            {
                try
                {
                    pacs.TtlIntrBkSttlmAmt = Decimal.Parse(doc.GetElementsByTagName("TtlIntrBkSttlmAmt").Item(0).InnerText);
                }

                catch { }
            }
            if (doc.GetElementsByTagName("NbOfTxs").Count > 0)
            {
                try
                {
                    pacs.NbOfTxs = Int32.Parse(doc.GetElementsByTagName("NbOfTxs").Item(0).InnerText);
                }
                catch { }
            }
            
            Guid btchbookgid = Guid.NewGuid();
            pacs.BtchBookgID = btchbookgid.ToString();

            int n = doc.GetElementsByTagName("CdtTrfTxInf").Count;

            for (int i = 0; i < n; i++)
            {
                XmlElement ElemCdtTrfTxInf = (XmlElement)doc.GetElementsByTagName("CdtTrfTxInf").Item(i);
                pacs = Pacs009Child(i, pacs, ElemCdtTrfTxInf);
                data.InsertInward009(pacs);
            }

            doc = null;

        }

        private Pacs009 Pacs009Child(int i, Pacs009 pacs, XmlElement doc)
        {
            pacs.InstgAgtBICFI = "";
            pacs.InstgAgtNm = "";
            pacs.InstgAgtBranchId = "";
            pacs.InstdAgtBICFI = "";
            pacs.InstdAgtNm = "";
            pacs.InstdAgtBranchId = "";
            pacs.IntrmyAgt1BICFI = "";
            pacs.IntrmyAgt1Nm = "";
            pacs.IntrmyAgt1BranchId = "";
            pacs.IntrmyAgt1AcctId = "";
            pacs.IntrmyAgt1AcctTp = "";
            pacs.LclInstrmPrtry = "";
            pacs.SvcLvlPrtry = "";
            pacs.CtgyPurpPrtry = "";
            pacs.InstrId = "";
            pacs.TxId = "";
            pacs.EndToEndId = "";
            pacs.IntrBkSttlmCcy = "";
            pacs.IntrBkSttlmAmt = 0;
            pacs.IntrBkSttlmDt = "";
            pacs.DbtrBICFI = "";
            pacs.DbtrNm = "";
            pacs.DbtrBranchId = "";
            pacs.DbtrAcctId = "";
            pacs.DbtrAcctTp = "";
            pacs.CdtrAgtBICFI = "";
            pacs.CdtrAgtBranchId = "";
            pacs.CdtrAgtAcctId = "";
            pacs.CdtrAgtAcctTp = "";
            pacs.CdtrBICFI = "";
            pacs.CdtrNm = "";
            pacs.CdtrBranchId = "";
            pacs.CdtrAcctId = "";
            pacs.CdtrAcctTp = "";
            pacs.InstrInf = "";

            //--------------------------------------
            if (doc.GetElementsByTagName("LclInstrm").Count > 0)
            {
                pacs.LclInstrmPrtry = doc.GetElementsByTagName("LclInstrm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("SvcLvl").Count > 0)
            {
                pacs.SvcLvlPrtry = doc.GetElementsByTagName("SvcLvl").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CtgyPurp").Count > 0)
            {
                pacs.CtgyPurpPrtry = doc.GetElementsByTagName("CtgyPurp").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("InstrId").Count > 0)
            {
                pacs.InstrId = doc.GetElementsByTagName("InstrId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("TxId").Count > 0)
            {
                pacs.TxId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("EndToEndId").Count > 0)
            {
                pacs.EndToEndId = doc.GetElementsByTagName("EndToEndId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("IntrBkSttlmAmt").Count > 0)
            {
                try
                {
                    pacs.IntrBkSttlmCcy = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).Attributes["Ccy"].Value;
                }
                catch { }
            }
            if (doc.GetElementsByTagName("IntrBkSttlmAmt").Count > 0)
            {
                try
                {
                    pacs.IntrBkSttlmAmt = decimal.Parse(doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText);
                }
                catch { }
            }
            if (doc.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
            {
                pacs.IntrBkSttlmDt = doc.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
            }
            //--------------------------------------

            if (doc.GetElementsByTagName("InstgAgt").Count > 0)
            {
                XmlElement elemInstgAgt = (XmlElement)doc.GetElementsByTagName("InstgAgt").Item(0);
                if (elemInstgAgt.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.InstgAgtBICFI = elemInstgAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemInstgAgt.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.InstgAgtNm = elemInstgAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemInstgAgt.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.InstgAgtBranchId = elemInstgAgt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            //----------------------------------------------------//

            if (doc.GetElementsByTagName("InstdAgt").Count > 0)
            {
                XmlElement elemInstdAgt = (XmlElement)doc.GetElementsByTagName("InstdAgt").Item(0);
                if (elemInstdAgt.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.InstdAgtBICFI = elemInstdAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemInstdAgt.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.InstdAgtNm = elemInstdAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemInstdAgt.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.InstdAgtBranchId = elemInstdAgt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            //----------------------------------------------------//
            if (doc.GetElementsByTagName("IntrmyAgt1").Count > 0)
            {
                XmlElement elemIntrmyAgt1 = (XmlElement)doc.GetElementsByTagName("IntrmyAgt1").Item(0);
                if (elemIntrmyAgt1.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.InstgAgtBICFI = elemIntrmyAgt1.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemIntrmyAgt1.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.InstdAgtNm = elemIntrmyAgt1.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemIntrmyAgt1.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.InstgAgtBranchId = elemIntrmyAgt1.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("IntrmyAgt1Acct").Count > 0)
            {
                XmlElement elemIntrmyAgt1Acct = (XmlElement)doc.GetElementsByTagName("IntrmyAgt1Acct").Item(0);
                if (elemIntrmyAgt1Acct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.IntrmyAgt1AcctTp = elemIntrmyAgt1Acct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }

                if (elemIntrmyAgt1Acct.GetElementsByTagName("Othr").Count > 0)
                {
                    XmlElement elemIntrmyAgt1AcctOther = (XmlElement)elemIntrmyAgt1Acct.GetElementsByTagName("Othr").Item(0);
                    if (elemIntrmyAgt1AcctOther.GetElementsByTagName("Id").Count > 0)
                    {
                        pacs.IntrmyAgt1AcctId = elemIntrmyAgt1AcctOther.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }

            //----------------------------------------------------//
            if (doc.GetElementsByTagName("Dbtr").Count > 0)
            {
                XmlElement elemDbtr = (XmlElement)doc.GetElementsByTagName("Dbtr").Item(0);
                if (elemDbtr.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.DbtrBICFI = elemDbtr.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemDbtr.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.DbtrNm = elemDbtr.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemDbtr.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.DbtrBranchId = elemDbtr.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("DbtrAcct").Count > 0)
            {
                XmlElement elemDbtrAcct = (XmlElement)doc.GetElementsByTagName("DbtrAcct").Item(0);
                if (elemDbtrAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.DbtrAcctTp = elemDbtrAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }

                if (elemDbtrAcct.GetElementsByTagName("Othr").Count > 0)
                {
                    XmlElement elemDbtrAcctOther = (XmlElement)elemDbtrAcct.GetElementsByTagName("Othr").Item(0);
                    if (elemDbtrAcctOther.GetElementsByTagName("Id").Count > 0)
                    {
                        pacs.DbtrAcctId = elemDbtrAcctOther.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }
            //----------------------------------------------------//

            if (doc.GetElementsByTagName("CdtrAgt").Count > 0)
            {
                XmlElement elemCdtrAgt = (XmlElement)doc.GetElementsByTagName("CdtrAgt").Item(0);
                if (elemCdtrAgt.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.CdtrAgtBICFI = elemCdtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemCdtrAgt.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrAgtBranchId = elemCdtrAgt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CdtrAgtAcct").Count > 0)
            {
                XmlElement elemCdtrAgtAcct = (XmlElement)doc.GetElementsByTagName("CdtrAgtAcct").Item(0);
                if (elemCdtrAgtAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.CdtrAgtAcctTp = doc.GetElementsByTagName("Prtry").Item(0).InnerText;
                }

                if (elemCdtrAgtAcct.GetElementsByTagName("Othr").Count > 0)
                {
                    XmlElement elemCdtrAgtAcctOher = (XmlElement)elemCdtrAgtAcct.GetElementsByTagName("Othr").Item(0);
                    if (elemCdtrAgtAcctOher.GetElementsByTagName("Id").Count > 0)
                    {
                        pacs.CdtrAgtAcctId = elemCdtrAgtAcctOher.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }

            if (doc.GetElementsByTagName("Cdtr").Count > 0)
            {
                XmlElement elemCdtr = (XmlElement)doc.GetElementsByTagName("Cdtr").Item(0);
                if (elemCdtr.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.CdtrBICFI = elemCdtr.GetElementsByTagName("BICFI").Item(0).InnerText;
                }

                if (elemCdtr.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.CdtrNm = elemCdtr.GetElementsByTagName("Nm").Item(0).InnerText;
                }

                if (elemCdtr.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrBranchId = elemCdtr.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CdtrAcct").Count > 0)
            {
                XmlElement elemCdtrAcct = (XmlElement)doc.GetElementsByTagName("CdtrAcct").Item(0);
                if (elemCdtrAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.CdtrAcctTp = elemCdtrAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }

                if (elemCdtrAcct.GetElementsByTagName("Othr").Count > 0)
                {
                    XmlElement elemCdtrAcctOther = (XmlElement)elemCdtrAcct.GetElementsByTagName("Othr").Item(0);
                    if (elemCdtrAcctOther.GetElementsByTagName("Id").Count > 0)
                    {
                        pacs.CdtrAcctId = elemCdtrAcctOther.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }

            if (doc.GetElementsByTagName("InstrInf").Count > 0)
            {
                pacs.InstrInf = doc.GetElementsByTagName("InstrInf").Item(0).InnerText;
            }

            return pacs;
        }

        public void LoadCamt06(string FileName, string xmlstr)
        {
            Camt06 camt = new Camt06();

            TeamBlueDB data = new TeamBlueDB();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;
            if (doc.GetElementsByTagName("AppHdr").Count > 0)
            {
                XmlElement elemAppHdr = (XmlElement)doc.GetElementsByTagName("AppHdr").Item(0);
                if (elemAppHdr.GetElementsByTagName("Fr").Count > 0)
                {
                    XmlElement elemBizIdIntrBkSttlmDt = (XmlElement)elemAppHdr.GetElementsByTagName("Fr").Item(0);
                    if (elemBizIdIntrBkSttlmDt.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.FrBICFI = elemBizIdIntrBkSttlmDt.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }
                if (elemAppHdr.GetElementsByTagName("To").Count > 0)
                {
                    XmlElement elemTo = (XmlElement)elemAppHdr.GetElementsByTagName("To").Item(0);
                    if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }
                if (elemAppHdr.GetElementsByTagName("BizMsgIdr").Count > 0)
                {
                    camt.BizMsgIdr = elemAppHdr.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
                }
                if (elemAppHdr.GetElementsByTagName("MsgDefIdr").Count > 0)
                {
                    camt.MsgDefIdr = elemAppHdr.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
                }
                if (elemAppHdr.GetElementsByTagName("BizSvc").Count > 0)
                {
                    camt.BizSvc = elemAppHdr.GetElementsByTagName("BizSvc").Item(0).InnerText;
                }
                if (elemAppHdr.GetElementsByTagName("CreDt").Count > 0)
                {
                    camt.CreDt = elemAppHdr.GetElementsByTagName("CreDt").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("MsgHdr").Count > 0)
            {
                XmlElement elemMsgHdr = (XmlElement)doc.GetElementsByTagName("MsgHdr").Item(0);
                if (elemMsgHdr.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.MsgId = elemMsgHdr.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
                if (elemMsgHdr.GetElementsByTagName("CreDtTm").Count > 0)
                {
                    camt.CreDtTm = elemMsgHdr.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                }

                if (elemMsgHdr.GetElementsByTagName("OrgnlBizQry").Count > 0)
                {
                    XmlElement elemOrgnlBizQry = (XmlElement)elemMsgHdr.GetElementsByTagName("OrgnlBizQry").Item(0);
                    camt.OrgnlBizQry1 = elemOrgnlBizQry.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
                if (elemMsgHdr.GetElementsByTagName("ReqTp").Count > 0)
                {
                    XmlElement elemPrtryId = (XmlElement)elemMsgHdr.GetElementsByTagName("ReqTp").Item(0);
                    if (elemPrtryId.GetElementsByTagName("Id").Count > 0)
                    {
                        camt.PrtryId = elemPrtryId.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }

            if (doc.GetElementsByTagName("ShrtBizId").Count > 0)
            {
                XmlElement elemShrtBizId = (XmlElement)doc.GetElementsByTagName("ShrtBizId").Item(0);

                if (elemShrtBizId.GetElementsByTagName("TxId").Count > 0)
                {
                    camt.TxId = elemShrtBizId.GetElementsByTagName("TxId").Item(0).InnerText;
                }
                if (elemShrtBizId.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
                {
                    camt.ShrtBizIdIntrBkSttlmDt = elemShrtBizId.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
                }
                if (elemShrtBizId.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.ShrtBizIdBICFI = elemShrtBizId.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("Pmt").Count > 0)
            {
                XmlElement elemPmt = (XmlElement)doc.GetElementsByTagName("Pmt").Item(0);
                if (elemPmt.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.PmtMsgId = elemPmt.GetElementsByTagName("MsgId").Item(0).InnerText;
                }

                if (elemPmt.GetElementsByTagName("Cd").Count > 0)
                {
                    XmlElement elemCd = (XmlElement)elemPmt.GetElementsByTagName("Cd").Item(0);
                    if (elemCd.GetElementsByTagName("Prtry").Count > 0)
                    {
                        camt.CdPrtry = elemCd.GetElementsByTagName("Prtry").Item(0).InnerText;
                    }
                }

                if (elemPmt.GetElementsByTagName("PrtryRjctn").Count > 0)
                {
                    XmlElement elemPrtryRjctn = (XmlElement)elemPmt.GetElementsByTagName("PrtryRjctn").Item(0);
                    if (elemPrtryRjctn.GetElementsByTagName("Rsn").Count > 0)
                    {
                        camt.PrtryRjctnRsn = elemPrtryRjctn.GetElementsByTagName("Rsn").Item(0).InnerText;
                    }
                }
            }

            if (doc.GetElementsByTagName("AmtWthCcy").Count > 0)
            {
                camt.Ccy = doc.GetElementsByTagName("AmtWthCcy").Item(0).Attributes["Ccy"].Value;
            }
            if (doc.GetElementsByTagName("AmtWthCcy").Count > 0)
            {
                camt.AmtWthCcy = Decimal.Parse(doc.GetElementsByTagName("AmtWthCcy").Item(0).InnerText);
            }
            if (doc.GetElementsByTagName("Pmt").Count > 0)
            {
                XmlElement elemIntrBkSttlmDt = (XmlElement)doc.GetElementsByTagName("Pmt").Item(0);
                if (elemIntrBkSttlmDt.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
                {
                    camt.IntrBkSttlmDt = elemIntrBkSttlmDt.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("EndToEndId").Count > 0)
            {
                camt.EndToEndId = doc.GetElementsByTagName("EndToEndId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Pties").Count > 0)
            {
                XmlElement elemPties = (XmlElement)doc.GetElementsByTagName("Pties").Item(0);
                if (elemPties.GetElementsByTagName("Dbtr").Count > 0)
                {
                    XmlElement elemDbtr = (XmlElement)elemPties.GetElementsByTagName("Dbtr").Item(0);
                    if (elemDbtr.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.DbtrBICFI = elemDbtr.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                    if (elemDbtr.GetElementsByTagName("Nm").Count > 0)
                    {
                        camt.DbtrBICFI = elemDbtr.GetElementsByTagName("Nm").Item(0).InnerText;
                    }
                }
                if (elemPties.GetElementsByTagName("DbtrAgt").Count > 0)
                {
                    XmlElement elemDbtrAgt = (XmlElement)elemPties.GetElementsByTagName("DbtrAgt").Item(0);
                    if (elemDbtrAgt.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.DbtrBICFI = elemDbtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                    if (elemDbtrAgt.GetElementsByTagName("Nm").Count > 0)
                    {
                        camt.DbtrBICFI = elemDbtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                    }
                }
                if (elemPties.GetElementsByTagName("CdtrAgt").Count > 0)
                {
                    XmlElement elemCdtrAgt = (XmlElement)elemPties.GetElementsByTagName("CdtrAgt").Item(0);
                    if (elemCdtrAgt.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.DbtrBICFI = elemCdtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                    if (elemCdtrAgt.GetElementsByTagName("Nm").Count > 0)
                    {
                        camt.DbtrBICFI = elemCdtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                    }
                }
                if (elemPties.GetElementsByTagName("Cdtr").Count > 0)
                {
                    XmlElement elemCdtr = (XmlElement)elemPties.GetElementsByTagName("Cdtr").Item(0);
                    if (elemCdtr.GetElementsByTagName("BICFI").Count > 0)
                    {
                        camt.DbtrBICFI = elemCdtr.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                    if (elemCdtr.GetElementsByTagName("Nm").Count > 0)
                    {
                        camt.DbtrBICFI = elemCdtr.GetElementsByTagName("Nm").Item(0).InnerText;
                    }
                }
            }

            if (doc.GetElementsByTagName("Acct").Count > 0)
            {
                XmlElement elemAcct = (XmlElement)doc.GetElementsByTagName("Acct").Item(0);
                if (elemAcct.GetElementsByTagName("Othr").Count > 0)
                {
                    XmlElement elemOthr = (XmlElement)doc.GetElementsByTagName("Othr").Item(0);
                    camt.DbtrBICFI = elemOthr.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            camt.XmlData = doc.OuterXml;
            data.InsertCamt06(camt);
            doc = null;
        }

        public void LoadCamt019(string FileName, string xmlstr)
        {
            Camt19 camt     = new Camt19();
            TeamBlueDB data = new TeamBlueDB();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elemFr = (XmlElement) doc.GetElementsByTagName("Fr").Item(0);
                if (elemFr.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.FrBICFI = elemFr.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("To").Count > 0)
            {
                XmlElement elemTo = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("BizMsgIdr").Count > 0)
            {
                camt.BizMsgIdr = doc.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("MsgDefIdr").Count > 0)
            {
                camt.MsgDefIdr = doc.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("BizSvc").Count > 0)
            {
                camt.BizSvc = doc.GetElementsByTagName("BizSvc").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDt").Count > 0)
            {
                camt.CreDt = doc.GetElementsByTagName("CreDt").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("MsgHdr").Count > 0)
            {
                XmlElement elemMsgHdr = (XmlElement)doc.GetElementsByTagName("MsgHdr").Item(0);
                if (elemMsgHdr.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.MsgHdrMsgId = elemMsgHdr.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
                if (elemMsgHdr.GetElementsByTagName("CreDtTm").Count > 0)
                {
                    camt.MsgHdrCreDtTm = elemMsgHdr.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                }
                if (elemMsgHdr.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.OrgnlBizQryMsgId = elemMsgHdr.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
                if (elemMsgHdr.GetElementsByTagName("OrgnlBizQry").Count > 0)
                {
                    XmlElement elemOrgnlBizQry = (XmlElement)elemMsgHdr.GetElementsByTagName("OrgnlBizQry").Item(0);
                    if (elemOrgnlBizQry.GetElementsByTagName("CreDtTm").Count > 0)
                    {
                        camt.OrgnlBizQryCreDtTm = elemOrgnlBizQry.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                    }
                }
            }
            if (doc.GetElementsByTagName("MktInfrstr").Count > 0)
            {
                XmlElement elemMktInfrstr = (XmlElement)doc.GetElementsByTagName("MktInfrstr").Item(0);
                if (doc.GetElementsByTagName("Prtry").Count > 0)
                {
                    camt.SysIdPrtry = elemMktInfrstr.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("BizDayInf").Count > 0)
            {
                XmlElement elemBizDayInf = (XmlElement)doc.GetElementsByTagName("BizDayInf").Item(0);
                if (doc.GetElementsByTagName("SysDt").Count > 0)
                {
                    camt.BizDayInfSysDt = elemBizDayInf.GetElementsByTagName("SysDt").Item(0).InnerText;
                }
            }
            camt.XmlData = doc.OuterXml;

            Guid Cam19ID = data.InsertCamt19(camt);

            int n = doc.GetElementsByTagName("Evt").Count;
            for (int i = 0; i < n; i++)
            {
                Cam19Evt evnt = new Cam19Evt();
                evnt.Camt19ID = Cam19ID;
                XmlElement elemEvt = (XmlElement) doc.GetElementsByTagName("Evt").Item(i);

                if (elemEvt.GetElementsByTagName("Tp").Count > 0)
                {
                    XmlElement elemTp = (XmlElement)doc.GetElementsByTagName("Tp").Item(0);
                    if (elemTp.GetElementsByTagName("Id").Count > 0)
                    {
                        evnt.TpPrtryId = elemEvt.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
                if (elemEvt.GetElementsByTagName("SchdldTm").Count > 0)
                {
                    evnt.SchdldTm = elemEvt.GetElementsByTagName("SchdldTm").Item(0).InnerText;
                }
                if (elemEvt.GetElementsByTagName("StartTm").Count > 0)
                {
                    evnt.StartTm = elemEvt.GetElementsByTagName("StartTm").Item(0).InnerText;
                }
                if (elemEvt.GetElementsByTagName("EndTm").Count > 0)
                {
                    evnt.EndTm = elemEvt.GetElementsByTagName("EndTm").Item(0).InnerText;
                }


                data.InsertCamt19Evt(evnt);
            }
            doc = null;
        }

        public void LoadCamt25(string FileName, string xmlstr)
        {
            camt25 camt = new camt25();
            TeamBlueDB data = new TeamBlueDB();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elemBizIdIntrBkSttlmDt = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);
                if (elemBizIdIntrBkSttlmDt.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.FrBICFI = elemBizIdIntrBkSttlmDt.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("To").Count>0)
            {
                XmlElement elemTo = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("BizMsgIdr").Count > 0)
            {
                camt.BizMsgIdr = doc.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("MsgDefIdr").Count > 0)
            {
                camt.MsgDefIdr = doc.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("BizSvc").Count > 0)
            {
                camt.BizSvc = doc.GetElementsByTagName("BizSvc").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDt").Count > 0)
            {
                camt.CreDt = doc.GetElementsByTagName("CreDt").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("MsgHdr").Count > 0)
            {
                XmlElement elemrMsgId = (XmlElement)doc.GetElementsByTagName("MsgHdr").Item(0);
                if (elemrMsgId.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.MsgId = elemrMsgId.GetElementsByTagName("MsgId").Item(0).InnerText;
                }

                if (doc.GetElementsByTagName("CreDtTm").Count > 0)
                {
                    camt.OrgnlMsgId = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("OrgnlMsgId").Count > 0)
            {
                XmlElement elemrOrgnlMsgId = (XmlElement)doc.GetElementsByTagName("OrgnlMsgId").Item(0);
                if (elemrOrgnlMsgId.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.OrgnlMsgId= elemrOrgnlMsgId.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("StsCd").Count > 0)
            {
                camt.StsCd = doc.GetElementsByTagName("StsCd").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("Desc").Count > 0)
            {
                camt.Desc = doc.GetElementsByTagName("Desc").Item(0).InnerText;
            }

            camt.XmlData = doc.OuterXml; 
            data.InsertCamt25(camt);
            doc = null;
        }

        public void LoadCamt998(string FileName, string xmlstr)
        {

            camt998 cam  = new camt998();
            cam.FileName = FileName;


            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            //WriteLog("LoadCamt998: loaded");

            #region AppHeader
            if (doc.GetElementsByTagName("AppHdr").Count > 0)
            {
                if (doc.GetElementsByTagName("Fr").Count > 0)
                {
                    XmlElement elemFrom = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);

                    if (elemFrom.GetElementsByTagName("Nm").Count > 0)
                    {
                        cam.FrBICFI = elemFrom.GetElementsByTagName("Nm").Item(0).InnerText;
                    }
                    if (elemFrom.GetElementsByTagName("BICFI").Count > 0)
                    {
                        cam.FrBICFI = elemFrom.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }

                if (doc.GetElementsByTagName("To").Count > 0)
                {
                    XmlElement elemTo = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                    if (elemTo.GetElementsByTagName("Nm").Count > 0)
                    {
                        cam.ToBICFI = elemTo.GetElementsByTagName("Nm").Item(0).InnerText;
                    } 
                    if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                    {
                        cam.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }

                if (doc.GetElementsByTagName("BizMsgIdr").Count > 0)
                {
                    cam.BizMsgIdr = doc.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
                }

                if (doc.GetElementsByTagName("MsgDefIdr").Count > 0)
                {
                    cam.MsgDefIdr = doc.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
                }

                if (doc.GetElementsByTagName("BizSvc").Count > 0)
                {
                    cam.BizSvc = doc.GetElementsByTagName("BizSvc").Item(0).InnerText;
                }
                if (doc.GetElementsByTagName("CreDt").Count > 0)
                {
                    cam.CreDt = doc.GetElementsByTagName("CreDt").Item(0).InnerText;
                }
            } 
            #endregion

            //WriteLog("LoadCamt998: AppHeaderLoaded.");

            #region PrtryMsgHdr
            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                cam.PrtryMsgIdRef = doc.GetElementsByTagName("Ref").Item(0).InnerText;

            }
            if (doc.GetElementsByTagName("Rltd").Count > 0)
            {
                cam.PrtryMsgRltdRef = doc.GetElementsByTagName("Rltd").Item(0).InnerText;
            } 
            #endregion

            //WriteLog("LoadCamt998: PrtryMsgHdr Loaded.");

            #region PrtryData
            if (doc.GetElementsByTagName("PrtryData").Count > 0)
            {
                //WriteLog("LoadCamt998: Inside PrtryData");

                XmlElement elemPrtryData = (XmlElement)doc.GetElementsByTagName("PrtryData").Item(0);

                if (elemPrtryData.GetElementsByTagName("Tp").Count > 0)
                {
                    cam.PrtryDataTp = doc.GetElementsByTagName("Tp").Item(0).InnerText;
                }

                #region UserTextMessage
		        if (elemPrtryData.GetElementsByTagName("UserTextMessage").Count > 0)
                {
                    XmlElement elemUserTextMessage = (XmlElement)elemPrtryData.GetElementsByTagName("UserTextMessage").Item(0);

                    if (elemUserTextMessage.GetElementsByTagName("Rcvr").Count > 0)
                    {
                        cam.PrtryDataRcvr = elemPrtryData.GetElementsByTagName("Rcvr").Item(0).InnerText;
                    }
                    if (elemUserTextMessage.GetElementsByTagName("Text").Count > 0)
                    {
                        cam.PrtryDataText = elemPrtryData.GetElementsByTagName("Text").Item(0).InnerText;
                    }
                } 
	            #endregion

                #region ServiceMessage
                if (elemPrtryData.GetElementsByTagName("ServiceMessage").Count > 0)
                {
                    //WriteLog("LoadCamt998: Inside ServiceMessage 0");

                    XmlElement elemServiceMessage = (XmlElement)elemPrtryData.GetElementsByTagName("ServiceMessage").Item(0);

                    if (elemServiceMessage.GetElementsByTagName("Code").Count > 0)
                    {
                        cam.ServiceMessageCode1 = elemServiceMessage.GetElementsByTagName("Code").Item(0).InnerText;
                    }
                    if (elemServiceMessage.GetElementsByTagName("Value").Count > 0)
                    {
                        cam.ServiceMessageValue1 = elemServiceMessage.GetElementsByTagName("Value").Item(0).InnerText;
                    }

                    //WriteLog("LoadCamt998: Inside ServiceMessage 1");
                    if (elemServiceMessage.GetElementsByTagName("Code").Count > 1)
                    {
                        cam.ServiceMessageCode2 = elemServiceMessage.GetElementsByTagName("Code").Item(1).InnerText;
                    }
                    if (elemServiceMessage.GetElementsByTagName("Value").Count > 1)
                    {
                        cam.ServiceMessageValue2 = elemServiceMessage.GetElementsByTagName("Value").Item(1).InnerText;
                    }

                    //WriteLog("LoadCamt998: Inside ServiceMessage2");

                    if (elemServiceMessage.GetElementsByTagName("Code").Count > 2)
                    {
                        cam.ServiceMessageCode3 = elemServiceMessage.GetElementsByTagName("Code").Item(2).InnerText;
                    }
                    if (elemServiceMessage.GetElementsByTagName("Value").Count > 2)
                    {
                        cam.ServiceMessageValue3 = elemServiceMessage.GetElementsByTagName("Value").Item(2).InnerText;
                    }

                    if (elemServiceMessage.GetElementsByTagName("Code").Count > 3)
                    {
                        cam.ServiceMessageCode4 = elemServiceMessage.GetElementsByTagName("Code").Item(3).InnerText;
                    }
                    if (elemServiceMessage.GetElementsByTagName("Value").Count > 3)
                    {
                        cam.ServiceMessageValue4 = elemServiceMessage.GetElementsByTagName("Value").Item(3).InnerText;
                    }

                     //WriteLog("LoadCamt998: Inside ServiceMessage3");
                    
                    if (elemServiceMessage.GetElementsByTagName("Code").Count > 4)
                    {
                        cam.ServiceMessageCode5 = elemServiceMessage.GetElementsByTagName("Code").Item(4).InnerText;
                    }
                    if (elemServiceMessage.GetElementsByTagName("Value").Count > 4)
                    {
                        cam.ServiceMessageValue5 = elemServiceMessage.GetElementsByTagName("Value").Item(4).InnerText;
                    }
                    //WriteLog("LoadCamt998: End ServiceMessage");
                }
	            #endregion
            }              
            #endregion

            cam.XmlData = doc.OuterXml;
            TeamBlueDB data = new TeamBlueDB();

            data.InsertCamt998(cam);
        }

        //protected void WriteLog(string Msg)
        //{
        //    FileStream fs = new FileStream("D:\\FloraLog\\" + System.DateTime.Today.ToString("yyyyMMdd") + ".log", FileMode.OpenOrCreate, FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.BaseStream.Seek(0, SeekOrigin.End);
        //    sw.WriteLine(System.DateTime.Now.ToString() + ": " + Msg);
        //    sw.Close();
        //    sw.Dispose();
        //    fs.Close();
        //    fs.Dispose();
        //}
    }

}


