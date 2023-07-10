namespace KetabBaz.Infrastructure.Data.Repositories.Base;

public class Repository<T> : IRepository<T> where T : class, IEntityBase
{
    protected readonly KetabBazDbContext _dbContext;
    protected readonly DbSet<T> _set;

    public Repository(KetabBazDbContext dbContext)
    {
        _dbContext = dbContext;
        _set = _dbContext.Set<T>();
    }

    public virtual async Task AddAsync(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        entity.DateUpdated = DateTimeOffset.UtcNow;
        await _set.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await _set.ToListAsync();

        return entities;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        var entity = await _set.FindAsync(id);

        return entity;
    }

    public virtual async Task RemoveAsync(int id)
    {
        var entity = await _set.FindAsync(id);
        _set.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        entity.DateUpdated = DateTimeOffset.UtcNow;
        await _dbContext.SaveChangesAsync();
    }
}
