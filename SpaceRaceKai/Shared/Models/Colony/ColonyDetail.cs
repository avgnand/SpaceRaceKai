namespace SpaceRaceKai.Shared.Models.Colony
{
    public class ColonyDetail
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Population { get; set; }

        public int ApprovalRating { get; set; }

        public int TechLevel { get; set; }

        public int IndustryLevel { get; set; }

        public int WealthLevel { get; set; }

        public int Playthroughs { get; set; }

        public int PlanetTypeId { get; set; }

        public string? PlanetTypeName { get; set; }
    }
}
