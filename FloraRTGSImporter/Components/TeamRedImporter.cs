using System;
using System.Xml;

namespace RTGSImporter
{
    class TeamRedImporter
    {
        public void LoadPacs008(string FileName, string xmlstr)
        {
            Pacs008 pacs = new Pacs008();
            TeamRedDB db = new TeamRedDB();
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlstr);

            pacs.FileName = FileName;

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elemFr = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);
                if (elemFr.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.FrBICFI = elemFr.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("To").Count > 0)
            {
                XmlElement elemTo = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
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
            if (doc.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
            {
                pacs.IntrBkSttlmDt = doc.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("NbOfTxs").Count > 0)
            {
                try
                {
                    pacs.NbOfTxs = Int32.Parse(doc.GetElementsByTagName("NbOfTxs").Item(0).InnerText);
                }
                catch{ }
            }

            Guid btchbookgid = Guid.NewGuid();
            pacs.BatchBookingID = btchbookgid.ToString();

            //--------------------------------
            if (doc.GetElementsByTagName("ClrChanl").Count > 0)
            {
                pacs.ClrChanl = doc.GetElementsByTagName("ClrChanl").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("SvcLvl").Count > 0)
            {
                XmlElement elemSvcLvl = (XmlElement)doc.GetElementsByTagName("SvcLvl").Item(0);

                if (elemSvcLvl.GetElementsByTagName("Prtry").Count > 0)
                {
                    try
                    {
                        pacs.SvcLvlPrtry = Int32.Parse(elemSvcLvl.GetElementsByTagName("Prtry").Item(0).InnerText);
                    }
                    catch { }
                }
            }

            if (doc.GetElementsByTagName("LclInstrm").Count > 0)
            {
                XmlElement elemLclInstrm = (XmlElement)doc.GetElementsByTagName("LclInstrm").Item(0);
                if (elemLclInstrm.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.LclInstrmPrtry = elemLclInstrm.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CtgyPurp").Count > 0)
            {
                XmlElement elemCtgyPurp = (XmlElement)doc.GetElementsByTagName("CtgyPurp").Item(0);
                if (elemCtgyPurp.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.CtgyPurpPrtry = elemCtgyPurp.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }
            //--------------------------------
            if (doc.GetElementsByTagName("InstgAgt").Count > 0)
            {
                XmlElement elemInstgAgtBICFI = (XmlElement)doc.GetElementsByTagName("InstgAgt").Item(0);
                if (elemInstgAgtBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.InstgAgtBICFI = elemInstgAgtBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("InstgAgt").Count > 0)
            {
                XmlElement elemInstgAgtNm = (XmlElement)doc.GetElementsByTagName("InstgAgt").Item(0);
                if (elemInstgAgtNm.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.InstgAgtNm = elemInstgAgtNm.GetElementsByTagName("Nm").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("InstgAgt").Count > 0)
            {
                XmlElement elemInstgAgtBranchId = (XmlElement)doc.GetElementsByTagName("InstgAgt").Item(0);
                if (elemInstgAgtBranchId.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.InstgAgtBranchId = elemInstgAgtBranchId.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }


            if (doc.GetElementsByTagName("InstdAgt").Count > 0)
            {
                XmlElement elemInstdAgtBICFI = (XmlElement)doc.GetElementsByTagName("InstdAgt").Item(0);
                if (elemInstdAgtBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.InstdAgtBICFI = elemInstdAgtBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("InstdAgt").Count > 0)
            {
                XmlElement elemInstdAgtNm = (XmlElement)doc.GetElementsByTagName("InstdAgt").Item(0);
                if (elemInstdAgtNm.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.InstdAgtNm = elemInstdAgtNm.GetElementsByTagName("Nm").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("InstdAgt").Count > 0)
            {
                XmlElement elemInstdAgtBranchId = (XmlElement)doc.GetElementsByTagName("InstdAgt").Item(0);
                if (elemInstdAgtBranchId.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.InstdAgtBranchId = elemInstdAgtBranchId.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            //--------------------------------

            int n = doc.GetElementsByTagName("CdtTrfTxInf").Count;


            for (int i = 0; i<n; i++)
            {
                XmlElement ElemCdtTrfTxInf = (XmlElement) doc.GetElementsByTagName("CdtTrfTxInf").Item(i);
                pacs = Pacs008Child(i, pacs, ElemCdtTrfTxInf);
                db.InsertInward008(pacs);
            }
            doc = null;
        }

        private Pacs008 Pacs008Child(int i, Pacs008 pacs, XmlElement doc)
        {
            pacs.InstrId = "";
            pacs.EndToEndId = "";
            pacs.TxId = "";
            pacs.Ccy = "";
            pacs.IntrBkSttlmAmt = 0;
            pacs.ChrgBr = "";
            pacs.DbtrNm = "";
            pacs.DbtrPstlAdr = "";
            pacs.DbtrStrtNm = "";
            pacs.DbtrTwnNm = "";
            pacs.DbtrAdrLine = "";
            pacs.DbtrCtry = "";
            pacs.DbtrAcctOthrId = "";
            pacs.DbtrAgtBICFI = "";
            pacs.DbtrAgtNm = "";
            pacs.DbtrAgtBranchId = "";
            pacs.DbtrAgtAcctOthrId = "";
            pacs.DbtrAgtAcctPrtry = "";
            pacs.CdtrAgtBICFI = "";
            pacs.CdtrAgtNm = "";
            pacs.CdtrAgtBranchId = "";
            pacs.CdtrAgtAcctOthrId = "";
            pacs.CdtrAgtAcctPrtry = "";
            pacs.CdtrNm = "";
            pacs.CdtrPstlAdr = "";
            pacs.CdtrStrtNm = "";
            pacs.CdtrTwnNm = "";
            pacs.CdtrAdrLine = "";
            pacs.CdtrCtry = "";
            pacs.CdtrAcctOthrId = "";
            pacs.CdtrAcctPrtry = "";
            pacs.InstrInf = "";
            pacs.Ustrd = "";

            if (doc.GetElementsByTagName("InstrId").Count > 0)
            {
                pacs.InstrId = doc.GetElementsByTagName("InstrId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("EndToEndId").Count > 0)
            {
                pacs.EndToEndId = doc.GetElementsByTagName("EndToEndId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("TxId").Count > 0)
            {
                pacs.TxId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
            }


            if (doc.GetElementsByTagName("IntrBkSttlmAmt").Count > 0)
            {
                pacs.Ccy = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).Attributes["Ccy"].Value;
            }

            if (doc.GetElementsByTagName("IntrBkSttlmAmt").Count > 0)
            {
                try
                {
                    pacs.IntrBkSttlmAmt = Decimal.Parse(doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText);
                }

                catch { }
            }


            if (doc.GetElementsByTagName("ChrgBr").Count > 0)
            {
                pacs.ChrgBr = doc.GetElementsByTagName("ChrgBr").Item(0).InnerText;
            }


            if (doc.GetElementsByTagName("Dbtr").Count > 0)
            {
                XmlElement ElemDbtr = (XmlElement)doc.GetElementsByTagName("Dbtr").Item(0);

                if (ElemDbtr.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.DbtrNm = ElemDbtr.GetElementsByTagName("Nm").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("PstlAdr").Count > 0)
                {
                    pacs.DbtrPstlAdr = ElemDbtr.GetElementsByTagName("PstlAdr").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("StrtNm").Count > 0)
                {
                    pacs.DbtrStrtNm = ElemDbtr.GetElementsByTagName("StrtNm").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("AdrLine").Count > 0)
                {
                    pacs.DbtrAdrLine = ElemDbtr.GetElementsByTagName("AdrLine").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("Ctry").Count > 0)
                {
                    pacs.DbtrCtry = ElemDbtr.GetElementsByTagName("Ctry").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("TwnNm").Count > 0)
                {
                    pacs.DbtrTwnNm = ElemDbtr.GetElementsByTagName("TwnNm").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("AdrLine").Count > 0)
                {
                    pacs.DbtrAdrLine = ElemDbtr.GetElementsByTagName("AdrLine").Item(0).InnerText;
                }

                if (ElemDbtr.GetElementsByTagName("Ctry").Count > 0)
                {
                    pacs.DbtrCtry = ElemDbtr.GetElementsByTagName("Ctry").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("DbtrAcct").Count > 0)
            {
                XmlElement elemDbtrAcctOthrId = (XmlElement)doc.GetElementsByTagName("DbtrAcct").Item(0);
                if (elemDbtrAcctOthrId.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.DbtrAcctOthrId = elemDbtrAcctOthrId.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("DbtrAgt").Count > 0)
            {
                XmlElement elemDbtrAgtBICFI = (XmlElement)doc.GetElementsByTagName("DbtrAgt").Item(0);
                if (elemDbtrAgtBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.DbtrAgtBICFI = elemDbtrAgtBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("DbtrAgt").Count > 0)
            {
                XmlElement DbtrAgt = (XmlElement)doc.GetElementsByTagName("DbtrAgt").Item(0);

                if (DbtrAgt.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.DbtrAgtNm = DbtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (DbtrAgt.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.DbtrAgtBranchId = DbtrAgt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("DbtrAgtAcct").Count > 0)
            {
                XmlElement DbtrAgtAcct = (XmlElement)doc.GetElementsByTagName("DbtrAgtAcct").Item(0);

                if (DbtrAgtAcct.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.DbtrAgtAcctOthrId = DbtrAgtAcct.GetElementsByTagName("Id").Item(0).InnerText;
                }
                if (DbtrAgtAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.DbtrAgtAcctPrtry = DbtrAgtAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CdtrAgt").Count > 0)
            {
                XmlElement elemCdtrAgt = (XmlElement)doc.GetElementsByTagName("CdtrAgt").Item(0);

                if (elemCdtrAgt.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.CdtrAgtBICFI = elemCdtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
                if (elemCdtrAgt.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.CdtrAgtNm = elemCdtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemCdtrAgt.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrAgtBranchId = elemCdtrAgt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CdtrAgtAcct").Count > 0)
            {
                XmlElement elemCdtrAgtAcct = (XmlElement)doc.GetElementsByTagName("CdtrAgtAcct").Item(0);
                if (elemCdtrAgtAcct.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrAgtAcctOthrId = elemCdtrAgtAcct.GetElementsByTagName("Id").Item(0).InnerText;
                }
                if (elemCdtrAgtAcct.GetElementsByTagName("Prtry").Count > 0)
                {

                    pacs.CdtrAgtAcctPrtry = elemCdtrAgtAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("Cdtr").Count > 0)
            {
                XmlElement elemCdtr = (XmlElement)doc.GetElementsByTagName("Cdtr").Item(0);
                if (elemCdtr.GetElementsByTagName("Nm").Count > 0)
                {
                    pacs.CdtrNm = elemCdtr.GetElementsByTagName("Nm").Item(0).InnerText;
                }
                if (elemCdtr.GetElementsByTagName("PstlAdr").Count > 0)
                {
                    pacs.CdtrPstlAdr = elemCdtr.GetElementsByTagName("PstlAdr").Item(0).InnerText;
                }
                if (elemCdtr.GetElementsByTagName("StrtNm").Count > 0)
                {
                    pacs.CdtrStrtNm = elemCdtr.GetElementsByTagName("StrtNm").Item(0).InnerText;
                }
                if (elemCdtr.GetElementsByTagName("TwnNm").Count > 0)
                {
                    pacs.CdtrTwnNm = elemCdtr.GetElementsByTagName("TwnNm").Item(0).InnerText;
                }
                if (elemCdtr.GetElementsByTagName("AdrLine").Count > 0)
                {
                    pacs.CdtrAdrLine = elemCdtr.GetElementsByTagName("AdrLine").Item(0).InnerText;
                }
                if (elemCdtr.GetElementsByTagName("Ctry").Count > 0)
                {
                    pacs.CdtrCtry = elemCdtr.GetElementsByTagName("Ctry").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("CdtrAcct").Count > 0)
            {
                XmlElement elemCdtrAcct = (XmlElement)doc.GetElementsByTagName("CdtrAcct").Item(0);

                if (elemCdtrAcct.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrAcctOthrId = elemCdtrAcct.GetElementsByTagName("Id").Item(0).InnerText;
                }
                if (elemCdtrAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.CdtrAcctPrtry = elemCdtrAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("InstrInf").Count > 0)
            {
                //Update for FCY
                if (pacs.Ccy != "BDT")
                {
                    int InstrInfTagCount = doc.GetElementsByTagName("InstrInf").Count;

                    for (int k = 0; k < InstrInfTagCount; k++)
                    {
                        string InstrInf = doc.GetElementsByTagName("InstrInf").Item(k).InnerText;
                        if (InstrInf.Contains("Org:")|| InstrInf.Contains("ORG: ") || InstrInf.Contains("//ORG: "))
                        {
                            pacs.OrginatorACType = InstrInf;
                        }
                        else if (InstrInf.Contains("Rec:") || InstrInf.Contains("REC: ")|| InstrInf.Contains("//REC: "))
                        {
                            pacs.ReceiverACType = InstrInf;
                        }
                        else if (InstrInf.Contains("Pur:")||InstrInf.Contains("PUR: ")|| InstrInf.Contains("//PUR: "))
                        {
                            pacs.PurposeOfTransaction = InstrInf;
                        }
                        else if (InstrInf.Contains("Otr:")||InstrInf.Contains("OTR: ")|| InstrInf.Contains("//OTR: "))
                        {
                            pacs.OtherInfo = InstrInf;
                        }
                        else
                        {
                            pacs.InstrInf = InstrInf;
                        }

                    }
                }
                //End
                else
                {


                    pacs.InstrInf = doc.GetElementsByTagName("InstrInf").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Ustrd").Count > 0)
            {
                pacs.Ustrd = doc.GetElementsByTagName("Ustrd").Item(0).InnerText;
            }
            return pacs;
        }

        public void LoadPacs002(string FileName, string xmlstr)
        {
            Pacs002 pacs = new Pacs002();

            TeamRedDB data = new TeamRedDB();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            pacs.FileName = FileName;

            //doc.LoadXml(doc.DocumentElement.GetElementsByTagName("block4").Item(0).InnerXml);

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elemFrBICFI = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);
                if (elemFrBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.FrBICFI = elemFrBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }


            if (doc.GetElementsByTagName("To").Count > 0)
            {
                XmlElement elemToBICFI = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elemToBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    pacs.ToBICFI = elemToBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
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

            if (doc.GetElementsByTagName("OrgnlMsgId").Count > 0)
            {
                pacs.OrgnlMsgId = doc.GetElementsByTagName("OrgnlMsgId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlMsgNmId").Count > 0)
            {
                pacs.OrgnlMsgNmId = doc.GetElementsByTagName("OrgnlMsgNmId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlCreDtTm").Count > 0)
            {
                pacs.OrgnlCreDtTm = doc.GetElementsByTagName("OrgnlCreDtTm").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("GrpSts").Count > 0)
            {
                pacs.GrpSts = doc.GetElementsByTagName("GrpSts").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Prtry").Count > 0)
            {
                pacs.RsnPrtry = doc.GetElementsByTagName("Prtry").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("AddtlInf").Count > 0)
            {
                pacs.AddtlInf = doc.GetElementsByTagName("AddtlInf").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlInstrId").Count > 0)
            {
                pacs.OrgnlInstrId = doc.GetElementsByTagName("OrgnlInstrId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlEndToEndId").Count > 0)
            {
                pacs.OrgnlEndToEndId = doc.GetElementsByTagName("OrgnlEndToEndId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlTxId").Count > 0)
            {
                pacs.OrgnlTxId = doc.GetElementsByTagName("OrgnlTxId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("TxSts").Count > 0)
            {
                pacs.TxSts = doc.GetElementsByTagName("TxSts").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Prtry").Count > 1)
            {
                pacs.TxInfAndStsPrtry = doc.GetElementsByTagName("Prtry").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("AddtlInf").Count > 1)
            {
                pacs.TxInfAndStsAddtlInf = doc.GetElementsByTagName("AddtlInf").Item(0).InnerText;
            }

            pacs.XmlData = doc.OuterXml;
            data.InsertPacs002(pacs);
            doc = null;
        }

        public void Loadcamt04(string FileName, string xmlstr)
        {
            Camt04 camt = new Camt04();

            TeamRedDB db = new TeamRedDB();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;

            if (doc.GetElementsByTagName("Fr").Count > 0)
            {
                XmlElement elemFrBICFI = (XmlElement)doc.GetElementsByTagName("Fr").Item(0);
                if (elemFrBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.FrBICFI = elemFrBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("To").Count > 0)
            {
                XmlElement elemToBICFI = (XmlElement)doc.GetElementsByTagName("To").Item(0);
                if (elemToBICFI.GetElementsByTagName("BICFI").Count > 0)
                {
                    camt.ToBICFI = elemToBICFI.GetElementsByTagName("BICFI").Item(0).InnerText;
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

            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                camt.MsgHdrMsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("CreDtTm").Count > 0)
            {
                camt.CreDtTm = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("OrgnlBizQry").Count > 0)
            {
                XmlElement elemOrgnlBizQryMsgId = (XmlElement)doc.GetElementsByTagName("OrgnlBizQry").Item(0);
                if (elemOrgnlBizQryMsgId.GetElementsByTagName("MsgId").Count > 0)
                {
                    camt.OrgnlBizQryMsgId = elemOrgnlBizQryMsgId.GetElementsByTagName("MsgId").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("AcctId").Count > 0)
            {
                XmlElement elemAcctIdOthrId = (XmlElement)doc.GetElementsByTagName("AcctId").Item(0);
                if (elemAcctIdOthrId.GetElementsByTagName("Id").Count > 0)
                {
                    camt.AcctIdOthrId = elemAcctIdOthrId.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("Cd").Count > 0)
            {
                camt.Cd = doc.GetElementsByTagName("Cd").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Ccy").Count > 0)
            {
                camt.Ccy = doc.GetElementsByTagName("Ccy").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("AmtWthtCcy").Count > 0)
            {
                camt.AmtWthtCcy = doc.GetElementsByTagName("AmtWthtCcy").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("CdtDbtInd").Count > 0)
            {
                camt.CdtDbtInd = doc.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("AnyBIC").Count > 0)
            {
                camt.AnyBIC = doc.GetElementsByTagName("AnyBIC").Item(0).InnerText;
            }

            camt.XmlData = doc.OuterXml;
            db.InsertCamt04(camt);
            doc = null;
        }
    }
}

