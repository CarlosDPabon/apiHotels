using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class IdentificationType
{
    public int IdentificationId { get; set; }

    public string IdentificationName { get; set; } = null!;

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
