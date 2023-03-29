namespace DAL.Model;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public bool Disabled { get; set; }


    public Customer(int id, string firstName,string lastName, string address, string email, bool disabled)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        Disabled = disabled;
    }
    public Customer(string firstName, string lastName, string address, string email,bool disabled)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        Disabled = disabled;
    }

}