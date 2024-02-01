namespace ProductsApi.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public String ProductName { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
