using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public int NumberRoom { get; set; }

    public int Capacity { get; set; }

    public string Type { get; set; } = null!;

    public int Price { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<RoomTax> RoomTaxes { get; set; } = new List<RoomTax>();
}
