using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Tax
{
    public int TaxId { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<RoomTax> RoomTaxes { get; set; } = new List<RoomTax>();
}
