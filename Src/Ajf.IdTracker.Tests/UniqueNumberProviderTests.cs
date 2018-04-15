using System;
using NUnit.Framework;
using Ajf.IdTracker.Shared;
using System.IO;

namespace Ajf.IdTracker.Tests
{
    [TestFixture]
    public class UniqueNumberProviderTests
    {
        [Test]
        public void TestThatGetUniqueWorksWhenFileNotThere()
        {
            // Arrange
            var csvName = Path.GetTempFileName() + ".csv";
            var sut =new UniqueNumberProvider( new CsvRepository(csvName));

            // Act
            var res = sut.GetUniqueNewNumber(new DateTime(2018, 4, 5), "031069-0503", "Anders Juul", "Grass", "Equipment-01");

            // Assert
            Assert.AreEqual("20180405-01", res);
        }
        [Test]
        public void TestThatGetUniqueWorksWhenFileIsThere()
        {
            // Arrange
            var csvName = Path.GetTempFileName() + ".csv";
            var sut = new UniqueNumberProvider(new CsvRepository(csvName));
            sut.GetUniqueNewNumber(new DateTime(2018, 4, 5), "031069-0503", "Anders Juul", "Grass", "Equipment-01");

            // Act
            var res = sut.GetUniqueNewNumber(new DateTime(2018, 4, 5), "031069-0503", "Anders Juul", "Grass", "Equipment-01");

            // Assert
            Assert.AreEqual("20180405-02", res);
        }
    }
}
