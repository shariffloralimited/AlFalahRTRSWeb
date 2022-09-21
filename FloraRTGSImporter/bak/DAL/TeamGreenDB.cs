using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamGreenDB
    {
        public void InsertInward004(Pacs004 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertInward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = pacs.FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 20);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 25);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 22);
            parameterBizMsgIdr.Value = pacs.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 20);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 17);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = pacs.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterBtchBookg = new SqlParameter("@BtchBookg", SqlDbType.VarChar, 8);
            parameterBtchBookg.Value = pacs.BtchBookg;
            myCommand.Parameters.Add(parameterBtchBookg);

            SqlParameter parameterBtchBookgID = new SqlParameter("@BtchBookgID", SqlDbType.UniqueIdentifier);
            parameterBtchBookgID.Value = new Guid(pacs.BtchBookgID);
            myCommand.Parameters.Add(parameterBtchBookgID);

            SqlParameter parameterTtlIntrBkSttlmAmt = new SqlParameter("@TtlIntrBkSttlmAmt", SqlDbType.Money);
            parameterTtlIntrBkSttlmAmt.Value = pacs.TtlIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterTtlIntrBkSttlmAmt);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterOrgnlMsgId = new SqlParameter("@OrgnlMsgId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgId.Value = pacs.OrgnlMsgId;
            myCommand.Parameters.Add(parameterOrgnlMsgId);

            SqlParameter parameterOrgnlMsgNmId = new SqlParameter("@OrgnlMsgNmId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgNmId.Value = pacs.OrgnlMsgNmId;
            myCommand.Parameters.Add(parameterOrgnlMsgNmId);

            SqlParameter parameterOrgnlCreDtTm = new SqlParameter("@OrgnlCreDtTm", SqlDbType.VarChar, 30);
            parameterOrgnlCreDtTm.Value = pacs.OrgnlCreDtTm;
            myCommand.Parameters.Add(parameterOrgnlCreDtTm);

            SqlParameter parameterRtrRsnOrgtrNm = new SqlParameter("@RtrRsnOrgtrNm", SqlDbType.VarChar, 140);
            parameterRtrRsnOrgtrNm.Value = pacs.RtrRsnOrgtrNm;
            myCommand.Parameters.Add(parameterRtrRsnOrgtrNm);

            SqlParameter parameterRtrRsnCd = new SqlParameter("@RtrRsnCd", SqlDbType.VarChar, 10);
            parameterRtrRsnCd.Value = pacs.RtrRsnCd;
            myCommand.Parameters.Add(parameterRtrRsnCd);

            SqlParameter parameterRtrRsnPrtry = new SqlParameter("@RtrRsnPrtry", SqlDbType.VarChar, 35);
            parameterRtrRsnPrtry.Value = pacs.RtrRsnPrtry;
            myCommand.Parameters.Add(parameterRtrRsnPrtry);

            SqlParameter parameterRtrRsnAddtlInf = new SqlParameter("@RtrRsnAddtlInf", SqlDbType.VarChar, 105);
            parameterRtrRsnAddtlInf.Value = pacs.RtrRsnAddtlInf;
            myCommand.Parameters.Add(parameterRtrRsnAddtlInf);

            SqlParameter parameterRtrId = new SqlParameter("@RtrId", SqlDbType.VarChar, 35);
            parameterRtrId.Value = pacs.RtrId;
            myCommand.Parameters.Add(parameterRtrId);

            SqlParameter parameterOrgnlInstrId = new SqlParameter("@OrgnlInstrId", SqlDbType.VarChar, 35);
            parameterOrgnlInstrId.Value = pacs.OrgnlInstrId;
            myCommand.Parameters.Add(parameterOrgnlInstrId);

            SqlParameter parameterOrgnlEndToEndId = new SqlParameter("@OrgnlEndToEndId", SqlDbType.VarChar, 35);
            parameterOrgnlEndToEndId.Value = pacs.OrgnlEndToEndId;
            myCommand.Parameters.Add(parameterOrgnlEndToEndId);

            SqlParameter parameterOrgnlTxId = new SqlParameter("@OrgnlTxId", SqlDbType.VarChar, 35);
            parameterOrgnlTxId.Value = pacs.OrgnlTxId;
            myCommand.Parameters.Add(parameterOrgnlTxId);

            SqlParameter parameterRtrdIntrBkSttlmCcy = new SqlParameter("@RtrdIntrBkSttlmCcy", SqlDbType.VarChar, 3);
            parameterRtrdIntrBkSttlmCcy.Value = pacs.RtrdIntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterRtrdIntrBkSttlmCcy);

            SqlParameter parameterRtrdIntrBkSttlmAmt = new SqlParameter("@RtrdIntrBkSttlmAmt", SqlDbType.Money);
            parameterRtrdIntrBkSttlmAmt.Value = pacs.RtrdIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterRtrdIntrBkSttlmAmt);

            SqlParameter parameterTxInfIntrBkSttlmDt = new SqlParameter("@TxInfIntrBkSttlmDt", SqlDbType.VarChar, 30);
            parameterTxInfIntrBkSttlmDt.Value = pacs.TxInfIntrBkSttlmDt;
            myCommand.Parameters.Add(parameterTxInfIntrBkSttlmDt);

            SqlParameter parameterChrgBr = new SqlParameter("@ChrgBr", SqlDbType.VarChar, 4);
            parameterChrgBr.Value = pacs.ChrgBr;
            myCommand.Parameters.Add(parameterChrgBr);

            SqlParameter parameterChrgsInfBICFI = new SqlParameter("@ChrgsInfBICFI", SqlDbType.VarChar, 8);
            parameterChrgsInfBICFI.Value = pacs.ChrgsInfBICFI;
            myCommand.Parameters.Add(parameterChrgsInfBICFI);

            SqlParameter parameterChrgsInfNm = new SqlParameter("@ChrgsInfNm", SqlDbType.VarChar, 15);
            parameterChrgsInfNm.Value = pacs.ChrgsInfNm;
            myCommand.Parameters.Add(parameterChrgsInfNm);

            SqlParameter parameterChrgsInfBranchId = new SqlParameter("@ChrgsInfBranchId", SqlDbType.VarChar, 25);
            parameterChrgsInfBranchId.Value = pacs.ChrgsInfBranchId;
            myCommand.Parameters.Add(parameterChrgsInfBranchId);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterTxRefIntrBkSttlmCcy = new SqlParameter("@TxRefIntrBkSttlmCcy", SqlDbType.VarChar, 7);
            parameterTxRefIntrBkSttlmCcy.Value = pacs.TxRefIntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmCcy);

            SqlParameter parameterTxRefIntrBkSttlmAmt = new SqlParameter("@TxRefIntrBkSttlmAmt", SqlDbType.Money);
            parameterTxRefIntrBkSttlmAmt.Value = pacs.TxRefIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmAmt);

            SqlParameter parameterTxRefIntrBkSttlmDt = new SqlParameter("@TxRefIntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterTxRefIntrBkSttlmDt.Value = pacs.TxRefIntrBkSttlmDt;
            myCommand.Parameters.Add(parameterTxRefIntrBkSttlmDt);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.Int);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterPmtMtd = new SqlParameter("@PmtMtd", SqlDbType.VarChar, 4);
            parameterPmtMtd.Value = pacs.PmtMtd;
            myCommand.Parameters.Add(parameterPmtMtd);

            SqlParameter parameterRmtInfUstrd = new SqlParameter("@RmtInfUstrd", SqlDbType.VarChar, 140);
            parameterRmtInfUstrd.Value = pacs.RmtInfUstrd;
            myCommand.Parameters.Add(parameterRmtInfUstrd);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 50);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrNmPstlAdr = new SqlParameter("@DbtrNmPstlAdr", SqlDbType.VarChar, 30);
            parameterDbtrNmPstlAdr.Value = pacs.DbtrNmPstlAdr;
            myCommand.Parameters.Add(parameterDbtrNmPstlAdr);

            SqlParameter parameterDbtrNmStrtNm = new SqlParameter("@DbtrNmStrtNm", SqlDbType.VarChar, 15);
            parameterDbtrNmStrtNm.Value = pacs.DbtrNmStrtNm;
            myCommand.Parameters.Add(parameterDbtrNmStrtNm);

            SqlParameter parameterDbtrNmTwnNm = new SqlParameter("@DbtrNmTwnNm", SqlDbType.VarChar, 15);
            parameterDbtrNmTwnNm.Value = pacs.DbtrNmTwnNm;
            myCommand.Parameters.Add(parameterDbtrNmTwnNm);

            SqlParameter parameterDbtrNmCtry = new SqlParameter("@DbtrNmCtry", SqlDbType.VarChar, 15);
            parameterDbtrNmCtry.Value = pacs.DbtrNmCtry;
            myCommand.Parameters.Add(parameterDbtrNmCtry);

            SqlParameter parameterDbtrNmAdrLine = new SqlParameter("@DbtrNmAdrLine", SqlDbType.VarChar, 70);
            parameterDbtrNmAdrLine.Value = pacs.DbtrNmAdrLine;
            myCommand.Parameters.Add(parameterDbtrNmAdrLine);

            SqlParameter parameterDbtrAcctId = new SqlParameter("@DbtrAcctId", SqlDbType.VarChar, 24);
            parameterDbtrAcctId.Value = pacs.DbtrAcctId;
            myCommand.Parameters.Add(parameterDbtrAcctId);

            SqlParameter parameterDbtrAcctTpPrtry = new SqlParameter("@DbtrAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAcctTpPrtry.Value = pacs.DbtrAcctTpPrtry;
            myCommand.Parameters.Add(parameterDbtrAcctTpPrtry);

            SqlParameter parameterDbtrAgtBICFINm = new SqlParameter("@DbtrAgtBICFINm", SqlDbType.VarChar, 140);
            parameterDbtrAgtBICFINm.Value = pacs.DbtrAgtBICFINm;
            myCommand.Parameters.Add(parameterDbtrAgtBICFINm);

            SqlParameter parameterDbtrAgtBICFI = new SqlParameter("@DbtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterDbtrAgtBICFI.Value = pacs.DbtrAgtBICFI;
            myCommand.Parameters.Add(parameterDbtrAgtBICFI);

            SqlParameter parameterDbtrAgtBranchId = new SqlParameter("@DbtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterDbtrAgtBranchId.Value = pacs.DbtrAgtBranchId;
            myCommand.Parameters.Add(parameterDbtrAgtBranchId);

            SqlParameter parameterDbtrAgtAcctId = new SqlParameter("@DbtrAgtAcctId", SqlDbType.VarChar, 24);
            parameterDbtrAgtAcctId.Value = pacs.DbtrAgtAcctId;
            myCommand.Parameters.Add(parameterDbtrAgtAcctId);

            SqlParameter parameterDbtrAgtAcctPrtry = new SqlParameter("@DbtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctPrtry.Value = pacs.DbtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterDbtrAgtAcctPrtry);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtNm = new SqlParameter("@CdtrAgtNm", SqlDbType.VarChar, 140);
            parameterCdtrAgtNm.Value = pacs.CdtrAgtNm;
            myCommand.Parameters.Add(parameterCdtrAgtNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctId = new SqlParameter("@CdtrAgtAcctId", SqlDbType.VarChar, 24);
            parameterCdtrAgtAcctId.Value = pacs.CdtrAgtAcctId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctId);

            SqlParameter parameterCdtrAgtAcctTpPrtry = new SqlParameter("@CdtrAgtAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctTpPrtry.Value = pacs.CdtrAgtAcctTpPrtry;
            myCommand.Parameters.Add(parameterCdtrAgtAcctTpPrtry);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 140);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrAdrLine = new SqlParameter("@CdtrAdrLine", SqlDbType.VarChar, 25);
            parameterCdtrAdrLine.Value = pacs.CdtrAdrLine;
            myCommand.Parameters.Add(parameterCdtrAdrLine);

            SqlParameter parameterCdtrAcctId = new SqlParameter("@CdtrAcctId", SqlDbType.VarChar, 24);
            parameterCdtrAcctId.Value = pacs.CdtrAcctId;
            myCommand.Parameters.Add(parameterCdtrAcctId);

            SqlParameter parameterCdtrAcctTpPrtry = new SqlParameter("@CdtrAcctTpPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAcctTpPrtry.Value = pacs.CdtrAcctTpPrtry;
            myCommand.Parameters.Add(parameterCdtrAcctTpPrtry);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt52(Camt052 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt52", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 32);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = camt.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            //------------------------------------

            SqlParameter parameterRptID = new SqlParameter("@RptID", SqlDbType.VarChar, 30);
            parameterRptID.Value = camt.RptID;
            myCommand.Parameters.Add(parameterRptID);

            SqlParameter parameterElctrncSeqNb = new SqlParameter("@ElctrncSeqNb", SqlDbType.VarChar, 30);
            parameterElctrncSeqNb.Value = camt.ElctrncSeqNb;
            myCommand.Parameters.Add(parameterElctrncSeqNb);

            SqlParameter parameterAcctId = new SqlParameter("@AcctId", SqlDbType.VarChar, 30);
            parameterAcctId.Value = camt.AcctId;
            myCommand.Parameters.Add(parameterAcctId);

            SqlParameter parameterAcctBIC = new SqlParameter("@AcctBIC", SqlDbType.VarChar, 30);
            parameterAcctBIC.Value = camt.AcctBIC;
            myCommand.Parameters.Add(parameterAcctBIC);

            SqlParameter parameterBalCD1 = new SqlParameter("@BalCD1", SqlDbType.VarChar, 10);
            parameterBalCD1.Value = camt.BalCD1;
            myCommand.Parameters.Add(parameterBalCD1);

            SqlParameter parameterCcy1 = new SqlParameter("@Ccy1", SqlDbType.VarChar, 3);
            parameterCcy1.Value = camt.Ccy1;
            myCommand.Parameters.Add(parameterCcy1);

            SqlParameter parameterBalAmnt1 = new SqlParameter("@BalAmnt1", SqlDbType.Decimal);
            parameterBalAmnt1.Value = camt.BalAmnt1;
            myCommand.Parameters.Add(parameterBalAmnt1);

            SqlParameter parameterCdtDbtInd1 = new SqlParameter("@CdtDbtInd1", SqlDbType.VarChar, 4);
            parameterCdtDbtInd1.Value = camt.CdtDbtInd1;
            myCommand.Parameters.Add(parameterCdtDbtInd1);

            SqlParameter parameterBalCD2 = new SqlParameter("@BalCD2", SqlDbType.VarChar, 10);
            parameterBalCD2.Value = camt.BalCD2;
            myCommand.Parameters.Add(parameterBalCD2);

            SqlParameter parameterCcy2 = new SqlParameter("@Ccy2", SqlDbType.VarChar, 3);
            parameterCcy2.Value = camt.Ccy2;
            myCommand.Parameters.Add(parameterCcy2);

            SqlParameter parameterBalAmnt2 = new SqlParameter("@BalAmnt2", SqlDbType.Decimal);
            parameterBalAmnt2.Value = camt.BalAmnt2;
            myCommand.Parameters.Add(parameterBalAmnt2);

            SqlParameter parameterCdtDbtInd2 = new SqlParameter("@CdtDbtInd2", SqlDbType.VarChar, 4);
            parameterCdtDbtInd2.Value = camt.CdtDbtInd2;
            myCommand.Parameters.Add(parameterCdtDbtInd2);

            SqlParameter parameterBalCD3 = new SqlParameter("@BalCD3", SqlDbType.VarChar, 10);
            parameterBalCD3.Value = camt.BalCD3;
            myCommand.Parameters.Add(parameterBalCD3);

            SqlParameter parameterCcy3 = new SqlParameter("@Ccy3", SqlDbType.VarChar, 3);
            parameterCcy3.Value = camt.Ccy3;
            myCommand.Parameters.Add(parameterCcy3);

            SqlParameter parameterBalAmnt3 = new SqlParameter("@BalAmnt3", SqlDbType.Decimal);
            parameterBalAmnt3.Value = camt.BalAmnt3;
            myCommand.Parameters.Add(parameterBalAmnt3);

            SqlParameter parameterCdtDbtInd3 = new SqlParameter("@CdtDbtInd3", SqlDbType.VarChar, 4);
            parameterCdtDbtInd3.Value = camt.CdtDbtInd3;
            myCommand.Parameters.Add(parameterCdtDbtInd3);

            //------------------------------------
            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt53(Camt053 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt53", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 8);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 32);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 20);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 17);
            parameterBizSvc.Value = camt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = camt.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = camt.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterStmtId = new SqlParameter("@StmtId", SqlDbType.VarChar, 35);
            parameterStmtId.Value = camt.StmtId;
            myCommand.Parameters.Add(parameterStmtId);

            SqlParameter parameterStmtPgNb = new SqlParameter("@StmtPgNb", SqlDbType.Int);
            parameterStmtPgNb.Value = camt.StmtPgNb;
            myCommand.Parameters.Add(parameterStmtPgNb);

            SqlParameter parameterLastPgInd = new SqlParameter("@LastPgInd", SqlDbType.VarChar, 8);
            parameterLastPgInd.Value = camt.LastPgInd;
            myCommand.Parameters.Add(parameterLastPgInd);

            SqlParameter parameterElctrncSeqNb = new SqlParameter("@ElctrncSeqNb", SqlDbType.Int);
            parameterElctrncSeqNb.Value = camt.ElctrncSeqNb;
            myCommand.Parameters.Add(parameterElctrncSeqNb);

            SqlParameter parameterStmtCreDtTm = new SqlParameter("@StmtCreDtTm", SqlDbType.VarChar, 30);
            parameterStmtCreDtTm.Value = camt.StmtCreDtTm;
            myCommand.Parameters.Add(parameterStmtCreDtTm);

            SqlParameter parameterStmtAcctId = new SqlParameter("@StmtAcctId", SqlDbType.VarChar, 30);
            parameterStmtAcctId.Value = camt.StmtAcctId;
            myCommand.Parameters.Add(parameterStmtAcctId);

            SqlParameter parameterOwnrOrgIdAnyBIC = new SqlParameter("@OwnrOrgIdAnyBIC", SqlDbType.VarChar, 8);
            parameterOwnrOrgIdAnyBIC.Value = camt.OwnrOrgIdAnyBIC;
            myCommand.Parameters.Add(parameterOwnrOrgIdAnyBIC);

            SqlParameter parameterBal1TpCd = new SqlParameter("@Bal1TpCd", SqlDbType.VarChar, 12);
            parameterBal1TpCd.Value = camt.Bal1TpCd;
            myCommand.Parameters.Add(parameterBal1TpCd);

            SqlParameter parameterBal1Ccy = new SqlParameter("@Bal1Ccy", SqlDbType.VarChar, 6);
            parameterBal1Ccy.Value = camt.Bal1Ccy;
            myCommand.Parameters.Add(parameterBal1Ccy);

            SqlParameter parameterBal1Amount = new SqlParameter("@Bal1Amount", SqlDbType.Money);
            parameterBal1Amount.Value = camt.Bal1Amount;
            myCommand.Parameters.Add(parameterBal1Amount);

            SqlParameter parameterBal1CdtDbtInd = new SqlParameter("@Bal1CdtDbtInd", SqlDbType.VarChar, 5);
            parameterBal1CdtDbtInd.Value = camt.Bal1CdtDbtInd;
            myCommand.Parameters.Add(parameterBal1CdtDbtInd);

            SqlParameter parameterBal1Dt = new SqlParameter("@Bal1Dt", SqlDbType.VarChar, 15);
            parameterBal1Dt.Value = camt.Bal1Dt;
            myCommand.Parameters.Add(parameterBal1Dt);

            SqlParameter parameterBal2TpCd = new SqlParameter("@Bal2TpCd", SqlDbType.VarChar, 5);
            parameterBal2TpCd.Value = camt.Bal2TpCd;
            myCommand.Parameters.Add(parameterBal2TpCd);

            SqlParameter parameterBal2Ccy = new SqlParameter("@Bal2Ccy", SqlDbType.VarChar, 6);
            parameterBal2Ccy.Value = camt.Bal2Ccy;
            myCommand.Parameters.Add(parameterBal2Ccy);

            SqlParameter parameterBal2Amount = new SqlParameter("@Bal2Amount", SqlDbType.Money);
            parameterBal2Amount.Value = camt.Bal2Amount;
            myCommand.Parameters.Add(parameterBal2Amount);

            SqlParameter parameterBal2CdtDbtInd = new SqlParameter("@Bal2CdtDbtInd", SqlDbType.VarChar, 5);
            parameterBal2CdtDbtInd.Value = camt.Bal2CdtDbtInd;
            myCommand.Parameters.Add(parameterBal2CdtDbtInd);

            SqlParameter parameterBal2Dt = new SqlParameter("@Bal2Dt", SqlDbType.VarChar, 15);
            parameterBal2Dt.Value = camt.Bal2Dt;
            myCommand.Parameters.Add(parameterBal2Dt);

            SqlParameter parameterNtryRef1 = new SqlParameter("@NtryRef1", SqlDbType.VarChar, 35);
            parameterNtryRef1.Value = camt.NtryRef1;
            myCommand.Parameters.Add(parameterNtryRef1);

            SqlParameter parameterNtryRef1Ccy = new SqlParameter("@NtryRef1Ccy", SqlDbType.VarChar, 6);
            parameterNtryRef1Ccy.Value = camt.NtryRef1Ccy;
            myCommand.Parameters.Add(parameterNtryRef1Ccy);

            SqlParameter parameterNtryRef1Amout = new SqlParameter("@NtryRef1Amout", SqlDbType.Money);
            parameterNtryRef1Amout.Value = camt.NtryRef1Amout;
            myCommand.Parameters.Add(parameterNtryRef1Amout);

            SqlParameter parameterNtryRef1CdtDbtInd = new SqlParameter("@NtryRef1CdtDbtInd", SqlDbType.VarChar, 5);
            parameterNtryRef1CdtDbtInd.Value = camt.NtryRef1CdtDbtInd;
            myCommand.Parameters.Add(parameterNtryRef1CdtDbtInd);

            SqlParameter parameterNtryRef1Sts = new SqlParameter("@NtryRef1Sts", SqlDbType.VarChar, 5);
            parameterNtryRef1Sts.Value = camt.NtryRef1Sts;
            myCommand.Parameters.Add(parameterNtryRef1Sts);

            SqlParameter parameterNtryRef1ValDt = new SqlParameter("@NtryRef1ValDt", SqlDbType.VarChar, 30);
            parameterNtryRef1ValDt.Value = camt.NtryRef1ValDt;
            myCommand.Parameters.Add(parameterNtryRef1ValDt);

            SqlParameter parameterBkTxCd1 = new SqlParameter("@BkTxCd1", SqlDbType.Int);
            parameterBkTxCd1.Value = camt.BkTxCd1;
            myCommand.Parameters.Add(parameterBkTxCd1);

            SqlParameter parameterAcctSvcrRef1 = new SqlParameter("@AcctSvcrRef1", SqlDbType.VarChar, 35);
            parameterAcctSvcrRef1.Value = camt.AcctSvcrRef1;
            myCommand.Parameters.Add(parameterAcctSvcrRef1);

            SqlParameter parameterInstrId1 = new SqlParameter("@InstrId1", SqlDbType.VarChar, 35);
            parameterInstrId1.Value = camt.InstrId1;
            myCommand.Parameters.Add(parameterInstrId1);

            SqlParameter parameterEndToEndId1 = new SqlParameter("@EndToEndId1", SqlDbType.VarChar, 35);
            parameterEndToEndId1.Value = camt.EndToEndId1;
            myCommand.Parameters.Add(parameterEndToEndId1);

            SqlParameter parameterTxId1 = new SqlParameter("@TxId1", SqlDbType.VarChar, 35);
            parameterTxId1.Value = camt.TxId1;
            myCommand.Parameters.Add(parameterTxId1);

            SqlParameter parameterNtryDtls1Ccy = new SqlParameter("@NtryDtls1Ccy", SqlDbType.VarChar, 6);
            parameterNtryDtls1Ccy.Value = camt.NtryDtls1Ccy;
            myCommand.Parameters.Add(parameterNtryDtls1Ccy);

            SqlParameter parameterNtryDtls1Amount = new SqlParameter("@NtryDtls1Amount", SqlDbType.Money);
            parameterNtryDtls1Amount.Value = camt.NtryDtls1Amount;
            myCommand.Parameters.Add(parameterNtryDtls1Amount);

            SqlParameter parameterNtryDtls1CdtDbtInd = new SqlParameter("@NtryDtls1CdtDbtInd", SqlDbType.VarChar, 35);
            parameterNtryDtls1CdtDbtInd.Value = camt.NtryDtls1CdtDbtInd;
            myCommand.Parameters.Add(parameterNtryDtls1CdtDbtInd);

            SqlParameter parameterNtryRef2 = new SqlParameter("@NtryRef2", SqlDbType.VarChar, 35);
            parameterNtryRef2.Value = camt.NtryRef2;
            myCommand.Parameters.Add(parameterNtryRef2);

            SqlParameter parameterNtryRef2Ccy = new SqlParameter("@NtryRef2Ccy", SqlDbType.VarChar, 6);
            parameterNtryRef2Ccy.Value = camt.NtryRef2Ccy;
            myCommand.Parameters.Add(parameterNtryRef2Ccy);

            SqlParameter parameterNtryRef2Amout = new SqlParameter("@NtryRef2Amout", SqlDbType.Money);
            parameterNtryRef2Amout.Value = camt.NtryRef2Amout;
            myCommand.Parameters.Add(parameterNtryRef2Amout);

            SqlParameter parameterNtryRef2CdtDbtInd = new SqlParameter("@NtryRef2CdtDbtInd", SqlDbType.VarChar, 35);
            parameterNtryRef2CdtDbtInd.Value = camt.NtryRef2CdtDbtInd;
            myCommand.Parameters.Add(parameterNtryRef2CdtDbtInd);

            SqlParameter parameterNtryRef2Sts = new SqlParameter("@NtryRef2Sts", SqlDbType.VarChar, 35);
            parameterNtryRef2Sts.Value = camt.NtryRef2Sts;
            myCommand.Parameters.Add(parameterNtryRef2Sts);

            SqlParameter parameterNtryRef2ValDt = new SqlParameter("@NtryRef2ValDt", SqlDbType.VarChar, 30);
            parameterNtryRef2ValDt.Value = camt.NtryRef2ValDt;
            myCommand.Parameters.Add(parameterNtryRef2ValDt);

            SqlParameter parameterBkTxCd2 = new SqlParameter("@BkTxCd2", SqlDbType.Int);
            parameterBkTxCd2.Value = camt.BkTxCd2;
            myCommand.Parameters.Add(parameterBkTxCd2);

            SqlParameter parameterAcctSvcrRef2 = new SqlParameter("@AcctSvcrRef2", SqlDbType.VarChar, 35);
            parameterAcctSvcrRef2.Value = camt.AcctSvcrRef2;
            myCommand.Parameters.Add(parameterAcctSvcrRef2);

            SqlParameter parameterInstrId2 = new SqlParameter("@InstrId2", SqlDbType.VarChar, 35);
            parameterInstrId2.Value = camt.InstrId2;
            myCommand.Parameters.Add(parameterInstrId2);

            SqlParameter parameterEndToEndId2 = new SqlParameter("@EndToEndId2", SqlDbType.VarChar, 35);
            parameterEndToEndId2.Value = camt.EndToEndId2;
            myCommand.Parameters.Add(parameterEndToEndId2);

            SqlParameter parameterTxId2 = new SqlParameter("@TxId2", SqlDbType.VarChar, 35);
            parameterTxId2.Value = camt.TxId2;
            myCommand.Parameters.Add(parameterTxId2);

            SqlParameter parameterNtryDtls2Ccy = new SqlParameter("@NtryDtls2Ccy", SqlDbType.VarChar, 6);
            parameterNtryDtls2Ccy.Value = camt.NtryDtls2Ccy;
            myCommand.Parameters.Add(parameterNtryDtls2Ccy);

            SqlParameter parameterNtryDtls2Amount = new SqlParameter("@NtryDtls2Amount", SqlDbType.Money);
            parameterNtryDtls2Amount.Value = camt.NtryDtls2Amount;
            myCommand.Parameters.Add(parameterNtryDtls2Amount);

            SqlParameter parameterNtryDtls2CdtDbtInd = new SqlParameter("@NtryDtls2CdtDbtInd", SqlDbType.VarChar, 35);
            parameterNtryDtls2CdtDbtInd.Value = camt.NtryDtls2CdtDbtInd;
            myCommand.Parameters.Add(parameterNtryDtls2CdtDbtInd);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt54(Camt54 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt54", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 25);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 32);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 20);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 17);
            parameterBizSvc.Value = camt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = camt.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = camt.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterNtfctnId = new SqlParameter("@NtfctnId", SqlDbType.VarChar, 35);
            parameterNtfctnId.Value = camt.NtfctnId;
            myCommand.Parameters.Add(parameterNtfctnId);

            SqlParameter parameterNtfctnCreDtTm = new SqlParameter("@NtfctnCreDtTm", SqlDbType.VarChar, 30);
            parameterNtfctnCreDtTm.Value = camt.NtfctnCreDtTm;
            myCommand.Parameters.Add(parameterNtfctnCreDtTm);

            SqlParameter parameterNtfctnAcctId = new SqlParameter("@NtfctnAcctId", SqlDbType.VarChar, 35);
            parameterNtfctnAcctId.Value = camt.NtfctnAcctId;
            myCommand.Parameters.Add(parameterNtfctnAcctId);

            SqlParameter parameterNtryRef = new SqlParameter("@NtryRef", SqlDbType.VarChar, 35);
            parameterNtryRef.Value = camt.NtryRef;
            myCommand.Parameters.Add(parameterNtryRef);

            SqlParameter parameterNtryCcy = new SqlParameter("@NtryCcy", SqlDbType.VarChar, 7);
            parameterNtryCcy.Value = camt.NtryCcy;
            myCommand.Parameters.Add(parameterNtryCcy);

            SqlParameter parameterNtryAmt = new SqlParameter("@NtryAmt", SqlDbType.Money);
            parameterNtryAmt.Value = camt.NtryAmt;
            myCommand.Parameters.Add(parameterNtryAmt);

            SqlParameter parameterNtryCdtDbtInd = new SqlParameter("@NtryCdtDbtInd", SqlDbType.VarChar, 15);
            parameterNtryCdtDbtInd.Value = camt.NtryCdtDbtInd;
            myCommand.Parameters.Add(parameterNtryCdtDbtInd);

            SqlParameter parameterNtrySts = new SqlParameter("@NtrySts", SqlDbType.VarChar, 15);
            parameterNtrySts.Value = camt.NtrySts;
            myCommand.Parameters.Add(parameterNtrySts);

            SqlParameter parameterNtryValDt = new SqlParameter("@NtryValDt", SqlDbType.VarChar, 30);
            parameterNtryValDt.Value = camt.NtryValDt;
            myCommand.Parameters.Add(parameterNtryValDt);

            SqlParameter parameterNtryBkTxCd = new SqlParameter("@NtryBkTxCd", SqlDbType.VarChar, 35);
            parameterNtryBkTxCd.Value = camt.NtryBkTxCd;
            myCommand.Parameters.Add(parameterNtryBkTxCd);

            SqlParameter parameterNtryDtlsInstrId = new SqlParameter("@NtryDtlsInstrId", SqlDbType.VarChar, 35);
            parameterNtryDtlsInstrId.Value = camt.NtryDtlsInstrId;
            myCommand.Parameters.Add(parameterNtryDtlsInstrId);

            SqlParameter parameterNtryDtlsEndToEndId = new SqlParameter("@NtryDtlsEndToEndId", SqlDbType.VarChar, 35);
            parameterNtryDtlsEndToEndId.Value = camt.NtryDtlsEndToEndId;
            myCommand.Parameters.Add(parameterNtryDtlsEndToEndId);

            SqlParameter parameterNtryDtlsTxId = new SqlParameter("@NtryDtlsTxId", SqlDbType.VarChar, 35);
            parameterNtryDtlsTxId.Value = camt.NtryDtlsTxId;
            myCommand.Parameters.Add(parameterNtryDtlsTxId);

            SqlParameter parameterNtryDtlsCcy = new SqlParameter("@NtryDtlsCcy", SqlDbType.VarChar, 7);
            parameterNtryDtlsCcy.Value = camt.NtryDtlsCcy;
            myCommand.Parameters.Add(parameterNtryDtlsCcy);

            SqlParameter parameterNtryDtlsAmount = new SqlParameter("@NtryDtlsAmount", SqlDbType.Money);
            parameterNtryDtlsAmount.Value = camt.NtryDtlsAmount;
            myCommand.Parameters.Add(parameterNtryDtlsAmount);

            SqlParameter parameterNtryDtlsCdtDbtInd = new SqlParameter("@NtryDtlsCdtDbtInd", SqlDbType.VarChar, 15);
            parameterNtryDtlsCdtDbtInd.Value = camt.NtryDtlsCdtDbtInd;
            myCommand.Parameters.Add(parameterNtryDtlsCdtDbtInd);

            SqlParameter parameterNtryDtlsInitgPtyAnyBIC = new SqlParameter("@NtryDtlsInitgPtyAnyBIC", SqlDbType.VarChar, 35);
            parameterNtryDtlsInitgPtyAnyBIC.Value = camt.NtryDtlsInitgPtyAnyBIC;
            myCommand.Parameters.Add(parameterNtryDtlsInitgPtyAnyBIC);

            SqlParameter parameterDbtrAnyBIC = new SqlParameter("@DbtrAnyBIC", SqlDbType.VarChar, 35);
            parameterDbtrAnyBIC.Value = camt.DbtrAnyBIC;
            myCommand.Parameters.Add(parameterDbtrAnyBIC);

            SqlParameter parameterCdtrAnyBIC = new SqlParameter("@CdtrAnyBIC", SqlDbType.VarChar, 35);
            parameterCdtrAnyBIC.Value = camt.CdtrAnyBIC;
            myCommand.Parameters.Add(parameterCdtrAnyBIC);

            SqlParameter parameterRltdDtsTxDtTm = new SqlParameter("@RltdDtsTxDtTm", SqlDbType.VarChar, 30);
            parameterRltdDtsTxDtTm.Value = camt.RltdDtsTxDtTm;
            myCommand.Parameters.Add(parameterRltdDtsTxDtTm);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public Pacs004 GetSingleCartOutward04(string OutwardID, string CartID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs004 pacs = new Pacs004();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = outid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID); ;
            myCommand.Parameters.Add(parameterCartID);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                pacs.PacsID = dr["OutwardID"].ToString();
                pacs.DetectTime = dr["DetectTime"].ToString();
                pacs.FrBICFI = (string)dr["FrBICFI"];
                pacs.ToBICFI = (string)dr["ToBICFI"];
                pacs.BizMsgIdr = (string)dr["BizMsgIdr"];
                pacs.MsgDefIdr = (string)dr["MsgDefIdr"];
                pacs.BizSvc = (string)dr["BizSvc"];
                pacs.CreDt = (string)dr["CreDt"];
                pacs.MsgId = (string)dr["MsgId"];
                pacs.CreDtTm = (string)dr["CreDtTm"];
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.OrgnlMsgId = (string)dr["OrgnlMsgId"];
                pacs.OrgnlMsgNmId = (string)dr["OrgnlMsgNmId"];
                pacs.OrgnlCreDtTm = (string)dr["OrgnlCreDtTm"];
                pacs.RtrRsnOrgtrNm = (string)dr["RtrRsnOrgtrNm"];
                pacs.RtrRsnCd = (string)dr["RtrRsnCd"];
                pacs.RtrRsnPrtry = (string)dr["RtrRsnPrtry"];
                pacs.RtrRsnAddtlInf = (string)dr["RtrRsnAddtlInf"];
                pacs.RtrId = (string)dr["RtrId"];
                pacs.OrgnlInstrId = (string)dr["OrgnlInstrId"];
                pacs.OrgnlEndToEndId = (string)dr["OrgnlEndToEndId"];
                pacs.OrgnlTxId = (string)dr["OrgnlTxId"];
                pacs.RtrdIntrBkSttlmCcy = (string)dr["RtrdIntrBkSttlmCcy"];
                pacs.RtrdIntrBkSttlmAmt = (decimal)dr["RtrdIntrBkSttlmAmt"];
                pacs.TxInfIntrBkSttlmDt = (string)dr["TxInfIntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.ChrgsInfBICFI = (string)dr["ChrgsInfBICFI"];
                pacs.ChrgsInfNm = (string)dr["ChrgsInfNm"];
                pacs.ChrgsInfBranchId = (string)dr["ChrgsInfBranchId"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.TxRefIntrBkSttlmCcy = (string)dr["TxRefIntrBkSttlmCcy"];
                pacs.TxRefIntrBkSttlmAmt = (decimal)dr["TxRefIntrBkSttlmAmt"];
                pacs.TxRefIntrBkSttlmDt = (string)dr["TxRefIntrBkSttlmDt"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.PmtMtd = (string)dr["PmtMtd"];
                pacs.RmtInfUstrd = (string)dr["RmtInfUstrd"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrNmPstlAdr = (string)dr["DbtrNmPstlAdr"];
                pacs.DbtrNmStrtNm = (string)dr["DbtrNmStrtNm"];
                pacs.DbtrNmTwnNm = (string)dr["DbtrNmTwnNm"];
                pacs.DbtrNmCtry = (string)dr["DbtrNmCtry"];
                pacs.DbtrNmAdrLine = (string)dr["DbtrNmAdrLine"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTpPrtry = (string)dr["DbtrAcctTpPrtry"];
                pacs.DbtrAgtBICFINm = (string)dr["DbtrAgtBICFINm"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctId = (string)dr["DbtrAgtAcctId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTpPrtry = (string)dr["CdtrAgtAcctTpPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAcctTpPrtry = (string)dr["CdtrAcctTpPrtry"];
                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.DeletedBy = (string)dr["DeletedBy"];
                pacs.DeleteTime = dr["DeleteTime"].ToString();
                pacs.CBSResponse = (string)dr["CBSResponse"];
                pacs.CBSTime = dr["CBSTime"].ToString();
                pacs.StatusID = (int)dr["StatusID"];

            }

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();

            return pacs;

        }

        public void SendOutward04(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = newGuid;
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterAdmin = new SqlParameter("@Admin", SqlDbType.VarChar, 50);
            parameterAdmin.Value = Admin;
            myCommand.Parameters.Add(parameterAdmin);

            SqlParameter parameterAdminIP = new SqlParameter("@AdminIP", SqlDbType.VarChar, 50);
            parameterAdminIP.Value = AdminIP;
            myCommand.Parameters.Add(parameterAdminIP);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
    }
}
