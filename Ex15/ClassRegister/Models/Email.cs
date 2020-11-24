namespace ClassRegister.Models
{
    internal class Email
    {
        public string EmailAddress { get; }

        public Email(string firstName, string surname)
        {
            EmailAddress = $"{firstName.Substring(0, 3)}{surname.Substring(0, 3)}@myschool.com";
        }
    }
}
