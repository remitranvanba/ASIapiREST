using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp.Services;

interface IService<TEntity>
{
    Task<List<TEntity>> GetAllAsync(string? nomControleur);
    Task<TEntity?> GetByIdAsync(string? nomControleur, int? id);
    Task<TEntity> GetByStringAsync(string? nomControleur, string? str);
    Task<bool> PostAsync(string? nomControleur, TEntity? entity);
    Task<bool> PutAsync(string? nomControleur, TEntity? entity);
    Task<bool> DeleteAsync(string? nomControleur, TEntity? entity);
}
