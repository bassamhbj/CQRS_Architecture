using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataBase {
    public class DBConnection {
        #region Properties
        private readonly string CONNECTION_STR;
        #endregion

        #region Constructor
        public DBConnection() {
            CONNECTION_STR = ConfigurationManager.ConnectionStrings["BooksDBConnectionString"].ConnectionString;
        }
        #endregion

        #region Public Methods
        public int InsertIntoDB(string sql, Dictionary<string, object> dbParams) {
            return ConnectToDB<int>(insertFunc, sql, dbParams);
        }

        public DataTable SelectFromDB(string sql, Dictionary<string, object> dbParams) {
            return ConnectToDB<DataTable>(selectFunc, sql, dbParams);
        }
        #endregion

        #region Private Methods
        private T ConnectToDB<T>(Func<SqlCommand, T> dbAction, string sql, Dictionary<string, object> dbParams) {
            T result;

            using (var connection = new SqlConnection(CONNECTION_STR)) {
                connection.Open();

                var sqlCmd = connection.CreateCommand();
                sqlCmd.CommandText = sql;

                foreach (var param in dbParams) {
                    sqlCmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                result = dbAction(sqlCmd);

                connection.Close();
            }

            return result;
        }

        private Func<SqlCommand, DataTable> selectFunc = (sqlCmd) => {
            var dt = new DataTable();

            using (var adapter = new SqlDataAdapter()) {
                adapter.SelectCommand = sqlCmd;
                try {
                    adapter.Fill(dt);
                }
                catch (Exception e) {
                    throw e;
                }
                finally {
                    adapter.Dispose();
                    sqlCmd.Dispose();
                }
            }

            return dt;
        };

        private Func<SqlCommand, int> insertFunc = (sqlCmd) => {
            int result = 0;

            try {
                result = sqlCmd.ExecuteNonQuery();

                var a = 0;
            }
            catch (Exception e) {
                throw e;
            }
            finally {
                sqlCmd.Dispose();
            }

            return result;
        };
        #endregion
    }
}
