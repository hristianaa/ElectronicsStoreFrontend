namespace ElectronicsStoreFrontend.Models
{
    public class UserOrderDto
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "";
    }
}
