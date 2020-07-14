using CarsList.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsList.Infrastructure.Services
{
    public interface ICarService
    {
        Task<CarDto> GetAsync(Guid id);

        Task<CarDto> GetAsync(string mark);

        Task<IEnumerable<CarDto>> BrowseAsync(string mark = null);

        Task CreateAsync(Guid id, string mark, string model, float capacity, DateTime dateOc, DateTime dateReview, string carType);

        Task UpdateAsync(Guid id, string mark, string model, float capacity, DateTime dateOc, DateTime dateReview, string carType);

        Task DeleteAsync(Guid id);
    }
}
