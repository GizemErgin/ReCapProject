using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator: AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.CardNameSurname).MinimumLength(5).WithMessage("İsim soyisim alanı 5 karakterden fazla olmalıdır.");
            RuleFor(p => p.CardNumber).Length(12).WithMessage("Kart numarası 12 karakter olmalıdır.");
            RuleFor(p => p.CardExpiryDate).MinimumLength(2).WithMessage("Kart tarihi 2 karakterden fazla olmalıdır.");
            RuleFor(p => p.CardCvv).Length(3).WithMessage("Güvenlik numarası 3 karakter olmalıdır.");

        }
    }
}
