namespace Phonebook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Phonebook phonebook = new Phonebook();
            phonebook.Add("765756624", "Alex");
            Console.WriteLine(phonebook.GetPhoneNumberByName("Alex"));
            Console.WriteLine(phonebook.GetPhoneNumberByName(""));
            Console.WriteLine(phonebook.GetAbonentByPhone("76575664").ToString());
            Console.WriteLine(phonebook.GetAbonentByPhone(""));
        }
    }
}
