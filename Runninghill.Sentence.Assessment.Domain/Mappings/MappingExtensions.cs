using Microsoft.EntityFrameworkCore;
using Runninghill.Sentence.Assessment.Domain.Models;

namespace Runninghill.Sentence.Assessment.Application.Common.Mappings;
public static class MappingExtensions
{
    public static Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) where T : class
    {
       return PaginatedList<T>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }
}
