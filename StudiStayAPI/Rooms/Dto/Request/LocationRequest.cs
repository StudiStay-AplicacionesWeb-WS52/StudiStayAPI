using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Dto.Request
{
    /// <summary>
    /// Esta clase se usa para mapear el request body a un objeto C# (la entidad Location)
    /// </summary>
    public class LocationRequest
    {
        [Required]
        [MaxLength(255)] // Adjust the maximum length as needed
        public string Address { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        [MaxLength(255)] // Adjust the maximum length as needed
        public string Country { get; set; }

        [Required]
        [MaxLength(255)] // Adjust the maximum length as needed
        public string City { get; set; }

        [Required]
        [MaxLength(255)] // Adjust the maximum length as needed
        public string State { get; set; }

        [Required]
        [MaxLength(20)] // Adjust the maximum length as needed
        public string ZipCode { get; set; }
    }
}
