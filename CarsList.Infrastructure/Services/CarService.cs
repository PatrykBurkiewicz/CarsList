using AutoMapper;
using CarsList.Core;
using CarsList.Core.Domain;
using CarsList.Core.Enums;
using CarsList.Core.Repositories;
using CarsList.Infrastructure.DTO;
using CarsList.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsList.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<CarDto> GetAsync(Guid id)
        {
            var @car = await _carRepository.GetAsync(id);

            return _mapper.Map<CarDto>(@car);
        }

        public async Task<CarDto> GetAsync(string mark)
        {
            var @car = await _carRepository.GetAsync(mark);

            return _mapper.Map<CarDto>(@car);
        }

        public async Task<IEnumerable<CarDto>> BrowseAsync(string mark = null)
        {
            var cars = await _carRepository.BrowseAsync(mark);

            return _mapper.Map<IEnumerable<CarDto>>(cars);


        }

        public async Task CreateAsync(Guid id, string mark, string model, float capacity, DateTime dateOc, DateTime dateReview, int carType)
        {
            if (carType != Convert.ToInt32(CarType.Car) && carType != Convert.ToInt32(CarType.SmallTruck) && carType != Convert.ToInt32(CarType.Truck))
            {
                throw new Exception($"Car Type: '{carType}' is invalid.");
            }

            var markAlphaNumericString = new AlphaNumericString(mark);

            var modelAlphaNumericString = new AlphaNumericString(model);
          
            var  @car = new Car(id, markAlphaNumericString, modelAlphaNumericString,  capacity, dateOc, dateReview, carType);
            await _carRepository.AddAsync(@car);

        }

        public async Task UpdateAsync(Guid id, string mark, string model, float capacity, DateTime dateOc, DateTime dateReview, int carType)
        {
            var @car = await _carRepository.GetOrFailAsync(id);

            if (carType != Convert.ToInt32(CarType.Car) && carType != Convert.ToInt32(CarType.SmallTruck) && carType != Convert.ToInt32(CarType.Truck))
            {
                throw new Exception($"Car Type: '{carType}' is invalid.");
            }

            var markAlphaNumericString = new AlphaNumericString(mark);

            var modelAlphaNumericString = new AlphaNumericString(model);

            @car.setMark(markAlphaNumericString);
            @car.setModel(modelAlphaNumericString);
            @car.setCapacity(capacity);
            @car.setDateOc(dateOc);
            @car.setDateReview(dateReview);
            @car.setCarType(carType);

            await _carRepository.UpdateAsync(@car);

          
        }
        public async Task DeleteAsync(Guid id)
        {
            var @car = await _carRepository.GetOrFailAsync(id);

            await _carRepository.DeleteAsync(@car);
        }
    }
}
