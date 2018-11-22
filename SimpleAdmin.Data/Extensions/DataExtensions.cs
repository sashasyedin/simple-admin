using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleAdmin.Data.Extensions
{
    public static class DataExtensions
    {
        public static void RemoveRange<TEntity>(this DbSet<TEntity> entities, Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            var records = entities.Where(predicate);
            entities.RemoveRange(records);
        }
    }
}
