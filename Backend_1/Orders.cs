namespace Backend_1
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderDate { get; set; }
        public string OurReference { get; set; }
        public string Status { get; set; }
        public int DeliveryTypeId { get; set; }
        public int InvoiceAdressId { get; set; }
        public int DeliveryAdressId { get; set; }

    }
}
