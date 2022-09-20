using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{
    public class CBSTranData
    {
        public string SLNo = "";
        public string TransType  = "";
        public string AcctId     = "";
        public decimal SttlmAmt  = 0;
        public string Ccy        = "";
        public string RoutingNo  = "";
        public string BranchCD   = "";
        public string EntryDesc  = "";
    }
    public class CBSTransactionDB
    {
        public void ReverseCBSTransaction(Guid FormID)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("CBS_ReverseTransaction", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterFormID = new SqlParameter("@FormID", SqlDbType.UniqueIdentifier, 50);
            parameterFormID.Value = FormID;
            myCommand.Parameters.Add(parameterFormID);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            myConnection.Dispose();
            myCommand.Dispose();

        }

        public void InsertCBSTransaction(CBSTranData data)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("CBS_InsertTransaction", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterSLNo = new SqlParameter("@SLNo", SqlDbType.VarChar, 16);
            parameterSLNo.Value = data.SLNo;
            myCommand.Parameters.Add(parameterSLNo);

            SqlParameter parameterTransType = new SqlParameter("@TransType", SqlDbType.VarChar, 10);
            parameterTransType.Value = data.TransType;
            myCommand.Parameters.Add(parameterTransType);

            SqlParameter parameterAcctId = new SqlParameter("@AcctId", SqlDbType.VarChar, 35);
            parameterAcctId.Value = data.AcctId;
            myCommand.Parameters.Add(parameterAcctId);

            SqlParameter parameterSttlmAmt = new SqlParameter("@SttlmAmt", SqlDbType.Money);
            parameterSttlmAmt.Value = data.SttlmAmt;
            myCommand.Parameters.Add(parameterSttlmAmt);

            SqlParameter parameterCcy = new SqlParameter("@Ccy", SqlDbType.VarChar, 7);
            parameterCcy.Value = data.Ccy;
            myCommand.Parameters.Add(parameterCcy);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = data.RoutingNo;
            myCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterBranchCD = new SqlParameter("@BranchCD", SqlDbType.VarChar, 4);
            parameterBranchCD.Value = data.BranchCD;
            myCommand.Parameters.Add(parameterBranchCD);

            SqlParameter parameterEntryDesc = new SqlParameter("@EntryDesc", SqlDbType.VarChar, 120);
            parameterEntryDesc.Value = data.EntryDesc;
            myCommand.Parameters.Add(parameterEntryDesc);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            myConnection.Dispose();
            myCommand.Dispose();

        }
        public DataTable GetCBSTransaction(string ClearingType, string RoutingNo, string FormName)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlDataAdapter myCommand = new SqlDataAdapter("CBS_GetTransaction", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterClearingType = new SqlParameter("@ClearingType", SqlDbType.VarChar, 10);
            parameterClearingType.Value = ClearingType;
            myCommand.SelectCommand.Parameters.Add(parameterClearingType);

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 9);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.SelectCommand.Parameters.Add(parameterFormName); 
            
            myConnection.Open();
            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();   

            return dt;
        }

    }
}

