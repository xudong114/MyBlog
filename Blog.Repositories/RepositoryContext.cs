using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Blog.Domain;

namespace Blog.Repositories
{
    public abstract class RepositoryContext : IRepositoryContext
    {
        public Guid Id { get; } = Guid.NewGuid();

        private ConcurrentDictionary<Guid, object> _newList = new ConcurrentDictionary<Guid, object>();

        private ConcurrentDictionary<Guid, object> _modifiedList = new ConcurrentDictionary<Guid, object>();

        private ConcurrentDictionary<Guid, object> _deletedList = new ConcurrentDictionary<Guid, object>();

        public bool Committed { get; protected set; } = true;

        public abstract void Commit();

        public abstract void Rollback();


        public void Dispose()
        {
            _newList.Clear();
            _modifiedList.Clear();
            _deletedList.Clear();
        }

        public virtual void RegisterDeleted<T>(T obj) where T : class, IAggregateRoot
        {
            object delObject = null;

            if (obj.Id.Equals(Guid.Empty))
                throw new ArgumentNullException("对象标识列为空", "obj");
            if (_newList.ContainsKey(obj.Id))
            {
                if (_newList.TryRemove(obj.Id, out delObject))
                    return;
            }
            delObject = null;
            bool removedStatus = _modifiedList.TryRemove(obj.Id, out delObject);

            bool addedStatus = false;

            if (_deletedList.ContainsKey(obj.Id))
            {
                addedStatus = true;
            }

            Committed = !(removedStatus || addedStatus);

        }

        public virtual void RegisterModified<T>(T obj) where T : class, IAggregateRoot
        {
            if (obj.Id.Equals(Guid.Empty))
                throw new ArgumentNullException("对象标识列为空。", "obj");
            if (_deletedList.ContainsKey(obj.Id))
                throw new InvalidOperationException("删除状态的对象无法标记为编辑状态");
            if (!_modifiedList.ContainsKey(obj.Id) && !_newList.ContainsKey(obj.Id))
                _modifiedList.TryAdd(obj.Id, obj);
            Committed = false;
        }

        public virtual void RegisterNew<T>(T obj) where T : class, IAggregateRoot
        {
            if (obj.Id.Equals(Guid.Empty))
                throw new ArgumentNullException("对象标识列为空。", "obj");
            if (_modifiedList.ContainsKey(obj.Id))
                throw new InvalidOperationException("编辑状态的对象无法被标记为创建状态。");
            if (_newList.ContainsKey(obj.Id))
                throw new InvalidOperationException("对象已经被标记为创建状态。");

            _newList.TryAdd(obj.Id, obj);
            Committed = false;
        }
    }
}
