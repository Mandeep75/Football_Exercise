using System;
using System.Collections.Generic;
using System.IO;
using IDAL;
using Utilities;

namespace DAL
{
    public class FootballTeamsRepository : IFootballTeamsRepository
    {

        public string DataSource { get; set; }


        public string RetrieveHeader()
        {
            string line = string.Empty;
            using (var reader = new StreamReader(DataSource))
            {
                line = reader.ReadLine();

            }
            return line;
        }


        public List<FootballTeamsData> RetrieveFootbalTeamsData()
        {
            bool isHeaderRow = true;
            List<FootballTeamsData> footballTeamData = new List<FootballTeamsData>();
            using (var reader = new StreamReader(DataSource))
            {
                while (!reader.EndOfStream)
                {
                    string[] values = null;
                    try
                    {
                        var line = reader.ReadLine();
                        if (isHeaderRow)// skip first row
                        {
                            isHeaderRow = false;
                            continue;
                        }
                        values = line.Split(',');
                        FootballTeamsData obj = new FootballTeamsData
                        {
                            TeamName = values[0],
                            For = Int32.Parse(values[5]),
                            Against = Int32.Parse(values[7])

                        };
                        footballTeamData.Add(obj);

                    }
                    catch (Exception ex)
                    {
                        Utilities.Utilities.WriteLog(string.Format("Invalid Data. TeamName: {0}, For : {1} , Against : {2}", values[0], values[5], values[7]));
                        Utilities.Utilities.WriteLog(ex.Message);
                    }


                }
            }

            return footballTeamData;        





        }


    }

    public class MockFootballTeamsRepository : IFootballTeamsRepository
    {

        public string DataSource { get; set; }


        public List<FootballTeamsData> RetrieveFootbalTeamsData()
        {
            return new List<FootballTeamsData>(){
                new FootballTeamsData { TeamName="Arsenal", For=79,Against=36 },
                 new FootballTeamsData { TeamName="Liverpool", For=67,Against=30 },
                  new FootballTeamsData { TeamName="Manchester_U", For=87,Against=45 },
                   new FootballTeamsData { TeamName="Newcastle", For=74,Against=52 },
                   new FootballTeamsData { TeamName="Southampton", For=46,Against=54 }
            };
        }
        public string RetrieveHeader()
        {
            return string.Empty;
        }
    }
}
