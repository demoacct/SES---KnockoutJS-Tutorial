using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knockout_Kendo_Tutorial.Models.Repositories.IRepository
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T value);
        Task<List<T>> RetrieveAll();
        Task<T> Retrieve(object id);
        Task<bool> Update(T value);
        Task<bool> Delete(object id);
    }
}
