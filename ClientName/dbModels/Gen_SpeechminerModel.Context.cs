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
    
    public partial class Alc_Gen_SPEECHMINEREntities : DbContext
    {
        public Alc_Gen_SPEECHMINEREntities()
            : base("name=Alc_Gen_SPEECHMINEREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<callAudioTbl> callAudioTbl { get; set; }
        public virtual DbSet<callMetaTbl> callMetaTbl { get; set; }
    }
}
