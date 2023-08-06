using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public int IdentificationId { get; set; }

    public int NumberIdentification { get; set; }

    public string HotelName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Ubication { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<HotelUser> HotelUsers { get; set; } = new List<HotelUser>();

    public virtual IdentificationType Identification { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
