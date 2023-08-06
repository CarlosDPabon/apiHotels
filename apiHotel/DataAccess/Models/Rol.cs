using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Rol
{
    public int RolId { get; set; }

    public string RolName { get; set; } = null!;

    public virtual ICollection<RolModule> RolModules { get; set; } = new List<RolModule>();
}
