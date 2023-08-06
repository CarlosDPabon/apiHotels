using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class RoomTax
{
    public int RelationId { get; set; }

    public int RoomId { get; set; }

    public int TaxId { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual Tax Tax { get; set; } = null!;
}
