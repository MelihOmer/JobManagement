﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.DataAccess.EntityConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Decription).HasColumnType("ntext").IsRequired();


            builder.HasData(new Department
            {
                Id = 1,
                Decription = "Birim Belirtilmedi"
            },
            new Department
            {
                Id = 2,
                Decription = "Bilgi İşlem Yazılım"
            },
            new Department
            {
                Id = 3,
                Decription = "Bilgi İşlem Donanım"
            });

        }
    }
}
