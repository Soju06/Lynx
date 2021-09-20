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

        public event EventHandler ParentAdded;
        public event EventHandler ParentRemoved;
        public event EventHandler Loaded;

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
            if (e.OldItems != null) foreach (var item in e.OldItems) {
                    var i = (Component)item;
                    i.Parents = null;
                    i.OnParentRemoved(i, EventArgs.Empty);
                }
            if (e.NewItems != null) foreach (var item in e.NewItems) {
                    var i = (Component)item;
                    i.Parents = this;
                    i.OnParentAdded(i, EventArgs.Empty);
                }
        }

        bool loadedValue;

        protected virtual void OnParentAdded(object sender, EventArgs e) {
            if (!loadedValue) {
                loadedValue = true;
                OnLoaded(sender, EventArgs.Empty);
            } ParentAdded?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnParentRemoved(object sender, EventArgs e) =>
            ParentRemoved?.Invoke(this, EventArgs.Empty);

        protected virtual void OnLoaded(object sender, EventArgs e) =>
            Loaded?.Invoke(this, EventArgs.Empty);

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
