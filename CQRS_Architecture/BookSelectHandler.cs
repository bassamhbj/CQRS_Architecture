using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Architecture {
    public class BookSelectHandler : CQRSCore.IQueryHandler<BookSelectQuery> {
        #region Constructors
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private Tuple<string, Dictionary<string, object>> GetSelectSqlByTitle(string title) {
            string sql = "";
            var dbParams = new Dictionary<string, object>();

            sql += Environment.NewLine + "SELECT * ";
            sql += Environment.NewLine + "FROM TBook ";
            sql += Environment.NewLine + "WHERE Title = @Title ";
            sql += Environment.NewLine + "ORDER BY BookId ASC ";

            dbParams.Add("Title", title);

            return new Tuple<string, Dictionary<string, object>>(sql, dbParams);
        }

        private Tuple<string, Dictionary<string, object>> GetSelectSqlByAuthor(string author) {
            string sql = "";
            var dbParams = new Dictionary<string, object>();

            sql += Environment.NewLine + "SELECT * ";
            sql += Environment.NewLine + "FROM TBook ";
            sql += Environment.NewLine + "WHERE Author = @Author ";
            sql += Environment.NewLine + "ORDER BY BookId ASC ";

            dbParams.Add("Author", author);

            return new Tuple<string, Dictionary<string, object>>(sql, dbParams);
        }
        #endregion

        #region Override Methods
        public DataTable Execute(BookSelectQuery query) {
            var dbConnection = new DataBase.DBConnection();
            var tuple = GetSelectSqlByTitle(query.Title);
            return dbConnection.SelectFromDB(tuple.Item1, tuple.Item2);
        }
        #endregion
    }
}
