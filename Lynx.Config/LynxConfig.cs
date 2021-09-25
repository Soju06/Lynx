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
        /// 데이터베이스 경로
        /// </summary>
        public string DatabasePath = Path.ChangeExtension(LynxEnvironment.ApplicationFullName, ".db");
    }
}
