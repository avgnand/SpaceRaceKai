using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.WorldEvent
{
    public class WorldEventEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int PlanetTypeId { get; set; }

        [Required]
        public int EventEffectId { get; set; }

    }
}
