using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace UnitTestProjectClassLibrary
{
    [TestClass]
    public class UnitTestClassLibrary
    {
        [TestMethod]
        public void Test_AverageRepairTime_ByModelID_WithValidData()
        {
            var database = new DataBase();
            var classInstance = new CalculateAverageRepairTime(database);

            double result = classInstance.CalculateAverageRepairTimeByModelID(1);

            Assert.IsTrue(result >= 0, "Среднее время ремонта должно быть неотрицательным.");
        }

        [TestMethod]
        public void Test_AverageRepairTime_ByModelID_WithInvalidModelID()
        {
            var database = new DataBase();
            var classInstance = new CalculateAverageRepairTime(database);

            double result = classInstance.CalculateAverageRepairTimeByModelID(-1);

            Assert.AreEqual(0, result, "Среднее время ремонта должно быть 0 для несуществующего modelID.");
        }
    }
}
