using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public int PersonId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<HotelUser> HotelUsers { get; set; } = new List<HotelUser>();

    public virtual Person Person { get; set; } = null!;
}
