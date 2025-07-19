using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Common.Models;
using TicketManagement.Domain.Entities.Tickets.Interfaces;

namespace TicketManagement.Domain.Entities.Tickets.Services
{
    public class TicketFactory : ITicketFactory
    {
        public DomainResult<Ticket> Create(string phoneNumber, string governorate, string district, string city)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length > 20)
                return DomainResult<Ticket>.Failure("Phone number is required and must be 20 characters or less.");

            if (string.IsNullOrWhiteSpace(governorate) || governorate.Length > 100)
                return DomainResult<Ticket>.Failure("Governorate is required and must be 100 characters or less.");

            if (string.IsNullOrWhiteSpace(district) || district.Length > 100)
                return DomainResult<Ticket>.Failure("District is required and must be 100 characters or less.");

            if (string.IsNullOrWhiteSpace(city) || city.Length > 100)
                return DomainResult<Ticket>.Failure("City is required and must be 100 characters or less.");

            var ticket = new Ticket(phoneNumber, governorate, district, city);

            return DomainResult<Ticket>.Success(ticket);
        }
    }
}
