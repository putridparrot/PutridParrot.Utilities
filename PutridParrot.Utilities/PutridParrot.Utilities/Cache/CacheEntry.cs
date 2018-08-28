using System;

namespace PutridParrot.Utilities.Cache
{
    internal class CacheEntry
    {
        internal CacheEntry(byte[] bytes, TimeSpan expiry)
        {
            Bytes = bytes;
            Expiry = expiry;

            Touch();
        }

        internal TimeSpan Expiry { get; private set; }
        internal byte[] Bytes { get; private set; }
        internal DateTime Expires { get; private set; }

        internal void Touch()
        {
            Expires = Expiry == TimeSpan.MaxValue ? 
                DateTime.MaxValue : 
                DateTime.Now.Add(Expiry);
        }
    }
}
