using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ActualTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_Add4and3_ResultIs7()
        {

        }

        [Test]
        public void Max_MaxOf5and5_ResultIs5()
        {

        }
    }

    [TestFixture]
    public class OrderServiceTests
    {

    }
    
    [TestFixture]
    public class ProductTests
    {

    }

    [TestFixture]
    public class Reservation
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
}
