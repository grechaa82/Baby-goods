public class Product
{
    public Guid Id { get; }
    public Category Category { get; private set; }
    public string Title { get; }
    public string Summary { get; }
    public string ImageUrl { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; private set; }

    public Product( 
        Category category, 
        string title, 
        string summary, 
        string imageUrl, 
        decimal price,
        Guid id = new Guid())
    {
        if (category == null)
        {
            throw new ArgumentNullException($"'{nameof(category)}' connot be null.");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException($"'{nameof(title)}' connot be null.");
        }

        if (string.IsNullOrWhiteSpace(summary))
        {
            throw new ArgumentException($"'{nameof(summary)}' connot be null.");
        }

        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException($"'{nameof(price)}' cannot be zero or less.");
        }

        Id = id;
        Category = category;
        Title = title;
        Summary = summary;
        ImageUrl = imageUrl;
        Price = price;
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetCategoryId(Category category)
    {
        Category = category;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetImageUrl(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            throw new ArgumentNullException($"'{nameof(imageUrl)}' connot be null.");
        }
        ImageUrl = imageUrl;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException($"'{nameof(price)}' cannot be zero or less.");
        }
        Price = price;
        ModifiedAt = DateTime.UtcNow;
    }
}