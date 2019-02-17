using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Architecture {
    public class BookEntryCommand : CQRSCore.Command {
        #region Constructors
        public BookEntryCommand(string title, string author) {
            this.BookId = new Random().Next(0, 999); // fix 
            this.Title = title;
            this.Author = author;
        }
        #endregion

        #region Properties
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        #endregion
    }
}
