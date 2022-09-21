using System;
using System.Data;
using System.Data.SqlClient;

namespace RTGSImporter
{
    class OutwardDB
    {
        public DataTable GetOutwardList(string RoutingNo, int StatusID)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlDataAdapter myCommand = new SqlDataAdapter("BP_GetListOutward", myConnection);
            myCommand.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterRoutingNo = new SqlParameter("@RoutingNo", SqlDbType.VarChar, 20);
            parameterRoutingNo.Value = RoutingNo;
            myCommand.SelectCommand.Parameters.Add(parameterRoutingNo);

            SqlParameter parameterStatusID = new SqlParameter("@StatusID", SqlDbType.Int, 4);
            parameterStatusID.Value = StatusID;
            myCommand.SelectCommand.Parameters.Add(parameterStatusID);

            myConnection.Open();

            DataTable dt = new DataTable();
            myCommand.Fill(dt);

            myConnection.Close();
            myCommand.Dispose();
            myConnection.Dispose();
            return dt;
        }
        public string AddToCart(string OutwardID, string FormName, string CartID)
        {
            SqlConnection myConnection = new SqlConnection(RTGS.AppVariable.ServerLogin);
            SqlCommand myCommand = new SqlCommand("BP_AddToCart", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterOutwardID = new SqlParameter("@OutwardID", SqlDbType.UniqueIdentifier, 50);
            parameterOutwardID.Value = new Guid(OutwardID);
            myCommand.Parameters.Add(parameterOutwardID);

            SqlParameter parameterFormName = new SqlParameter("@FormName", SqlDbType.VarChar, 10);
            parameterFormName.Value = FormName;
            myCommand.Parameters.Add(parameterFormName);

            SqlParameter parameterCartID = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier, 50);
            parameterCartID.Value = new Guid(CartID);
            myCommand.Parameters.Add(parameterCartID);

            SqlParameter parameterResult = new SqlParameter("@Result", SqlDbType.VarChar, 60);
            parameterResult.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(parameterResult);

            myConnection.Open();
            myCommand.ExecuteNonQuery();

            string Result = (string) parameterResult.Value;

            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();

            return Result;
        }
    }
}
