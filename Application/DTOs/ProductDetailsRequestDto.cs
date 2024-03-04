namespace Application.DTOs
{
    public record ProductDetailsRequestDto
    {
         DateTime? UpdatedAt { get;  set; }
         string ProductName { get; set; }
         string ProductDescription { get; set; }
         int ProductPrice { get; set; }
         int ProductStock { get; set; }
    }
}