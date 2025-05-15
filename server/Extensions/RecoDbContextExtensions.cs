using RecoCms6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Extensions
{
    public static class RecoDbContextExtensions
    {
        public static TEntity DetachedClone<TEntity>(this RecoDbContext context, TEntity entity) where TEntity : class
            => context.Entry(entity).CurrentValues.Clone().ToObject() as TEntity;
    }
}
