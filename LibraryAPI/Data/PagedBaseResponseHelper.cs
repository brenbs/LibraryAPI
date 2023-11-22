using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace LibraryAPI.Data
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>
            (IQueryable<T> query, PagedBaseRequest request)
            where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);
            response.TotalRegisters = count;
            response.Page = request.Page;
            if (string.IsNullOrEmpty(request.OrderByPorperty) && !request.Desc)
                response.Data = await query.ToListAsync();
            else
                response.Data = query.OrderByDynamic(request.OrderByPorperty, request.Desc)
                   .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

            return response;
        }
        private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName, bool desc)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = propertyName.Split('.')
                .Aggregate((Expression)parameter, Expression.Property);
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);
            if (desc)
            {
                return query.OrderByDescending(lambda.Compile());
            }
            else
            {
                return query.OrderBy(lambda.Compile());
            }
        }
    }       
}
