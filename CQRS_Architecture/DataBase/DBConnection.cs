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
    public DataTable TestDB() {
      string sql = "SELECT * FROM TBook ";

      return ConnectToDB(selectFunc, sql);
    }
    #endregion

    #region Private Methods
    private T ConnectToDB<T>(Func<SqlCommand, T> dbAction, string sql) {
      T result;

      using (var connection = new SqlConnection(CONNECTION_STR)) {
        connection.Open();

        var sqlCmd = connection.CreateCommand();
        sqlCmd.CommandText = sql;

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
        } catch (Exception e) {
          throw e;
        } finally {
          adapter.Dispose();
          sqlCmd.Dispose();
        }
      }

      return dt;
    };
    #endregion
  }
}
