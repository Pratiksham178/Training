﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserManagement.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProfileEntities : DbContext
    {
        public ProfileEntities()
            : base("name=ProfileEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<country_list> country_list { get; set; }
        public virtual DbSet<country_table> country_table { get; set; }
        public virtual DbSet<filelist> filelist { get; set; }
        public virtual DbSet<Hobby_table> Hobby_table { get; set; }
        public virtual DbSet<language_table> language_table { get; set; }
        public virtual DbSet<note_table> note_table { get; set; }
        public virtual DbSet<notes> notes { get; set; }
        public virtual DbSet<state_table> state_table { get; set; }
        public virtual DbSet<statelist_table> statelist_table { get; set; }
        public virtual DbSet<user_table> user_table { get; set; }
        public virtual DbSet<userDetails> userDetails { get; set; }
        public virtual DbSet<userrolerelation> userrolerelation { get; set; }
        public virtual DbSet<userroletable> userroletable { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    
        public virtual ObjectResult<getState_Result> getState(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getState_Result>("getState", idParameter);
        }
    
        public virtual ObjectResult<selectstate1_Result> selectstate1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectstate1_Result>("selectstate1");
        }
    }
}
