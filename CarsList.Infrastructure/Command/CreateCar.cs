using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarsList.Infrastructure.Command
{
    public class CreateCar
    {
        public Guid CarId { get; set; }

        public string Mark { get;  set; }

        public string Model { get;  set; }

        public float Capacity { get;  set; }

        public DateTime DateOc { get;  set; }
        public DateTime DateReview { get;  set; }

        public string CarType { get;  set; }

    }
}
