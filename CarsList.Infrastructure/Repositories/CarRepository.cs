using CarsList.Core;
using CarsList.Core.Domain;
using CarsList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsList.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly CarsListDbContext _dbContext;

        public CarRepository(CarsListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetAsync(Guid id)
           => await Task.FromResult(_dbContext.Cars.SingleOrDefault(x => x.Id == id));
        public async Task<Car> GetAsync(string mark)
           => await Task.FromResult(_dbContext.Cars.SingleOrDefault(x => x.Mark == mark));

        public async Task<IEnumerable<Car>> BrowseAsync(string mark = "")
        {
            var cars = _dbContext.Cars.AsEnumerable();

            if (!string.IsNullOrEmpty(mark))
            {
                cars = cars.Where(x => x.Mark.ToLowerInvariant()
                    .Contains(mark.ToLowerInvariant()));
            }
            return await Task.FromResult(cars);
        }


        public async Task AddAsync(Car @car)
        {
            _dbContext.Cars.Add(@car);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Car @car)
        {
            _dbContext.Cars.Update(@car);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Car @car)
        {
            _dbContext.Cars.Remove(@car);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
