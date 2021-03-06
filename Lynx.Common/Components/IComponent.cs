namespace Lynx.Common.Components {
    /// <summary>
    ///  컴포넌트
    /// </summary>
    public interface IComponent : IDisposable {
        /// <summary>
        /// 이름
        /// </summary>
        string Name { get; set; }

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
        IEnumerable<IComponent> GetComponents(Type type);

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        IComponent GetComponent(Type type);

        /// <summary>
        /// 컴포넌트를 추가합니다
        ///   리턴값:
        ///     현재 컴포넌트를 리턴합니다.
        /// </summary>
        IComponent AddComponent(IComponent component);

        /// <summary>
        /// 컴포넌트를 추가합니다
        ///   리턴값:
        ///     현재 컴포넌트를 리턴합니다.
        /// </summary>
        IComponent AddComponent(string name, IComponent component);

        /// <summary>
        /// 컴포넌트를 제거합니다.
        ///   리턴값:
        ///     성공 여부를 리턴합니다.
        /// </summary>
        bool RemoveComponent(IComponent component);

        /// <summary>
        /// 컴포넌트를 제거합니다.
        ///   리턴값:
        ///     성공 여부를 리턴합니다.
        /// </summary>
        bool RemoveComponent(string name);

        /// <summary>
        /// 부모 요소가 연결됨
        /// </summary>
        event EventHandler ParentAdded;
        /// <summary>
        /// 부모 요소와 연결이 없어짐
        /// </summary>
        event EventHandler ParentRemoved;
        /// <summary>
        /// 첫 부모 요소와 연결될때 실행됨
        /// </summary>
        event EventHandler Loaded;
    }
}
