public class Category
{
    public Guid Id { get; }
    public string Name { get; }
    public Guid? ParentId { get; }
    public List<Category> Categories { get; private set; } = new List<Category>();

    public Category(
        string name,
        Guid id = new Guid(),
        Guid? parentId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException($"'{nameof(name)}' connot be null.");
        }

        Id = id;
        Name = name;
        ParentId = parentId;
    }

    public void AddCategories(List<Category> items)
    {
        if (items == null)
        {
            throw new ArgumentNullException($"'{nameof(items)}' connot be null.");
        }

        foreach (var item in items)
        {
            Categories.Add(item);
        }
    }
}