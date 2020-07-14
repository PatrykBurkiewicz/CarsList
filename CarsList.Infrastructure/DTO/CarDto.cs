using System;
using System.Collections.Generic;
using System.Text;

namespace CarsList.Infrastructure.DTO
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public string Mark { get; set; }
        public string Model { get; set; }

        public float Capacity { get; set; }

        public DateTime DateOc { get; set; }
        public DateTime DateReview { get; set; }

        public string CarType { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
