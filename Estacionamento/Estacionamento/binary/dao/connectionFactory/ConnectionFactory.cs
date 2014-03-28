using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace Estacionamento
{
    public abstract class ConnectionFactory
    {

        private static String QUERYDBCONNECTION = "User=SYSDBA;Password=masterkey;DataBase=" + Directory.GetCurrentDirectory() + @"\ESTACIONAMENTO.FDB;Port=3050;DataSource=localhost;Dialect=3;Charset=UTF8;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;";

        public static FbConnection getConnection()
        {
            FbConnection conn = null;
            try
            {
                conn = new FbConnection(QUERYDBCONNECTION);
            }
            catch (FbException ex)
            {
                ex.Message.ToString();
            }
            return conn;
        }

        public static void closeAll(FbConnection connection, FbCommand query)
        {
            query.Dispose();
            connection.Close();
        }

        public static void closeAll(FbConnection connection, FbCommand query, FbDataReader dataReader)
        {
            dataReader.Close();
            query.Dispose();
            connection.Close();
        }
    }
}