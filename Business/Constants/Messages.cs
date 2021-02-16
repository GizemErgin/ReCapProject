using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba ekleme işlemi başarıyla gerçekleşti.";
        public static string CarDeleted = "Araba silme işlemi başarıyla gerçekleşti.";
        public static string CarUpdated = "Araba güncelleme işlemi başarıyla gerçekleşti.";
        public static string CarDailyPriceInvalid = "Hata! Günlük fiyat 0'dan büyük olmalıdır.";
        public static string CarDescriptionInvalid = "Hata! Açıklama en az iki karakter olmalıdır.";

        public static string ColorAdded = "Renk ekleme işlemi başarıyla gerçekleşti.";
        public static string ColorDeleted = "Renk silme işlemi başarıyla gerçekleşti.";
        public static string ColorUpdated = "Renk güncelleme işlemi başarıyla gerçekleşti.";
        
        public static string BrandAdded = "Marka ekleme işlemi başarıyla gerçekleşti.";
        public static string BrandDeleted = "Marka silme işlemi başarıyla gerçekleşti.";
        public static string BrandUpdated = "Marka güncelleme işlemi başarıyla gerçekleşti.";
        public static string BrandNameInvalid = "Hata! Marka ismi em az iki karakter olmalıdır.";

        public static string UserAdded = "Kullanıcı ekleme işlemi başarıyla gerçekleşti.";
        public static string UserDeleted = "Kullanıcı silme işlemi başarıyla gerçekleşti.";
        public static string UserUpdated = "Kullanıcı güncelleme işlemi başarıyla gerçekleşti.";

        public static string CustomerAdded = "Müşteri ekleme işlemi başarıyla gerçekleşti.";
        public static string CustomerDeleted = "Müşteri silme işlemi başarıyla gerçekleşti.";
        public static string CustomerUpdated = "Müşteri güncelleme işlemi başarıyla gerçekleşti.";

        public static string RentalAdded = "Araba kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalDelivered = "Araba teslim etme işlemi başarıyla gerçekleşti.";
        public static string RentalUpdated = "Kiralama işlemi başarıyla güncellendi.";
        public static string RentalReturnDateIsNull = "Araba henüz teslim edilmemiştir, kiralanamaz.";
        public static string RentalReturnDateIsNotNull = "Araba zaten teslim edilmiştir, tekrar teslim işlemi yapılamaz.";

        public static string InvalidRequest = "Lütfen bilgileri kontrol edip, tekrar deneyin";
        public static string MaintenanceTime = "Sistem şu anda bakımdadır.";
    }
}
