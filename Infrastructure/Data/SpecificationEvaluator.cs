using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, Ispecification<T> spec) 
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }
        
    }
}