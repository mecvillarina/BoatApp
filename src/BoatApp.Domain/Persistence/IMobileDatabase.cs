using System.Linq.Expressions;
using BoatApp.Models.Entities;
using SQLite;

namespace BoatApp.Domain.Persistence;

public interface IMobileDatabase
{
    SQLiteAsyncConnection ConnAsync { get; }
    Task InsertAllAsync<T>(IEnumerable<T> list) where T : class, IEntity, new();
    Task UpdateAllAsync<T>(IEnumerable<T> list) where T : class, IEntity, new();

    Task<int> CountAsync<T>() where T : class, IEntity, new();
    Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new();
    Task<int> DeleteAllAsync<T>() where T : class, IEntity, new();
    Task<int> DeleteAsync<T>(int id) where T : class, IEntity, new();
    Task<int> DeleteAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new();

    Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new();
    Task<List<T>> ToListAsync<T>() where T : class, IEntity, new();
    Task<List<T>> Where<T>(Expression<Func<T, bool>> expression) where T : class, IEntity, new();
    Task<int> InsertAsync<T>(T item) where T : class, IEntity, new();
    Task<int> UpdateAsync<T>(T item) where T : IEntity;
}
