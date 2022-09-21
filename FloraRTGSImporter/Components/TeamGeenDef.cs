using System;

namespace RTGSImporter
{
    public class Pacs004
    {
        public string PacsID = "";
        public string DetectTime = "";
        public string FileName = "";
        public string FrBICFI = "";
        public string ToBICFI = "";
        public string BizMsgIdr = "";
        public string MsgDefIdr = "";
        public string BizSvc = "";
        public string CreDt = "";
        public string MsgId = "";
        public string CreDtTm = "";
        public string BtchBookg = "";
        public string BtchBookgID =  "00000000-0000-0000-0000-000000000000";
        public decimal TtlIntrBkSttlmAmt = 0;
        public int    NbOfTxs = 0;
        public string OrgnlMsgId = "";
        public string OrgnlMsgNmId = "";
        public string OrgnlCreDtTm = "";
        public string RtrRsnOrgtrNm = "";
        public string RtrRsnCd = "";
        public string RtrRsnPrtry = "";
        public string RtrRsnAddtlInf = "";
        public string RtrId = "";
        public string OrgnlInstrId = "";
        public string OrgnlEndToEndId = "";
        public string OrgnlTxId = "";
        public string RtrdIntrBkSttlmCcy = "";
        public decimal RtrdIntrBkSttlmAmt = 0;
        public string TxInfIntrBkSttlmDt = "";
        public string ChrgBr = "";
        public string ChrgsInfBICFI = "";
        public string ChrgsInfNm = "";
        public string ChrgsInfBranchId = "";
        public string InstgAgtBICFI = "";
        public string InstdAgtBICFI = "";
        public string TxRefIntrBkSttlmCcy = "";
        public decimal TxRefIntrBkSttlmAmt = 0;
        public string TxRefIntrBkSttlmDt = "";
        public int    SvcLvlPrtry = 0;
        public string LclInstrmPrtry = "";
        public string CtgyPurpPrtry = "";
        public string PmtMtd = "";
        public string RmtInfUstrd = "";
        public string DbtrNm = "";
        public string DbtrNmPstlAdr = "";
        public string DbtrNmStrtNm = "";
        public string DbtrNmTwnNm = "";
        public string DbtrNmCtry = "";
        public string DbtrNmAdrLine = "";
        public string DbtrAcctId = "";
        public string DbtrAcctTpPrtry = "";
        public string DbtrAgtBICFINm = "";
        public string DbtrAgtBICFI = "";
        public string DbtrAgtBranchId = "";
        public string DbtrAgtAcctId = "";
        public string DbtrAgtAcctPrtry = "";
        public string CdtrAgtBICFI = "";
        public string CdtrAgtNm = "";
        public string CdtrAgtBranchId = "";
        public string CdtrAgtAcctId = "";
        public string CdtrAgtAcctTpPrtry = "";
        public string CdtrNm = "";
        public string CdtrAdrLine = "";
        public string CdtrAcctId = "";
        public string CdtrAcctTpPrtry = "";
        public string Maker = "";
        public string MakeTime = "";
        public string MakerIP = "";
        public string Checker = "";
        public string CheckTime = "";
        public string CheckerIP = "";
        public string DeletedBy = "";
        public string DeleteTime = "";
        public string CBSResponse = "";
        public string CBSTime = "";
        public int StatusID = 0;
    }

    public class Camt052
    {
        public string Camt52Id = "";
        public string FileName = "";
        public string DetectTime = "";
        public string BizMsgIdr = "";
        public string MsgId = "";
        public string CreDt = "";
        public string RptID = "";
        public string ElctrncSeqNb = "";
        public string AcctId = "";
        public string AcctBIC = "";
        public string BalCD1 = ""; 
        public decimal BalAmnt1 = 0;
        public string Ccy1 = "";
        public string CdtDbtInd1 = "";
        public string BalCD2 = "";
        public decimal BalAmnt2 = 0;
        public string Ccy2 = "";
        public string CdtDbtInd2 = "";
        public string BalCD3 = "";
        public decimal BalAmnt3 = 0;
        public string Ccy3 = "";
        public string CdtDbtInd3 = "";
        public string XmlData = "";
    }

    public class Camt053
    {
        public string FileName = "";
        public string Cam53ID = "";
        public string DetectTime = "";
        public string ToBICFI = "";
        public string BizMsgIdr = "";
        public string MsgDefIdr = "";
        public string BizSvc = "";
        public string CreDt = "";
        public string MsgId = "";
        public string CreDtTm = "";
        public string StmtId = "";
        public int StmtPgNb = 0;
        public string LastPgInd = "";
        public int ElctrncSeqNb = 0;
        public string StmtCreDtTm = "";
        public string StmtAcctId = "";
        public string OwnrOrgIdAnyBIC = "";
        public string Bal1TpCd = "";
        public string Bal1Ccy = "";
        public decimal Bal1Amount = 0;
        public string Bal1CdtDbtInd = "";
        public string Bal1Dt = "";
        public string Bal2TpCd = "";
        public string Bal2Ccy = "";
        public decimal Bal2Amount = 0;
        public string Bal2CdtDbtInd = "";
        public string Bal2Dt = "";
        public string NtryRef1 = "";
        public string NtryRef1Ccy = "";
        public decimal NtryRef1Amout = 0;
        public string NtryRef1CdtDbtInd = "";
        public string NtryRef1Sts = "";
        public string NtryRef1ValDt = "";
        public int BkTxCd1 = 0;
        public string AcctSvcrRef1 = "";
        public string InstrId1 = "";
        public string EndToEndId1 = "";
        public string TxId1 = "";
        public string NtryDtls1Ccy = "";
        public decimal NtryDtls1Amount = 0;
        public string NtryDtls1CdtDbtInd = "";
        public string NtryRef2 = "";
        public string NtryRef2Ccy = "";
        public decimal NtryRef2Amout = 0;
        public string NtryRef2CdtDbtInd = "";
        public string NtryRef2Sts = "";
        public string NtryRef2ValDt = "";
        public int BkTxCd2 = 0;
        public string AcctSvcrRef2 = "";
        public string InstrId2 = "";
        public string EndToEndId2 = "";
        public string TxId2 = "";
        public string NtryDtls2Ccy = "";
        public decimal NtryDtls2Amount = 0;
        public string NtryDtls2CdtDbtInd = "";
        public string XmlData = "";
    }

    public class Camt54
    {
        public string FileName = "";
        public string Camt054ID = "";
        public string DetectTime = "";
        public string ToBICFI = "";
        public string BizMsgIdr = "";
        public string MsgDefIdr = "";
        public string BizSvc = "";
        public string CreDt = "";
        public string MsgId = "";
        public string CreDtTm = "";
        public string NtfctnId = "";
        public string NtfctnCreDtTm = "";
        public string NtfctnAcctId = "";
        public string NtryRef = "";
        public string NtryCcy = "";
        public decimal NtryAmt = 0;
        public string NtryCdtDbtInd = "";
        public string NtrySts = "";
        public string NtryValDt = "";
        public string NtryBkTxCd = "";
        public string NtryDtlsInstrId = "";
        public string NtryDtlsEndToEndId = "";
        public string NtryDtlsTxId = "";
        public string NtryDtlsCcy = "";
        public decimal NtryDtlsAmount = 0;
        public string NtryDtlsCdtDbtInd = "";
        public string NtryDtlsInitgPtyAnyBIC = "";
        public string NtryDtlsInitgPtyNm = "";
        public string DbtrAnyBIC = "";
        public string CdtrAnyBIC = "";
        public string RltdDtsTxDtTm = "";
        public string XmlData = "";
    }

}
