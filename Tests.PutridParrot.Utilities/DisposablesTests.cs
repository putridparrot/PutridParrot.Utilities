using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class DisposablesTests
    {
        internal class TestDisposable : IDisposable
        {
            private bool disposed;
            public TestDisposable()
            {
                disposed = false;
            }
            public bool IsDisposed
            {
                get { return disposed; }
            }
            public void Dispose()
            {
                disposed = true;
            }
        }

        [Test]
        public void ExplicitDispose()
        {
            TestDisposable o = new TestDisposable();

            Assert.IsFalse(o.IsDisposed);

            var disposer = new Disposables();
            disposer.Add(o);
            disposer.Dispose();

            Assert.IsTrue(o.IsDisposed);
        }
        [Test]
        public void ImplicitDispose()
        {
            TestDisposable o = new TestDisposable();

            Assert.IsFalse(o.IsDisposed);

            using (var disposer = new Disposables())
            {
                disposer.Add(o);
            }

            Assert.IsTrue(o.IsDisposed);
        }
        [Test]
        public void Add()
        {
            TestDisposable[] o = new TestDisposable[4];
            for (int i = 0; i < o.Length; i++)
            {
                o[i] = new TestDisposable();
            }

            using (var disposer = new Disposables())
            {
                foreach (IDisposable d in o)
                {
                    disposer.Add(d);
                }
            }
            foreach (TestDisposable d in o)
            {
                Assert.IsTrue(d.IsDisposed);
            }
        }
        [Test]
        public void Remove()
        {
            TestDisposable[] o = new TestDisposable[4];
            for (int i = 0; i < o.Length; i++)
            {
                o[i] = new TestDisposable();
            }

            using (var disposer = new Disposables())
            {
                foreach (IDisposable d in o)
                {
                    disposer.Add(d);
                }
                disposer.RemoveAt(2);
            }
            for (int i = 0; i < o.Length; i++)
            {
                if (i == 2)
                    Assert.IsFalse(o[i].IsDisposed);
                else
                    Assert.IsTrue(o[i].IsDisposed);
            }
        }
    }

}
