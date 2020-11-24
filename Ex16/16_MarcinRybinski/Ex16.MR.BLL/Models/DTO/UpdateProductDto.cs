namespace Ex16.MR.BLL.Models.DTO
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Type Type { get; set; }
    }
}