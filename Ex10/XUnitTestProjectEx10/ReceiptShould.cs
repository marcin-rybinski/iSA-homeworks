using System;
using System.Collections.Generic;
using System.Linq;
using Ex10;
using FluentAssertions;
using Xunit;


namespace XUnitTestProjectEx10
{


    public class ReceiptShould
    {
        private readonly Receipt _sut;
        private readonly int _testDataTotalCost;

        public static List<object[]> InnerTestData => new List<object[]>()
        {
            new object[] {"beer", 3, 3},
            new object[] {"sausage", 2, 2},
            new object[] {"bread", 1, 3}
        };

        public ReceiptShould()
        {
            _sut = new Receipt();

            foreach (var obj in InnerTestData)
            {
                int.TryParse(obj[1].ToString(), out var numberOfItems);
                int.TryParse(obj[2].ToString(), out var priceInUsd);

                _sut.RecordLine(obj[0].ToString(), numberOfItems, priceInUsd);
            }

            foreach (var obj in InnerTestData)
            {
                int.TryParse(obj[1].ToString(), out var numberOfItems);
                int.TryParse(obj[2].ToString(), out var priceInUsd);

                _testDataTotalCost += numberOfItems * priceInUsd;
            }

        }

        [Fact]
        public void Record_Correct_Number_Of_Lines_With_Given_Data()
        {
            var actual = _sut.Lines;

            actual.Should().HaveCount(InnerTestData.Count());
        }

        [Fact]
        public void Calculate_Correct_Number_Of_Lines()
        {
            var actual = _sut.GetTotalNumberOfLines();

            actual.Should().Be(InnerTestData.Count());
        }

        [Theory]
        [MemberData(nameof(ReceiptTestData.NegativeQuantityData), MemberType = typeof(ReceiptTestData))]
        public void Throw_Exception_When_Given_Negative_OrZero_Quantity(string title, int numberOfItems, int priceInUsd)
        {
            void GiveNegativeOrZeroQuantity()
            {
                _sut.RecordLine(title, numberOfItems, priceInUsd);
            }

            var ex = Assert.Throws<InvalidOperationException>(GiveNegativeOrZeroQuantity);

            Assert.Contains("You can't add line", ex.Message);
        }

        [Theory]
        [MemberData(nameof(ReceiptTestData.NegativePriceData), MemberType = typeof(ReceiptTestData))]
        public void Throw_Exception_When_Given_Negative_OrZero_Price(string title, int numberOfItems, int priceInUsd)
        {
            void GiveNegativeOrZeroQuantity()
            {
                _sut.RecordLine(title, numberOfItems, priceInUsd);
            }

            var ex = Assert.Throws<InvalidOperationException>(GiveNegativeOrZeroQuantity);

            Assert.Contains("You can't add line", ex.Message);
        }

        [Fact]
        public void Calculate_Correct_Cost_Of_Products()
        {
            var actual = _sut.CalculateTotalCost();

            var expected = _testDataTotalCost;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Add_Another_Line_To_Receipt_When_Reversing_Last_Line()
        {
            _sut.ReverseLastLine();

            var actual = _sut.Lines;

            actual.Should().HaveCount(InnerTestData.Count + 1);

        }

        [Fact]
        public void Have_Total_Cost_Lowered_By_Removed_Items_Costs_After_Reversing_Last_Line()
        {
            _sut.ReverseLastLine();

            var actual = _sut.Lines.Sum(item => item.PriceInUsd * item.Number);

            var expected = 0;
            for (var i = 0; i < InnerTestData.Count - 1; i++)
            {
                int.TryParse(InnerTestData[i][1].ToString(), out var numberOfItems);
                int.TryParse(InnerTestData[i][2].ToString(), out var priceInUsd);

                expected += numberOfItems * priceInUsd;
            }

            actual.Should().Be(expected);
        }

        [Fact]
        public void Throw_Exception_When_Trying_To_Remove_Line_When_There_Is_No_Line_In_Record()
        {
            var emptySut = new Receipt();

            void ReverseMoreLinesThanTheNumberOfLines()
            {
                emptySut.ReverseLastLine();
            }

            var ex = Assert.Throws<InvalidOperationException>(ReverseMoreLinesThanTheNumberOfLines);

            Assert.Contains("There is no lines", ex.Message);
        }

        [Fact]
        public void Throw_Exception_When_Trying_To_Reverse_Line_Twice_In_A_Row()
        {
            void TryReversingLineTwiceInARow()
            {
                _sut.ReverseLastLine();
                _sut.ReverseLastLine();
            }

            var ex = Assert.Throws<InvalidOperationException>(TryReversingLineTwiceInARow);

            Assert.Contains("once per product", ex.Message);

            Assert.Equal(_sut.Lines.Count(), InnerTestData.Count + 1);
        }

        [Fact]
        public void Reverse_A_Line_After_Reversing_And_Adding_NextOne()
        {

            _sut.ReverseLastLine();
            _sut.RecordLine("cabbage", 2, 2);
            _sut.ReverseLastLine();

            var actual = _sut.Lines.Sum(item => item.PriceInUsd * item.Number);

            var expected = 0;
            for (var i = 0; i < InnerTestData.Count - 1; i++)
            {
                int.TryParse(InnerTestData[i][1].ToString(), out var numberOfItems);
                int.TryParse(InnerTestData[i][2].ToString(), out var priceInUsd);

                expected += numberOfItems * priceInUsd;
            }

            actual.Should().Be(expected);

            Assert.Equal(_sut.Lines.Count(), InnerTestData.Count + 3);
        }

    }

    public class ReceiptTestData
    {
        public static IEnumerable<object[]> NegativeQuantityData => new List<object[]>()
        {
            new object[] { "beer", -123, 3 },
            new object[] { "sausage", 0, 2 },
            new object[] { "bread", int.MinValue, 3 }
        };

        public static IEnumerable<object[]> NegativePriceData => new List<object[]>()
        {
            new object[] { "beer", 3, -3 },
            new object[] { "sausage", 2, 0 },
            new object[] { "bread", 1, int.MinValue }
        };
    }
}
