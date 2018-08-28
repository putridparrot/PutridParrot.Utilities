using System;
using System.Threading;

namespace PutridParrot.Utilities.Cache
{
    public class CacheScheduler :
        ICacheScheduler,
        IDisposable
    {
        private Timer _timer;
        private readonly TimeSpan _period;
        private event EventHandler _subscribe;

        public CacheScheduler(TimeSpan period)
        {
            _period = period == default(TimeSpan) ?
                TimeSpan.FromSeconds(60) :
                period;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void Check()
        {
            if (_subscribe?.GetInvocationList().Length <= 0)
            {
                // if we have NO registered clients
                if (_timer != null)
                {
                    _timer.Change(-1, -1);
                    _timer.Dispose();
                    _timer = null;
                }
            }
            else
            {
                // if we have registered clients
                if (_timer == null)
                {
                    _timer = new Timer(Update);
                    _timer.Change(_period, _period);
                }
            }
        }

        private void Update(object o)
        {
            Update();
        }

        public void Update()
        {
            // call connected clients to scavenge
            _subscribe?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Subscribe
        {
            add
            {
                _subscribe += value;
                Check();
            }
            remove
            {
                _subscribe -= value;
                Check();
            }
        }
    }

}
