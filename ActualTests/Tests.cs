using System;
using NUnit.Framework;
using UnitTests;

namespace ActualTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_Add4and3_ResultIs7()
        {
            int number1 = 4;
            int number2 = 3;

            int result = MyMath.Add(number1, number2);

            Assert.AreEqual(result, 7);
        }

        [Test]
        public void Max_MaxOf5and8_ResultIs8()
        {
            int number1 = 5;
            int number2 = 8;

            int result = MyMath.Max(number1, number2);

            Assert.AreEqual(result, 8);
        }

        [Test]
        public void Divide_AnyNumByZero_ThrowsException()
        {
            int number1 = 10;
            int number2 = 0;

            Assert.Throws<System.DivideByZeroException>(() => MyMath.Divide(number1, number2));
        }
    }

    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder()
        {

        }
    }

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_CustomerIsGoldFalse_Price()
        {

        }

        [Test]
        public void GetPrice_CustomerIsGoldTrue_PriceIsLower()
        {

        }
    }

    [TestFixture]
    public class Reservation
    {
        [Test]
        public void CanBeCancelledBy_True()
        {

        }

        public void CanBeCancelledBy_False()
        {

        }
    }
}
