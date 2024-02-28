namespace TaskProject.Infrastructure.DTO
{
    public class DropDownDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public object Extra { get; set; } = new { };
    }
}
