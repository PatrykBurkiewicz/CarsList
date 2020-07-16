using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarsList.Core.Domain
{
    public class Car : Entity
    {
        public string Mark { get; protected set; }

        public string Model { get; protected set; }

        public float Capacity { get; protected set; }

        public DateTime DateOc { get; protected set; }
        public DateTime DateReview { get; protected set; }

        public int CarType { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }
        protected Car()
        {

        }

        public Car(Guid id, string mark, string model, float capacity, DateTime dateOc, DateTime dateReview, int carType)
        {
            Id = id;
            setMark(mark);
            setModel(model);
            setCapacity(capacity);
            setDateOc(dateOc);
            setDateReview(dateReview);
            setCarType(carType);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }


        public void setMark(string mark)
        {
            if (string.IsNullOrWhiteSpace(mark))
            {
                throw new Exception($"Car with id: '{Id}' can not have an empty mark.");
            }
            Mark = mark;
            UpdatedAt = DateTime.UtcNow;
        }
        public void setModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new Exception($"Car with id: '{Id}' can not have an empty model.");
            }
            Model = model;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setCapacity(float capacity)
        {
            Capacity = capacity;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setDateOc(DateTime dateOc)
        {

            DateOc = dateOc;
            UpdatedAt = DateTime.UtcNow;
        }
        public void setDateReview(DateTime dateReview)
        {

            DateReview = dateReview;
            UpdatedAt = DateTime.UtcNow;
        }

        public void setCarType(int carType)
        {

            CarType = carType;
            UpdatedAt = DateTime.UtcNow;
        }

     
        

    }
}
