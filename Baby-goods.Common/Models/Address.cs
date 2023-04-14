public class Address
{
    public Guid Id { get; }
    public User User { get; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string AddressLine1 { get; private set; }
    public string AddressLine2 { get; private set; }
    public string AddressLine3 { get; private set; }
    public string AddressLine4 { get; private set; }

    public Address(
        User user, 
        string city, 
        string country, 
        string addressLine1, 
        string addressLine2, 
        string addressLine3, 
        string addressLine4,
        Guid id = new Guid())
    {
        if (user == null)
        {
            throw new ArgumentNullException($"'{nameof(user)}' connot be null.");
        }

        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentNullException($"'{nameof(city)}' connot be null.");
        }

        if (string.IsNullOrEmpty(country))
        {
            throw new ArgumentNullException($"'{nameof(country)}' connot be null.");
        }

        if (string.IsNullOrEmpty(addressLine1))
        {
            throw new ArgumentNullException($"'{nameof(addressLine1)}' connot be null.");
        }

        if (string.IsNullOrEmpty(addressLine2))
        {
            throw new ArgumentNullException($"'{nameof(addressLine2)}' connot be null.");
        }

        if (string.IsNullOrEmpty(addressLine3))
        {
            throw new ArgumentNullException($"'{nameof(addressLine3)}' connot be null.");
        }

        Id = id;
        User = user;
        City = city;
        Country = country;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        AddressLine3 = addressLine3;
        AddressLine4 = addressLine4;
    }

    public void SetCity(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentNullException($"'{nameof(city)}' connot be null.");
        }
        City = city;
    }

    public void SetCountry(string country)
    {
        if (string.IsNullOrEmpty(country))
        {
            throw new ArgumentNullException($"'{nameof(country)}' connot be null.");
        }
        Country = country;
    }

    public void SetAddressLine1(string addressLine1)
    {
        if (string.IsNullOrEmpty(addressLine1))
        {
            throw new ArgumentNullException($"'{nameof(addressLine1)}' connot be null.");
        }
        AddressLine1 = addressLine1;
    }

    public void SetAddressLine2(string addressLine2)
    {
        if (string.IsNullOrEmpty(addressLine2))
        {
            throw new ArgumentNullException($"'{nameof(addressLine2)}' connot be null.");
        }
        AddressLine2 = addressLine2;
    }

    public void SetAddressLine3(string addressLine3)
    {
        if (string.IsNullOrEmpty(addressLine3))
        {
            throw new ArgumentNullException($"'{nameof(addressLine3)}' connot be null.");
        }
        AddressLine3 = addressLine3;
    }

    public void SetAddressLine4(string addressLine4)
    {
        AddressLine4 = addressLine4;
    }
}