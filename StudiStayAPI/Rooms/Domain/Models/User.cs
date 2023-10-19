﻿namespace StudiStayAPI.Rooms.Domain.Models;

/// <summary>
/// Entidad que representa a un usuario
/// </summary>
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    
    //relaciones
    public IList<Post> Posts { get; set; } = new List<Post>();
}