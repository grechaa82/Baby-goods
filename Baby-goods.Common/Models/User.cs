public class User
{
    public Guid Id { get; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Phone { get; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; private set; }

    public User(
        string username, 
        string password, 
        string firstName, 
        string lastName, 
        string phone, 
        Role role,
        Guid id = new Guid())
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException($"'{nameof(username)}' connot be null.");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException($"'{nameof(password)}' connot be null.");
        }

        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
        }

        if (string.IsNullOrEmpty(phone))
        {
            throw new ArgumentException($"'{nameof(phone)}' cannot be null or empty.", nameof(phone));
        }

        Id = id;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Role = role;
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException($"'{nameof(username)}' connot be null.");
        }

        Username = username;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException($"'{nameof(password)}' connot be null.");
        }

        Password = password;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetRole(Role role)
    {
        Role = role;
        ModifiedAt = DateTime.UtcNow;
    }
}