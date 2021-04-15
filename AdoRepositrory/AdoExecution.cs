using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdoRepositrory
{
    public class AdoExecution
    {
        SqlConnection con = null;
        public AdoExecution(string connectionString)
        {
             con = new SqlConnection(connectionString);

        }
        public int ExecuteProcedureReturn(Dictionary<string, object> keyValuePairs, string procedureName)
        {
            try
            {
                int result = 0;
                SqlCommand dbCommand = new SqlCommand(procedureName,con);
                 
                dbCommand.CommandType = CommandType.StoredProcedure;
                foreach (var sqlParameter in from item in keyValuePairs
                                             let sqlParameter = new SqlParameter()
                                             { ParameterName = item.Key, Value = item.Value }
                                             select sqlParameter)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }

                if (dbCommand.Connection.State == ConnectionState.Closed)
                {
                    dbCommand.Connection.Open();
                }

                result = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
