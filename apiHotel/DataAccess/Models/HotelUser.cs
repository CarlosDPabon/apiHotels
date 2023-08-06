using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class HotelUser
{
    public int RelationId { get; set; }

    public int UserId { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
