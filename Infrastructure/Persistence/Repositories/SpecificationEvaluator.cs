using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal static class SpecificationEvaluator
    {
         public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery,Specifications<T> specifications) where T: class
        {
            var query = inputQuery;
            if(specifications.Critera is not null) query= query.Where(specifications.Critera);
            //foreach (var item in specifications.IncludesExpression)
            //{
            //    query= query.Include(item);
            //
            query = specifications.IncludesExpression.Aggregate(query, (curentQuery, includeExpression) => curentQuery.Include(includeExpression));
            return query;
        }
    }
}
