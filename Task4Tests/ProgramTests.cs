using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void DistributeTheSum_WhenSumIsNan_ShouldThrowArumentException()
        {
            Action action = () => Task4.Program.DistributeTheSum("ПОСЛ", double.NaN, "1000;2000;3000;5000;8000;5000");
            ArgumentException argumentException = Assert.ThrowsException<ArgumentException>(action);

            Assert.AreEqual("Your sum is NaN.", argumentException.Message);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenSumIsPositiveInfinity_ShouldThrowArgumentException()
        {
            Action action = () => Task4.Program.DistributeTheSum("ПОСЛ", double.PositiveInfinity, "1000;2000;3000;5000;8000;5000");
            ArgumentException argumentException = Assert.ThrowsException<ArgumentException>(action);

            Assert.AreEqual("Your sum is positive infinity.", argumentException.Message);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenSumIsNegativeInfinity_ShouldThrowArgumentException()
        {
            Action action = () => Task4.Program.DistributeTheSum("ПОСЛ", double.NegativeInfinity, "1000;2000;3000;5000;8000;5000");
            ArgumentException argumentException = Assert.ThrowsException<ArgumentException>(action);

            Assert.AreEqual("Your sum is less than or equal to zero.", argumentException.Message);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenOptionIsInvalid_ShouldThrowArgumentException()
        {
            Action action = () => Task4.Program.DistributeTheSum("GJC", 10000, "1000;2000;3000;5000;8000;5000");
            ArgumentException argumentException = Assert.ThrowsException<ArgumentException>(action);

            Assert.AreEqual("Invalid option.", argumentException.Message);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenOptionIsPROP_ReturnsProtoptionsOfSumByPROP()
        {
            var result = Task4.Program.DistributeTheSum("ПРОП", 10000, "1000;2000;3000;5000;8000;5000");
            var expected = "416,67;833,33;1250;2083,33;3333,33;2083,34";

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenOptionIsPERV_ReturnsProportionsOfSumByPERV()
        {
            var result = Task4.Program.DistributeTheSum("ПЕРВ", 10000, "1000;2000;3000;5000;8000;5000");
            var expected = "1000;2000;3000;4000;0;0";

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DistributeTheSum_WhenOptionIsPOSL_ReturnsProportionsOfSumByPOSL()
        {
            var result = Task4.Program.DistributeTheSum("ПОСЛ", 10000, "1000;2000;3000;5000;8000;5000");
            var expected = "0;0;0;0;5000;5000";

            Assert.AreEqual(expected, result);
        }
    }
}