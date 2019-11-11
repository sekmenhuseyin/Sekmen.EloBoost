namespace EloBoost.Models.Boosters
{
    public class BoostersPageViewModel
    {
        public string Guid { get; set; }
        public string SourceLeagueTypes { get; set; }
        public string SourceDivisionTypes { get; set; }
        public string DestinationLeagueTypes { get; set; }
        public string DestinationDivisionTypes { get; set; }
        public string LeaguePoints { get; set; }
        public string ServerNames { get; set; }
        public string QueueTypes { get; set; }
        public string FormSecurity { get; set; }
        public decimal Price { get; set; }
    }
}
