namespace Lynx.Common {
    /// <summary>
    /// lynx 환경
    /// </summary>
    public class LynxEnvironment {
        /// <summary>
        /// 링크스
        /// </summary>
        public const string LynxName = "Lynx";

        /// <summary>
        /// 관리 포트
        /// </summary>
        public const ushort ManagementPort = 34142;

        /// <summary>
        /// 앱 경로
        /// </summary>
        public static string ApplicationPath => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 앱 풀네임
        /// </summary>
        public static string ApplicationFullName => System.Reflection.Assembly.GetEntryAssembly().Location;
    }
}
