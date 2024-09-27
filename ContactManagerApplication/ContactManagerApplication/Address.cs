using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApplication
{
    internal class Address
    {
        private string Place { get; set; }
        private string Type { get; set; }
        private string Description { get; set; }

        public Address(string place , string type , string description)
        {
            Place = place;
            Type= type;
            Description = description;
        }
        public void SetPlace(string place)
        {
            Place = place;
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
            return $"Address : {Place}, Type : {Type}, Description : {Description}";
        }
    }
}
