namespace ElectronicsStoreFrontend.Models
{
    public class OrderConfirmationDto
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
