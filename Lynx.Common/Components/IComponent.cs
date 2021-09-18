namespace Lynx.Common.Components {
    /// <summary>
    ///  컴포넌트
    /// </summary>
    public interface IComponent : IDisposable {
        /// <summary>
        /// 부모, 없을 시 null
        /// </summary>
        Component? Parents { get; }

        /// <summary>
        /// 컴포넌트들
        /// </summary>
        ComponentCollection Components { get; }

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        IEnumerable GetComponents(Type type);

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        object GetComponent(Type type);
    }
}
