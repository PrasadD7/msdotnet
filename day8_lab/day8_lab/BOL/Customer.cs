using System;
namespace BOL
{
    [Serializable]
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
