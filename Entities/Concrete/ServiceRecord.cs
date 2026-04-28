using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ServiceRecord : IEntity
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public Double Price { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
