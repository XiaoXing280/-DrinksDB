//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DrinkDBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DrinkDBEntities : DbContext
    {
        public DrinkDBEntities()
            : base("name=DrinkDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DrinkInfo> DrinkInfo { get; set; }
        public virtual DbSet<DrinkNews> DrinkNews { get; set; }
        public virtual DbSet<DrinkType> DrinkType { get; set; }
        public virtual DbSet<MessInfo> MessInfo { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
