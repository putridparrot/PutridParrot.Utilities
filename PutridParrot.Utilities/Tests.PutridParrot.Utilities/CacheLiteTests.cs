using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities.Cache;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture, Ignore("Under development")]
    public class CacheLiteTests
    {
        [Test]
        public void Set_EnsureValueIsStoredInTheCache()
        {
            var c = new CacheLite();
            c.Set("id1", "Scooby Doo", TimeSpan.MaxValue);

            Assert.AreEqual("Scooby Doo", c.Get<string>("id1"));
        }

        [Test]
        public void Exists_EnsureValueIsStoredInTheCache()
        {
            var c = new CacheLite();
            c.Set("id1", "Scooby Doo", TimeSpan.MaxValue);

            Assert.IsTrue(c.Exists("id1"));
        }

        [Test]
        public void Remove_EnsureItemIsRemovedFromTheCache()
        {
            var c = new CacheLite();
            c.Set("id1", "Scooby Doo", TimeSpan.MaxValue);
            c.Remove("id1");

            Assert.IsFalse(c.Exists("id1"));
        }

        [Test]
        public void Clear_EnsureItemIsRemovedFromTheCache()
        {
            var c = new CacheLite();
            c.Set("id1", "Scooby Doo", TimeSpan.MaxValue);
            c.Clear();

            Assert.IsFalse(c.Exists("id1"));
        }

        [Test]
        public void ScheduledExpiry_EnsureItemRemoved()
        {
            var scheduler = new CacheScheduler(TimeSpan.FromSeconds(5));
            var c = new CacheLite(scheduler);
            c.Set("id1", "Scooby Doo", TimeSpan.FromSeconds(1));

            // force an update
            scheduler.Update();

            Assert.IsFalse(c.Exists("id1"));
        }
    }
}
