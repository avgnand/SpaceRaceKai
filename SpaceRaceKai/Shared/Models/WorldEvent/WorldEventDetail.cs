namespace SpaceRaceKai.Shared.Models.WorldEvent
{
    public class WorldEventDetail
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int PlanetTypeId { get; set; }

        public string? PlanetTypeName { get; set; }

        public int EventEffectId { get; set; }

        public int PopulationChange { get; set; }

        public int ApprovalChange { get; set; }

        public int TechChange { get; set; }

        public int IndustryChange { get; set; }

        public int WealthChange { get; set; }

    }
}
