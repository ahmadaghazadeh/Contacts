using System;
using System.Collections.Generic;

namespace ReadModel.Infrastructure.Models;

public partial class Contact
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
