﻿using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Security.Dto.Response;
using StudiStayAPI.Rooms.Dto.Response;
using System.Collections.Generic;

namespace StudiStayAPI.Rooms.Dto.Response;

public class ReservationResponse
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; } 
    public int StayHours { get; set; } 
    public DateTime CheckInDate { get; set; } 
    public DateTime CheckOutDate { get; set; }
    public string PaymentMethod { get; set; } 
    public UserResponse User { get; set; }
    public PostResponse Post { get; set; }
}