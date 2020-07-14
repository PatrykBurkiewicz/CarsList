using CarsList.Core.Domain;
using CarsList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsList.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Car> GetOrFailAsync(this ICarRepository repository, Guid id)
        {
            var @car = await repository.GetAsync(id);
            if (@car == null)
            {
                throw new Exception($"Car with id: '{id}' does not exists.");
            }
            return @car;
        }
    }
}
