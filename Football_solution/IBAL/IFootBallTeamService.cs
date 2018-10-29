using System;
using IDAL;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IBAL
{
    public interface IFootBallTeamService
    {
        //string DataStore { get; set; }
        List<FootballTeamsData> RetriveTeamDetailsWithLeastDifference();
        void ValidateStructure();
    }
    public class InvalidColumnCountException : Exception { }
    public class InvalidColumnNameException : Exception { }

    public static class ValidColumns
    {

        //Team,P,W,L,D,F,-,A,Pts
        public const string Column_0_Name = "Team";
        public const string Column_1_Name = "P";
        public const string Column_2_Name = "W";
        public const string Column_3_Name = "L";
        public const string Column_4_Name = "D";
        public const string Column_5_Name = "F";
        public const string Column_6_Name = "-";
        public const string Column_7_Name = "A";
        public const string Column_8_Name = "Pts";
        public static List<string> AllColumnNames = new List<string>
        {
            Column_0_Name,Column_1_Name,Column_2_Name,Column_3_Name,Column_4_Name,Column_5_Name,
            Column_6_Name,Column_7_Name,Column_8_Name
        };


    }

    public class CustomException<T> : Exception where T : Exception
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) { }
        public CustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
