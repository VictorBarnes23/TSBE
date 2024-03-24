namespace WebApplication1.Models.DTOs
{
    public class TicketDTO
    {
        public int? Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Resolution { get; set; }

        public string? Name { get; set; }

        public string? Resolver { get; set; }

        public bool? Completed { get; set; }

    }

    //public class TicketUpdateDTO
    //{
    //    public string? Title { get; set; }

    //    public string? Description { get; set; }

    //    public string? Resolution { get; set; }

    //    public string? Name { get; set; }

    //    public string? Resolver { get; set; }

    //    public bool? Completed { get; set; }

    //}
}
