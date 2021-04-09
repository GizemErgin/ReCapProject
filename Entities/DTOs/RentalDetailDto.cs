using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto: IDto
    {
        
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string Decription { get; set; }
        public decimal DailyPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? EstReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardCvv { get; set; }
        public int TotalPaye { get; set; }
    }
}
