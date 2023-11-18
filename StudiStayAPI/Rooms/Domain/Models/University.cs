namespace StudiStayAPI.Rooms.Domain.Models;

public class University
{
    public int Id { get; set; }
    public string LogoUrl { get; set; }
    public string Name { get; set; }
    public string Initials { get; set; }

    // Relations 
    
    public int LocationId { get; set; }
    public Location Location { get; set; }

    public string ZipCode
        {
            get { return Location?.ZipCode; }
        }
}
