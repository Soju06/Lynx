using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Lynx.Logger {
    public class LoggerListenerCollection : Collection<LoggerListener> {
        /// <summary>
        /// 리스너를 제거합니다.
        /// </summary>
        public bool Remove(string name) =>
            Remove(this.Select(e => e.Name == name));
    }
}
