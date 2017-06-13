using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_GroupingService;


namespace TDD_GroupingServiceTest
{
    [TestClass]
    public class GroupProductTest
    {
        private readonly TestDataGenerator _testDataGenerator = new TestDataGenerator();

        [TestMethod]
        public void Sum_Cost_Groupby_3Row_Should_Return6_15_24_21()
        {
            var product = _testDataGenerator.GenerateProductTestData();
            var groupProduct = new GroupingService();
            var expected = new List<int> { 6, 15, 24, 21 };


            var actual = groupProduct.Grouping(3, "Cost", product);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sum_Revenue_Groupby_4Row_Should_Return50_66_60()
        {
            var product = _testDataGenerator.GenerateProductTestData();
            var groupProduct = new GroupingService();
            var expected = new List<int> { 50, 66, 60 };


            var actual = groupProduct.Grouping(4, "Revenue", product);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Groupby_0Row_Should_Throw_ArgumentException()
        {
            var product = _testDataGenerator.GenerateProductTestData();
            var groupProduct = new GroupingService();

            Action act = () => groupProduct.Grouping(0, "Revenue", product);

            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void Groupby_NegativeNumber_Should_Throw_ArgumentException()
        {
            var product = _testDataGenerator.GenerateProductTestData();
            var groupProduct = new GroupingService();

            Action act = () => groupProduct.Grouping(-1, "Revenue", product);

            act.ShouldThrow<ArgumentException>();
        }


        [TestMethod]
        public void Sum_NotExistedColumn_Groupby_4Row_Should_Throw_ArgumentException()
        {
            var product = _testDataGenerator.GenerateProductTestData();
            var groupProduct = new GroupingService();

            Action act = () => groupProduct.Grouping(3, "hello", product);

            act.ShouldThrow<ArgumentException>();
        }
    }
}
