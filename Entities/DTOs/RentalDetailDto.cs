using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto: IDto
    {
        public int CarId { get; set; }
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string Decription { get; set; }
        public int ModelYear { get; set; }
    }
}
