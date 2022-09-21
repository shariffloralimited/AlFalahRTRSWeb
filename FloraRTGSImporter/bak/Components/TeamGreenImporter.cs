using System;
using System.Xml;

namespace RTGSImporter
{
    class TeamGreenImporter
    {
        public void LoadPacs004(string FileName, string xmlstr)
        {
            Pacs004 pacs = new Pacs004();
            TeamGreenDB db = new TeamGreenDB();
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlstr);

            pacs.FileName = FileName;

            if (doc.GetElementsByTagName("AppHdr").Count > 0)
            {
                XmlElement elemAppHdr = (XmlElement)doc.GetElementsByTagName("AppHdr").Item(0);

                if (elemAppHdr.GetElementsByTagName("Fr").Count > 0)
                {
                    XmlElement elemFr = (XmlElement)elemAppHdr.GetElementsByTagName("Fr").Item(0);
                    if (elemFr.GetElementsByTagName("BICFI").Count > 0)
                    {
                        pacs.FrBICFI = elemFr.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }
                if (elemAppHdr.GetElementsByTagName("To").Count > 0)
                {
                    XmlElement elemTo = (XmlElement)elemAppHdr.GetElementsByTagName("To").Item(0);
                    if (elemTo.GetElementsByTagName("BICFI").Count > 0)
                    {
                        pacs.ToBICFI = elemTo.GetElementsByTagName("BICFI").Item(0).InnerText;
                    }
                }

                if (elemAppHdr.GetElementsByTagName("BizMsgIdr").Count > 0)
                {
                    pacs.BizMsgIdr = elemAppHdr.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
                }

                if (elemAppHdr.GetElementsByTagName("MsgDefIdr").Count > 0)
                {
                    pacs.MsgDefIdr = elemAppHdr.GetElementsByTagName("MsgDefIdr").Item(0).InnerText;
                }

                if (elemAppHdr.GetElementsByTagName("BizSvc").Count > 0)
                {
                    pacs.BizSvc = elemAppHdr.GetElementsByTagName("BizSvc").Item(0).InnerText;
                }

                if (elemAppHdr.GetElementsByTagName("CreDt").Count > 0)
                {
                    pacs.CreDt = elemAppHdr.GetElementsByTagName("CreDt").Item(0).InnerText;
                }
            }


            if (doc.GetElementsByTagName("PmtRtr").Count > 0)
            {
                XmlElement elemPmtRtr = (XmlElement)doc.GetElementsByTagName("PmtRtr").Item(0);

                if (elemPmtRtr.GetElementsByTagName("GrpHdr").Count > 0)
                {
                    XmlElement elemGrpHdr = (XmlElement)elemPmtRtr.GetElementsByTagName("GrpHdr").Item(0);

                    if (elemGrpHdr.GetElementsByTagName("MsgId").Count > 0)
                    {
                        pacs.MsgId = elemGrpHdr.GetElementsByTagName("MsgId").Item(0).InnerText;
                    }

                    if (elemGrpHdr.GetElementsByTagName("CreDtTm").Count > 0)
                    {
                        pacs.CreDtTm = elemGrpHdr.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                    }

                    if (elemGrpHdr.GetElementsByTagName("BtchBookg").Count > 0)
                    {
                        pacs.BtchBookg = elemGrpHdr.GetElementsByTagName("BtchBookg").Item(0).InnerText;
                    }
                    if (elemGrpHdr.GetElementsByTagName("TtlIntrBkSttlmAmt").Count > 0)
                    {
                        try
                        {
                            pacs.TtlIntrBkSttlmAmt = Decimal.Parse(elemGrpHdr.GetElementsByTagName("TtlIntrBkSttlmAmt").Item(0).InnerText);
                        }

                        catch { }
                    }
                    if (elemGrpHdr.GetElementsByTagName("NbOfTxs").Count > 0)
                    {
                        try
                        {
                            pacs.NbOfTxs = Int32.Parse(elemGrpHdr.GetElementsByTagName("NbOfTxs").Item(0).InnerText);
                        }
                        catch { }
                    }
                }

                if (elemPmtRtr.GetElementsByTagName("OrgnlGrpInf").Count > 0)
                {
                    XmlElement elemOrgnlGrpInf = (XmlElement)elemPmtRtr.GetElementsByTagName("OrgnlGrpInf").Item(0);

                    if (elemOrgnlGrpInf.GetElementsByTagName("OrgnlMsgId").Count > 0)
                    {
                        pacs.OrgnlMsgId = elemOrgnlGrpInf.GetElementsByTagName("OrgnlMsgId").Item(0).InnerText;
                    }
                    if (elemOrgnlGrpInf.GetElementsByTagName("OrgnlMsgNmId").Count > 0)
                    {
                        pacs.OrgnlMsgNmId = elemOrgnlGrpInf.GetElementsByTagName("OrgnlMsgNmId").Item(0).InnerText;
                    }
                    if (elemOrgnlGrpInf.GetElementsByTagName("OrgnlCreDtTm").Count > 0)
                    {
                        pacs.OrgnlCreDtTm = elemOrgnlGrpInf.GetElementsByTagName("OrgnlCreDtTm").Item(0).InnerText;
                    }

                    if (elemOrgnlGrpInf.GetElementsByTagName("RtrRsnInf").Count > 0)
                    {
                        XmlElement elemRtrRsnInf = (XmlElement)elemOrgnlGrpInf.GetElementsByTagName("RtrRsnInf").Item(0);

                        if (elemRtrRsnInf.GetElementsByTagName("Prtry").Count > 0)
                        {
                            pacs.RtrRsnPrtry = elemRtrRsnInf.GetElementsByTagName("Prtry").Item(0).InnerText;
                        }
                        if (elemRtrRsnInf.GetElementsByTagName("AddtlInf").Count > 0)
                        {
                            pacs.RtrRsnAddtlInf = elemRtrRsnInf.GetElementsByTagName("AddtlInf").Item(0).InnerText;
                        }
                    }

                }
                if (elemPmtRtr.GetElementsByTagName("TxInf").Count > 0)
                {
                    XmlElement elemTxInf = (XmlElement)elemPmtRtr.GetElementsByTagName("TxInf").Item(0);

                    if (elemTxInf.GetElementsByTagName("RtrId").Count > 0)
                    {
                        pacs.RtrId = elemTxInf.GetElementsByTagName("RtrId").Item(0).InnerText;
                    }
                    if (elemTxInf.GetElementsByTagName("OrgnlInstrId").Count > 0)
                    {
                        pacs.OrgnlInstrId = elemTxInf.GetElementsByTagName("OrgnlInstrId").Item(0).InnerText;
                    }
                    if (elemTxInf.GetElementsByTagName("OrgnlEndToEndId").Count > 0)
                    {
                        pacs.OrgnlEndToEndId = elemTxInf.GetElementsByTagName("OrgnlEndToEndId").Item(0).InnerText;
                    }
                    if (elemTxInf.GetElementsByTagName("OrgnlTxId").Count > 0)
                    {
                        pacs.OrgnlTxId = elemTxInf.GetElementsByTagName("OrgnlTxId").Item(0).InnerText;
                    }
                    if (elemTxInf.GetElementsByTagName("RtrdIntrBkSttlmAmt").Count > 0)
                    {
                        try
                        {
                            pacs.RtrdIntrBkSttlmCcy = elemTxInf.GetElementsByTagName("RtrdIntrBkSttlmAmt").Item(0).Attributes["Ccy"].Value;
                        }
                        catch { }
                        try
                        {
                            pacs.RtrdIntrBkSttlmAmt = Decimal.Parse(elemTxInf.GetElementsByTagName("RtrdIntrBkSttlmAmt").Item(0).InnerText);
                        }
                        catch { }
                    }

                    if (elemTxInf.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
                    {
                        pacs.TxInfIntrBkSttlmDt = elemTxInf.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
                    }
                    if (elemTxInf.GetElementsByTagName("ChrgBr").Count > 0)
                    {
                        pacs.ChrgBr = elemTxInf.GetElementsByTagName("ChrgBr").Item(0).InnerText;
                    }

                    if (elemTxInf.GetElementsByTagName("InstgAgt").Count > 0)
                    {
                        XmlElement elemInstgAgt = (XmlElement)elemTxInf.GetElementsByTagName("InstgAgt").Item(0);

                        if (elemInstgAgt.GetElementsByTagName("BICFI").Count > 0)
                        {
                            pacs.InstgAgtBICFI = elemInstgAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                        }
                    }
                    if (elemTxInf.GetElementsByTagName("InstdAgt").Count > 0)
                    {
                        XmlElement elemInstdAgt = (XmlElement)elemTxInf.GetElementsByTagName("InstdAgt").Item(0);
                        if (elemInstdAgt.GetElementsByTagName("BICFI").Count > 0)
                        {
                            pacs.InstdAgtBICFI = elemInstdAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                        }
                    }



                    if (elemTxInf.GetElementsByTagName("OrgnlTxRef").Count > 0)
                    {
                        XmlElement elemOrgnlTxRef = (XmlElement)elemTxInf.GetElementsByTagName("OrgnlTxRef").Item(0);

                        //-------------------------
                        if (elemOrgnlTxRef.GetElementsByTagName("IntrBkSttlmAmt").Count > 0)
                        {
                            try
                            {
                                pacs.TxRefIntrBkSttlmCcy = elemTxInf.GetElementsByTagName("IntrBkSttlmAmt").Item(0).Attributes["Ccy"].Value;
                            }
                            catch { }
                            try
                            {
                                pacs.TxRefIntrBkSttlmAmt = Decimal.Parse(elemTxInf.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText);
                            }
                            catch { }
                        }

                        if (elemOrgnlTxRef.GetElementsByTagName("IntrBkSttlmDt").Count > 0)
                        {
                            pacs.TxRefIntrBkSttlmDt = elemOrgnlTxRef.GetElementsByTagName("IntrBkSttlmDt").Item(0).InnerText;
                        }

                        //------------------------
                        if (elemOrgnlTxRef.GetElementsByTagName("PmtTpInf").Count > 0)
                        {
                            XmlElement elemPmtTpInf = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("PmtTpInf").Item(0);

                            if (elemPmtTpInf.GetElementsByTagName("SvcLvl").Count > 0)
                            {
                                XmlElement elemSvcLvl = (XmlElement)elemPmtTpInf.GetElementsByTagName("SvcLvl").Item(0);
                                if (elemSvcLvl.GetElementsByTagName("Prtry").Count > 0)
                                {
                                    try
                                    {
                                        pacs.SvcLvlPrtry = Int32.Parse(elemSvcLvl.GetElementsByTagName("Prtry").Item(0).InnerText);
                                    }
                                    catch { }
                                }
                            }
                            if (elemPmtTpInf.GetElementsByTagName("LclInstrm").Count > 0)
                            {
                                XmlElement elemLclInstrm = (XmlElement)elemPmtTpInf.GetElementsByTagName("LclInstrm").Item(0);
                                if (elemLclInstrm.GetElementsByTagName("Prtry").Count > 0)
                                {
                                    try
                                    {
                                        pacs.LclInstrmPrtry = elemLclInstrm.GetElementsByTagName("Prtry").Item(0).InnerText;
                                    }
                                    catch { }
                                }
                            }
                            if (elemPmtTpInf.GetElementsByTagName("CtgyPurp").Count > 0)
                            {
                                XmlElement elemCtgyPurp = (XmlElement)elemPmtTpInf.GetElementsByTagName("CtgyPurp").Item(0);
                                if (elemCtgyPurp.GetElementsByTagName("Prtry").Count > 0)
                                {
                                    pacs.CtgyPurpPrtry = elemCtgyPurp.GetElementsByTagName("Prtry").Item(0).InnerText;
                                }
                            }
                        }

                        //--------------------------------------------
                        if (elemOrgnlTxRef.GetElementsByTagName("PmtMtd").Count > 0)
                        {
                            pacs.PmtMtd = elemOrgnlTxRef.GetElementsByTagName("PmtMtd").Item(0).InnerText;
                        }
                        //--------------------------------------------

                        if (elemOrgnlTxRef.GetElementsByTagName("Dbtr").Count > 0)
                        {
                            XmlElement elemDbtr = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("Dbtr").Item(0);

                            if (elemDbtr.GetElementsByTagName("Nm").Count > 0)
                            {
                                pacs.DbtrNm = elemDbtr.GetElementsByTagName("Nm").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("PstlAdr").Count > 0)
                            {
                                pacs.DbtrNmPstlAdr = elemDbtr.GetElementsByTagName("PstlAdr").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("StrtNm").Count > 0)
                            {
                                pacs.DbtrNmStrtNm = elemDbtr.GetElementsByTagName("StrtNm").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("TwnNm").Count > 0)
                            {
                                pacs.DbtrNmTwnNm = elemDbtr.GetElementsByTagName("TwnNm").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("Ctry").Count > 0)
                            {
                                pacs.DbtrNmCtry = elemDbtr.GetElementsByTagName("Ctry").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("AdrLine").Count > 0)
                            {
                                pacs.DbtrNmAdrLine = elemDbtr.GetElementsByTagName("AdrLine").Item(0).InnerText;
                            }
                            if (elemDbtr.GetElementsByTagName("Othr").Count > 0)
                            {
                                XmlElement elemDbtrOthr = (XmlElement)elemDbtr.GetElementsByTagName("Othr").Item(0);
                                if (elemDbtrOthr.GetElementsByTagName("Id").Count > 0)
                                {
                                    pacs.DbtrAcctId = elemDbtrOthr.GetElementsByTagName("Id").Item(0).InnerText;
                                }
                            }
                            if (elemDbtr.GetElementsByTagName("Prtry").Count > 0)
                            {
                                pacs.DbtrAcctTpPrtry = elemDbtr.GetElementsByTagName("Prtry").Item(0).InnerText;
                            }
                        }
                        if (elemOrgnlTxRef.GetElementsByTagName("DbtrAgt").Count > 0)
                        {
                            XmlElement elemDbtrAgt = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("DbtrAgt").Item(0);

                            if (elemDbtrAgt.GetElementsByTagName("Nm").Count > 0)
                            {
                                pacs.DbtrAgtBICFINm = elemDbtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                            }
                            if (elemDbtrAgt.GetElementsByTagName("BICFI").Count > 0)
                            {
                                pacs.DbtrAgtBICFI = elemDbtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                            }

                            if (elemDbtrAgt.GetElementsByTagName("BrnchId").Count > 0)
                            {
                                XmlElement elemDbtrAgtBranchId = (XmlElement)elemDbtrAgt.GetElementsByTagName("BrnchId").Item(0);

                                if (elemDbtrAgtBranchId.GetElementsByTagName("Id").Count > 0)
                                {
                                    pacs.DbtrAgtBranchId = elemDbtrAgtBranchId.GetElementsByTagName("Id").Item(0).InnerText;
                                }
                            }
                            if (elemDbtrAgt.GetElementsByTagName("Prtry").Count > 0)
                            {
                                pacs.DbtrAgtAcctPrtry = elemDbtrAgt.GetElementsByTagName("Prtry").Item(0).InnerText;
                            }
                        }

                        if (elemOrgnlTxRef.GetElementsByTagName("DbtrAgtAcct").Count > 0)
                        {
                            XmlElement elemDbtrAgtAcct = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("DbtrAgtAcct").Item(0);
                            if (elemDbtrAgtAcct.GetElementsByTagName("Id").Count > 0)
                            {
                                pacs.DbtrAgtAcctId = elemDbtrAgtAcct.GetElementsByTagName("Id").Item(0).InnerText;
                            }
                        }

                        if (elemOrgnlTxRef.GetElementsByTagName("CdtrAgt").Count > 0)
                        {
                            XmlElement elemCdtrAgt = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("CdtrAgt").Item(0);

                            if (elemCdtrAgt.GetElementsByTagName("BICFI").Count > 0)
                            {
                                pacs.CdtrAgtBICFI = elemCdtrAgt.GetElementsByTagName("BICFI").Item(0).InnerText;
                            }
                            if (elemCdtrAgt.GetElementsByTagName("Nm").Count > 0)
                            {
                                pacs.CdtrAgtNm = elemCdtrAgt.GetElementsByTagName("Nm").Item(0).InnerText;
                            }
                            if (elemCdtrAgt.GetElementsByTagName("BrnchId").Count > 0)
                            {
                                XmlElement CdtrAgtBranchId = (XmlElement)elemCdtrAgt.GetElementsByTagName("BrnchId").Item(0);

                                if (CdtrAgtBranchId.GetElementsByTagName("Id").Count > 0)
                                {
                                    pacs.CdtrAgtBranchId = CdtrAgtBranchId.GetElementsByTagName("Id").Item(0).InnerText;
                                }
                            }
                            if (elemCdtrAgt.GetElementsByTagName("Othr").Count > 0)
                            {
                                XmlElement CdtrAgtOthr = (XmlElement)elemCdtrAgt.GetElementsByTagName("Othr").Item(0);
                                if (CdtrAgtOthr.GetElementsByTagName("Id").Count > 0)
                                {
                                    pacs.CdtrAgtAcctId = CdtrAgtOthr.GetElementsByTagName("Id").Item(0).InnerText;
                                }
                            }
                            if (elemCdtrAgt.GetElementsByTagName("Prtry").Count > 0)
                            {
                                pacs.CdtrAgtAcctTpPrtry = elemCdtrAgt.GetElementsByTagName("Prtry").Item(0).InnerText;
                            }
                        }
                        //----------------------------------

                        if (elemOrgnlTxRef.GetElementsByTagName("CdtrAgtAcct").Count > 0)
                        {
                            XmlElement elemCdtrAgtAcct = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("CdtrAgtAcct").Item(0);
                            if (elemCdtrAgtAcct.GetElementsByTagName("Id").Count > 0)
                            {
                                pacs.CdtrAgtAcctId = elemCdtrAgtAcct.GetElementsByTagName("Id").Item(0).InnerText;
                            }
                        }

                        //----------------------------------
                        if (elemOrgnlTxRef.GetElementsByTagName("Cdtr").Count > 0)
                        {
                            XmlElement elemCdtr = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("Cdtr").Item(0);

                            if (elemCdtr.GetElementsByTagName("Nm").Count > 0)
                            {
                                pacs.CdtrNm = elemCdtr.GetElementsByTagName("Nm").Item(0).InnerText;
                            }
                            if (elemCdtr.GetElementsByTagName("AdrLine").Count > 0)
                            {
                                pacs.CdtrAdrLine = elemCdtr.GetElementsByTagName("AdrLine").Item(0).InnerText;
                            }

                        }
                        if (elemOrgnlTxRef.GetElementsByTagName("CdtrAcct").Count > 0)
                        {
                            XmlElement elemCdtrAcct = (XmlElement)elemOrgnlTxRef.GetElementsByTagName("CdtrAcct").Item(0);
                            if (elemCdtrAcct.GetElementsByTagName("Othr").Count > 0)
                            {
                                XmlElement elemCdtrAcctOthr = (XmlElement)elemCdtrAcct.GetElementsByTagName("Othr").Item(0);
                                pacs.CdtrAcctId = elemCdtrAcctOthr.GetElementsByTagName("Id").Item(0).InnerText;
                            }
                        }
                      
                    }
                }
            }


            //--------------------------
            /*
            if (doc.GetElementsByTagName("RtrRsnOrgtrNm").Count > 0)
            {
                pacs.RtrRsnOrgtrNm = doc.GetElementsByTagName("RtrRsnOrgtrNm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("RtrRsnCd").Count > 0)
            {
                pacs.RtrRsnCd = doc.GetElementsByTagName("RtrRsnCd").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("ChrgsInfBICFI").Count > 0)
            {
                pacs.ChrgsInfBICFI = doc.GetElementsByTagName("ChrgsInfBICFI").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("ChrgsInfNm").Count > 0)
            {
                pacs.ChrgsInfNm = doc.GetElementsByTagName("ChrgsInfNm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("ChrgsInfBranchId").Count > 0)
            {
                pacs.ChrgsInfBranchId = doc.GetElementsByTagName("ChrgsInfBranchId").Item(0).InnerText;
            }
            */
            //--------------------------

            if (doc.GetElementsByTagName("RmtInfUstrd").Count > 0)
            {
                pacs.RmtInfUstrd = doc.GetElementsByTagName("RmtInfUstrd").Item(0).InnerText;
            }


            if (doc.GetElementsByTagName("CdtrAcct").Count > 0)
            {
                XmlElement elemCdtrAcct = (XmlElement)doc.GetElementsByTagName("CdtrAcct").Item(0);

                if (elemCdtrAcct.GetElementsByTagName("Prtry").Count > 0)
                {
                    pacs.CdtrAcctTpPrtry = elemCdtrAcct.GetElementsByTagName("Prtry").Item(0).InnerText;
                }

                XmlElement elemCdtrAcctOthr = (XmlElement) elemCdtrAcct.GetElementsByTagName("Othr").Item(0);

                if (elemCdtrAcctOthr.GetElementsByTagName("Id").Count > 0)
                {
                    pacs.CdtrAcctId = elemCdtrAcctOthr.GetElementsByTagName("Id").Item(0).InnerText;
                } 

            }


            db.InsertInward004(pacs);
        }
        public void LoadCamt52(string FileName, string xmlstr)
        {
            Camt052 camt = new Camt052();
            TeamGreenDB data = new TeamGreenDB();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;

            if (doc.GetElementsByTagName("BizMsgIdr").Count > 0)
            {
                camt.BizMsgIdr = doc.GetElementsByTagName("BizMsgIdr").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDt").Count > 0)
            {
                camt.CreDt = doc.GetElementsByTagName("CreDt").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                camt.MsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Rpt").Count > 0)
            {
                XmlElement elemRpt = (XmlElement)doc.GetElementsByTagName("Rpt").Item(0);
                if (elemRpt.GetElementsByTagName("Id").Count > 0)
                {
                    camt.RptID= elemRpt.GetElementsByTagName("Id").Item(0).InnerText;
                }
                if (elemRpt.GetElementsByTagName("ElctrncSeqNb").Count > 0)
                {
                    camt.ElctrncSeqNb = elemRpt.GetElementsByTagName("ElctrncSeqNb").Item(0).InnerText;
                }
                if (elemRpt.GetElementsByTagName("Acct").Count > 0)
                {
                    XmlElement elemAcct = (XmlElement)doc.GetElementsByTagName("Acct").Item(0);
                    if (elemAcct.GetElementsByTagName("Othr").Count > 0)
                    {
                        XmlElement elemOthr = (XmlElement)elemAcct.GetElementsByTagName("Othr").Item(0);
                        camt.AcctId = elemOthr.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                    if (elemAcct.GetElementsByTagName("AnyBIC").Count > 0)
                    {
                        camt.AcctBIC = elemAcct.GetElementsByTagName("AnyBIC").Item(0).InnerText;
                    }
                }

                if (elemRpt.GetElementsByTagName("Bal").Count > 0)
                {
                    if (elemRpt.GetElementsByTagName("Cd").Count > 0)
                    {
                        camt.BalCD1 = elemRpt.GetElementsByTagName("Cd").Item(0).InnerText;
                    }
                    if (elemRpt.GetElementsByTagName("Amt").Count > 0)
                    {
                        camt.Ccy1 = elemRpt.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                        camt.BalAmnt1 = Decimal.Parse(elemRpt.GetElementsByTagName("Amt").Item(0).InnerText);
                    }
                    if (elemRpt.GetElementsByTagName("CdtDbtInd").Count > 0)
                    {
                        camt.CdtDbtInd1 = elemRpt.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                    }
                    //--------------------------
                    if (elemRpt.GetElementsByTagName("Cd").Count > 1)
                    {
                        camt.BalCD2 = elemRpt.GetElementsByTagName("Cd").Item(1).InnerText;
                    }
                    if (elemRpt.GetElementsByTagName("Amt").Count > 1)
                    {
                        camt.Ccy2 = elemRpt.GetElementsByTagName("Amt").Item(1).Attributes["Ccy"].Value;
                        camt.BalAmnt2 = Decimal.Parse(elemRpt.GetElementsByTagName("Amt").Item(1).InnerText);
                    }
                    if (elemRpt.GetElementsByTagName("CdtDbtInd").Count > 1)
                    {
                        camt.CdtDbtInd2 = elemRpt.GetElementsByTagName("CdtDbtInd").Item(1).InnerText;
                    }
                    //-------------------------------------
                    if (elemRpt.GetElementsByTagName("Cd").Count > 2)
                    {
                        camt.BalCD3 = elemRpt.GetElementsByTagName("Cd").Item(2).InnerText;
                    }
                    if (elemRpt.GetElementsByTagName("Amt").Count > 2)
                    {
                        camt.Ccy3 = elemRpt.GetElementsByTagName("Amt").Item(2).Attributes["Ccy"].Value;
                        camt.BalAmnt3 = Decimal.Parse(elemRpt.GetElementsByTagName("Amt").Item(2).InnerText);
                    }
                    if (elemRpt.GetElementsByTagName("CdtDbtInd").Count > 2)
                    {
                        camt.CdtDbtInd3 = elemRpt.GetElementsByTagName("CdtDbtInd").Item(2).InnerText;
                    }
                    //---------------------------------------
                }

            }

            camt.XmlData = doc.OuterXml;
            data.InsertCamt52(camt);
            doc = null;
        }
        public void LoadCamt53(string FileName, string xmlstr)
        {
            Camt053 camt = new Camt053();
            TeamGreenDB data = new TeamGreenDB();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;

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
            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                camt.MsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDtTm").Count > 0)
            {
                camt.CreDtTm = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("Stmt").Count > 0)
            {
                XmlElement elemStmt = (XmlElement)doc.GetElementsByTagName("Stmt").Item(0);
                if (elemStmt.GetElementsByTagName("Id").Count > 0)
                {
                    camt.StmtId = elemStmt.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("PgNb").Count > 0)
            {
                try
                {
                    camt.StmtPgNb = Int32.Parse(doc.GetElementsByTagName("PgNb").Item(0).InnerText);
                }
                catch { }
            }
            if (doc.GetElementsByTagName("LastPgInd").Count > 0)
            {
                camt.LastPgInd = doc.GetElementsByTagName("LastPgInd").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("ElctrncSeqNb").Count > 0)
            {
                try
                {
                    camt.ElctrncSeqNb = Int32.Parse(doc.GetElementsByTagName("ElctrncSeqNb").Item(0).InnerText);
                }
                catch { }
            }

            if (doc.GetElementsByTagName("CreDtTm").Count > 0)
            {
                camt.StmtCreDtTm = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("Acct").Count > 0)
            {
                XmlElement elemAcct = (XmlElement)doc.GetElementsByTagName("Acct").Item(0);

                if (elemAcct.GetElementsByTagName("Id").Count > 0)
                {
                    camt.StmtAcctId = elemAcct.GetElementsByTagName("Id").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Ownr").Count > 0)
            {
                XmlElement elemOwnr = (XmlElement)doc.GetElementsByTagName("Ownr").Item(0);
                if (elemOwnr.GetElementsByTagName("AnyBIC").Count > 0)
                {
                    camt.OwnrOrgIdAnyBIC = elemOwnr.GetElementsByTagName("AnyBIC").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Bal").Count > 0)
            {
                XmlElement elemBal1 = (XmlElement)doc.GetElementsByTagName("Bal").Item(0);

                if (elemBal1.GetElementsByTagName("Cd").Count > 0)
                {
                    camt.Bal1TpCd = elemBal1.GetElementsByTagName("Cd").Item(0).InnerText;
                }
                if (elemBal1.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.Bal1Ccy = elemBal1.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                try
                {
                    camt.Bal1Amount = decimal.Parse(elemBal1.GetElementsByTagName("Amt").Item(0).InnerText);
                }
                catch{ }


                if (elemBal1.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.Bal1CdtDbtInd = elemBal1.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
                if (elemBal1.GetElementsByTagName("Dt").Count > 0)
                {
                    camt.Bal1Dt = doc.GetElementsByTagName("Dt").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Bal").Count > 1)
            {
                XmlElement elemBal2 = (XmlElement)doc.GetElementsByTagName("Bal").Item(1);
                if (elemBal2.GetElementsByTagName("Cd").Count > 0)
                {
                    camt.Bal2TpCd = elemBal2.GetElementsByTagName("Cd").Item(0).InnerText;
                }
                if (elemBal2.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.Bal2Ccy = elemBal2.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                try
                {
                    camt.Bal2Amount = decimal.Parse(elemBal2.GetElementsByTagName("Amt").Item(0).InnerText);
                }
                catch { }

                if (elemBal2.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.Bal2CdtDbtInd = elemBal2.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
                if (elemBal2.GetElementsByTagName("Dt").Count > 0)
                {
                    camt.Bal2Dt = doc.GetElementsByTagName("Dt").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Ntry").Count > 0)
            {
                XmlElement elemNtry = (XmlElement)doc.GetElementsByTagName("Ntry").Item(0);

                if (elemNtry.GetElementsByTagName("NtryRef").Count > 0)
                {
                    camt.NtryRef1 = elemNtry.GetElementsByTagName("NtryRef").Item(0).InnerText;
                }
                if (elemNtry.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.NtryRef1Ccy = elemNtry.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                try
                {
                    camt.NtryRef1Amout = decimal.Parse(elemNtry.GetElementsByTagName("Amt").Item(0).InnerText);
                }
                catch { }

                if (elemNtry.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.NtryRef1CdtDbtInd = elemNtry.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
                if (elemNtry.GetElementsByTagName("Sts").Count > 0)
                {
                    camt.NtryRef1Sts = elemNtry.GetElementsByTagName("Sts").Item(0).InnerText;
                }
                if (elemNtry.GetElementsByTagName("ValDt").Count > 0)
                {
                    camt.NtryRef1ValDt = elemNtry.GetElementsByTagName("ValDt").Item(0).InnerText;
                }
                if (elemNtry.GetElementsByTagName("Cd").Count > 0)
                {
                    try
                    {
                        camt.BkTxCd1 = Int32.Parse(elemNtry.GetElementsByTagName("Cd").Item(0).InnerText);
                    }
                    catch { }
                }
                if (elemNtry.GetElementsByTagName("Cd").Count > 0)
                {
                    try
                    {
                        camt.BkTxCd1 = Int32.Parse(elemNtry.GetElementsByTagName("Cd").Item(0).InnerText);
                    }
                    catch { }
                }
            }
            if (doc.GetElementsByTagName("NtryDtls").Count > 0)
            {
                XmlElement elemNtryDtls = (XmlElement)doc.GetElementsByTagName("NtryDtls").Item(0);
                if (elemNtryDtls.GetElementsByTagName("AcctSvcrRef").Count > 0)
                {
                    camt.AcctSvcrRef1 = elemNtryDtls.GetElementsByTagName("AcctSvcrRef").Item(0).InnerText;
                }
                if (elemNtryDtls.GetElementsByTagName("InstrId").Count > 0)
                {
                    camt.InstrId1 = elemNtryDtls.GetElementsByTagName("InstrId").Item(0).InnerText;
                }
                if (elemNtryDtls.GetElementsByTagName("EndToEndId").Count > 0)
                {
                    camt.EndToEndId1 = elemNtryDtls.GetElementsByTagName("EndToEndId").Item(0).InnerText;
                }
                if (elemNtryDtls.GetElementsByTagName("TxId").Count > 0)
                {
                    camt.TxId1 = elemNtryDtls.GetElementsByTagName("TxId").Item(0).InnerText;
                }
                if (elemNtryDtls.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.NtryDtls1Ccy = elemNtryDtls.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                if (elemNtryDtls.GetElementsByTagName("Amt").Count > 0)
                {
                    try
                    {
                        camt.NtryDtls1Amount = decimal.Parse(elemNtryDtls.GetElementsByTagName("Amt").Item(0).InnerText);
                    }
                    catch { }
                }
                if (elemNtryDtls.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.NtryDtls1CdtDbtInd = elemNtryDtls.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
            }
            if (doc.GetElementsByTagName("Ntry").Count > 1)
            {
                XmlElement elemNtry2 = (XmlElement)doc.GetElementsByTagName("Ntry").Item(1);

                if (elemNtry2.GetElementsByTagName("NtryRef").Count > 0)
                {
                    camt.NtryRef2 = elemNtry2.GetElementsByTagName("NtryRef").Item(0).InnerText;
                }
                if (elemNtry2.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.NtryRef2Ccy = elemNtry2.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                if (elemNtry2.GetElementsByTagName("Amt").Count > 0)
                {
                    try
                    {
                        camt.NtryRef2Amout = decimal.Parse(elemNtry2.GetElementsByTagName("Amt").Item(0).InnerText);
                    }
                    catch { }
                }
                if (elemNtry2.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.NtryRef2CdtDbtInd = elemNtry2.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
                if (elemNtry2.GetElementsByTagName("Sts").Count > 0)
                {
                    camt.NtryRef2Sts = elemNtry2.GetElementsByTagName("Sts").Item(0).InnerText;
                }
                if (elemNtry2.GetElementsByTagName("ValDt").Count > 0)
                {
                    camt.NtryRef2ValDt = elemNtry2.GetElementsByTagName("ValDt").Item(0).InnerText;
                }
                if (elemNtry2.GetElementsByTagName("Cd").Count > 0)
                {
                    try
                    {
                        camt.BkTxCd2 = Int32.Parse(elemNtry2.GetElementsByTagName("Cd").Item(0).InnerText);
                    }
                    catch { }
                }
            }
            if (doc.GetElementsByTagName("NtryDtls").Count > 0)
            {
                XmlElement elemNtryDtls2 = (XmlElement)doc.GetElementsByTagName("NtryDtls").Item(0);

                if (elemNtryDtls2.GetElementsByTagName("AcctSvcrRef").Count > 0)
                {
                    try
                    {
                        camt.AcctSvcrRef2 = elemNtryDtls2.GetElementsByTagName("AcctSvcrRef").Item(0).InnerText;
                    }
                    catch { }
                }
                if (elemNtryDtls2.GetElementsByTagName("InstrId").Count > 0)
                {
                    camt.InstrId2 = elemNtryDtls2.GetElementsByTagName("InstrId").Item(0).InnerText;
                }
                if (elemNtryDtls2.GetElementsByTagName("EndToEndId").Count > 0)
                {
                    camt.EndToEndId2 = elemNtryDtls2.GetElementsByTagName("EndToEndId").Item(0).InnerText;
                }
                if (elemNtryDtls2.GetElementsByTagName("TxId").Count > 0)
                {
                    camt.TxId2 = elemNtryDtls2.GetElementsByTagName("TxId").Item(0).InnerText;
                }
                if (elemNtryDtls2.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.NtryDtls2Ccy = elemNtryDtls2.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }
                if (elemNtryDtls2.GetElementsByTagName("Amt").Count > 0)
                {
                    try
                    {
                        camt.NtryDtls2Amount = decimal.Parse(elemNtryDtls2.GetElementsByTagName("Amt").Item(0).InnerText);
                    }
                    catch { }
                }
                if (elemNtryDtls2.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.NtryDtls2CdtDbtInd = elemNtryDtls2.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }
            }
            camt.XmlData = doc.OuterXml;
            data.InsertCamt53(camt);
            doc = null;
        }
        public void LoadCamt54(string FileName, string xmlstr)
        {
            Camt54 camt = new Camt54();
            TeamGreenDB data = new TeamGreenDB();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);

            camt.FileName = FileName;
            
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

            if (doc.GetElementsByTagName("MsgId").Count > 0)
            {
                camt.MsgId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
            }
            if (doc.GetElementsByTagName("CreDtTm").Count > 0)
            {
                camt.CreDtTm = doc.GetElementsByTagName("CreDtTm").Item(0).InnerText;
            }

            if (doc.GetElementsByTagName("Ntfctn").Count > 0)
            {
                XmlElement elemNtfctn = (XmlElement)doc.GetElementsByTagName("Ntfctn").Item(0);

                if (elemNtfctn.GetElementsByTagName("Id").Count > 0)
                {
                    camt.NtfctnId = elemNtfctn.GetElementsByTagName("Id").Item(0).InnerText;
                }
                if (elemNtfctn.GetElementsByTagName("CreDtTm").Count > 0)
                {
                    camt.NtfctnCreDtTm = elemNtfctn.GetElementsByTagName("CreDtTm").Item(0).InnerText;
                }

                if (doc.GetElementsByTagName("Acct").Count > 0)
                {
                    XmlElement elemAcct = (XmlElement)doc.GetElementsByTagName("Acct").Item(0);
                    if (elemAcct.GetElementsByTagName("Id").Count > 0)
                    {
                        camt.NtfctnAcctId = elemAcct.GetElementsByTagName("Id").Item(0).InnerText;
                    }
                }
            }
            if (doc.GetElementsByTagName("Ntry").Count > 0)
            {
                XmlElement elemNtry = (XmlElement)doc.GetElementsByTagName("Ntry").Item(0);

                if (elemNtry.GetElementsByTagName("NtryRef").Count > 0)
                {
                    camt.NtryRef = elemNtry.GetElementsByTagName("NtryRef").Item(0).InnerText;
                }

                if (elemNtry.GetElementsByTagName("Amt").Count > 0)
                {
                    camt.NtryCcy = elemNtry.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                }

                if (elemNtry.GetElementsByTagName("Amt").Count > 0)
                {
                    try
                    {
                        camt.NtryAmt = decimal.Parse(elemNtry.GetElementsByTagName("Amt").Item(0).InnerText);
                    }
                    catch { }
                }

                if (elemNtry.GetElementsByTagName("CdtDbtInd").Count > 0)
                {
                    camt.NtryCdtDbtInd = elemNtry.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                }

                if (elemNtry.GetElementsByTagName("Sts").Count > 0)
                {
                    camt.NtrySts = elemNtry.GetElementsByTagName("Sts").Item(0).InnerText;
                }

                if (elemNtry.GetElementsByTagName("Dt").Count > 0)
                {
                    camt.NtryValDt = elemNtry.GetElementsByTagName("Dt").Item(0).InnerText;

                }
                if (elemNtry.GetElementsByTagName("Cd").Count > 0)
                {
                    camt.NtryBkTxCd = elemNtry.GetElementsByTagName("Cd").Item(0).InnerText;
                }
            }

            if (doc.GetElementsByTagName("NtryDtls").Count > 0)
            {
                XmlElement elemNtryDtls = (XmlElement)doc.GetElementsByTagName("NtryDtls").Item(0);

                if (elemNtryDtls.GetElementsByTagName("TxDtls").Count > 0)
                {
                    XmlElement elemTxDtls = (XmlElement)elemNtryDtls.GetElementsByTagName("TxDtls").Item(0);

                    if (elemTxDtls.GetElementsByTagName("InstrId").Count > 0)
                    {
                        camt.NtryDtlsInstrId = elemTxDtls.GetElementsByTagName("InstrId").Item(0).InnerText;
                    }
                    if (elemTxDtls.GetElementsByTagName("EndToEndId").Count > 0)
                    {
                        camt.NtryDtlsEndToEndId = elemTxDtls.GetElementsByTagName("EndToEndId").Item(0).InnerText;
                    }
                    if (elemTxDtls.GetElementsByTagName("TxId").Count > 0)
                    {
                        camt.NtryDtlsTxId = elemTxDtls.GetElementsByTagName("TxId").Item(0).InnerText;
                    }
                    if (elemTxDtls.GetElementsByTagName("Amt").Count > 0)
                    {
                        camt.NtryDtlsCcy = elemTxDtls.GetElementsByTagName("Amt").Item(0).Attributes["Ccy"].Value;
                    }
                    if (elemTxDtls.GetElementsByTagName("Amt").Count > 0)
                    {
                        try
                        {
                            camt.NtryDtlsAmount = decimal.Parse(elemTxDtls.GetElementsByTagName("Amt").Item(0).InnerText);
                        }
                        catch { }
                    }
                    if (elemTxDtls.GetElementsByTagName("CdtDbtInd").Count > 0)
                    {
                        camt.NtryDtlsCdtDbtInd = elemTxDtls.GetElementsByTagName("CdtDbtInd").Item(0).InnerText;
                    }

                    if (elemTxDtls.GetElementsByTagName("InitgPty").Count > 0)
                    {
                        XmlElement elemInitgPty = (XmlElement)elemTxDtls.GetElementsByTagName("InitgPty").Item(0);
                        if (elemInitgPty.GetElementsByTagName("Nm").Count > 0)
                        {
                            camt.NtryDtlsInitgPtyNm = elemInitgPty.GetElementsByTagName("Nm").Item(0).InnerText;
                        }
                    }

                    if (elemTxDtls.GetElementsByTagName("Cdtr").Count > 0)
                    {
                        XmlElement elemCdtr = (XmlElement)elemTxDtls.GetElementsByTagName("Cdtr").Item(0);
                        if (elemCdtr.GetElementsByTagName("AnyBIC").Count > 0)
                        {
                            camt.CdtrAnyBIC = elemCdtr.GetElementsByTagName("AnyBIC").Item(0).InnerText;
                        }
                    }
                    if (elemTxDtls.GetElementsByTagName("Dbtr").Count > 0)
                    {
                        XmlElement elemDbtr = (XmlElement)elemTxDtls.GetElementsByTagName("Dbtr").Item(0);
                        if (elemDbtr.GetElementsByTagName("AnyBIC").Count > 0)
                        {
                            camt.DbtrAnyBIC = elemDbtr.GetElementsByTagName("AnyBIC").Item(0).InnerText;
                        }
                    }
                    if (elemTxDtls.GetElementsByTagName("RltdDts").Count > 0)
                    {
                        XmlElement elemRltdDts = (XmlElement)elemTxDtls.GetElementsByTagName("Dbtr").Item(0);
                        if (elemTxDtls.GetElementsByTagName("TxDtTm").Count > 0)
                        {
                            camt.RltdDtsTxDtTm = elemTxDtls.GetElementsByTagName("TxDtTm").Item(0).InnerText;
                        }
                    }
                }
            }
            camt.XmlData = doc.OuterXml;
            data.InsertCamt54(camt);
            doc = null;
        }//End Method
    }// End Class
} //End Namespace
