namespace Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public byte Image { get; set; }

        public int TypeId { get; set; }

        public Basket Basket { get; set; }

        public int BasketId { get; set; }
    }
}
