using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.EventEffect
{
    public class EventEffectEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PopulationChange { get; set; }

        [Required]
        public int ApprovalChange { get; set; }

        [Required]
        public int TechChange { get; set; }

        [Required]
        public int IndustryChange { get; set; }

        [Required]
        public int WealthChange { get; set; }
    }
}
