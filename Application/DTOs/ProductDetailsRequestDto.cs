namespace Application.DTOs
{
    public record ProductDetailsRequestDto
    {
         int Id { get;  set; }
         DateTime CreatedAt { get;  set; }
         DateTime? UpdatedAt { get;  set; }
         string ProductName { get; set; }
         string ProductDescription { get; set; }
         int ProductPrice { get; set; }
         int ProductStock { get; set; }
    }
}