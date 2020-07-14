using CarsList.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsList.Core.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetAsync(Guid id);
        Task<Car> GetAsync(string mark);

        Task<IEnumerable<Car>> BrowseAsync(string mark = "");

        Task AddAsync(Car @car);
        Task UpdateAsync(Car @car);
        Task DeleteAsync(Car @car);
    }
}
