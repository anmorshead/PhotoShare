﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Models;

namespace PhotoShare.Data
{
    //changed DbContext to IdentityDbContext
    public class PhotoShareContext : IdentityDbContext<ApplicationUser>
    {
        public PhotoShareContext (DbContextOptions<PhotoShareContext> options)
            : base(options)
        {
        }

        public DbSet<PhotoShare.Models.Photo> Photo { get; set; } = default!;
        public DbSet<PhotoShare.Models.Tag> Tag { get; set; } = default!;
    }
}
