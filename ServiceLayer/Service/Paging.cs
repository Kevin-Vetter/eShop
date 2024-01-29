using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public static class Paging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int start, int numberOfProducts) => query.Skip((start-1) * numberOfProducts).Take(numberOfProducts);
    }
}
