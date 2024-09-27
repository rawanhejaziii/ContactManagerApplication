using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApplication
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public string City { get; private set; }
        public string AddedDate { get; private set; }


        public List<string> address { get; private set; } = new List<string>();
        public List<string> phone { get; private set; } = new List<string>();
        public List<string> email { get; private set; } = new List<string>();

        
        public User(int id, string firstName, string lastName, string gender, string city, string addedDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            City = city;
            AddedDate = addedDate;
        }
        
        public bool Search(string data)
        {
            if(address.Contains(data) ||
                phone.Contains(data)||
                email.Contains(data))
            {
                return true;
            }
            return false;
        }
        public void AddContact(string Type, string Value)
        {
            if (Type == "phone")
                phone.Add(Value);
            else if (Type== "email")
                email.Add(Value);
            else if(Type=="address")
                address.Add(Value);
        }
        public void EditCon(string Type , string OldValue , string NewValue)
        {
            if (Type == "phone")
            {
                int index = phone.IndexOf(OldValue);
                if (index != -1)
                    phone[index] = NewValue;
            }
            else if (Type == "email")
            {
                int index = email.IndexOf(OldValue);
                if (index != -1)
                    email[index] = NewValue;
            }
            else if (Type == "address")
            {
                int index = address.IndexOf(OldValue);
                if (index != -1)
                    address[index] = NewValue;
            }
            
            }
        public void EditInfo(string Type, string NewValue)
        {
            switch (Type.ToLower())
            {
                case "firstName":
                    FirstName = NewValue; 
                    break;
                case "lastName":
                    LastName = NewValue; 
                    break;
                case "gender":
                    Gender = NewValue;
                    break;
                case "city":
                    City = NewValue; 
                    break;
                default:
                    Console.WriteLine("Invalid type specified for edit.");
                    break;
            }
            }
        public void Remove(string Type , string Value)
        {
            if (Type == "phone")
                phone.Remove(Value);
            else if (Type == "email")
                email.Remove(Value);
            else if (Type == "address")
                address.Remove(Value);
        }

        public void Show()
        {
            Console.WriteLine($"ID:  { Id}");
            Console.WriteLine($"Name:  {FirstName} , {LastName}");
            Console.WriteLine($"Gender:  {Gender}");
            Console.WriteLine($"City:  {City}");
            Console.WriteLine($"Added Date:  {AddedDate}");

            Console.WriteLine($"Addresses:  {address}");
            Console.WriteLine($"Phones: {phone}");
            Console.WriteLine($"Emails:  {email}");
        }
    }
}
