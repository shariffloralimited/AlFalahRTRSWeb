using System;

namespace RTGSImporter
{
        public class Pacs009
        {
            public string FileName = "";
            public string PacsID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string BtchBookg = "";
            public string BtchBookgID = "00000000-0000-0000-0000-000000000000";
            public decimal TtlIntrBkSttlmAmt = 0;
            public int NbOfTxs = 0;

            public string LclInstrmPrtry = "";
            public string SvcLvlPrtry = "";
            public string CtgyPurpPrtry = "";
            public string InstrId = "";
            public string TxId = "";
            public string EndToEndId = "";
            public string IntrBkSttlmCcy = "";
            public decimal IntrBkSttlmAmt = 0;
            public string IntrBkSttlmDt = "";

            public string InstgAgtBICFI = "";
            public string InstgAgtNm = "";
            public string InstgAgtBranchId = "";

            public string InstdAgtBICFI = "";
            public string InstdAgtNm = "";
            public string InstdAgtBranchId = "";

            public string IntrmyAgt1BICFI = "";
            public string IntrmyAgt1Nm = "";
            public string IntrmyAgt1BranchId = "";
            public string IntrmyAgt1AcctId = "";
            public string IntrmyAgt1AcctTp = "";

            public string DbtrBICFI = "";
            public string DbtrNm = "";
            public string DbtrBranchId = "";
            public string DbtrAcctId = "";
            public string DbtrAcctTp = "";

            public string CdtrAgtBICFI = "";
            public string CdtrAgtBranchId = "";
            public string CdtrAgtAcctId = "";
            public string CdtrAgtAcctTp = "";

            public string CdtrBICFI = "";
            public string CdtrNm = "";
            public string CdtrBranchId = "";
            public string CdtrAcctId = "";
            public string CdtrAcctTp = "";

            public string InstrInf = "";
            public string PmntRsn = "";

            public string Maker = "";
            public string MakeTime = "";
            public string MakerIP = "";
            public string Checker = "";
            public string CheckTime = "";
            public string CheckerIP = "";
            public string Admin = "";
            public string AdminTime = "";
            public string AdminIP = "";
            public string DeletedBy = "";
            public string DeleteTime = "";
            public string CBSResponse = "";
            public string CBSTime = "";
            public int StatusID = 0;
        }

        public class Camt06
        {
            public string Camt06ID = "";
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
            public string OrgnlBizQry1 = "";
            public string PrtryId = "";
            public string TxId = "";
            public string ShrtBizIdIntrBkSttlmDt = "";
            public string ShrtBizIdBICFI = "";
            public string PmtMsgId = "";
            public string CdPrtry = "";
            public string PrtryRjctnRsn = "";
            public string Ccy = "";
            public decimal AmtWthCcy = 0;
            public string IntrBkSttlmDt = "";
            public string EndToEndId = "";
            public string DbtrBICFI = "";
            public string CdtrBICFI = "";
            public string AcctId = "";
            public string XmlData = "";
        }
        public class Camt19
        {
            public string FileName = "";
            public string Camt19ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgHdrMsgId = "";
            public string MsgHdrCreDtTm = "";
            public string OrgnlBizQryMsgId = "";
            public string OrgnlBizQryCreDtTm = "";
            public string SysIdPrtry = "";
            public string BizDayInfSysDt = "";
            public string XmlData = "";
        }
        public class Cam19Evt
        {
            public string EvtID = ""; 
            public Guid Camt19ID = Guid.Empty;
            public string TpPrtryId = "";
            public string SchdldTm = "";
            public string StartTm = "";
            public string EndTm = "";

        }
        public class camt25
        {
            public string FileName = "";
            public string Camt25ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string OrgnlMsgId = "";
            public string StsCd = "";
            public string Desc = "";
            public string XmlData = "";
        }
        public class camt07
        {
            public string FileName = "";
            public string Camt07ID = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string MsgId = "";
            public string CreDtTm = "";
            public string TxId = "";
            public string IntrBkSttlmDt = "";
            public string InstgAgtBICFI = "";
            public string NewPmtValSetPrtryCd = "";
            public string XmlData = "";
        }
        public class camt998
        {
            public string Camt998ID = "";
            public string FileName = "";
            public string DetectTime = "";
            public string FrBICFI = "";
            public string ToBICFI = "";
            public string BizMsgIdr = "";
            public string MsgDefIdr = "";
            public string BizSvc = "";
            public string CreDt = "";
            public string PrtryMsgIdRef = "";
            public string PrtryMsgRltdRef = "";
            public string PrtryDataTp = "";
            public string PrtryDataRcvr = "";
            public string PrtryDataText = "";
            public string ServiceMessageCode = "";
            public string ServiceMessageCode1 = "";
            public string ServiceMessageValue1 = "";
            public string ServiceMessageCode2 = "";
            public string ServiceMessageValue2 = "";
            public string ServiceMessageCode3 = "";
            public string ServiceMessageValue3 = "";
            public string ServiceMessageCode4 = "";
            public string ServiceMessageValue4 = "";
            public string ServiceMessageCode5 = "";
            public string ServiceMessageValue5 = "";
            public string LqdtReqTp = "";
            public string LqdtPvdSys = "";
            public string LqdtReqId = "";
            public string LqdtReqAcctTp = "";
            public string LqdtReqAcctOwnrBIC = "";
            public string LqdtReqAmtWthCCY = "";
            public string LqdtRelTrfSndr = "";
            public string LqdtRelTrfSttlmDt = "";
            public string LqdtRelTrfRef = "";
            public string LqdtReqMtrtDt = "";
            public string LqdtOpTp = "";
            public string StlfLmtId = "";
            public string AcctOwnrOrgId = "";
            public string NewLmtAmtWthtCcy = "";
            public string XmlData = "";
        }
}
