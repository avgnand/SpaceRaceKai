using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.WorldEvent
{
    public class WorldEventCreate
    {
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int PlanetTypeId { get; set; }

        [Required]
        public int EventEffectId { get; set; }
    }
}