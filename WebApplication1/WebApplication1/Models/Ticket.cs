using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Resolver { get; set; }

    public bool? Completed { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
