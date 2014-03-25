using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPNUOCTHUDUC.LinQ;
using log4net;
using System.Data;
using System.Data.SqlClient;

namespace CAPNUOCTHUDUC.DAL.QLDHN
{
    public static class C_DocSoTD
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_DocSoTD).Name);
        static DocSoDataContext db = new DocSoDataContext();

        public static DataTable getDataTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                if (db.Connection.State == ConnectionState.Open)
                {
                    db.Connection.Close();
                }
                db.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection getDataTable" + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return table;
        }

        public static int ExecuteCommand(string sql)
        {
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection ExecuteCommand : " + sql);
                log.Error("LinQConnection ExecuteCommand : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int ExecuteCommand_(string sql)
        {
            int result = 0;
            try
            {
                SqlConnection conn = new SqlConnection(db.Connection.ConnectionString);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conn.Close();
                db.Connection.Close();
                db.SubmitChanges();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("LinQConnection ExecuteCommand_ : " + sql);
                log.Error("LinQConnection ExecuteCommand_ : " + ex.Message);

            }
            finally
            {
                db.Connection.Close();
            }
            db.SubmitChanges();
            return result;
        }

        public static int getCSDHN(string danhbo)
        {
            DataTable tb = getDataTable("SELECT TOP(1) FROM ORDER BY NAM DESC ,KY DESC");
            if (tb.Rows.Count > 0)
            {
                return int.Parse(tb.Rows[0][1] == null ? (tb.Rows[0][1] + "") : "0");
            }
            return 0;


        }
    

 
    }
}
