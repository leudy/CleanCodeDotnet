using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Entities.Specificactions
{
  public abstract  class Specification<T>
    {
        public abstract Expression<Func<T,bool>> Expression { get; set; }
        public bool IsSastifyedBy(T Entity)
        {
            Func<T, bool> ExpressionDelegate = Expression.Compile();
            return ExpressionDelegate(Entity);
        }
    }
}
