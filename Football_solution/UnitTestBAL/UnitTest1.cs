using System;
using BAL;
using IBAL;
using IDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestBAL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodTeamwithMinDifference()
        {
            var FootballTeamsRepositoryMock = new Mock<IFootballTeamsRepository>();
            FootballTeamsRepositoryMock.Setup(x => x.RetrieveFootbalTeamsData())
                .Returns(new List<FootballTeamsData> { new FootballTeamsData{ TeamName="StPeter", Against=54,For=40
               }, new FootballTeamsData{ TeamName="StJohn", Against=34,For=40
               } });


            IFootBallTeamService obj = new FootBallTeamService(FootballTeamsRepositoryMock.Object);
            var teams = obj.RetriveTeamDetailsWithLeastDifference();
            Assert.AreEqual(teams[0].TeamName, "StJohn");
        }

        [TestMethod]
        [ExpectedException(typeof(CustomException<InvalidColumnCountException>))]        
        public void TestMethodValidateStructure1()
        {
            var FootballTeamsRepositoryMock = new Mock<IFootballTeamsRepository>();
            FootballTeamsRepositoryMock.Setup(x => x.RetrieveHeader())
                .Returns("header");


            IFootBallTeamService obj = new FootBallTeamService(FootballTeamsRepositoryMock.Object);
            obj.ValidateStructure();
           
        }

        [TestMethod]
        [ExpectedException(typeof(CustomException<InvalidColumnNameException>))]
        public void TestMethodValidateStructure2()
        {
            var FootballTeamsRepositoryMock = new Mock<IFootballTeamsRepository>();
             FootballTeamsRepositoryMock.Setup(x => x.RetrieveHeader())
                .Returns("header1, header2,header3,header4, header5,header6, header7, header8, header9");


            IFootBallTeamService obj = new FootBallTeamService(FootballTeamsRepositoryMock.Object);
            obj.ValidateStructure();

        }


    }
}
