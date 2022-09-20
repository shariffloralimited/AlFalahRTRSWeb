using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGS
{

    public class setttings 
    {
        public string   MainRoutingNo            = "";
        public string   AdditionalRoutingNo1     = "";
        public string   AdditionalRoutingNo2     = "";
        public string   AdditionalRoutingNo3     = "";
        public string   AdditionalRoutingNo4     = "";
        public string   AdditionalRoutingNo5    = "";
        public string   AdditionalRoutingNo6     = "";
        public string   AdditionalRoutingNo7    = "";
        public string   AdditionalRoutingNo8    = "";
        public string   AdditionalRoutingNo9     = "";
        public string   AdditionalRoutingNo10    = "";

    }
    public class SettingsDB
    {

        public void UpdateCutoffTime(string HVCT, string RVCT, string OHVCT, string ORVCT)
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ACH_UpdateCTSetting", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterHVCT = new SqlParameter("@HVCT", SqlDbType.VarChar, 4);
            parameterHVCT.Value = HVCT;
            myCommand.Parameters.Add(parameterHVCT);

            SqlParameter parameterRVCT = new SqlParameter("@RVCT", SqlDbType.VarChar, 4);
            parameterRVCT.Value = RVCT;
            myCommand.Parameters.Add(parameterRVCT);


            SqlParameter parameterOHVCT = new SqlParameter("@OHVCT", SqlDbType.VarChar, 4);
            parameterOHVCT.Value = OHVCT;
            myCommand.Parameters.Add(parameterOHVCT);

            SqlParameter parameterORVCT = new SqlParameter("@ORVCT", SqlDbType.VarChar, 4);
            parameterORVCT.Value = ORVCT;
            myCommand.Parameters.Add(parameterORVCT);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

        }
        public SqlDataReader GetSettings()
        {
            SqlConnection myConnection = new SqlConnection(AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_GetSettings", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return result;
        }
        public void UpdateValue(string FieldName, int FieldVal)
        {
            string sql = "Update RTGS.dbo.RTGS_BankSetting SET " + FieldName + " = " + FieldVal.ToString();
            ExecuteSQL(sql, "RTGS");
        }
        public void ExecuteSQL(string commandText, string databaseName)
        {
            SqlConnection connection = new SqlConnection(AppVariables.ConStr);
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandTimeout = 60;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
        }


        public void UpdateHeadOfficeRoutingNo(string MainRoutingNo, string AdditionalRoutingNo1, string AdditionalRoutingNo2, string AdditionalRoutingNo3, string AdditionalRoutingNo4, string AdditionalRoutingNo5, 
            string AdditionalRoutingNo6, string AdditionalRoutingNo7, string AdditionalRoutingNo8, string AdditionalRoutingNo9, string AdditionalRoutingNo10)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("ADM_UpdateHeadOfficeRoutingNo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMainRoutingNo = new SqlParameter("@MainRoutingNo", SqlDbType.VarChar, 50);
            parameterMainRoutingNo.Value = MainRoutingNo;
            myCommand.Parameters.Add(parameterMainRoutingNo);

            SqlParameter parameterAdditionalRoutingNo1 = new SqlParameter("@AdditionalRoutingNo1", SqlDbType.VarChar,50);
            parameterAdditionalRoutingNo1.Value = AdditionalRoutingNo1;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo1);

            SqlParameter parameterAdditionalRoutingNo2 = new SqlParameter("@AdditionalRoutingNo2", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo2.Value = AdditionalRoutingNo2;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo2);

            SqlParameter parameterAdditionalRoutingNo3 = new SqlParameter("@AdditionalRoutingNo3", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo3.Value = AdditionalRoutingNo3;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo3);

            SqlParameter parameterAdditionalRoutingNo4 = new SqlParameter("@AdditionalRoutingNo4", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo4.Value = AdditionalRoutingNo4;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo4);

            SqlParameter parameterAdditionalRoutingNo5 = new SqlParameter("@AdditionalRoutingNo5", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo5.Value = AdditionalRoutingNo5;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo5);

            SqlParameter parameterAdditionalRoutingNo6 = new SqlParameter("@AdditionalRoutingNo6", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo6.Value = AdditionalRoutingNo6;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo6);

            SqlParameter parameterAdditionalRoutingNo7 = new SqlParameter("@AdditionalRoutingNo7", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo7.Value = AdditionalRoutingNo7;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo7);

            SqlParameter parameterAdditionalRoutingNo8 = new SqlParameter("@AdditionalRoutingNo8", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo8.Value = AdditionalRoutingNo8;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo8);

            SqlParameter parameterAdditionalRoutingNo9 = new SqlParameter("@AdditionalRoutingNo9", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo9.Value = AdditionalRoutingNo9;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo9);

            SqlParameter parameterAdditionalRoutingNo10 = new SqlParameter("@AdditionalRoutingNo10", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo10.Value = AdditionalRoutingNo10;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo10);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            myConnection.Dispose();
            myCommand.Dispose();

        }

        public setttings  getHeadOfficeRoutingNo() 
        { 
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariables.ConStr);
            SqlCommand myCommand = new SqlCommand("RTGS_getHeadOfficeRoutingNo", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterMainRoutingNo = new SqlParameter("@MainRoutingNo", SqlDbType.VarChar, 50);
            parameterMainRoutingNo.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterMainRoutingNo);

            SqlParameter parameterAdditionalRoutingNo1= new SqlParameter("@AdditionalRoutingNo1", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo1.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo1);

            SqlParameter parameterAdditionalRoutingNo2 = new SqlParameter("@AdditionalRoutingNo2", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo2.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo2);

             SqlParameter parameterAdditionalRoutingNo3 = new SqlParameter("@AdditionalRoutingNo3", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo3.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo3);

            SqlParameter parameterAdditionalRoutingNo4= new SqlParameter("@AdditionalRoutingNo4", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo4.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo4);

            SqlParameter parameterAdditionalRoutingNo5= new SqlParameter("@AdditionalRoutingNo5", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo5.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo5);

            SqlParameter parameterAdditionalRoutingNo6 = new SqlParameter("@AdditionalRoutingNo6", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo6.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo6);

            SqlParameter parameterAdditionalRoutingNo7 = new SqlParameter("@AdditionalRoutingNo7", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo7.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo7);
            
            SqlParameter parameterAdditionalRoutingNo8= new SqlParameter("@AdditionalRoutingNo8", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo8.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo8);

            SqlParameter parameterAdditionalRoutingNo9 = new SqlParameter("@AdditionalRoutingNo9", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo9.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo9);

            SqlParameter parameterAdditionalRoutingNo10 = new SqlParameter("@AdditionalRoutingNo10", SqlDbType.VarChar, 50);
            parameterAdditionalRoutingNo10.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterAdditionalRoutingNo10);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            setttings bd = new setttings();

            bd.MainRoutingNo  =(string)parameterMainRoutingNo.Value;
            bd.AdditionalRoutingNo1 = (string) parameterAdditionalRoutingNo1.Value;
            bd.AdditionalRoutingNo2 = (string) parameterAdditionalRoutingNo2.Value;
            bd.AdditionalRoutingNo3 = (string) parameterAdditionalRoutingNo3.Value;
            bd.AdditionalRoutingNo4 = (string) parameterAdditionalRoutingNo4.Value;
            bd.AdditionalRoutingNo5 = (string) parameterAdditionalRoutingNo5.Value;
            bd.AdditionalRoutingNo6 = (string) parameterAdditionalRoutingNo6.Value;
            bd.AdditionalRoutingNo7 = (string) parameterAdditionalRoutingNo7.Value;
            bd.AdditionalRoutingNo8 = (string) parameterAdditionalRoutingNo8.Value;
            bd.AdditionalRoutingNo9 = (string) parameterAdditionalRoutingNo9.Value;
            bd.AdditionalRoutingNo10 = (string) parameterAdditionalRoutingNo10.Value;
         
            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();

            return bd;
        }
    }
}





