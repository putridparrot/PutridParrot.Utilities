using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class SerializationTests
    {
        [Serializable]
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Test]
        public void ToBytes_Null_ExpectNull()
        {
            Person p = null;
            var bytes = Serialization.ToBytes(p);
            Assert.IsNull(bytes);
        }

        [Test]
        public void ToBytes_NonNull_ExpectNonNull()
        {
            var p = new Person
            {
                FirstName = "Scooby",
                LastName = "Doo"
            };
            var bytes = Serialization.ToBytes(p);
            Assert.IsNotNull(bytes);
        }

        [Test]
        public void FromBytes_Null_ExpectNull()
        {
            byte[] bytes = null;
            var result = Serialization.FromBytes<Person>(bytes);
            Assert.IsNull(result);
        }

        [Test]
        public void FromBytes_NonNull_ExpectNonNull()
        {
            var p = new Person
            {
                FirstName = "Scooby",
                LastName = "Doo"
            };
            var bytes = Serialization.ToBytes(p);

            var result = Serialization.FromBytes<Person>(bytes);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ToStream_ObjectToStream_ExpectValidStream()
        {
            var p = new Person
            {
                FirstName = "Scooby",
                LastName = "Doo"
            };

            using (var stream = Serialization.ToStream(p))
            {
                Assert.IsNotNull(stream);
            }
        }

        [Test]
        public void FromStream_ObjectFromStream_ExpectOriginalObject()
        {
            var p = new Person
            {
                FirstName = "Scooby",
                LastName = "Doo"
            };

            using (var stream = Serialization.ToStream(p))
            {
                var clone = Serialization.FromStream<Person>(stream);
                Assert.AreEqual("Scooby", clone.FirstName);
                Assert.AreEqual("Doo", clone.LastName);

                Assert.AreNotSame(p, clone);
            }
        }

        [Test]
        public void Clone_EnsureObjectCorrectlyCloned()
        {
            var p = new Person
            {
                FirstName = "Scooby",
                LastName = "Doo"
            };

            var clone = Serialization.Clone(p);
            Assert.AreEqual("Scooby", clone.FirstName);
            Assert.AreEqual("Doo", clone.LastName);

            Assert.AreNotSame(p, clone);
        }

        [Test]
        public void Clone_Null_ExpectDefaultOfT()
        {
            Person p = null;
            var clone = Serialization.Clone(p);
            Assert.IsNull(clone);
        }
    }
}
