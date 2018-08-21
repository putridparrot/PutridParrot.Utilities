using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Utilities;

namespace Tests.PutridParrot.Utilities
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class EnumDescriptorTests
    {
        private const string TWO = "Number Two";
        private const string THREE = "Third";
        private const string FOUR = "Four";
        private const string FIVE = "Five gold rings";

        private const string TWO_CASETEST = "NuMbEr TwO";
        private const string THREE_CASETEST = "ThIrD";
        private const string FOUR_CASETEST = "FoUr";
        private const string FIVE_CASETEST = "FiVe GoLd RiNgs";
        const string TESTENUM = "List of test enumerations";

        [System.ComponentModel.Description(TESTENUM)]
        public enum TestEnum
        {
            // Intentionally commented out to test that default behaviour works - [EnumDescriptor.Description("1")]
            One,
            [System.ComponentModel.Description(TWO)]
            Two,
            [System.ComponentModel.Description(THREE)]
            Three,
            [System.ComponentModel.Description(FOUR)]
            Four,
            [System.ComponentModel.Description(FIVE)]
            Five
        }

        public enum NoDescriptionEnum
        {
        }

        #region GetDescription Tests for the enumerated description        
        [Test]
        public void EnumDescription()
        {
            Assert.AreEqual(TESTENUM, EnumDescriptor.GetDescription(typeof(TestEnum)));
        }
        [Test]
        public void Generic_EnumDescription()
        {
            Assert.AreEqual(TESTENUM, EnumDescriptor.GetDescription<TestEnum>());
        }
        [Test]
        public void EnumDescriptionNoDescription()
        {
            Assert.AreEqual(null, EnumDescriptor.GetDescription(typeof(NoDescriptionEnum)));
        }
        [Test]
        public void Generic_EnumDescriptionNoDescription()
        {
            Assert.AreEqual(null, EnumDescriptor.GetDescription<NoDescriptionEnum>());
        }
        #endregion

        #region GetDescription Tests
        [
        TestCase(null, TestEnum.One),
        TestCase(TWO, TestEnum.Two),
        TestCase(THREE, TestEnum.Three),
        TestCase(FOUR, TestEnum.Four),
        TestCase(FIVE, TestEnum.Five)
        ]
        public void GetDescription(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetDescription(typeof(TestEnum), value));
        }

        [
        TestCase(null, TestEnum.One),
        TestCase(TWO, TestEnum.Two),
        TestCase(THREE, TestEnum.Three),
        TestCase(FOUR, TestEnum.Four),
        TestCase(FIVE, TestEnum.Five)
        ]
        public void Generic_GetDescription(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetDescription<TestEnum>(value));
        }
        #endregion

        #region GetDisplayName Tests
        [
        TestCase("One", TestEnum.One),
        TestCase(TWO, TestEnum.Two),
        TestCase(THREE, TestEnum.Three),
        TestCase(FOUR, TestEnum.Four),
        TestCase(FIVE, TestEnum.Five)
        ]
        public void GetDisplayName(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetDisplayName(typeof(TestEnum), value));
        }

        [
        TestCase("One", TestEnum.One),
        TestCase(TWO, TestEnum.Two),
        TestCase(THREE, TestEnum.Three),
        TestCase(FOUR, TestEnum.Four),
        TestCase(FIVE, TestEnum.Five)
        ]
        public void Generic_GetDisplayName(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetDisplayName<TestEnum>(value));
        }
        #endregion

        #region GetName Tests
        [
        TestCase("One", TestEnum.One),
        TestCase("Two", TestEnum.Two),
        TestCase("Three", TestEnum.Three),
        TestCase("Four", TestEnum.Four),
        TestCase("Five", TestEnum.Five)
        ]
        public void GetName(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetName(typeof(TestEnum), value));
        }

        [
        TestCase("One", TestEnum.One),
        TestCase("Two", TestEnum.Two),
        TestCase("Three", TestEnum.Three),
        TestCase("Four", TestEnum.Four),
        TestCase("Five", TestEnum.Five)
        ]
        public void Generic_GetName(string expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.GetName<TestEnum>(value));
        }
        #endregion

        #region GetDisplayNames Tests
        [Test]
        public void GetDisplayNames()
        {
            string[] names = EnumDescriptor.GetDisplayNames(typeof(TestEnum));
            Assert.AreEqual(5, names.Length);
            Assert.AreEqual("One", names[0]);
            Assert.AreEqual(TWO, names[1]);
            Assert.AreEqual(THREE, names[2]);
            Assert.AreEqual(FOUR, names[3]);
            Assert.AreEqual(FIVE, names[4]);
        }

        [Test]
        public void Generic_GetDisplayNames()
        {
            string[] names = EnumDescriptor.GetDisplayNames<TestEnum>();
            Assert.AreEqual(5, names.Length);
            Assert.AreEqual("One", names[0]);
            Assert.AreEqual(TWO, names[1]);
            Assert.AreEqual(THREE, names[2]);
            Assert.AreEqual(FOUR, names[3]);
            Assert.AreEqual(FIVE, names[4]);
        }
        #endregion

        #region GetDescriptions Tests
        [Test]
        public void GetDescriptions()
        {
            string[] names = EnumDescriptor.GetDescriptions(typeof(TestEnum));
            Assert.AreEqual(5, names.Length);
            Assert.AreEqual(null, names[0]);
            Assert.AreEqual(TWO, names[1]);
            Assert.AreEqual(THREE, names[2]);
            Assert.AreEqual(FOUR, names[3]);
            Assert.AreEqual(FIVE, names[4]);
        }

        [Test]
        public void Generic_GetDescriptions()
        {
            string[] names = EnumDescriptor.GetDescriptions<TestEnum>();
            Assert.AreEqual(5, names.Length);
            Assert.AreEqual(null, names[0]);
            Assert.AreEqual(TWO, names[1]);
            Assert.AreEqual(THREE, names[2]);
            Assert.AreEqual(FOUR, names[3]);
            Assert.AreEqual(FIVE, names[4]);
        }
        #endregion

        #region ParseDisplayName Tests
        [
        TestCase(TestEnum.One, "One"),
        TestCase(TestEnum.Two, TWO),
        TestCase(TestEnum.Three, THREE),
        TestCase(TestEnum.Four, FOUR),
        TestCase(TestEnum.Five, FIVE)
        ]
        public void ParseDisplayName(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName(typeof(TestEnum), value));
        }

        [
        TestCase(TestEnum.One, "One"),
        TestCase(TestEnum.Two, TWO),
        TestCase(TestEnum.Three, THREE),
        TestCase(TestEnum.Four, FOUR),
        TestCase(TestEnum.Five, FIVE)
        ]
        public void Generic_ParseDisplayName(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName<TestEnum>(value));
        }
        #endregion

        #region ParseDescription Tests
        [
        //TestCase(null, "One", ExpectedException = typeof(ArgumentException)),
        TestCase(TestEnum.Two, TWO),
        TestCase(TestEnum.Three, THREE),
        TestCase(TestEnum.Four, FOUR),
        TestCase(TestEnum.Five, FIVE),
        //TestCase(null, "Unknown", ExpectedException = typeof(ArgumentException)),
        ]
        public void ParseDescription(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDescription(typeof(TestEnum), value));
        }

        [
        //TestCase(null, "One", ExpectedException = typeof(ArgumentException)),
        TestCase(TestEnum.Two, TWO),
        TestCase(TestEnum.Three, THREE),
        TestCase(TestEnum.Four, FOUR),
        TestCase(TestEnum.Five, FIVE),
        //TestCase(null, "Unknown", ExpectedException = typeof(ArgumentException)),
        ]
        public void Generic_ParseDescription(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDescription<TestEnum>(value));
        }
        #endregion

        #region Parse Tests
        [
        TestCase(TestEnum.One, "One"),
        TestCase(TestEnum.Two, "Two"),
        TestCase(TestEnum.Three, "Three"),
        TestCase(TestEnum.Four, "Four"),
        TestCase(TestEnum.Five, "Five")
        ]
        public void Parse(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.Parse(typeof(TestEnum), value));
        }

        [
        TestCase(TestEnum.One, "One"),
        TestCase(TestEnum.Two, "Two"),
        TestCase(TestEnum.Three, "Three"),
        TestCase(TestEnum.Four, "Four"),
        TestCase(TestEnum.Five, "Five")
        ]
        public void Generic_Parse(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.Parse<TestEnum>(value));
        }
        #endregion

        #region ParseDisplayName Case Tests
        [
        TestCase(TestEnum.One, "one"),
        TestCase(TestEnum.Two, TWO_CASETEST),
        TestCase(TestEnum.Three, THREE_CASETEST),
        TestCase(TestEnum.Four, FOUR_CASETEST),
        TestCase(TestEnum.Five, FIVE_CASETEST)
        ]
        public void ParseDisplayNameIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName(typeof(TestEnum), value, true));
        }

        [
        TestCase(TestEnum.One, "one"),
        TestCase(TestEnum.Two, TWO_CASETEST),
        TestCase(TestEnum.Three, THREE_CASETEST),
        TestCase(TestEnum.Four, FOUR_CASETEST),
        TestCase(TestEnum.Five, FIVE_CASETEST)
        ]
        public void Generic_ParseDisplayNameIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName<TestEnum>(value, true));
        }

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, TWO_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, THREE_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, FOUR_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, FIVE_CASETEST, ExpectedException = typeof(ArgumentException))
        //]
        //public void ParseDisplayNameCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName(typeof(TestEnum), value, false));
        //}

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, TWO_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, THREE_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, FOUR_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, FIVE_CASETEST, ExpectedException = typeof(ArgumentException))
        //]
        //public void Generic_ParseDisplayNameCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.ParseDisplayName<TestEnum>(value, false));
        //}
        #endregion

        #region ParseDescription Case Tests
        [
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        TestCase(TestEnum.Two, TWO_CASETEST),
        TestCase(TestEnum.Three, THREE_CASETEST),
        TestCase(TestEnum.Four, FOUR_CASETEST),
        TestCase(TestEnum.Five, FIVE_CASETEST)
        ]
        public void ParseDescriptionIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDescription(typeof(TestEnum), value, true));
        }

        [
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        TestCase(TestEnum.Two, TWO_CASETEST),
        TestCase(TestEnum.Three, THREE_CASETEST),
        TestCase(TestEnum.Four, FOUR_CASETEST),
        TestCase(TestEnum.Five, FIVE_CASETEST)
        ]
        public void Generic_ParseDescriptionIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.ParseDescription<TestEnum>(value, true));
        }

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, TWO_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, THREE_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, FOUR_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, FIVE_CASETEST, ExpectedException = typeof(ArgumentException))
        //]
        //public void ParseDescriptionCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.ParseDescription(typeof(TestEnum), value, false));
        //}

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, TWO_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, THREE_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, FOUR_CASETEST, ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, FIVE_CASETEST, ExpectedException = typeof(ArgumentException))
        //]
        //public void Generic_ParseDescriptionCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.ParseDescription<TestEnum>(value, false));
        //}
        #endregion

        #region ParseDescription Case Tests
        [
        TestCase(TestEnum.One, "one"),
        TestCase(TestEnum.Two, "two"),
        TestCase(TestEnum.Three, "three"),
        TestCase(TestEnum.Four, "four"),
        TestCase(TestEnum.Five, "five")
        ]
        public void ParseIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.Parse(typeof(TestEnum), value, true));
        }

        [
        TestCase(TestEnum.One, "one"),
        TestCase(TestEnum.Two, "two"),
        TestCase(TestEnum.Three, "three"),
        TestCase(TestEnum.Four, "four"),
        TestCase(TestEnum.Five, "five")
        ]
        public void Generic_ParseIgnoreCase(object expected, string value)
        {
            Assert.AreEqual(expected, EnumDescriptor.Parse<TestEnum>(value, true));
        }

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, "two", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, "three", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, "four", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, "five", ExpectedException = typeof(ArgumentException))
        //]
        //public void ParseCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.Parse(typeof(TestEnum), value, false));
        //}

        //[
        //TestCase(TestEnum.One, "one", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Two, "two", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Three, "three", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Four, "four", ExpectedException = typeof(ArgumentException)),
        //TestCase(TestEnum.Five, "five", ExpectedException = typeof(ArgumentException))
        //]
        //public void Generic_ParseCaseSensitive(object expected, string value)
        //{
        //    Assert.AreEqual(expected, EnumDescriptor.Parse<TestEnum>(value, false));
        //}
        #endregion

        [
        TestCase(true, "One"),
        TestCase(true, TWO),
        TestCase(true, THREE),
        TestCase(true, FOUR),
        TestCase(true, FIVE),
        TestCase(false, "Unknown")
        ]
        public void IsDisplayNameDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDisplayNameDefined(typeof(TestEnum), value));
        }

        [
        TestCase(true, "One"),
        TestCase(true, TWO),
        TestCase(true, THREE),
        TestCase(true, FOUR),
        TestCase(true, FIVE),
        TestCase(false, "Unknown")
        ]
        public void Generic_IsDisplayNameDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDisplayNameDefined<TestEnum>(value));
        }

        [
        TestCase(false, "One"),
        TestCase(true, TWO),
        TestCase(true, THREE),
        TestCase(true, FOUR),
        TestCase(true, FIVE),
        TestCase(false, "Unknown")
        ]
        public void IsDescriptionDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDescriptionDefined(typeof(TestEnum), value));
        }

        [
        TestCase(false, "One"),
        TestCase(true, TWO),
        TestCase(true, THREE),
        TestCase(true, FOUR),
        TestCase(true, FIVE),
        TestCase(false, "Unknown")
        ]
        public void Generic_IsDescriptionDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDescriptionDefined<TestEnum>(value));
        }

        [
        TestCase(true, "One"),
        TestCase(true, "Two"),
        TestCase(true, "Three"),
        TestCase(true, "Four"),
        TestCase(true, "Five"),
        TestCase(false, "Unknown")
        ]
        public void IsDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDefined(typeof(TestEnum), value));
        }

        [
        TestCase(true, "One"),
        TestCase(true, "Two"),
        TestCase(true, "Three"),
        TestCase(true, "Four"),
        TestCase(true, "Five"),
        TestCase(false, "Unknown")
        ]
        public void Generic_IsDefined(bool expected, object value)
        {
            Assert.AreEqual(expected, EnumDescriptor.IsDefined<TestEnum>(value));
        }
    }
}
