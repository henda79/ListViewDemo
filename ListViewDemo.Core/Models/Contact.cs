namespace ListViewDemo.Core.Models
{
    public class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Contact(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
