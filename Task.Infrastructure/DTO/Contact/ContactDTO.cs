namespace TaskProject.Infrastructure.DTO.Contact
{

    public class ContactDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int Id { get; internal set; }
        public bool IsActive { get; internal set; }
    }
}
