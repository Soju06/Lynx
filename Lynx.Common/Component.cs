using Lynx.Common.Components;

namespace Lynx.Common {
    /// <summary>
    /// 컴포넌트
    /// </summary>
    public abstract class Component : IComponent {
        protected bool disposedValue;

        public Component() {
            Components.CollectionChanged += OnCollectionChanged;
        }

        public virtual string Name { get; set; }

        /// <summary>
        /// 부모, 없다면 null
        /// </summary>
        public Component Parents { get; private set; }

        /// <summary>
        /// 컴포넌트들
        /// </summary>
        public ComponentCollection Components { get; private set; } = new();

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public IEnumerable<IComponent> GetComponents(Type type) => Components.GetComponents(type);

        /// <summary>
        /// 컴포넌트를 가져옵니다.
        /// 컴포넌트가 없을 시 null을 리턴합니다.
        /// </summary>
        public IComponent GetComponent(Type type) => Components.GetComponent(type);

        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) foreach (var item in e.OldItems) ((Component)item).Parents = null;
            if (e.NewItems != null) foreach (var item in e.NewItems) ((Component)item).Parents = this;
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {

                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IComponent AddComponent(IComponent component) {
            Components.Add(component);
            return this;
        }

        public IComponent AddComponent(string name, IComponent component) {
            component.Name = name;
            Components.Add(component);
            return this;
        }

        public bool RemoveComponent(IComponent component) =>
            Components.Remove(component);

        public bool RemoveComponent(string name) =>
            Components.Remove(name);
    }
}
