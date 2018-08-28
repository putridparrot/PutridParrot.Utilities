using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PutridParrot.Utilities.Cache
{
    /// <summary>
    /// CacheLite allows caching of data along with 
    /// the ability to auto evict items from the cache 
    /// upon expiry. The cache copies the items, hence
    /// will not have the same reference as the data 
    /// stored
    /// </summary>
    public class CacheLite : IDisposable
    {
        private readonly ReaderWriterLockSlim _readerWriterLock;
        private readonly Dictionary<string, CacheEntry> _store;
        private readonly ICacheScheduler _scheduler;

        public CacheLite(ICacheScheduler scheduler = null)
        {
            _scheduler = scheduler;
            _readerWriterLock = new ReaderWriterLockSlim();
            _store = new Dictionary<string, CacheEntry>();

            if (_scheduler != null)
            {
                _scheduler.Subscribe += SchedulerOnSubscribe;
            }
        }

        private void SchedulerOnSubscribe(object sender, EventArgs eventArgs)
        {
            Scavenge();
        }

        public void Set<T>(string key, T value, TimeSpan expiry)
        {
            Condition.IsTrue(!String.IsNullOrEmpty(key), nameof(key));
            Condition.IsNotNull(value, nameof(value));

            _readerWriterLock.EnterWriteLock();
            try
            {
                _store[key] = new CacheEntry(Serialization.ToBytes(value), expiry);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public T Get<T>(string key)
        {
            Condition.IsTrue(!String.IsNullOrEmpty(key), nameof(key));

            var value = default(T);

            _readerWriterLock.EnterReadLock();
            try
            {
                if (_store.TryGetValue(key, out var cacheItem))
                {
                    value = Serialization.FromBytes<T>(cacheItem.Bytes);
                    cacheItem.Touch();
                }
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
            return value;
        }

        public void Remove(string key)
        {
            Condition.IsTrue(!String.IsNullOrEmpty(key), nameof(key));

            _readerWriterLock.EnterWriteLock();
            try
            {
                _store.Remove(key);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public bool Exists(string key)
        {
            Condition.IsTrue(!String.IsNullOrEmpty(key), nameof(key));

            _readerWriterLock.EnterReadLock();
            try
            {
                return _store.ContainsKey(key);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }

        public void Clear()
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                _store.Clear();
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        private void Scavenge()
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                var now = DateTime.Now;
                var expired = _store.Where(i => now >= i.Value.Expires);

                foreach (var key in expired)
                {
                    _store.Remove(key.Key);
                }
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public void Dispose()
        {
            if (_scheduler != null)
            {
                _scheduler.Subscribe -= SchedulerOnSubscribe;
            }
            _readerWriterLock?.Dispose();
        }
    }
}
