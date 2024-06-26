﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int TicketId { get; set; }

    public virtual Ticket? Ticket { get; set; } = null!;
}
