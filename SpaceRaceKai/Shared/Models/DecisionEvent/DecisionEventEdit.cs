using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.DecisionEvent
{
    public class DecisionEventEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int EventEffectIdA { get; set; }

        [Required]
        public int EventEffectIdB { get; set; }

    }
}
