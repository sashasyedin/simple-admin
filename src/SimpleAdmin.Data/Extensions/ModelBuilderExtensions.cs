﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleAdmin.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            //foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            //    entity.Relational().TableName = entity.DisplayName();
        }
    }
}
