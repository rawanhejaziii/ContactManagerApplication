using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApplication
{
    internal class Email
    {
        private string _Email { get; set; }
        private string Type { get; set; }
        private string Description { get; set; }

        public Email(string email, string type, string description)
        {
            _Email = email;
            Type = type;
            Description = description;
        }
        public void SetEmail(string email)
        {
            _Email = email;
        }
        public void SetType(string type)
        {
            Type = type;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public string GetAddress()
        {
            return $"Address : {_Email}, Type : {Type}, Description : {Description}";
        }
    }
}
