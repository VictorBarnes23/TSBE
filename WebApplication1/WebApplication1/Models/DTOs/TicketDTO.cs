namespace WebApplication1.Models.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Resolution { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Resolver { get; set; }

        public bool? Completed { get; set; }

    }
}
