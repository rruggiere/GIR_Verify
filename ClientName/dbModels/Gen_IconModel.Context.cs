﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIR_Preventive_ClientName.dbModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Alc_Gen_ICONEntities : DbContext
    {
        public Alc_Gen_ICONEntities()
            : base("name=Alc_Gen_ICONEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<G_CALL> G_CALL { get; set; }
        public virtual DbSet<G_PARTY> G_PARTY { get; set; }
        public virtual DbSet<G_PARTY_STAT> G_PARTY_STAT { get; set; }
    }
}