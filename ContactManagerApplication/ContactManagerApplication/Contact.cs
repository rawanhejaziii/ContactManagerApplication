using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApplication
{
    public class Contact
    {
        private int count;

        public List<User> users;
        
        public Contact()
        {
            users = new List<User>();
            count = 0;
        }
        public void AddUser(User useer)
        {
            users.Add(useer);
            count++;
        }
        public void EditUser(int UserId , User UpdateUser)
        {
            for(int i =0; i< users.Count; i++)
            {
                if (users[i].Id== UserId)
                {
                    users[i] = UpdateUser;
                    break;
                }
            }
        }
        public int CountUsers()
        {
            return count;
        }
        public User? SearchUser(string SearchUbyF , string SearchUbyL)
        {
            foreach(var item in users)
            {
                if(item.FirstName.Contains(SearchUbyF) &&
                    item.LastName.Contains(SearchUbyL))
                {
                    return item;
                }
            }
            Console.WriteLine("User NOT Found");
            return null;
        }
        public void DeleteUser(int Idd)
        {
            users.RemoveAll(u => u.Id == Idd);
            count--;
        }
        public void ShowAll()
        {
            foreach(var item in users)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.FirstName} {item.LastName}");
            }
        }
    }
}
