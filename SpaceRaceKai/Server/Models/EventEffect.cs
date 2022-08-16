using System.ComponentModel.DataAnnotations;

namespace SpaceRaceKai.Server.Models
{
    public class EventEffect
    {
        [Key]
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
