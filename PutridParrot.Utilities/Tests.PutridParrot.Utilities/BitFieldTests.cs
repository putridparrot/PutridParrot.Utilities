using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class BitFieldTests
    {
        [Test]
        public void ConstructorDefault()
        {
            var bits = new BitFields();
            Assert.AreEqual(0, bits.State);
        }

        [Test]
        public void ConstructorSingleArgument()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(3, bits.State);
        }

        [Test]
        public void StateSetGet()
        {
            var bits = new BitFields();
            bits.State = 5;
            Assert.AreEqual(5, bits.State);
        }

        [Test]
        public void Count()
        {
            var bits = new BitFields();
            Assert.AreEqual(64, bits.Count);
        }

        [Test]
        public void IndexerSetGet()
        {
            var bits = new BitFields();
            bits[2] = true;
            Assert.AreEqual(4, bits.State);
            Assert.IsTrue(bits[2]);
        }

        [Test]
        public void IndexGet_LowerRangeException()
        {
            var bits = new BitFields();
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var value = bits[-1];
            });
        }

        [Test]
        public void IndexGet_UpperRangeException()
        {
            var bits = new BitFields();
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var value = bits[64];
            });
        }

        [Test]
        public void IndexSet_LowerRangeException()
        {
            var bits = new BitFields();
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                bits[-1] = true;
            });
        }

        [Test]
        public void IndexSet_UpperRangeException()
        {
            var bits = new BitFields();
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                bits[64] = true;
            });
        }

        [Test]
        public void And_Instance()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(3 & 2, bits.And(2));
        }

        [Test]
        public void Or_Instance()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(3 | 2, bits.Or(2));
        }

        [Test]
        public void Xor_Instance()
        {
            BitFields bits = new BitFields(3);
            Assert.AreEqual(3 ^ 2, bits.Xor(2));
        }

        [Test]
        public void Not_Instance()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(~3, bits.Not());
        }

        [Test]
        public void And_Static()
        {
            Assert.AreEqual(3 & 2, BitFields.And(3, 2));
        }

        [Test]
        public void Or_Static()
        {
            Assert.AreEqual(3 | 2, BitFields.Or(3, 2));
        }

        [Test]
        public void Xor_Static()
        {
            Assert.AreEqual(3 ^ 2, BitFields.Xor(3, 2));
        }

        [Test]
        public void Not_Static()
        {
            Assert.AreEqual(~3, BitFields.Not(3));
        }

        [Test]
        public void And_Operator()
        {
            BitFields bits = new BitFields(3);
            Assert.AreEqual(3 & 2, bits & 2);
        }

        [Test]
        public void Or_Operator()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(3 | 2, bits | 2);
        }

        [Test]
        public void Xor_Operator()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(3 ^ 2, bits ^ 2);
        }

        [Test]
        public void Not_Operator()
        {
            var bits = new BitFields(3);
            Assert.AreEqual(~3, ~bits);
        }

        [Test]
        public void LeftShift_Operator()
        {
            var bits = new BitFields(1);
            Assert.AreEqual(1 << 3, bits << 3);
        }

        [Test]
        public void RightShift_Operator()
        {
            var bits = new BitFields(1);
            Assert.AreEqual(1 >> 3, bits >> 3);
        }

        [Test]
        public void ImplicitOperator()
        {
            var bits = new BitFields(5);
            long value = bits;
            Assert.AreEqual(5, value);
        }
    }
}
