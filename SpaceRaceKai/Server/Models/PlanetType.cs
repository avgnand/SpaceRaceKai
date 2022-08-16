using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Server.Models
{
    public class PlanetType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int TemperatureRating { get; set; }

        [Required]
        public int LandCover { get; set; }

    }
}
