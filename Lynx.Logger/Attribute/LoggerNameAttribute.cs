namespace Lynx.Logger.Attribute {
    /// <summary>
    /// 로거 이름
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LoggerNameAttribute : System.Attribute {
        public LoggerNameAttribute(string name) {
            Name = name;
        }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; }
    }
}
