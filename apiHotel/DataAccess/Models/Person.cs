using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public int IdentificationId { get; set; }

    public int NumberIdentification { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public virtual ICollection<BookingPerson> BookingPeople { get; set; } = new List<BookingPerson>();

    public virtual IdentificationType Identification { get; set; } = null!;

    public virtual ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
}
