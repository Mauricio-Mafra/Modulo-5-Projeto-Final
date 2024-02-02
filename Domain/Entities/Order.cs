namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required int ProductId { get; set; }
    }
}
