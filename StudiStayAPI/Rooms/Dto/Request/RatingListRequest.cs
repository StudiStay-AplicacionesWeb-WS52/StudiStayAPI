using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudiStayAPI.Rooms.Domain.Models
{
    /// <summary>
    /// Esta clase se usa para mapear el request body a un objeto C# (la entidad RatingList)
    /// </summary>
    public class RatingListRequest
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int PostId { get; set; }
    }
}
