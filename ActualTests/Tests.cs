using System;
using NUnit.Framework;
using Moq;
using UnitTests;
using NLog;

namespace ActualTests
{
    [TestFixture]
    public class MathTests
    {
        private Logger log;
        [OneTimeSetUp]
        public void SetUpLogger()
        {
            log = LogManager.GetCurrentClassLogger();
        }
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

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string testResult = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            log.Info($"Test: {testName, -50} | Result: {testResult}");
        }
    }

    [TestFixture]
    public class OrderServiceTests
    {
        private Logger log;

        [OneTimeSetUp]
        public void SetUpLogger()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var orderService = new OrderService(storage.Object);
            var order = new Order();

            orderService.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string testResult = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            log.Info($"Test: {testName,-50} | Result: {testResult}");
        }
    }

    [TestFixture]
    public class ProductTests
    {
        private Product product;
        private Logger log;

        [OneTimeSetUp]
        public void SetUpLogger()
        {
            log = LogManager.GetCurrentClassLogger();
        }
      
        [SetUp]
        public void SetUp()
        {
            product = new Product();
        }

        [TestCase(10)]
        [TestCase(5)]
        public void GetPrice_CustomerIsGoldFalse_ReturnsFullPrice(float price)
        {
            product.ListPrice = price;
            var customer = new Customer { IsGold = false };

            float result = product.GetPrice(customer);

            Assert.AreEqual(price, result, 0.001);
        }

        [TestCase(10)]
        [TestCase(5)]
        public void GetPrice_CustomerIsGoldTrue_ReturnsLowerPrice(float price)
        {
            product.ListPrice = price;
            var customer = new Customer { IsGold = true };

            float result = product.GetPrice(customer);

            Assert.AreEqual(price * 0.7, result, 0.001);
        }

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string testResult = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            log.Info($"Test: {testName,-50} | Result: {testResult}");
        }
    }

    [TestFixture]
    public class ReservationTests
    {
        private Reservation reservation;
        private Logger log;

        [OneTimeSetUp]
        public void SetUpLogger()
        {
            log = LogManager.GetCurrentClassLogger();
        }

        [SetUp]
        public void SetUp()
        {
            reservation = new Reservation();
        }


        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            var admin = new User { IsAdmin = true };
            var result = reservation.CanBeCancelledBy(admin);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsTrue()
        {

            var user = new User { IsAdmin = false };
            reservation.MadeBy = user;

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsFalse()
        {

            var user = new User { IsAdmin = false };
            reservation.MadeBy = user;
            var newUser = new User { IsAdmin = false };

            var result = reservation.CanBeCancelledBy(newUser);

            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string testResult = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            log.Info($"Test: {testName,-50} | Result: {testResult}");
        }
    }
}
