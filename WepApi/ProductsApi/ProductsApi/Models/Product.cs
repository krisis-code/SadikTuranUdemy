namespace ProductsApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public String ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }
}
