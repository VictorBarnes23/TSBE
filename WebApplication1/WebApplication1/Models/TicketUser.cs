using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TicketUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? GoogleId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
