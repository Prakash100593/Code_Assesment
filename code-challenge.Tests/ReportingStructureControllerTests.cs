using challenge.Models;
using code_challenge.Tests.Integration.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace code_challenge.Tests.Integration
{
    [TestClass]
    public class ReportingStructureControllerTests
    {
        private static HttpClient _httpClient;
        private static TestServer _testServer;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestServerStartup>()
                .UseEnvironment("Development"));

            _httpClient = _testServer.CreateClient();
        }

        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        [TestMethod]
        public void GetReportingStructure_Count_0()
        {
            // Arrange
            var employeeId = "fakeid";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingStructure/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var result = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(result.NumberOfReports, 0);
        }

        [TestMethod]
        public void GetReportingStructure_Test_Pass_1()
        {
            // Arrange
            var employeeId = "16a596ae-edd3-4847-99fe-c4518e82c86f";
            var firstName = "John";
            var lastName = "Lennon";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingStructure/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(firstName, result.Employee.FirstName);
            Assert.AreEqual(lastName, result.Employee.LastName);
            Assert.IsNotNull(result.Employee.DirectReports);
            Assert.AreEqual(2, result.Employee.DirectReports.Count);
            Assert.AreEqual(4, result.NumberOfReports);
        }

        [TestMethod]
        public void GetReportingStructure_Test_Pass_2()
        {
            // Arrange
            var employeeId = "b7839309-3348-463b-a7e3-5de1c168beb3";
            var firstName = "Paul";
            var lastName = "McCartney";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingStructure/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(firstName, result.Employee.FirstName);
            Assert.AreEqual(lastName, result.Employee.LastName);
            Assert.IsNotNull(result.Employee.DirectReports);
            Assert.AreEqual(0, result.Employee.DirectReports.Count);

            Assert.AreEqual(0, result.NumberOfReports);
        }

        [TestMethod]
        public void GetReportingStructure_Test_Pass_3()
        {
            // Arrange
            var employeeId = "03aa1462-ffa9-4978-901b-7c001562cf6f";
            var firstName = "Ringo";
            var lastName = "Starr";

            // Execute
            var getRequestTask = _httpClient.GetAsync($"api/reportingStructure/{employeeId}");
            var response = getRequestTask.Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = response.DeserializeContent<ReportingStructure>();

            Assert.AreEqual(firstName, result.Employee.FirstName);
            Assert.AreEqual(lastName, result.Employee.LastName);
            Assert.IsNotNull(result.Employee.DirectReports);
            Assert.AreEqual(2, result.Employee.DirectReports.Count);

            Assert.AreEqual(2, result.NumberOfReports);
        }

    }
}
