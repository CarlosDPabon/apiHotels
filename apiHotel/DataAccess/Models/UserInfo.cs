using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<ContactEmergency> ContactEmergencies { get; set; } = new List<ContactEmergency>();

    public virtual ICollection<HotelUser> HotelUsers { get; set; } = new List<HotelUser>();

    public virtual Person Person { get; set; } = null!;
}
