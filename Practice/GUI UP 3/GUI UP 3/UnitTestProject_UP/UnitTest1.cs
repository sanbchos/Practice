using GUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace UnitTestProject_UP
{
    [TestClass]
    public class GetRplyByIDTest
    {
        private Login_Form_Window testClass;

        [TestInitialize]
        public void Setup()
        {
            testClass = new Login_Form_Window();
        }

        [TestMethod]
        public void Test_GetRoleByStatusID_WithValidIDs()
        {
            Assert.AreEqual("Менеджер", testClass.GetRoleByStatusID(1));
            Assert.AreEqual("Мастер", testClass.GetRoleByStatusID(2));
            Assert.AreEqual("Оператор", testClass.GetRoleByStatusID(3));
            Assert.AreEqual("Клиент", testClass.GetRoleByStatusID(4));
        }

        [TestMethod]
        public void Test_GetRoleByStatusID_WithInvalidID()
        {
            Assert.AreEqual("Неизвестная роль", testClass.GetRoleByStatusID(0));
            Assert.AreEqual("Неизвестная роль", testClass.GetRoleByStatusID(5));
            Assert.AreEqual("Неизвестная роль", testClass.GetRoleByStatusID(-1));
        }
    }

    [TestClass]
    public class DataBaseTests
    {
        private DataBase database;

        [TestInitialize]
        public void Setup()
        {
            database = new DataBase();
        }

        [TestMethod]
        public void Test_GetConnection_ShouldReturnSqlConnection()
        {
            SqlConnection returnedConnection = database.GetConnection();

            Assert.IsNotNull(returnedConnection);
        }

        [TestMethod]
        public void Test_ConnectionState_ShouldBeInitiallyClosed()
        {
            SqlConnection newConnection = database.GetConnection();

            Assert.AreEqual(System.Data.ConnectionState.Closed, newConnection.State);
        }

        [TestMethod]
        public void Test_GetConnection_ShouldBeClosed()
        {
            database.openConnection();
            database.closeConnection();

            SqlConnection returnedConnection = database.GetConnection();

            Assert.AreEqual(System.Data.ConnectionState.Closed, returnedConnection.State);
        }
    }
}
