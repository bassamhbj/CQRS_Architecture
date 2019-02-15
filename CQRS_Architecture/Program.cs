using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Architecture {
  class Program {
    static void Main(string[] args) {
      var db = new DataBase.DBConnection();

      var dt = db.TestDB();

      Console.ReadKey();
    }
  }
}
