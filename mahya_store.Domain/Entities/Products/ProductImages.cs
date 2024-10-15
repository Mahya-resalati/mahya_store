using mahya_store.Domain.Entities.Commons;

namespace mahya_store.Domain.Entities.Products
{
    public class ProductImages:BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }

}
