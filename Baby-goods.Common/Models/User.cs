public class User
{
    public Guid Id { get; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; private set; }

    public User(
        string username,
        string email,
        string password, 
        string firstName, 
        string lastName, 
        string phone, 
        Role role = Role.Customer,
        Guid id = new Guid())
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException($"'{nameof(username)}' connot be null.");
        }

        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException($"'{nameof(email)}' connot be null.");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException($"'{nameof(password)}' connot be null.");
        }

        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(phone))
        {
            throw new ArgumentException($"'{nameof(phone)}' cannot be null or empty.");
        }

        Id = id;
        Username = username;
        Email = email;
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
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentNullException($"'{nameof(username)}' connot be null or whitespace.");
        }

        Username = username;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentNullException($"'{nameof(password)}' connot be null or whitespace.");
        }
         
        Password = password;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetFirstNameAndLastName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException($"'{nameof(firstName)}' connot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException($"'{nameof(lastName)}' connot be null or whitespace.");
        }

        FirstName = firstName;
        LastName = lastName;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new ArgumentNullException($"'{nameof(phone)}' connot be null or whitespace.");
        }

        Phone = phone;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetRole(Role role)
    {
        Role = role;
        ModifiedAt = DateTime.UtcNow;
    }
}