using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRSCore;

namespace CQRS_Architecture {
    class BookEntryHandler : CQRSCore.ICommandHandler<BookEntryCommand> {
        #region Constructor
        public BookEntryHandler() {

        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private Tuple<string, Dictionary<string, object>> GetInsertSQL(BookEntryCommand commnad) {
            string sql = "";
            var dbParams = new Dictionary<string, object>();

            sql += Environment.NewLine + "INSERT INTO TBook ( ";
            sql += Environment.NewLine + "  BookId, ";
            sql += Environment.NewLine + "  Title, ";
            sql += Environment.NewLine + "  Author ";
            sql += Environment.NewLine + ") VALUES( ";
            sql += Environment.NewLine + " @BookId, ";
            sql += Environment.NewLine + " @Title, ";
            sql += Environment.NewLine + " @Author ";
            sql += Environment.NewLine + ") ";

            dbParams.Add("BookId", commnad.BookId);
            dbParams.Add("Title", commnad.Title);
            dbParams.Add("Author", commnad.Author);

            return new Tuple<string, Dictionary<string, object>>(sql, dbParams);
        }
        #endregion

        #region Override Methdos
        public void Execute(BookEntryCommand command) {
            var dbConnection = new DataBase.DBConnection();
            var tuple = GetInsertSQL(command);
            dbConnection.InsertIntoDB(tuple.Item1, tuple.Item2);
        }
        #endregion
    }
}
