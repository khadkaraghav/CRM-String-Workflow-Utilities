﻿using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class EncodeHtmlTests
    {
        #region Test Initialization and Cleanup
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestMethodInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup() { }
        #endregion

        [TestMethod]
        public void EncodeHtml_Given_PlainString_Then_EncodeSuccessfully()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToEncode", "Svendborg Værft A/S" },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Svendborg V&#230;rft A/S";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<EncodeHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["EncodedString"]);
        }
    }
}