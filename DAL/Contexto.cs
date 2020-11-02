
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
//using CrismeyriP2_Apl.Entidades;

namespace CrismeyriP2_Apl.DAL
{
    public class Contexto : DbContext
    {
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Proyecto.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}