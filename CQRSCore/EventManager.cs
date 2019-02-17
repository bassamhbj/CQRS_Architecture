using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCore {
    public class EventManager {
        #region Properties
        private static EventManager _instance;

        public List<Event> EventRecord { get; set; }
        public event EventHandler<Command> CommandEvent;
        public event EventHandler<Query> QueryEvent;
        #endregion

        #region Constructors
        private EventManager() {
            EventRecord = new List<Event>();
        }

        public static EventManager Instance {
            get {
                if (_instance == null) {
                    _instance = new EventManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Public Methods
        public void OnCommand(Command command) {
            CommandEvent?.Invoke(this, command);
        }
        public void OnQuery(Query query) {
            QueryEvent?.Invoke(this, query);
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
