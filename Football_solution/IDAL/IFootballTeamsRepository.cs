using System;
using System.Collections.Generic;

namespace IDAL
{
    public interface IFootballTeamsRepository
    {
        string DataSource { get; set; }
        string RetrieveHeader();
        List<FootballTeamsData> RetrieveFootbalTeamsData();
    }
}
