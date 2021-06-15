using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppPeruFail.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){
           
        }
        public DbSet<AppPeruFail.Models.Comentario> Comentarios { get; set; }
        public DbSet<AppPeruFail.Models.Fail> Fails { get; set; }
    }
}
