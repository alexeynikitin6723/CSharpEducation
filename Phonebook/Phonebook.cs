using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Phonebook
    {
        private static Phonebook instance;
        private List<Abonent> abonents;
        private string filePath = "phonebook.txt";

        public Phonebook()
        {
            abonents = new List<Abonent>();
            ReadFromFile();
        }
        public static Phonebook GetInstance()
        {
            if (instance == null)
            {
                instance = new Phonebook();
            }
            return instance;
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Abonent abonent in abonents)
                {
                    sw.WriteLine($"{abonent.PhoneNumber}:{abonent.Name}");
                }
            }
        }

        private void ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] part = line.Split(":");
                    if (part.Length == 2)
                    {
                        abonents.Add(new Abonent { PhoneNumber = part[0], Name = part[1] });
                    }
                }
            }
        }

        public Abonent GetAbonentByPhone(string phoneNumber)
        {
            return abonents.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }
        public string GetPhoneNumberByName(string name)
        {
            return abonents.Where(x => x.Name == name).Select(x => x.PhoneNumber).FirstOrDefault();
        }
        public void Delete(string phoneNumber)
        {
            Abonent abonent = GetAbonentByPhone(phoneNumber);
            if (abonent is not null)
            {
                abonents.Remove(abonent);
                SaveToFile();
            }
        }
        public void Add(string phoneNumber, string name)
        {
            if(abonents.Any(x => x.PhoneNumber == phoneNumber))
            {
                Console.WriteLine($"Такой пользователь уже существует");
                return;
            }
            Abonent abonent = new Abonent() { PhoneNumber = phoneNumber, Name = name };
            abonents.Add(abonent);
            SaveToFile();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Abonent abonent in abonents)
            {
                sb.Append($"{abonent.PhoneNumber}:{abonent.Name}");
            }
            return sb.ToString();
        }
    }
}
