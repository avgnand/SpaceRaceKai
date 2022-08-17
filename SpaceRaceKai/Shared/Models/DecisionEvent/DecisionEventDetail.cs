namespace SpaceRaceKai.Shared.Models.DecisionEvent
{
    public class DecisionEventDetail
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int EventEffectIdA { get; set; }

        public int PopulationChangeA { get; set; }

        public int ApprovalChangeA { get; set; }

        public int TechChangeA { get; set; }

        public int IndustryChangeA { get; set; }

        public int WealthChangeA { get; set; }

        public int EventEffectIdB { get; set; }

        public int PopulationChangeB { get; set; }

        public int ApprovalChangeB { get; set; }

        public int TechChangeB { get; set; }

        public int IndustryChangeB { get; set; }

        public int WealthChangeB { get; set; }
    }
}
