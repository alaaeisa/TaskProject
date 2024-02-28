namespace TaskProject.Infrastructure.DTO
{
    public class DataTableParamterDTO
    {
        public string Search { get; set; } = string.Empty;
        public string Draw { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public string OrderDir { get; set; } = string.Empty;
        public int StartRec { get; set; }
        public int PageSize { get; set; }
        public bool IsArabic { get; set; }
    }
}
