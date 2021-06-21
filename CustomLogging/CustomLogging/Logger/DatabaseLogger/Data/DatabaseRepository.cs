using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 using System.Data.SqlClient;
using CustomLogging.Model;

namespace CustomLogging.Logger.DatabaseLogger.Data
{
   public  class DatabaseRepository
    {
        protected readonly Log _log;
        public DatabaseRepository( )
        {            

        }

        internal void Log(Log log, DatabaseLoggerProvider _dbProvider)
        {
            string saveStaff = "INSERT into " +  _dbProvider.Options.tableName + "( Message       ,MessageTemplate       ,Level       ,TimeStamp       ,Exception   ,Properties) " +
                  " VALUES ('" + log.Message + "', '" + log.MessageTemplate + "', '" + log.Level + "', '" + log.TimeStamp + "', '" + log.Exception + "', '" + log.Properties + "');";

            SqlConnection conn = new SqlConnection(_dbProvider.Options.connectionString);

            SqlCommand querySaveStaff = new SqlCommand(saveStaff,conn);

            try
            {
                conn.Open();
                querySaveStaff.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var x = e.Message;
                //Error when save data
 
            }
        }
    }
}
