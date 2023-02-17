using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Pharmacist : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string ContactAddress { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }

    public Pharmacist()
    {
        Sales = new HashSet<Sale>();
    }

    public Pharmacist(int id, string firstName, string lastName, string gender, int age, string contactAddress,
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