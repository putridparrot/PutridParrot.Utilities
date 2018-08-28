using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class PathTests
    {
        [Test]
        public void Combine1()
        {
            var root = "c:\\home\\sub\\one";
            var relative = "..\\two";

            Assert.AreEqual("c:\\home\\sub\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineNoBacks()
        {
            var root = "c:\\home\\sub\\one";
            var relative = "two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineNoBacksPreceedingSeperator()
        {
            var root = "c:\\home\\sub\\one";
            var relative = "\\two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineNoBacksPostSeperator()
        {
            var root = "c:\\home\\sub\\one";
            var relative = "two\\";

            Assert.AreEqual("c:\\home\\sub\\one\\two\\", Path.Combine(root, relative));
        }

        [Test]
        public void CombineSuffixedRoot()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineLeadingWhitespaceRelative()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "    two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineTrailingWhitespaceRelative()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "two    ";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineLeadingWhitespaceRoot()
        {
            var root = "   c:\\home\\sub\\one\\";
            var relative = "two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineTrailingWhitespaceRoot()
        {
            var root = "c:\\home\\sub\\one\\    ";
            var relative = "two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineLeadingWhitespaceBoth()
        {
            var root = "   c:\\home\\sub\\one\\";
            var relative = "    two";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineTrailingWhitespaceBoth()
        {
            var root = "c:\\home\\sub\\one\\   ";
            var relative = "two   ";

            Assert.AreEqual("c:\\home\\sub\\one\\two", Path.Combine(root, relative));
        }

        [Test]
        public void CombineStaggeredBackTokens()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "..\\two\\..";

            Assert.AreEqual("c:\\home\\sub", Path.Combine(root, relative));
        }

        [Test]
        public void CombineSimpleBack()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "..";

            Assert.AreEqual("c:\\home\\sub", Path.Combine(root, relative));
        }

        [Test]
        public void CombineSimpleBackWithTrailing()
        {
            var root = "c:\\home\\sub\\one\\";
            var relative = "..\\";

            Assert.AreEqual("c:\\home\\sub\\", Path.Combine(root, relative));
        }

        [Test]
        public void CombineBackTooFar()
        {
            var root = "c:\\home";
            var relative = "..\\..\\..\\home";

            Assert.AreEqual("home", Path.Combine(root, relative));
        }
    }
}
