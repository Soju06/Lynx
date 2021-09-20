using Lynx.Common.Components;
using System.Collections.ObjectModel;
using System.Transactions;

namespace Lynx.Common {
    /// <summary>
    /// 컴포넌트 컬랙션
    /// not support parent
    /// </summary>
    public class ComponentCollection : ObservableCollection<IComponent> {
        public ComponentCollection() : base() {

        }

        /// <summary>
        /// 컴포넌트를 추가합니다.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="NotSupportedException" />
        public new IComponent Add(IComponent component) {
            if (component == null) throw new ArgumentNullException(nameof(component));
            if (component.Parents?.Components?.Contains(component) == true) throw new NotSupportedException
                    ("This component is being used by another component.");
            base.Add(component);
            return component;
        }

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public IEnumerable<IComponent> GetComponents(Type type) { 
            foreach (var item in this)
                if (EqualsType(item?.GetType(), type))
                    yield return item;
        }

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public IComponent GetComponent(Type type) {
            foreach (var item in this)
                if (EqualsType(item?.GetType(), type)) 
                    return item;
            return null;
        }

        public static bool EqualsType(Type itype, Type type) => itype == type || itype?.BaseType == type ||
                    (type?.IsInterface == true && itype?.GetInterfaces()?.Contains(type) == true);

        /// <summary>
        /// 컴포넌트를 제거합니다.
        /// </summary>
        public bool Remove(string name) =>
            Remove(this.Select(e => e.Name == name));
    }
}
