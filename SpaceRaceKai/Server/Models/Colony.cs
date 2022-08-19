using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Server.Models
{
    public class Colony
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(48)]
        public string? Name { get; set; }

        public int Population { get; set; }

        public int ApprovalRating { get; set; }

        public int TechLevel { get; set; }

        public int IndustryLevel { get; set; }

        public int WealthLevel { get; set; }

        public int Playthroughs { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(PlanetType))]
        public int PlanetTypeId { get; set; }

        public virtual PlanetType PlanetType { get; set; }

    }
}
