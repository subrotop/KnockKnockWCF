using Microsoft.VisualStudio.TestTools.UnitTesting;
using KnockKnockWCF;

namespace KnockKnockUnitTestProject
{
    [TestClass]
    public class KnockKnockTest
    {
        [TestMethod]
        public void GetFibonacci()
        {
            // Arrange
            KnockKnockService kkService = new KnockKnockService();

            // Act
            long result = kkService.Fibonacci(5);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBinetsFibonacciNumber()
        {
            // Arrange
            KnockKnockService kkService = new KnockKnockService();

            // Act
            long result = kkService.GetBinetsFibonacciNumber(5);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsShapeTriangle()
        {
            // Arrange
            KnockKnockService kkService = new KnockKnockService();

            // pass multiple combination of values
            var test1 = kkService.TriangleType(0, 0, 0);
            var test2 = kkService.TriangleType(1, 1, 2); //sum of the sides
            var test3 = kkService.TriangleType(-1, -1, -1);
            var test4 = kkService.TriangleType(3, 3, 5000);
            var test5 = kkService.TriangleType(-2147483648, -2147483648, -2147483648);

            var test6 = kkService.TriangleType(1, 1, 1);
            var test7 = kkService.TriangleType(2147483647, 2147483647, 2147483647);

            var test8 = kkService.TriangleType(3, 3, 5);
            var test9 = kkService.TriangleType(10, 10, 5);
            var test10 = kkService.TriangleType(3, 4, 5);

            // Assert
            Assert.IsTrue(test1 == TypeOfTriangle.Error);
            Assert.IsTrue(test2 == TypeOfTriangle.Error);
            Assert.IsTrue(test3 == TypeOfTriangle.Error);
            Assert.IsTrue(test4 == TypeOfTriangle.Error);
            Assert.IsTrue(test5 == TypeOfTriangle.Error);

            Assert.IsTrue(test6 == TypeOfTriangle.Equilateral);
            Assert.IsTrue(test7 == TypeOfTriangle.Equilateral);

            Assert.IsTrue(test8 == TypeOfTriangle.Isosceles);
            Assert.IsTrue(test9 == TypeOfTriangle.Isosceles);
            Assert.IsTrue(test10 == TypeOfTriangle.Scalene);
        }

        [TestMethod()]
        public void ReverseStringTest()
        {
            // Arrange
            KnockKnockService kkService = new KnockKnockService();

            // reverse value and assert
            var test1 = kkService.ReverseWords("dog");
            Assert.IsTrue(test1.Equals("god"));
        }

    }
}
