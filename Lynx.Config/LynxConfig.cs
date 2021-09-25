using LiteDB;
using Lynx.Common;
using Lynx.Logger.Interface;
using System;

namespace Lynx.Config {
    /// <summary>
    /// Lynx 구성
    /// </summary>
    public class LynxConfig : Component, ILoggableComponent {

        public LynxConfig() {

        }

        /// <summary>
        /// 데이터베이스
        /// </summary>
        public LiteDatabase Database { get; private set; }

        /// <summary>
        /// 로거
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// 데이터베이스 경로
        /// </summary>
        public string DatabasePath { get; } = Path.ChangeExtension(LynxEnvironment.ApplicationFullName, ".db");

        bool isInited;

        public void OnLoggerInited(ILogger logger) {
            if (isInited) return;
            isInited = true;
            Database = new(DatabasePath);
            Database.GetStorage<string>("LYNX_SYS", "Version").;
        }
    }
}
