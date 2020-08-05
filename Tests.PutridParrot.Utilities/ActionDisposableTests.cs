using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ActionDisposableTests
    {
        [Test]
        public void EnsureActionCalledOnDispose()
        {
            var called = false;

            using (var disposable = new ActionDisposable(() => called = true))
            {
            }

            Assert.IsTrue(called);
        }
    }
}
