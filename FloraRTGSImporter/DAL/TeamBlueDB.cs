using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamBlueDB
    {
        public void InsertInward009(Pacs009 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertInward09", myConnection);
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

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            parameterBizMsgIdr.Value = pacs.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
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

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 70);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 35);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 70);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterIntrmyAgt1BICFI = new SqlParameter("@IntrmyAgt1BICFI", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BICFI.Value = pacs.IntrmyAgt1BICFI;
            myCommand.Parameters.Add(parameterIntrmyAgt1BICFI);

            SqlParameter parameterIntrmyAgt1Nm = new SqlParameter("@IntrmyAgt1Nm", SqlDbType.VarChar, 70);
            parameterIntrmyAgt1Nm.Value = pacs.IntrmyAgt1Nm;
            myCommand.Parameters.Add(parameterIntrmyAgt1Nm);

            SqlParameter parameterIntrmyAgt1BranchId = new SqlParameter("@IntrmyAgt1BranchId", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1BranchId.Value = pacs.IntrmyAgt1BranchId;
            myCommand.Parameters.Add(parameterIntrmyAgt1BranchId);

            SqlParameter parameterIntrmyAgt1AcctId = new SqlParameter("@IntrmyAgt1AcctId", SqlDbType.VarChar, 34);
            parameterIntrmyAgt1AcctId.Value = pacs.IntrmyAgt1AcctId;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctId);

            SqlParameter parameterIntrmyAgt1AcctTp = new SqlParameter("@IntrmyAgt1AcctTp", SqlDbType.VarChar, 50);
            parameterIntrmyAgt1AcctTp.Value = pacs.IntrmyAgt1AcctTp;
            myCommand.Parameters.Add(parameterIntrmyAgt1AcctTp);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.VarChar, 35);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 34);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterIntrBkSttlmCcy = new SqlParameter("@IntrBkSttlmCcy", SqlDbType.VarChar, 3);
            parameterIntrBkSttlmCcy.Value = pacs.IntrBkSttlmCcy;
            myCommand.Parameters.Add(parameterIntrBkSttlmCcy);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterDbtrBICFI = new SqlParameter("@DbtrBICFI", SqlDbType.VarChar, 25);
            parameterDbtrBICFI.Value = pacs.DbtrBICFI;
            myCommand.Parameters.Add(parameterDbtrBICFI);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 70);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrBranchId = new SqlParameter("@DbtrBranchId", SqlDbType.VarChar, 35);
            parameterDbtrBranchId.Value = pacs.DbtrBranchId;
            myCommand.Parameters.Add(parameterDbtrBranchId);

            SqlParameter parameterDbtrAcctId = new SqlParameter("@DbtrAcctId", SqlDbType.VarChar, 35);
            parameterDbtrAcctId.Value = pacs.DbtrAcctId;
            myCommand.Parameters.Add(parameterDbtrAcctId);

            SqlParameter parameterDbtrAcctTp = new SqlParameter("@DbtrAcctTp", SqlDbType.VarChar, 50);
            parameterDbtrAcctTp.Value = pacs.DbtrAcctTp;
            myCommand.Parameters.Add(parameterDbtrAcctTp);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 35);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 35);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctId = new SqlParameter("@CdtrAgtAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAgtAcctId.Value = pacs.CdtrAgtAcctId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctId);

            SqlParameter parameterCdtrAgtAcctTp = new SqlParameter("@CdtrAgtAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAgtAcctTp.Value = pacs.CdtrAgtAcctTp;
            myCommand.Parameters.Add(parameterCdtrAgtAcctTp);

            SqlParameter parameterCdtrBICFI = new SqlParameter("@CdtrBICFI", SqlDbType.VarChar, 35);
            parameterCdtrBICFI.Value = pacs.CdtrBICFI;
            myCommand.Parameters.Add(parameterCdtrBICFI);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 70);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrBranchId = new SqlParameter("@CdtrBranchId", SqlDbType.VarChar, 35);
            parameterCdtrBranchId.Value = pacs.CdtrBranchId;
            myCommand.Parameters.Add(parameterCdtrBranchId);

            SqlParameter parameterCdtrAcctId = new SqlParameter("@CdtrAcctId", SqlDbType.VarChar, 34);
            parameterCdtrAcctId.Value = pacs.CdtrAcctId;
            myCommand.Parameters.Add(parameterCdtrAcctId);

            SqlParameter parameterCdtrAcctTp = new SqlParameter("@CdtrAcctTp", SqlDbType.VarChar, 50);
            parameterCdtrAcctTp.Value = pacs.CdtrAcctTp;
            myCommand.Parameters.Add(parameterCdtrAcctTp);

            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterPmntRsn = new SqlParameter("@PmntRsn", SqlDbType.VarChar, 140);
            parameterPmntRsn.Value = pacs.PmntRsn;
            myCommand.Parameters.Add(parameterPmntRsn);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt06(Camt06 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt06", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 25);
            parameterFrBICFI.Value = camt.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 20);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
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

            SqlParameter parameterOrgnlBizQry1 = new SqlParameter("@OrgnlBizQry1", SqlDbType.VarChar, 35);
            parameterOrgnlBizQry1.Value = camt.OrgnlBizQry1;
            myCommand.Parameters.Add(parameterOrgnlBizQry1);

            SqlParameter parameterPrtryId = new SqlParameter("@PrtryId", SqlDbType.VarChar, 35);
            parameterPrtryId.Value = camt.PrtryId;
            myCommand.Parameters.Add(parameterPrtryId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = camt.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterShrtBizIdIntrBkSttlmDt = new SqlParameter("@ShrtBizIdIntrBkSttlmDt", SqlDbType.VarChar, 30);
            parameterShrtBizIdIntrBkSttlmDt.Value = camt.ShrtBizIdIntrBkSttlmDt;
            myCommand.Parameters.Add(parameterShrtBizIdIntrBkSttlmDt);

            SqlParameter parameterShrtBizIdBICFI = new SqlParameter("@ShrtBizIdBICFI", SqlDbType.VarChar, 20);
            parameterShrtBizIdBICFI.Value = camt.ShrtBizIdBICFI;
            myCommand.Parameters.Add(parameterShrtBizIdBICFI);

            SqlParameter parameterPmtMsgId = new SqlParameter("@PmtMsgId", SqlDbType.VarChar, 34);
            parameterPmtMsgId.Value = camt.PmtMsgId;
            myCommand.Parameters.Add(parameterPmtMsgId);

            SqlParameter parameterCdPrtry = new SqlParameter("@CdPrtry", SqlDbType.VarChar, 35);
            parameterCdPrtry.Value = camt.CdPrtry;
            myCommand.Parameters.Add(parameterCdPrtry);

            SqlParameter parameterPrtryRjctnRsn = new SqlParameter("@PrtryRjctnRsn", SqlDbType.VarChar, 50);
            parameterPrtryRjctnRsn.Value = camt.PrtryRjctnRsn;
            myCommand.Parameters.Add(parameterPrtryRjctnRsn);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCcy.Value = camt.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterAmtWthCcy = new SqlParameter("@AmtWthCcy", SqlDbType.Money);
            parameterAmtWthCcy.Value = camt.AmtWthCcy;
            myCommand.Parameters.Add(parameterAmtWthCcy);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = camt.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 34);
            parameterEndToEndId.Value = camt.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterDbtrBICFI = new SqlParameter("@DbtrBICFI", SqlDbType.VarChar, 35);
            parameterDbtrBICFI.Value = camt.DbtrBICFI;
            myCommand.Parameters.Add(parameterDbtrBICFI);

            SqlParameter parameterCdtrBICFI = new SqlParameter("@CdtrBICFI", SqlDbType.VarChar, 35);
            parameterCdtrBICFI.Value = camt.CdtrBICFI;
            myCommand.Parameters.Add(parameterCdtrBICFI);

            SqlParameter parameterAcctId = new SqlParameter("@AcctId", SqlDbType.VarChar, 34);
            parameterAcctId.Value = camt.AcctId;
            myCommand.Parameters.Add(parameterAcctId);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public Guid InsertCamt19(Camt19 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt19", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 25);
            parameterFrBICFI.Value = camt.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar,20);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
            parameterBizSvc.Value = camt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgHdrMsgId = new SqlParameter("@MsgHdrMsgId", SqlDbType.VarChar,34);
            parameterMsgHdrMsgId.Value = camt.MsgHdrMsgId;
            myCommand.Parameters.Add(parameterMsgHdrMsgId);

            SqlParameter parameterMsgHdrCreDtTm = new SqlParameter("@MsgHdrCreDtTm", SqlDbType.VarChar, 30);
            parameterMsgHdrCreDtTm.Value = camt.MsgHdrCreDtTm;
            myCommand.Parameters.Add(parameterMsgHdrCreDtTm);

            SqlParameter parameterOrgnlBizQryMsgId = new SqlParameter("@OrgnlBizQryMsgId", SqlDbType.VarChar, 34);
            parameterOrgnlBizQryMsgId.Value = camt.OrgnlBizQryMsgId;
            myCommand.Parameters.Add(parameterOrgnlBizQryMsgId);

            SqlParameter parameterOrgnlBizQryCreDtTm = new SqlParameter("@OrgnlBizQryCreDtTm", SqlDbType.VarChar, 30);
            parameterOrgnlBizQryCreDtTm.Value = camt.OrgnlBizQryCreDtTm;
            myCommand.Parameters.Add(parameterOrgnlBizQryCreDtTm);

            SqlParameter parameterSysIdPrtry = new SqlParameter("@SysIdPrtry", SqlDbType.VarChar, 15);
            parameterSysIdPrtry.Value = camt.SysIdPrtry;
            myCommand.Parameters.Add(parameterSysIdPrtry);

            SqlParameter parameterBizDayInfSysDt = new SqlParameter("@BizDayInfSysDt", SqlDbType.VarChar,30);
            parameterBizDayInfSysDt.Value = camt.BizDayInfSysDt;
            myCommand.Parameters.Add(parameterBizDayInfSysDt);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 
            
            SqlParameter parameterCam19ID = new SqlParameter("@Cam19ID", SqlDbType.UniqueIdentifier);
            parameterCam19ID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterCam19ID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            Guid Cam19ID = (Guid)parameterCam19ID.Value;
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return Cam19ID;
        }

        public void InsertCamt19Evt(Cam19Evt evt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt19Evt", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterCam19ID = new SqlParameter("@Cam19ID", SqlDbType.UniqueIdentifier, 50);
            parameterCam19ID.Value = evt.Camt19ID;
            myCommand.Parameters.Add(parameterCam19ID);

            SqlParameter parameterTpPrtryId = new SqlParameter("@TpPrtryId", SqlDbType.VarChar, 50);
            parameterTpPrtryId.Value = evt.TpPrtryId;
            myCommand.Parameters.Add(parameterTpPrtryId);

            SqlParameter parameterSchdldTm = new SqlParameter("@SchdldTm", SqlDbType.VarChar, 35);
            parameterSchdldTm.Value = evt.SchdldTm;
            myCommand.Parameters.Add(parameterSchdldTm);

            SqlParameter parameterStartTm = new SqlParameter("@StartTm", SqlDbType.VarChar, 35);
            parameterStartTm.Value = evt.StartTm;
            myCommand.Parameters.Add(parameterStartTm);

            SqlParameter parameteEndTm = new SqlParameter("@EndTm", SqlDbType.VarChar, 35);
            parameteEndTm.Value = evt.EndTm;
            myCommand.Parameters.Add(parameteEndTm);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt25(camt25 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt25", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 
            
            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 25);
            parameterFrBICFI.Value = camt.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 20);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 35);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 20);
            parameterBizSvc.Value = camt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 34);
            parameterMsgId.Value = camt.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 30);
            parameterCreDtTm.Value = camt.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterOrgnlMsgId = new SqlParameter("@OrgnlMsgId", SqlDbType.VarChar, 34);
            parameterOrgnlMsgId.Value = camt.OrgnlMsgId;
            myCommand.Parameters.Add(parameterOrgnlMsgId);

            SqlParameter parameterStsCd = new SqlParameter("@StsCd", SqlDbType.VarChar, 4);
            parameterStsCd.Value = camt.StsCd;
            myCommand.Parameters.Add(parameterStsCd);

            SqlParameter parameterDesc = new SqlParameter("@Desc", SqlDbType.VarChar, 170);
            parameterDesc.Value = camt.Desc;
            myCommand.Parameters.Add(parameterDesc);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertCamt998(camt998 camtt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt998", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camtt.FileName;
            myCommand.Parameters.Add(parameterFileName);

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 50);
            parameterFrBICFI.Value = camtt.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 50);
            parameterToBICFI.Value = camtt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 50);
            parameterBizMsgIdr.Value = camtt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 50);
            parameterMsgDefIdr.Value = camtt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 50);
            parameterBizSvc.Value = camtt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterAppHdrCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 30);
            parameterAppHdrCreDt.Value = camtt.CreDt;
            myCommand.Parameters.Add(parameterAppHdrCreDt);

            SqlParameter parameterPrtryMsgIdRef = new SqlParameter("@PrtryMsgIdRef", SqlDbType.VarChar, 50);
            parameterPrtryMsgIdRef.Value = camtt.PrtryMsgIdRef;
            myCommand.Parameters.Add(parameterPrtryMsgIdRef);

            SqlParameter parameterPrtryMsgRltdRef = new SqlParameter("@PrtryMsgRltdRef", SqlDbType.VarChar, 50);
            parameterPrtryMsgRltdRef.Value = camtt.PrtryMsgRltdRef;
            myCommand.Parameters.Add(parameterPrtryMsgRltdRef);

            SqlParameter parameterPrtryDataTp = new SqlParameter("@PrtryDataTp", SqlDbType.VarChar, 50);
            parameterPrtryDataTp.Value = camtt.PrtryDataTp;
            myCommand.Parameters.Add(parameterPrtryDataTp);

            SqlParameter parameterPrtryDataRcvr = new SqlParameter("@PrtryDataRcvr", SqlDbType.VarChar, 50);
            parameterPrtryDataRcvr.Value = camtt.PrtryDataRcvr;
            myCommand.Parameters.Add(parameterPrtryDataRcvr);

            SqlParameter parameterPrtryDataText = new SqlParameter("@PrtryDataText", SqlDbType.VarChar, 250);
            parameterPrtryDataText.Value = camtt.PrtryDataText;
            myCommand.Parameters.Add(parameterPrtryDataText);

            SqlParameter parameterServiceMessageCode = new SqlParameter("@ServiceMessageCode", SqlDbType.VarChar, 50);
            parameterServiceMessageCode.Value = camtt.ServiceMessageCode;
            myCommand.Parameters.Add(parameterServiceMessageCode);

            SqlParameter parameterServiceMessageCode1 = new SqlParameter("@ServiceMessageCode1", SqlDbType.VarChar, 50);
            parameterServiceMessageCode1.Value = camtt.ServiceMessageCode1;
            myCommand.Parameters.Add(parameterServiceMessageCode1);

            SqlParameter parameterServiceMessageValue1 = new SqlParameter("@ServiceMessageValue1", SqlDbType.VarChar, 50);
            parameterServiceMessageValue1.Value = camtt.ServiceMessageValue1;
            myCommand.Parameters.Add(parameterServiceMessageValue1);

            SqlParameter parameterServiceMessageCode2 = new SqlParameter("@ServiceMessageCode2", SqlDbType.VarChar, 50);
            parameterServiceMessageCode2.Value = camtt.ServiceMessageCode2;
            myCommand.Parameters.Add(parameterServiceMessageCode2);

            SqlParameter parameterServiceMessageValue2 = new SqlParameter("@ServiceMessageValue2", SqlDbType.VarChar, 50);
            parameterServiceMessageValue2.Value = camtt.ServiceMessageValue2;
            myCommand.Parameters.Add(parameterServiceMessageValue2);

            SqlParameter parameterServiceMessageCode3 = new SqlParameter("@ServiceMessageCode3", SqlDbType.VarChar, 50);
            parameterServiceMessageCode3.Value = camtt.ServiceMessageCode3;
            myCommand.Parameters.Add(parameterServiceMessageCode3);


            SqlParameter parameterServiceMessageValue3 = new SqlParameter("@ServiceMessageValue3", SqlDbType.VarChar, 50);
            parameterServiceMessageValue3.Value = camtt.ServiceMessageValue3;
            myCommand.Parameters.Add(parameterServiceMessageValue3);

            SqlParameter parameterServiceMessageCode4 = new SqlParameter("@ServiceMessageCode4", SqlDbType.VarChar, 50);
            parameterServiceMessageCode4.Value = camtt.ServiceMessageCode4;
            myCommand.Parameters.Add(parameterServiceMessageCode4);

            SqlParameter parameterServiceMessageValue4 = new SqlParameter("@ServiceMessageValue4", SqlDbType.VarChar, 50);
            parameterServiceMessageValue4.Value = camtt.ServiceMessageValue4;
            myCommand.Parameters.Add(parameterServiceMessageValue4);

            SqlParameter parameterServiceMessageCode5 = new SqlParameter("@ServiceMessageCode5", SqlDbType.VarChar, 50);
            parameterServiceMessageCode5.Value = camtt.ServiceMessageCode5;
            myCommand.Parameters.Add(parameterServiceMessageCode5);

            SqlParameter parameterServiceMessageValue5 = new SqlParameter("@ServiceMessageValue5", SqlDbType.VarChar, 50);
            parameterServiceMessageValue5.Value = camtt.ServiceMessageValue5;
            myCommand.Parameters.Add(parameterServiceMessageValue5);

            SqlParameter parameterLqdtReqTp = new SqlParameter("@LqdtReqTp", SqlDbType.VarChar, 10);
            parameterLqdtReqTp.Value = camtt.LqdtReqTp;
            myCommand.Parameters.Add(parameterLqdtReqTp);

            SqlParameter parameterLqdtPvdSys = new SqlParameter("@LqdtPvdSys", SqlDbType.VarChar, 10);
            parameterLqdtPvdSys.Value = camtt.LqdtPvdSys;
            myCommand.Parameters.Add(parameterLqdtPvdSys);

            SqlParameter parameterLqdtReqId = new SqlParameter("@LqdtReqId", SqlDbType.VarChar, 34);
            parameterLqdtReqId.Value = camtt.LqdtReqId;
            myCommand.Parameters.Add(parameterLqdtReqId);

            SqlParameter parameterLqdtReqAcctTp = new SqlParameter("@LqdtReqAcctTp", SqlDbType.VarChar, 10);
            parameterLqdtReqAcctTp.Value = camtt.LqdtReqAcctTp;
            myCommand.Parameters.Add(parameterLqdtReqAcctTp);

            SqlParameter parameterLqdtReqAcctOwnrBIC = new SqlParameter("@LqdtReqAcctOwnrBIC", SqlDbType.VarChar, 50);
            parameterLqdtReqAcctOwnrBIC.Value = camtt.LqdtReqAcctOwnrBIC;
            myCommand.Parameters.Add(parameterLqdtReqAcctOwnrBIC);

            SqlParameter parameterLqdtReqAmtWthCCY = new SqlParameter("@LqdtReqAmtWthCCY", SqlDbType.VarChar, 3);
            parameterLqdtReqAmtWthCCY.Value = camtt.LqdtReqAmtWthCCY;
            myCommand.Parameters.Add(parameterLqdtReqAmtWthCCY);

            SqlParameter parameterLqdtRelTrfSndr = new SqlParameter("@LqdtRelTrfSndr", SqlDbType.VarChar, 50);
            parameterLqdtRelTrfSndr.Value = camtt.LqdtRelTrfSndr;
            myCommand.Parameters.Add(parameterLqdtRelTrfSndr);

            SqlParameter parameterLqdtRelTrfSttlmDt = new SqlParameter("@LqdtRelTrfSttlmDt", SqlDbType.VarChar, 30);
            parameterLqdtRelTrfSttlmDt.Value = camtt.LqdtRelTrfSttlmDt;
            myCommand.Parameters.Add(parameterLqdtRelTrfSttlmDt);

            SqlParameter parameterLqdtRelTrfRef = new SqlParameter("@LqdtRelTrfRef", SqlDbType.VarChar, 34);
            parameterLqdtRelTrfRef.Value = camtt.LqdtRelTrfRef;
            myCommand.Parameters.Add(parameterLqdtRelTrfRef);

            SqlParameter parameterLqdtReqMtrtDt = new SqlParameter("@LqdtReqMtrtDt", SqlDbType.VarChar, 30);
            parameterLqdtReqMtrtDt.Value = camtt.LqdtReqMtrtDt;
            myCommand.Parameters.Add(parameterLqdtReqMtrtDt);

            SqlParameter parameterLqdtOpTp = new SqlParameter("@LqdtOpTp", SqlDbType.VarChar, 50);
            parameterLqdtOpTp.Value = camtt.LqdtOpTp;
            myCommand.Parameters.Add(parameterLqdtOpTp);

            SqlParameter parameterStlfLmtId = new SqlParameter("@StlfLmtId", SqlDbType.VarChar, 50);
            parameterStlfLmtId.Value = camtt.StlfLmtId;
            myCommand.Parameters.Add(parameterStlfLmtId);

            SqlParameter parameterAcctOwnrOrgId = new SqlParameter("@AcctOwnrOrgId", SqlDbType.VarChar, 30);
            parameterAcctOwnrOrgId.Value = camtt.AcctOwnrOrgId;
            myCommand.Parameters.Add(parameterAcctOwnrOrgId);

            SqlParameter parameterNewLmtAmtWthtCcy = new SqlParameter("@NewLmtAmtWthtCcy", SqlDbType.VarChar, 3);
            parameterNewLmtAmtWthtCcy.Value = camtt.NewLmtAmtWthtCcy;
            myCommand.Parameters.Add(parameterNewLmtAmtWthtCcy);

            SqlParameter parameterxmlstr = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterxmlstr.Value = camtt.XmlData;
            myCommand.Parameters.Add(parameterxmlstr); 
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();

        }

        public Pacs009 GetSingleCartOutward09(string OutwardID, string CartID)
        {
            Guid outid = new Guid(OutwardID);
            Pacs009 pacs = new Pacs009();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward09", myConnection);
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

                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.SvcLvlPrtry = (string)dr["SvcLvlPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.IntrBkSttlmCcy = (string)dr["IntrBkSttlmCcy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];

                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];

                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];

                pacs.IntrmyAgt1BICFI = (string)dr["IntrmyAgt1BICFI"];
                pacs.IntrmyAgt1Nm = (string)dr["IntrmyAgt1Nm"];
                pacs.IntrmyAgt1BranchId = (string)dr["IntrmyAgt1BranchId"];
                pacs.IntrmyAgt1AcctId = (string)dr["IntrmyAgt1AcctId"];
                pacs.IntrmyAgt1AcctTp = (string)dr["IntrmyAgt1AcctTp"];

                pacs.DbtrBICFI = (string)dr["DbtrBICFI"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrBranchId = (string)dr["DbtrBranchId"];
                pacs.DbtrAcctId = (string)dr["DbtrAcctId"];
                pacs.DbtrAcctTp = (string)dr["DbtrAcctTp"];

                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctId = (string)dr["CdtrAgtAcctId"];
                pacs.CdtrAgtAcctTp = (string)dr["CdtrAgtAcctTp"];

                pacs.CdtrBICFI = (string)dr["CdtrBICFI"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrBranchId = (string)dr["CdtrBranchId"];
                pacs.CdtrAcctId = (string)dr["CdtrAcctId"];
                pacs.CdtrAcctTp = (string)dr["CdtrAcctTp"];

                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.PmntRsn = (string)dr["PmntRsn"];

                pacs.Maker = (string)dr["Maker"];
                pacs.MakeTime = dr["MakeTime"].ToString();
                pacs.MakerIP = (string)dr["MakerIP"];
                pacs.Checker = (string)dr["Checker"];
                pacs.CheckTime = dr["CheckTime"].ToString();
                pacs.CheckerIP = (string)dr["CheckerIP"];
                pacs.Admin = (string)dr["Admin"];
                pacs.AdminTime = dr["AdminTime"].ToString();
                pacs.AdminIP = (string)dr["AdminIP"];
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

        public void SendOutward09(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward09", myConnection);
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
