﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeyMouse.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KeyMouseEntities : DbContext
    {
        public KeyMouseEntities()
            : base("name=KeyMouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dl_basic_user> dl_basic_user { get; set; }
        public virtual DbSet<sys_function> sys_function { get; set; }
        public virtual DbSet<sys_role> sys_role { get; set; }
        public virtual DbSet<sys_user_role> sys_user_role { get; set; }
        public virtual DbSet<t_f_data> t_f_data { get; set; }
        public virtual DbSet<t_f_keymou> t_f_keymou { get; set; }
        public virtual DbSet<t_f_userlogin> t_f_userlogin { get; set; }
        public virtual DbSet<sys_role_function> sys_role_function { get; set; }
    }
}
