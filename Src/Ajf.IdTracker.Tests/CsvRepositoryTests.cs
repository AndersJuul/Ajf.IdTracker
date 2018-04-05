using System;
using NUnit.Framework;
using Ajf.IdTracker.Shared;

namespace Ajf.IdTracker.Tests
{
    [TestFixture]
    public class CsvRepositoryTests
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var sut = new CsvRepository();

            // Act
            var res = sut.GetUniqueNewNumber(new DateTime(2018, 4, 4), "031069-0503");

            // Assert
            Assert.IsNotNullOrEmpty(res);
        }
    }
}
