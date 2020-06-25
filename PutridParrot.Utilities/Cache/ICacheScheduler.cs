using System;

namespace PutridParrot.Utilities.Cache
{
    public interface ICacheScheduler
    {
        event EventHandler Subscribe;
    }
}
