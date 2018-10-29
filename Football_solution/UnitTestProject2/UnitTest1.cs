using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using IDAL;
using System.Configuration;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {

        string DataStore { get; set; }

        [TestInitialize()]
        public void Initialize()
        {
            DataStore = ConfigurationManager.AppSettings["FootballDBlocation"];
        }
        [TestMethod]
        public void TestMethod1()
        {
            IFootballTeamsRepository repository = new FootballTeamsRepository();
            repository.DataSource = DataStore;
            var footballTeamData=repository.RetrieveFootbalTeamsData();
            Assert.AreEqual(footballTeamData.Count, 20);

        }
    }
}
