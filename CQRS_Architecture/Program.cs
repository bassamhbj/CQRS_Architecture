using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Architecture {
    class Program {
        static void Main(string[] args) {
            //var bookEntry = new BookEntryHandler();
            //bookEntry.Execute(new BookEntryCommand("Harry Potter", "J.K. Rowling"));

            var bookSelect = new BookSelectHandler();
            var dt = bookSelect.Execute(new BookSelectQuery() { Title = "Harry Potter " });

            Console.ReadKey();
        }
    }
}
