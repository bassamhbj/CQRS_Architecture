using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Architecture {
    public class BookSelectQuery : CQRSCore.Query {
        #region Constructors
        public BookSelectQuery() {

        }
        #endregion

        #region Properties
        public string Title { get; set; }
        public string Author { get; set; }
        #endregion
    }
}
