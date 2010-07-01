using System.Collections.Generic;

namespace jqGridAddEditDelete.Models
{
    public interface IRepositoryWithTypedId<T, IdT>
    {
        T Get(IdT id);

        IList<T> GetAll();

        IList<T> FindAll(IDictionary<string, object> propertyValuePairs);

        T FindOne(IDictionary<string, object> propertyValuePairs);

        T SaveOrUpdate(T entity);

        void Delete(T entity);

        IDbContext DbContext { get; }

        bool HasErrors { get; set; }

        List<ErrorViewModel> Errors { get; set; }
    }

    public interface IDbContext
    {
    }
}