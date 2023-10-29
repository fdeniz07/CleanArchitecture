﻿using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configuration
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.ToTable("ErrorLogs");
        }
    }
}
