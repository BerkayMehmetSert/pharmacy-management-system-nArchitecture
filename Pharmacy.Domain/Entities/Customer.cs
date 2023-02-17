using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Customer : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }
    public virtual ICollection<Report> Reports { get; set; }

    public Customer()
    {
        Sales = new HashSet<Sale>();
        Purchases = new HashSet<Purchase>();
        Reports = new HashSet<Report>();
    }

    public Customer(int id, string firstName, string lastName, string gender, int age, string contactAddress,
        string email, string password) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Age = age;
        ContactAddress = contactAddress;
        Email = email;
        Password = password;
    }
}