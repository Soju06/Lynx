using Lynx.Common.Components;
using System.Collections;
using System.Collections.ObjectModel;

namespace Lynx.Common {
    /// <summary>
    /// 컴포넌트 컬랙션
    /// not support parent
    /// </summary>
    public class ComponentCollection : ObservableCollection<IComponent> {
        public ComponentCollection() : base() {

        }
        
        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public IEnumerable GetComponents(Type type) { 
            foreach (var item in this)
                if (item?.GetType() == type) yield return item;
        }

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public object GetComponent(Type type) {
            foreach (var item in this)
                if (item?.GetType() == type) return item;
            return null;
        }
    }
}
