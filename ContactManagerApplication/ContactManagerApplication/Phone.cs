using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApplication
{
    internal class Phone
    {
        private string _Phone { get; set; }
        private string Type { get; set; }
        private string Description { get; set; }

        public Phone(string phone, string type, string description)
        {
            _Phone = phone;
            Type = type;
            Description = description;
        }
        public void SetPhone(string phone)
        {
            _Phone = phone;
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
            return $"Address : {_Phone}, Type : {Type}, Description : {Description}";
        }
    }
}