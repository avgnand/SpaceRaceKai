using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Shared.Models.Colony
{
    public class ColonyEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public int ApprovalRating { get; set; }

        [Required]
        public int TechLevel { get; set; }

        [Required]
        public int IndustryLevel { get; set; }

        [Required]
        public int WealthLevel { get; set; }

        [Required]
        public int PlanetTypeId { get; set; }

    }
}
