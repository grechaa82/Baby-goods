public class Category
{
    public Guid Id { get; }
    public string Name { get; }

    public Category(string name, Guid id = new Guid())
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException($"'{nameof(name)}' connot be null.");
        }

        Id = id;
        Name = name;
    }
}