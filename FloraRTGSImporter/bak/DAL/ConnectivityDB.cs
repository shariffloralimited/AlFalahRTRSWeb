using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RTGSImporter
{

    public class ConnectivityDB
    {
        public void SetSTPStatus(bool Status)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("CON_SetSTPStatus", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterStatus = new SqlParameter("@Status", SqlDbType.Bit);
            parameterStatus.Value = Status;
            myCommand.Parameters.Add(parameterStatus); 
    
            myConnection.Open();
            myCommand.ExecuteNonQuery();

            myConnection.Close();
            myConnection.Dispose();
            myCommand.Dispose();          
        }
    }
}