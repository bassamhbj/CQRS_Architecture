using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCore {
  public class EventManager {
    #region Properties
    private static EventManager _instance;
    #endregion

    #region Constructors
    private EventManager() {

    }

    public static EventManager Instance {
      get {
        if(_instance == null) {
          _instance = new EventManager();
        }
        return _instance;
      }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
  }
}
