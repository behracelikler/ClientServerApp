using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLibrary
{
    public class SqlOperations
    {
        public static SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=master;Trusted_Connection=True;");

        public static SqlConnection GetConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception)
            {
                throw;
            }

            return conn;
        }

        public static SqlConnection CloseConnection(Boolean pKeepServerLog)
        {
            if (!pKeepServerLog)
                return null;
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            return conn;
        }

        public static void SQLLog(Boolean pKeepServerLog, string pDataSender, string pDataSend, string pDataReceived,
                                  string pBackSendMessage, string pListenIP, int pListenPort, string pErrorContent)
        {
            if (!pKeepServerLog)
                return;

            using (SqlCommand insertCommand = new SqlCommand("INSERT INTO TABLE_LOG (DATASSENDER, DATASEND, DATARECEIVED, BACKSENDMESSAGE, TIME, IP, PORT, ERRORCONTENT)"
                                                  + " VALUES (@DATASSENDER, @DATASEND, @DATARECEIVED, @BACKSENDMESSAGE, @TIME, @IP, @PORT, @ERRORCONTENT)", SqlOperations.GetConnection()))

            {
                insertCommand.Parameters.Add(new SqlParameter("DATASSENDER", pDataSender));
                insertCommand.Parameters.Add(new SqlParameter("DATASEND", pDataSend));
                insertCommand.Parameters.Add(new SqlParameter("DATARECEIVED", pDataReceived));
                insertCommand.Parameters.Add(new SqlParameter("BACKSENDMESSAGE", pBackSendMessage));
                insertCommand.Parameters.Add(new SqlParameter("TIME", DateTime.Now));
                insertCommand.Parameters.Add(new SqlParameter("IP", pListenIP));
                insertCommand.Parameters.Add(new SqlParameter("PORT", pListenPort));
                insertCommand.Parameters.Add(new SqlParameter("ERRORCONTENT", pErrorContent));
                insertCommand.ExecuteNonQuery();
            }

            /*
           CREATE TABLE [dbo].[TABLE_LOG](
          [ID] [int] IDENTITY(1,1) NOT NULL,
          [DATASSENDER] [nvarchar](300) NULL,
          [DATASEND] [nvarchar](300) NULL, 
          [DATARECEIVED] [nvarchar](300) NULL,  
          [BACKSENDMESSAGE][nvarchar](300) NULL,
          [TIME] [datetime] NULL,
          [IP] [nvarchar](20) NULL,
          [PORT] [int]  NULL,
          [ERRORCONTENT]  [Text] NULL,
          CONSTRAINT [PK_TABLE_LOG] PRIMARY KEY CLUSTERED 
          (
          [ID] ASC
          ) ) ON [PRIMARY]
            */
        }

    }
}
