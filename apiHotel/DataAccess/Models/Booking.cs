using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
