using Lynx.Common.Components;

namespace Lynx.Common.Linq {
    /// <summary>
    /// 컴포넌트 컬렉션 Linq
    /// </summary>
    public static class ComponentLinq {
        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public static T GetComponent<T>(this ComponentCollection collection) where T : IComponent =>
            (T)collection.GetComponent(typeof(T));

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public static IEnumerable<T> GetComponents<T>(this ComponentCollection collection) where T : IComponent =>
            collection.GetComponents(typeof(T)).Cast<T>();

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public static T GetComponent<T>(this Component component) where T : IComponent =>
            (T)component.GetComponent(typeof(T));

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public static IEnumerable<T> GetComponents<T>(this Component component) where T : IComponent =>
            component.GetComponents(typeof(T)).Cast<T>();
    }
}
