using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class RolModule
{
    public int Relation { get; set; }

    public int RolId { get; set; }

    public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Rol Rol { get; set; } = null!;
}
