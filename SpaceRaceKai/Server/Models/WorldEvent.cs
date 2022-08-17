using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Server.Models
{
    public class WorldEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [ForeignKey(nameof(PlanetType))]
        public int PlanetTypeId { get; set; }

        [ForeignKey(nameof(EventEffect))]
        public int EventEffectId { get; set; }

        public virtual PlanetType PlanetType { get; set; }
        public virtual EventEffect EventEffect { get; set; }

    }
}
