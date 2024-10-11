using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Specification
{
    public class BaseSpecification<T>(Expression<Func<T, bool>> criteria) : Ispecification<T>
    {
   
        public Expression<Func<T, bool>> Criteria => criteria;
    }
}