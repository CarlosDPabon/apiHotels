using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ContactEmergency
{
    public int ContactEmergencyId { get; set; }

    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int PhoneNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual UserInfo User { get; set; } = null!;
}
