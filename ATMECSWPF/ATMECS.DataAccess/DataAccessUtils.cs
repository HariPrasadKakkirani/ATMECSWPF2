using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMECS.Model2;
using System.IO;
using System.Xml.Serialization;

namespace ATMECS.DataAccess
{
    public class DataAccessUtils
    {
        private const string StorageFile = "Contacts.xml";
        public static Contact GetContactById(int contactId)
        {
            var contacts = ReadFromFile();
            return contacts.Single(f => f.Id == contactId);
        }

        public static void SaveContact(Contact contact)
        {
            if (contact.Id <= 0)
            {
                InsertContact(contact);
            }
            else
            {
                UpdateContact(contact);
            }
        }

        public static void DeleteContact(int contactId)
        {
            var contacts = ReadFromFile();
            var existing = contacts.Single(f => f.Id == contactId);
            contacts.Remove(existing);
            SaveToFile(contacts);
        }

        private static void UpdateContact(Contact contact)
        {
            var contacts = ReadFromFile();
            var existing = contacts.Single(f => f.Id == contact.Id);
            var indexOfExisting = contacts.IndexOf(existing);
            contacts.Insert(indexOfExisting, contact);
            contacts.Remove(existing);
            SaveToFile(contacts);
        }

        private static void InsertContact(Contact contact)
        {
            var contacts = ReadFromFile();
            var maxContactId = contacts.Count == 0 ? 0 : contacts.Max(f => f.Id);
            contact.Id = maxContactId + 1;
            contacts.Add(contact);
            SaveToFile(contacts);
        }

        public static IEnumerable<LookupItem> GetAllContacts()
        {
            return ReadFromFile()
              .Select(f => new LookupItem
              {
                  Id = f.Id,
                  DisplayMember = $"{f.FirstName} {f.LastName}"
              });
        }

        private static List<Contact> ReadFromFile()
        {
            //if (!File.Exists(StorageFile))
            //{
                return new List<Contact>
                {
                    new Contact{Id=1,FirstName = "Hari",LastName="Prasad",
                        Birthday = new DateTime(1980,10,28)},
                    new Contact{Id=2,FirstName = "Naveen",LastName="Kumar",
                        Birthday = new DateTime(1982,10,10)},
                    new Contact{Id=3,FirstName="Rajesh",LastName="Kumar",
                        Birthday = new DateTime(2011,05,13)},
                    new Contact{Id=4,FirstName="Kalyan",LastName="Kumar",
                        Birthday = new DateTime(2013,02,25)},
                    new Contact{Id=5,FirstName = "Lakshmi",LastName="K",
                        Birthday = new DateTime(1981,01,10)},
                    new Contact{Id=6,FirstName="Ramana",LastName="R",
                        Birthday = new DateTime(1970,03,5)},
                     new Contact{Id=7,FirstName="Osman",LastName="Ali",
                        Birthday = new DateTime(1987,07,16)},
                     new Contact{Id=8,FirstName="Suresh",LastName="Kumar",
                        Birthday = new DateTime(1983,05,23)},
                };
            //}

            //string text = File.ReadAllText(StorageFile);
        }

        private static void SaveToFile(List<Contact> contacts)
        {
            
        }
    }
}
