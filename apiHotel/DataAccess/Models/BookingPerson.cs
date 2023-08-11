using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class BookingPerson
{
    public int RelationId { get; set; }

    public int PersonId { get; set; }

    public int BookingId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
