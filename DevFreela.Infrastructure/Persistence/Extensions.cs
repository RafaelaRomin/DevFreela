using DevFreela.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public static class Extensions
{
    public static async Task<PaginationResult<T>> GetPaged<T>(
        this IQueryable<T> query, 
        int page, 
        int pageSize) where T : class
    {
        var result = new PaginationResult<T>();

        result.Page = page;
        result.PageSize = pageSize;
        result.ItemsCount = await query.CountAsync();
        
        var pageCount = (double)result.ItemsCount / pageSize;
        result.TotalPages = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;

        result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
    
}