using OnlineShop.Domain.Entities;

namespace Domain.Entities
{   /// <summary>
    /// Товар
    /// </summary>
    public class ItemEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public byte[] Image { get; set; }

        public Guid TypeId { get; set; }

        public virtual TypeEntity Types { get; set; }

    }
}
