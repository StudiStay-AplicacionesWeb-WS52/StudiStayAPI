using System.ComponentModel.DataAnnotations;

namespace StudiStay.API.Rent.Domain.Models
{
    /// <summary>
    /// Esta clase se usa para mapear el request body a un objeto C# (la entidad Rating)
    /// </summary>
    public class RatingRequest
    {
        [Required]
        public float Score { get; set; }

        [MaxLength(255)] // Adjust the maximum length as needed
        public string Comment { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RatingListId { get; set; }
    }
}
