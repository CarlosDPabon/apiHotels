using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<RolModule> RolModules { get; set; } = new List<RolModule>();
}
