using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public int UserId { get; set; }

    public int ContactEmergencyId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public virtual ICollection<BookingPerson> BookingPeople { get; set; } = new List<BookingPerson>();

    public virtual ContactEmergency ContactEmergency { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
