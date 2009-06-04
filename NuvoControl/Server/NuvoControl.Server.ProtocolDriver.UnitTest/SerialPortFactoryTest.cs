﻿using NuvoControl.Server.ProtocolDriver.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace NuvoControl.Server.ProtocolDriver.Test
{
    
    
    /// <summary>
    ///This is a test class for SerialPortFactoryTest and is intended
    ///to contain all SerialPortFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerialPortFactoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for LoadDriver
        ///</summary>
        [TestMethod()]
        public void LoadDriverTest()
        {
            string assemblyName = "E:\\NuvoControl_Trunk\\NuvoControl\\Server\\NuvoControl.Server.ProtocolDriver.Simulator\\bin\\Debug\\NuvoControl.Server.ProtocolDriver.Simulator.dll";
            string className = "NuvoControl.Server.ProtocolDriver.Simulator.ProtocolDriverSimulator";
            ISerialPort expected = null; // TODO: Initialize to an appropriate value
            ISerialPort actual;
            actual = SerialPortFactory.LoadDriver(assemblyName, className);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
