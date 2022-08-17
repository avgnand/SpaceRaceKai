using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.PlanetType
{
    public class PlanetTypeEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int TemperatureRating { get; set; }

        [Required]
        public int LandCover { get; set; }

    }
}
