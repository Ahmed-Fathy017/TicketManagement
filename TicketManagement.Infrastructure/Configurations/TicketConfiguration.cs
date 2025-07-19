using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Entities.Tickets;

namespace TicketManagement.Infrastructure.Configurations
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Governorate)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.District)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.IsHandled)
                .IsRequired();
        }
    }
}
