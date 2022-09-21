using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class TeamRedDB
    {
        public void InsertPacs002(Pacs002 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertPacs002", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = pacs.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 20);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 20);
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

            SqlParameter parameterOrgnlMsgId = new SqlParameter("@OrgnlMsgId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgId.Value = pacs.OrgnlMsgId;
            myCommand.Parameters.Add(parameterOrgnlMsgId);

            SqlParameter parameterOrgnlMsgNmId = new SqlParameter("@OrgnlMsgNmId", SqlDbType.VarChar, 35);
            parameterOrgnlMsgNmId.Value = pacs.OrgnlMsgNmId;
            myCommand.Parameters.Add(parameterOrgnlMsgNmId);

            SqlParameter parameterOrgnlCreDtTm = new SqlParameter("@OrgnlCreDtTm", SqlDbType.VarChar, 30);
            parameterOrgnlCreDtTm.Value = pacs.OrgnlCreDtTm;
            myCommand.Parameters.Add(parameterOrgnlCreDtTm);

            SqlParameter parameterGrpSts = new SqlParameter("@GrpSts", SqlDbType.VarChar, 5);
            parameterGrpSts.Value = pacs.GrpSts;
            myCommand.Parameters.Add(parameterGrpSts);

            SqlParameter parameterRsnPrtry = new SqlParameter("@RsnPrtry", SqlDbType.VarChar, 10);
            parameterRsnPrtry.Value = pacs.RsnPrtry;
            myCommand.Parameters.Add(parameterRsnPrtry);

            SqlParameter parameterAddtlInf = new SqlParameter("@AddtlInf", SqlDbType.VarChar, 50);
            parameterAddtlInf.Value = pacs.AddtlInf;
            myCommand.Parameters.Add(parameterAddtlInf);

            SqlParameter parameterOrgnlInstrId = new SqlParameter("@OrgnlInstrId", SqlDbType.VarChar, 35);
            parameterOrgnlInstrId.Value = pacs.OrgnlInstrId;
            myCommand.Parameters.Add(parameterOrgnlInstrId);

            SqlParameter parameterOrgnlEndToEndId = new SqlParameter("@OrgnlEndToEndId", SqlDbType.VarChar, 35);
            parameterOrgnlEndToEndId.Value = pacs.OrgnlEndToEndId;
            myCommand.Parameters.Add(parameterOrgnlEndToEndId);

            SqlParameter parameterOrgnlTxId = new SqlParameter("@OrgnlTxId", SqlDbType.VarChar, 35);
            parameterOrgnlTxId.Value = pacs.OrgnlTxId;
            myCommand.Parameters.Add(parameterOrgnlTxId);

            SqlParameter parameterTxSts = new SqlParameter("@TxSts", SqlDbType.VarChar, 5);
            parameterTxSts.Value = pacs.TxSts;
            myCommand.Parameters.Add(parameterTxSts);

            SqlParameter parameterTxInfAndStsPrtry = new SqlParameter("@TxInfAndStsPrtry", SqlDbType.VarChar, 10);
            parameterTxInfAndStsPrtry.Value = pacs.TxInfAndStsPrtry;
            myCommand.Parameters.Add(parameterTxInfAndStsPrtry);

            SqlParameter parameterTxInfAndStsAddtlInf = new SqlParameter("@TxInfAndStsAddtlInf", SqlDbType.VarChar, 50);
            parameterTxInfAndStsAddtlInf.Value = pacs.TxInfAndStsAddtlInf;
            myCommand.Parameters.Add(parameterTxInfAndStsAddtlInf);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = pacs.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public void InsertInward008(Pacs008 pacs)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertInward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = pacs.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 8);
            parameterFrBICFI.Value = pacs.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 12);
            parameterToBICFI.Value = pacs.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 35);
            parameterBizMsgIdr.Value = pacs.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 16);
            parameterMsgDefIdr.Value = pacs.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 10);
            parameterBizSvc.Value = pacs.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 50);
            parameterCreDt.Value = pacs.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgId = new SqlParameter("@MsgId", SqlDbType.VarChar, 35);
            parameterMsgId.Value = pacs.MsgId;
            myCommand.Parameters.Add(parameterMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 50);
            parameterCreDtTm.Value = pacs.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterBtchBookg = new SqlParameter("@BtchBookg", SqlDbType.VarChar, 8);
            parameterBtchBookg.Value = pacs.BtchBookg;
            myCommand.Parameters.Add(parameterBtchBookg);

            SqlParameter parameterBtchBookgID = new SqlParameter("@BtchBookgID", SqlDbType.UniqueIdentifier);
            parameterBtchBookgID.Value = new Guid(pacs.BatchBookingID);
            myCommand.Parameters.Add(parameterBtchBookgID);

            SqlParameter parameterNbOfTxs = new SqlParameter("@NbOfTxs", SqlDbType.Int);
            parameterNbOfTxs.Value = pacs.NbOfTxs;
            myCommand.Parameters.Add(parameterNbOfTxs);

            SqlParameter parameterInstrId = new SqlParameter("@InstrId", SqlDbType.VarChar, 35);
            parameterInstrId.Value = pacs.InstrId;
            myCommand.Parameters.Add(parameterInstrId);

            SqlParameter parameterEndToEndId = new SqlParameter("@EndToEndId", SqlDbType.VarChar, 35);
            parameterEndToEndId.Value = pacs.EndToEndId;
            myCommand.Parameters.Add(parameterEndToEndId);

            SqlParameter parameterTxId = new SqlParameter("@TxId", SqlDbType.VarChar, 35);
            parameterTxId.Value = pacs.TxId;
            myCommand.Parameters.Add(parameterTxId);

            SqlParameter parameterClrChanl = new SqlParameter("@ClrChanl", SqlDbType.VarChar, 10);
            parameterClrChanl.Value = pacs.ClrChanl;
            myCommand.Parameters.Add(parameterClrChanl);

            SqlParameter parameterSvcLvlPrtry = new SqlParameter("@SvcLvlPrtry", SqlDbType.Int);
            parameterSvcLvlPrtry.Value = pacs.SvcLvlPrtry;
            myCommand.Parameters.Add(parameterSvcLvlPrtry);

            SqlParameter parameterLclInstrmPrtry = new SqlParameter("@LclInstrmPrtry", SqlDbType.VarChar, 35);
            parameterLclInstrmPrtry.Value = pacs.LclInstrmPrtry;
            myCommand.Parameters.Add(parameterLclInstrmPrtry);

            SqlParameter parameterCtgyPurpPrtry = new SqlParameter("@CtgyPurpPrtry", SqlDbType.VarChar, 35);
            parameterCtgyPurpPrtry.Value = pacs.CtgyPurpPrtry;
            myCommand.Parameters.Add(parameterCtgyPurpPrtry);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCcy.Value = pacs.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterTtlIntrBkSttlmAmt = new SqlParameter("@TtlIntrBkSttlmAmt", SqlDbType.Money);
            parameterTtlIntrBkSttlmAmt.Value = pacs.TtlIntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterTtlIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmAmt = new SqlParameter("@IntrBkSttlmAmt", SqlDbType.Money);
            parameterIntrBkSttlmAmt.Value = pacs.IntrBkSttlmAmt;
            myCommand.Parameters.Add(parameterIntrBkSttlmAmt);

            SqlParameter parameterIntrBkSttlmDt = new SqlParameter("@IntrBkSttlmDt", SqlDbType.VarChar, 10);
            parameterIntrBkSttlmDt.Value = pacs.IntrBkSttlmDt;
            myCommand.Parameters.Add(parameterIntrBkSttlmDt);

            SqlParameter parameterChrgBr = new SqlParameter("@ChrgBr", SqlDbType.VarChar, 4);
            parameterChrgBr.Value = pacs.ChrgBr;
            myCommand.Parameters.Add(parameterChrgBr);

            SqlParameter parameterInstgAgtBICFI = new SqlParameter("@InstgAgtBICFI", SqlDbType.VarChar, 20);
            parameterInstgAgtBICFI.Value = pacs.InstgAgtBICFI;
            myCommand.Parameters.Add(parameterInstgAgtBICFI);

            SqlParameter parameterInstgAgtNm = new SqlParameter("@InstgAgtNm", SqlDbType.VarChar, 140);
            parameterInstgAgtNm.Value = pacs.InstgAgtNm;
            myCommand.Parameters.Add(parameterInstgAgtNm);

            SqlParameter parameterInstgAgtBranchId = new SqlParameter("@InstgAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstgAgtBranchId.Value = pacs.InstgAgtBranchId;
            myCommand.Parameters.Add(parameterInstgAgtBranchId);

            SqlParameter parameterInstdAgtBICFI = new SqlParameter("@InstdAgtBICFI", SqlDbType.VarChar, 8);
            parameterInstdAgtBICFI.Value = pacs.InstdAgtBICFI;
            myCommand.Parameters.Add(parameterInstdAgtBICFI);

            SqlParameter parameterInstdAgtNm = new SqlParameter("@InstdAgtNm", SqlDbType.VarChar, 140);
            parameterInstdAgtNm.Value = pacs.InstdAgtNm;
            myCommand.Parameters.Add(parameterInstdAgtNm);

            SqlParameter parameterInstdAgtBranchId = new SqlParameter("@InstdAgtBranchId", SqlDbType.VarChar, 35);
            parameterInstdAgtBranchId.Value = pacs.InstdAgtBranchId;
            myCommand.Parameters.Add(parameterInstdAgtBranchId);

            SqlParameter parameterDbtrNm = new SqlParameter("@DbtrNm", SqlDbType.VarChar, 140);
            parameterDbtrNm.Value = pacs.DbtrNm;
            myCommand.Parameters.Add(parameterDbtrNm);

            SqlParameter parameterDbtrPstlAdr = new SqlParameter("@DbtrPstlAdr", SqlDbType.VarChar, 140);
            parameterDbtrPstlAdr.Value = pacs.DbtrPstlAdr;
            myCommand.Parameters.Add(parameterDbtrPstlAdr);

            SqlParameter parameterDbtrStrtNm = new SqlParameter("@DbtrStrtNm", SqlDbType.VarChar, 70);
            parameterDbtrStrtNm.Value = pacs.DbtrStrtNm;
            myCommand.Parameters.Add(parameterDbtrStrtNm);

            SqlParameter parameterDbtrTwnNm = new SqlParameter("@DbtrTwnNm", SqlDbType.VarChar, 35);
            parameterDbtrTwnNm.Value = pacs.DbtrTwnNm;
            myCommand.Parameters.Add(parameterDbtrTwnNm);

            SqlParameter parameterDbtrAdrLine = new SqlParameter("@DbtrAdrLine", SqlDbType.VarChar, 70);
            parameterDbtrAdrLine.Value = pacs.DbtrAdrLine;
            myCommand.Parameters.Add(parameterDbtrAdrLine);

            SqlParameter parameterDbtrCtry = new SqlParameter("@DbtrCtry", SqlDbType.VarChar, 20);
            parameterDbtrCtry.Value = pacs.DbtrCtry;
            myCommand.Parameters.Add(parameterDbtrCtry);

            SqlParameter parameterDbtrAcctOthrId = new SqlParameter("@DbtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterDbtrAcctOthrId.Value = pacs.DbtrAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAcctOthrId);

            SqlParameter parameterDbtrAgtBICFI = new SqlParameter("@DbtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterDbtrAgtBICFI.Value = pacs.DbtrAgtBICFI;
            myCommand.Parameters.Add(parameterDbtrAgtBICFI);

            SqlParameter parameterDbtrAgtNm = new SqlParameter("@DbtrAgtNm", SqlDbType.VarChar, 140);
            parameterDbtrAgtNm.Value = pacs.DbtrAgtNm;
            myCommand.Parameters.Add(parameterDbtrAgtNm);

            SqlParameter parameterDbtrAgtBranchId = new SqlParameter("@DbtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterDbtrAgtBranchId.Value = pacs.DbtrAgtBranchId;
            myCommand.Parameters.Add(parameterDbtrAgtBranchId);

            SqlParameter parameterDbtrAgtAcctOthrId = new SqlParameter("@DbtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctOthrId.Value = pacs.DbtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterDbtrAgtAcctOthrId);

            SqlParameter parameterDbtrAgtAcctPrtry = new SqlParameter("@DbtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterDbtrAgtAcctPrtry.Value = pacs.DbtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterDbtrAgtAcctPrtry);

            SqlParameter parameterCdtrAgtBICFI = new SqlParameter("@CdtrAgtBICFI", SqlDbType.VarChar, 8);
            parameterCdtrAgtBICFI.Value = pacs.CdtrAgtBICFI;
            myCommand.Parameters.Add(parameterCdtrAgtBICFI);

            SqlParameter parameterCdtrAgtNm = new SqlParameter("@CdtrAgtNm", SqlDbType.VarChar, 140);
            parameterCdtrAgtNm.Value = pacs.CdtrAgtNm;
            myCommand.Parameters.Add(parameterCdtrAgtNm);

            SqlParameter parameterCdtrAgtBranchId = new SqlParameter("@CdtrAgtBranchId", SqlDbType.VarChar, 20);
            parameterCdtrAgtBranchId.Value = pacs.CdtrAgtBranchId;
            myCommand.Parameters.Add(parameterCdtrAgtBranchId);

            SqlParameter parameterCdtrAgtAcctOthrId = new SqlParameter("@CdtrAgtAcctOthrId", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctOthrId.Value = pacs.CdtrAgtAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAgtAcctOthrId);

            SqlParameter parameterCdtrAgtAcctPrtry = new SqlParameter("@CdtrAgtAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAgtAcctPrtry.Value = pacs.CdtrAgtAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAgtAcctPrtry);

            SqlParameter parameterCdtrNm = new SqlParameter("@CdtrNm", SqlDbType.VarChar, 140);
            parameterCdtrNm.Value = pacs.CdtrNm;
            myCommand.Parameters.Add(parameterCdtrNm);

            SqlParameter parameterCdtrPstlAdr = new SqlParameter("@CdtrPstlAdr", SqlDbType.VarChar, 140);
            parameterCdtrPstlAdr.Value = pacs.CdtrPstlAdr;
            myCommand.Parameters.Add(parameterCdtrPstlAdr);

            SqlParameter parameterCdtrStrtNm = new SqlParameter("@CdtrStrtNm", SqlDbType.VarChar, 70);
            parameterCdtrStrtNm.Value = pacs.CdtrStrtNm;
            myCommand.Parameters.Add(parameterCdtrStrtNm);

            SqlParameter parameterCdtrTwnNm = new SqlParameter("@CdtrTwnNm", SqlDbType.VarChar, 35);
            parameterCdtrTwnNm.Value = pacs.CdtrTwnNm;
            myCommand.Parameters.Add(parameterCdtrTwnNm);

            SqlParameter parameterCdtrAdrLine = new SqlParameter("@CdtrAdrLine", SqlDbType.VarChar, 70);
            parameterCdtrAdrLine.Value = pacs.CdtrAdrLine;
            myCommand.Parameters.Add(parameterCdtrAdrLine);

            SqlParameter parameterCdtrCtry = new SqlParameter("@CdtrCtry", SqlDbType.VarChar, 20);
            parameterCdtrCtry.Value = pacs.CdtrCtry;
            myCommand.Parameters.Add(parameterCdtrCtry);

            SqlParameter parameterCdtrAcctOthrId = new SqlParameter("@CdtrAcctOthrId", SqlDbType.VarChar, 34);
            parameterCdtrAcctOthrId.Value = pacs.CdtrAcctOthrId;
            myCommand.Parameters.Add(parameterCdtrAcctOthrId);

            SqlParameter parameterCdtrAcctPrtry = new SqlParameter("@CdtrAcctPrtry", SqlDbType.VarChar, 35);
            parameterCdtrAcctPrtry.Value = pacs.CdtrAcctPrtry;
            myCommand.Parameters.Add(parameterCdtrAcctPrtry);

            SqlParameter parameterInstrInf = new SqlParameter("@InstrInf", SqlDbType.VarChar, 140);
            parameterInstrInf.Value = pacs.InstrInf;
            myCommand.Parameters.Add(parameterInstrInf);

            SqlParameter parameterUstrd = new SqlParameter("@Ustrd", SqlDbType.VarChar, 140);
            parameterUstrd.Value = pacs.Ustrd;
            myCommand.Parameters.Add(parameterUstrd);

            SqlParameter parameterOrginatorACType = new SqlParameter("@OrginatorACType", SqlDbType.VarChar, 30);
            parameterOrginatorACType.Value = pacs.OrginatorACType;
            myCommand.Parameters.Add(parameterOrginatorACType);

            SqlParameter parameterReceiverACType = new SqlParameter("@ReceiverACType", SqlDbType.VarChar, 30);
            parameterReceiverACType.Value = pacs.ReceiverACType;
            myCommand.Parameters.Add(parameterReceiverACType);

            SqlParameter parameterPurposeOfTransaction = new SqlParameter("@PurposeOfTransaction", SqlDbType.VarChar, 30);
            parameterPurposeOfTransaction.Value = pacs.PurposeOfTransaction;
            myCommand.Parameters.Add(parameterPurposeOfTransaction);

            SqlParameter parameterOtherInfo = new SqlParameter("@OtherInfo", SqlDbType.VarChar, 30);
            parameterOtherInfo.Value = pacs.OtherInfo;
            myCommand.Parameters.Add(parameterOtherInfo);





            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }
        
        public void InsertCamt04(Camt04 camt)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_InsertCamt04", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFileName = new SqlParameter("@FileName", SqlDbType.VarChar, 50);
            parameterFileName.Value = camt.FileName;
            myCommand.Parameters.Add(parameterFileName); 

            SqlParameter parameterFrBICFI = new SqlParameter("@FrBICFI", SqlDbType.VarChar, 12);
            parameterFrBICFI.Value = camt.FrBICFI;
            myCommand.Parameters.Add(parameterFrBICFI);

            SqlParameter parameterToBICFI = new SqlParameter("@ToBICFI", SqlDbType.VarChar, 8);
            parameterToBICFI.Value = camt.ToBICFI;
            myCommand.Parameters.Add(parameterToBICFI);

            SqlParameter parameterBizMsgIdr = new SqlParameter("@BizMsgIdr", SqlDbType.VarChar, 30);
            parameterBizMsgIdr.Value = camt.BizMsgIdr;
            myCommand.Parameters.Add(parameterBizMsgIdr);

            SqlParameter parameterMsgDefIdr = new SqlParameter("@MsgDefIdr", SqlDbType.VarChar, 16);
            parameterMsgDefIdr.Value = camt.MsgDefIdr;
            myCommand.Parameters.Add(parameterMsgDefIdr);

            SqlParameter parameterBizSvc = new SqlParameter("@BizSvc", SqlDbType.VarChar, 5);
            parameterBizSvc.Value = camt.BizSvc;
            myCommand.Parameters.Add(parameterBizSvc);

            SqlParameter parameterCreDt = new SqlParameter("@CreDt", SqlDbType.VarChar, 21);
            parameterCreDt.Value = camt.CreDt;
            myCommand.Parameters.Add(parameterCreDt);

            SqlParameter parameterMsgHdrMsgId = new SqlParameter("@MsgHdrMsgId", SqlDbType.VarChar, 12);
            parameterMsgHdrMsgId.Value = camt.MsgHdrMsgId;
            myCommand.Parameters.Add(parameterMsgHdrMsgId);

            SqlParameter parameterCreDtTm = new SqlParameter("@CreDtTm", SqlDbType.VarChar, 20);
            parameterCreDtTm.Value = camt.CreDtTm;
            myCommand.Parameters.Add(parameterCreDtTm);

            SqlParameter parameterOrgnlBizQryMsgId = new SqlParameter("@OrgnlBizQryMsgId", SqlDbType.VarChar, 16);
            parameterOrgnlBizQryMsgId.Value = camt.OrgnlBizQryMsgId;
            myCommand.Parameters.Add(parameterOrgnlBizQryMsgId);

            SqlParameter parameterAcctIdOthrId = new SqlParameter("@AcctIdOthrId", SqlDbType.VarChar, 30);
            parameterAcctIdOthrId.Value = camt.AcctIdOthrId;
            myCommand.Parameters.Add(parameterAcctIdOthrId);

            SqlParameter parameterCd = new SqlParameter("@Cd", SqlDbType.VarChar, 3);
            parameterCd.Value = camt.Cd;
            myCommand.Parameters.Add(parameterCd);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 3);
            parameterCcy.Value = camt.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterAmtWthtCcy = new SqlParameter("@AmtWthtCcy", SqlDbType.VarChar, 50);
            parameterAmtWthtCcy.Value = camt.AmtWthtCcy;
            myCommand.Parameters.Add(parameterAmtWthtCcy);

            SqlParameter parameterCdtDbtInd = new SqlParameter("@CdtDbtInd", SqlDbType.VarChar, 5);
            parameterCdtDbtInd.Value = camt.CdtDbtInd;
            myCommand.Parameters.Add(parameterCdtDbtInd);

            SqlParameter parameterAnyBIC = new SqlParameter("@AnyBIC", SqlDbType.VarChar, 8);
            parameterAnyBIC.Value = camt.AnyBIC;
            myCommand.Parameters.Add(parameterAnyBIC);

            SqlParameter parameterXmlData = new SqlParameter("@XmlData", SqlDbType.VarChar, 64000);
            parameterXmlData.Value = camt.XmlData;
            myCommand.Parameters.Add(parameterXmlData); 

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();
        }

        public Pacs008 GetSingleCartOutward08(string OutwardID, string CartID)
        {
            Pacs008 pacs = new Pacs008();

            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("GetSingleCartOutward08", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = new Guid(OutwardID); ;
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
                pacs.BtchBookg = (string)dr["BtchBookg"];
                pacs.BatchBookingID = dr["BatchBookingID"].ToString();
                pacs.NbOfTxs = (int)dr["NbOfTxs"];
                pacs.InstrId = (string)dr["InstrId"];
                pacs.EndToEndId = (string)dr["EndToEndId"];
                pacs.TxId = (string)dr["TxId"];
                pacs.ClrChanl = (string)dr["ClrChanl"];
                pacs.SvcLvlPrtry = (int)dr["SvcLvlPrtry"];
                pacs.LclInstrmPrtry = (string)dr["LclInstrmPrtry"];
                pacs.CtgyPurpPrtry = (string)dr["CtgyPurpPrtry"];
                pacs.Ccy = (string)dr["Ccy"];
                pacs.IntrBkSttlmAmt = (decimal)dr["IntrBkSttlmAmt"];
                pacs.IntrBkSttlmDt = (string)dr["IntrBkSttlmDt"];
                pacs.ChrgBr = (string)dr["ChrgBr"];
                pacs.InstgAgtBICFI = (string)dr["InstgAgtBICFI"];
                pacs.InstgAgtNm = (string)dr["InstgAgtNm"];
                pacs.InstgAgtBranchId = (string)dr["InstgAgtBranchId"];
                pacs.InstdAgtBICFI = (string)dr["InstdAgtBICFI"];
                pacs.InstdAgtNm = (string)dr["InstdAgtNm"];
                pacs.InstdAgtBranchId = (string)dr["InstdAgtBranchId"];
                pacs.DbtrNm = (string)dr["DbtrNm"];
                pacs.DbtrPstlAdr = (string)dr["DbtrPstlAdr"];
                pacs.DbtrStrtNm = (string)dr["DbtrStrtNm"];
                pacs.DbtrTwnNm = (string)dr["DbtrTwnNm"];
                pacs.DbtrAdrLine = (string)dr["DbtrAdrLine"];
                pacs.DbtrCtry = (string)dr["DbtrCtry"];
                pacs.DbtrAcctOthrId = (string)dr["DbtrAcctOthrId"];
                pacs.DbtrAgtBICFI = (string)dr["DbtrAgtBICFI"];
                pacs.DbtrAgtNm = (string)dr["DbtrAgtNm"];
                pacs.DbtrAgtBranchId = (string)dr["DbtrAgtBranchId"];
                pacs.DbtrAgtAcctOthrId = (string)dr["DbtrAgtAcctOthrId"];
                pacs.DbtrAgtAcctPrtry = (string)dr["DbtrAgtAcctPrtry"];
                pacs.CdtrAgtBICFI = (string)dr["CdtrAgtBICFI"];
                pacs.CdtrAgtNm = (string)dr["CdtrAgtNm"];
                pacs.CdtrAgtBranchId = (string)dr["CdtrAgtBranchId"];
                pacs.CdtrAgtAcctOthrId = (string)dr["CdtrAgtAcctOthrId"];
                pacs.CdtrAgtAcctPrtry = (string)dr["CdtrAgtAcctPrtry"];
                pacs.CdtrNm = (string)dr["CdtrNm"];
                pacs.CdtrPstlAdr = (string)dr["CdtrPstlAdr"];
                pacs.CdtrStrtNm = (string)dr["CdtrStrtNm"];
                pacs.CdtrTwnNm = (string)dr["CdtrTwnNm"];
                pacs.CdtrAdrLine = (string)dr["CdtrAdrLine"];
                pacs.CdtrCtry = (string)dr["CdtrCtry"];
                pacs.CdtrAcctOthrId = (string)dr["CdtrAcctOthrId"];
                pacs.CdtrAcctPrtry = (string)dr["CdtrAcctPrtry"];
                pacs.InstrInf = (string)dr["InstrInf"];
                pacs.Ustrd = (string)dr["Ustrd"];
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

        public void SendOutward08(string OutwardID, string Admin, string AdminIP)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);

            Guid newGuid = new Guid(OutwardID);

            SqlCommand myCommand = new SqlCommand("ADM_SendOutward08", myConnection);
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
