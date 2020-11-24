namespace ClassRegister.Models
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set; } = new Address();
    }
}