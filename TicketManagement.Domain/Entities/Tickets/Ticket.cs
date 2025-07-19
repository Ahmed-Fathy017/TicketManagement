using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Domain.Entities.Tickets
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsHandled { get; private set; }

        internal Ticket(string phoneNumber, string governorate, string district, string city)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            District = district;
            City = city;
            CreatedAt = DateTime.UtcNow;
            IsHandled = false;
        }

        private Ticket() 
        {
            PhoneNumber = default!;
            Governorate = default!;
            District = default!;
            City = default!;
        }

        public void MarkAsHandled()
        {
            IsHandled = true;
        }
    }
}
