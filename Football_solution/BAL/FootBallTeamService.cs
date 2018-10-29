using System;
using IDAL;
using IBAL;
using System.Linq;
using System.Collections.Generic;

namespace BAL
{
    public class FootBallTeamService : IFootBallTeamService
    {
        private IFootballTeamsRepository footballTeamRepository;

        //public string DataStore { get; set; }

        public FootBallTeamService(IFootballTeamsRepository _footballTeamRepository)
        {
            footballTeamRepository = _footballTeamRepository;
            //footballTeamRepository.DataSource = DataStore;
        }
        public List<FootballTeamsData> RetriveTeamDetailsWithLeastDifference()
        {
            var footbalteamsdata = footballTeamRepository.RetrieveFootbalTeamsData();
            footbalteamsdata.ForEach(x =>  x.Difference = Math.Abs(x.For - x.Against));

            var minimumDifference= footbalteamsdata.Min(f => f.Difference);
            return footbalteamsdata.Where(f => f.Difference == minimumDifference).ToList();
        }

        public void ValidateStructure()
        {
            var header = footballTeamRepository.RetrieveHeader();

            var columnNames = header.Split(',');

            //Check for number of Columns
            if (columnNames.Length != ValidColumns.AllColumnNames.Count)
            {
                throw new CustomException<InvalidColumnCountException>(string.Format("File Structure Invalid.Expected No of Columns:  {0}, Actual {1}"
                    , ValidColumns.AllColumnNames.Count, columnNames.Length));
                //Utilities.Utilities.WriteLog(string.Format("File Structure Invalid.Expected No of Columns:  {0}, Actual {1}"
                //    , ValidColumns.AllColumnNames.Count, columnNames.Length));
                //return false;
            }

            //Check Names of Columns
            int i = 0;
            foreach (var columnName in columnNames)
            {
                if (columnName == ValidColumns.AllColumnNames[i])
                {
                    i++;
                    continue;
                }
                else
                {
                    throw new CustomException<InvalidColumnNameException>(string.Format("File Structure Invalid.Columns Names dont match expected columns"));
                    //Utilities.Utilities.WriteLog(string.Format("File Structure Invalid.Columns Names dont match expected columns"));
                    //return false;
                }
            }
        }


            
    }
}
