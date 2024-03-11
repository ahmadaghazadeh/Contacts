using System;
using System.Collections.Generic;

namespace ReadModel.Infrastructure.Models;

public partial class Phone
{
    public Guid ContactId { get; set; }

    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Number { get; set; } = null!;

    public virtual Contact Contact { get; set; } = null!;
}
