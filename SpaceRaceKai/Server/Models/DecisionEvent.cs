using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Server.Models
{
    public class DecisionEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [ForeignKey(nameof(EventEffectA))]
        public int EventEffectIdA { get; set; }

        [ForeignKey(nameof(EventEffectB))]
        public int EventEffectIdB { get; set; }

        public virtual EventEffect EventEffectA { get; set; }
        public virtual EventEffect EventEffectB { get; set; }

    }
}
