using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static int indexMainMenu = 0;

        static void Main(string[] args)
        {
            Menu();
        }









        //ColorOperations
        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.Write("Eklemek istediğiniz rengi baş harfi büyük olacak şekilde yazınız: ");
            var colorname = Console.ReadLine();
            colorManager.Add(new Color() { ColorName = colorname});
        }
        private static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorList();
            Console.WriteLine("Silmek istediğiniz rengin Id'si: ");
            int id = int.Parse(Console.ReadLine());
            colorManager.Delete(new Color { ColorId = id });
        }
        private static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorList();
            Console.WriteLine("Güncellemek istediğiniz rengin Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var colorEntity = colorManager.GetByColorId(id).Data;
            Console.WriteLine(colorEntity.ColorId + " " + colorEntity.ColorName);
            Console.WriteLine("");
            Console.Write("Yeni Renk Giriniz: ");
            colorEntity.ColorName = Console.ReadLine();
            colorManager.Update(colorEntity);
        }
        private static void SelectByColorId(int colorId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailsByColorId(colorId).Data)
            {
                Console.WriteLine(car.Id + " "+ car.BrandName + " " + car.ModelYear+ " "+ car.ColorName + " " + car.DailyPrice + "TL Günlük "+ car.Decription);
            }
        }
        private static void ColorList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        //BrandOperations
        private static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " -- " + brand.BrandName);
            }
        }
        private static void SelectByBrandId(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailsByBrandId(brandId).Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandName + " " + car.ModelYear+ " " + car.ColorName + " " + car.DailyPrice + "TL Günlük " + car.Decription);
            }
        }
        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.Write("Eklemek istediğiniz markayı baş harfi büyük olacak şekilde yazınız: ");
            var brandname = Console.ReadLine();
            brandManager.Add(new Brand() { BrandName = brandname });
        }
        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandList();
            Console.WriteLine("Silmek istediğiniz markanın Id'si: ");
            int id = int.Parse(Console.ReadLine());
            brandManager.Delete(new Brand { BrandId = id });
        }
        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandList();
            Console.WriteLine("Güncellemek istediğiniz markanın Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var brandEntity = brandManager.GetByBrandId(id).Data;
            Console.WriteLine(brandEntity.BrandId + " " + brandEntity.BrandName);
            Console.WriteLine("");
            Console.Write("Yeni Marka Giriniz: ");
            brandEntity.BrandName = Console.ReadLine();
            brandManager.Update(brandEntity);
        }

        //CarOperations
        private static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + "TL Günlük " + " " + car.Description);
            }
        }
        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarList();
            Console.WriteLine("Silmek istediğiniz Car Id: ");
            int id = int.Parse(Console.ReadLine());
            carManager.Delete(new Car { Id = id });
        }
        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandList();
            var car = new Car();
            Console.WriteLine("Brand Id Giriniz: ");
            car.BrandId = int.Parse(Console.ReadLine());
            //Console.Clear();
            ColorList();
            Console.WriteLine("Color Id Giriniz: ");
            car.ColorId = int.Parse(Console.ReadLine());
            //Console.Clear();
            Console.WriteLine("Model Yılını Giriniz: ");
            car.ModelYear = int.Parse(Console.ReadLine());
            //Console.Clear();
            Console.WriteLine("Günlük Ücret Giriniz: ");
            car.DailyPrice = decimal.Parse(Console.ReadLine());
            //Console.Clear();
            Console.WriteLine("Açıklama ekleyiniz: ");
            car.Description = Console.ReadLine();

            carManager.Add(car);

        }
        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarList();
            Console.WriteLine("Güncellemek istediğiniz arabanın Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var carEntity = carManager.Get(id).Data;
            Console.WriteLine( carEntity.Id + " " + carEntity.BrandId + " " + carEntity.ColorId + " " + carEntity.ModelYear + " "+ carEntity.DailyPrice+ "TL Günlük " + carEntity.Description);
            Console.WriteLine("");
            BrandList();
            Console.Write("Brand Id Giriniz: ");
            carEntity.BrandId = int.Parse(Console.ReadLine());
            ColorList();
            Console.Write("\nColor Id Giriniz: ");
            carEntity.ColorId = int.Parse(Console.ReadLine());
            Console.Write("\nModel Yılını Giriniz: ");
            carEntity.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("\nGünlük Ücret Giriniz: ");
            carEntity.DailyPrice = decimal.Parse(Console.ReadLine());
            Console.Write("\nAçıklama ekleyiniz: ");
            carEntity.Description = Console.ReadLine();
            carManager.Update(carEntity);
        }
        private static void CarById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Id: ");
            Console.WriteLine(carManager.Get(int.Parse(Console.ReadLine())).Data.Description);
        }
        private static void CarByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.Write("\nBrand Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine(carManager.Get(id).Data.Id + " " + carManager.Get(id).Data.ModelYear + " " + carManager.Get(id).Data.Description + " " + carManager.Get(id).Data.DailyPrice + "TL Günlük");
        }
        private static void CarByDailyPrice(decimal min, decimal max)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.DailyPrice>min && car.DailyPrice<max ?
                                  car.Id + " " + car.ModelYear + " " + car.DailyPrice + "TL Günlük " + " " + car.Description
                                  : "");
            }
        }
        private static void GetAllCarsIsNotNull()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAllCarsIsNotNull().Data;
            foreach (var car in result)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + "TL Günlük " + " " + car.Description);
            }
        }

        //UserOperations
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.Write("Kullanıcı adı giriniz: ");
            var firstname = Console.ReadLine();
            Console.Write("Kullanıcı soyadı giriniz: ");
            var lastname = Console.ReadLine();
            Console.Write("Kullanıcı email adresi giriniz: ");
            var email = Console.ReadLine();
            Console.Write("Kullanıcı şifresi giriniz: ");
            var password = Console.ReadLine();
            //userManager.Add(new User() { FirstName=firstname, LastName=lastname, Email=email, Password=password});
        }
        private static void UserDelete()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            UserList();
            Console.Write("Silmek istediğiniz kullanıcının Id'si: ");
            int id = int.Parse(Console.ReadLine());
            userManager.Delete(new User { Id = id });
        }
        private static void UserUpdate()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            UserList();
            Console.WriteLine("Güncellemek istediğiniz kullanıcının Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var userEntity = userManager.GetByUserId(id).Data;
            Console.WriteLine(userEntity.FirstName +" "+userEntity.LastName+" "+userEntity.Email);
            Console.WriteLine("");
            Console.Write("İsmi güncelleyiniz: ");
            userEntity.FirstName = Console.ReadLine();
            Console.Write("Soyismi güncelleyiniz: ");
            userEntity.LastName = Console.ReadLine();
            Console.Write("Email güncelleyiniz: ");
            userEntity.Email = Console.ReadLine();
            userManager.Update(userEntity);
        }
        private static void SelectByUserId(int userId)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = userManager.GetByUserId(userId).Data;
            Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName + " " + user.Email);
        }
        private static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + " " + user.FirstName + " " + user.LastName);
            }
        }

        //CustomerOperations
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserList();
            Console.Write("Müşteri olarak eklemek istediğiniz kullanıcının Id'sini giriniz: ");
            var userid = int.Parse(Console.ReadLine());
            Console.Write("Şirket adı giriniz: ");
            var companyname = Console.ReadLine();
            customerManager.Add(new Customer() { UserId=userid, CompanyName=companyname });
        }
        private static void CustomerDelete()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            CustomerList();
            Console.Write("Silmek istediğiniz müşterinin Id'si: ");
            int id = int.Parse(Console.ReadLine());
            customerManager.Delete(new Customer { Id = id });
        }
        private static void CustomerUpdate()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            CustomerList();
            Console.WriteLine("Güncellemek istediğiniz müşterinin Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var customerEntity = customerManager.GetByCustomerId(id).Data;
            Console.WriteLine(customerEntity.UserId + " " + customerEntity.CompanyName);
            Console.WriteLine("");
            UserList();
            Console.Write("Kullanıcı Id'si güncelleyiniz: ");
            customerEntity.UserId = int.Parse(Console.ReadLine());
            Console.Write("Şirket adını güncelleyiniz: ");
            customerEntity.CompanyName = Console.ReadLine();
            customerManager.Update(customerEntity);
        }
        private static void SelectByCustomerId(int customerId)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customer = customerManager.GetByCustomerId(customerId).Data;
            Console.WriteLine(customer.Id+ " "+ "Kullanıcı Id "+customer.UserId + " " +customer.CompanyName);
        }
        private static void CustomerList()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.Id + " " + customer.CompanyName);
            }
        }

        //RentalOperations
        private static void RentAdd(int carId, int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Rent(carId, customerId);
        }
        private static void RentDeliver()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalReturnDateIsNullList();
            Console.Write("\nTeslim etme işlemini yapmak istediğiniz Rent Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Teslim tarihi: " + DateTime.Now);
            rentalManager.Deliver(id, DateTime.Now);
        }
        private static void RentUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalFullList();
            Console.WriteLine("Güncellemek istediğiniz verilerin Rent Id'si: ");
            int id = int.Parse(Console.ReadLine());
            var rentalEntity = rentalManager.Get(id).Data;
            Console.WriteLine(rentalEntity.CarId + " " + rentalEntity.CustomerId + " " + rentalEntity.RentDate + " "+ rentalEntity.ReturnDate);
            Console.WriteLine("");
            CarList();
            Console.Write("Araba Id'si güncelleyiniz: ");
            rentalEntity.CarId = int.Parse(Console.ReadLine());
            CustomerList();
            Console.Write("Müşteri Id'si güncelleyiniz: ");
            rentalEntity.CustomerId = int.Parse(Console.ReadLine());
            Console.Write("Kiralama tarihini güncelleyiniz: ");
            rentalEntity.RentDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Teslim etme tarihini güncelleyiniz. Teslim edilmesiyse boş bırakınız:  ");
            rentalEntity.ReturnDate = DateTime.Parse(Console.ReadLine());
            rentalManager.Update(rentalEntity);
        }
        private static void ListRentalByCustomerId(int customerId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentalEntity = rentalManager.GetRentalDetailsByCustomerId(customerId).Data;
            foreach (var rent in rentalEntity)
            {
                Console.WriteLine(rent.Id + " " + rent.ModelYear + " " + rent.BrandName + " " +rent.Decription + " " + "Kiralanan Firma: " + rent.CompanyName);
            }
        }
        private static void ListRentalByCarId(int carId)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentalEntity = rentalManager.GetRentalDetailsByCarId(carId).Data;
            foreach (var rent in rentalEntity)
            {
                Console.WriteLine(rent.Id + " " + rent.ModelYear + " " + rent.BrandName + " " + rent.Decription + " " + "Kiralanan Firma: " + rent.CompanyName);
            }
        }
        private static void RentalFullList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rent in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rent.Id + " " + rent.ModelYear + " " + rent.BrandName + rent.Decription + " " + "Kiralanan Firma: " + rent.CompanyName + " Kiralama Tarihi: "+ rent.RentDate + " Teslim Edilme Tarihi: " +rent.ReturnDate);
            }
        }
        private static void RentalReturnDateIsNullList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rent in rentalManager.GetRentalDetailsReturnDateIsNull().Data)
            {
                Console.WriteLine(rent.Id + " " + rent.ModelYear + " " + rent.BrandName + rent.Decription + " " + " Kiralanan Firma: " + rent.CompanyName + " Kiralama Tarihi: " + rent.RentDate + " Teslim Edilme Tarihi: " + rent.ReturnDate);
            }
        }

        //Menu Show
        private static void Menu()
        {
            List<string> menuItems = new List<string>()
            {
                "Araç İşlemleri",
                "Renk İşlemleri",
                "Marka İşlemleri",
                "Kullanıcı İşlemleri",
                "Müşteri İşlemleri",
                "Kiralama İşlemleri",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                Select(selectedMenuItem);
            }
        }

        //Menu Selecet
        private static void Select(string selectedMenuItem)
        {
            switch (selectedMenuItem)
            {
                case "Araç İşlemleri":
                    indexMainMenu = 0;
                    CarOperationsMenu();
                    break;
                case "Renk İşlemleri":
                    indexMainMenu = 0;
                    ColorOperationsMenu();
                    break;
                case "Marka İşlemleri":
                    indexMainMenu = 0;
                    BrandOperationsMenu();
                    break;
                case "Kullanıcı İşlemleri":
                    indexMainMenu = 0;
                    UserOperationsMenu();
                    break;
                case "Müşteri İşlemleri":
                    indexMainMenu = 0;
                    CustomerOperationsMenu();
                    break;
                case "Kiralama İşlemleri":
                    indexMainMenu = 0;
                    RentalOperationsMenu();
                    break;
                case "Çıkış":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        //Menu Select Color and Read Key
        public static string drawMainMenu(List<string> items)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (i == indexMainMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return items[indexMainMenu];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

        private static void CarOperationsMenu()
        {
            List<string> menuItems = new List<string>()
            {
                "Tüm Araçları Listele",
                "Markaya Göre Listele",
                "Fiyata Göre Listele",
                "Araba Ekle",
                "Araba Sil",
                "Araba Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Tüm Araçları Listele":
                        CarList();
                        Console.WriteLine("");
                        break;
                    case "Markaya Göre Listele":
                        BrandList();
                        CarByBrandId();
                        Console.WriteLine("");
                        break;
                    case "Fiyata Göre Listele":
                        Console.Write("\nMinimum Fiyat: ");
                        decimal min = decimal.Parse(Console.ReadLine());
                        Console.Write("\nMaksimum Fiyat: ");
                        decimal max = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        CarByDailyPrice(min, max);
                        Console.WriteLine("");
                        break;
                    case "Araba Ekle":
                        CarAdd();
                        break;
                    case "Araba Sil":
                        CarDelete();
                        break;
                    case "Araba Güncelle":
                        CarUpdate();
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ColorOperationsMenu()
        {

            List<string> menuItems = new List<string>()
            {
                "Renkleri Listele",
                "Renge Göre Seçim Yap",
                "Renk Ekle",
                "Renk Sil",
                "Renk Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Renkleri Listele":
                        ColorList();
                        Console.WriteLine("");
                        break;
                    case "Renge Göre Seçim Yap":
                        ColorList();
                        Console.Write("\nColor Id: ");
                        int id = int.Parse(Console.ReadLine());
                        SelectByColorId(id);
                        Console.WriteLine("");
                        break;
                    case "Renk Ekle":
                        ColorAdd();
                        Console.WriteLine("");
                        break;
                    case "Renk Sil":
                        ColorDelete();
                        Console.WriteLine("");
                        break;
                    case "Renk Güncelle":
                        ColorUpdate();
                        Console.WriteLine("");
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void BrandOperationsMenu()
        {

            List<string> menuItems = new List<string>()
            {
                "Markaları Listele",
                "Markaya Göre Seçim Yap",
                "Marka Ekle",
                "Marka Sil",
                "Marka Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Markaları Listele":
                        BrandList();
                        Console.WriteLine("");
                        break;
                    case "Markaya Göre Seçim Yap":
                        BrandList();
                        Console.Write("\nBrand Id: ");
                        int id = int.Parse(Console.ReadLine());
                        SelectByBrandId(id);
                        Console.WriteLine("");
                        break;
                    case "Marka Ekle":
                        BrandAdd();
                        Console.WriteLine("");
                        break;
                    case "Marka Sil":
                        BrandDelete();
                        Console.WriteLine("");
                        break;
                    case "Marka Güncelle":
                        BrandUpdate();
                        Console.WriteLine("");
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void UserOperationsMenu()
        {
            List<string> menuItems = new List<string>()
            {
                "Kullanıcıları Listele",
                "ID'ye Göre Kullanıcı Detaylarını Listele",
                "Kullanıcı Ekle",
                "Kullanıcı Sil",
                "Kullanıcı Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Kullanıcıları Listele":
                        UserList();
                        Console.WriteLine("");
                        break;
                    case "ID'ye Göre Kullanıcı Detaylarını Listele":
                        UserList();
                        Console.Write("Kullanıcı Id: ");
                        var userId = int.Parse(Console.ReadLine());
                        SelectByUserId(userId);
                        Console.WriteLine("");
                        break;
                    case "Kullanıcı Ekle":
                        UserAdd();
                        break;
                    case "Kullanıcı Sil":
                        UserDelete();
                        break;
                    case "Kullanıcı Güncelle":
                        UserUpdate();
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void CustomerOperationsMenu()
        {
            List<string> menuItems = new List<string>()
            {
                "Müşterileri Listele",
                "ID'ye Göre Müşteri Detaylarını Listele",
                "Müşteri Ekle",
                "Müşteri Sil",
                "Müşteri Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Müşterileri Listele":
                        CustomerList();
                        Console.WriteLine("");
                        break;
                    case "ID'ye Göre Müşteri Detaylarını Listele":
                        CustomerList();
                        Console.Write("Kullanıcı Id: ");
                        var customerId = int.Parse(Console.ReadLine());
                        SelectByCustomerId(customerId);
                        Console.WriteLine("");
                        break;
                    case "Müşteri Ekle":
                        CustomerAdd();
                        break;
                    case "Müşteri Sil":
                        CustomerDelete();
                        break;
                    case "Müşteri Güncelle":
                        CustomerUpdate();
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RentalOperationsMenu()
        {
            List<string> menuItems = new List<string>()
            {
                "Tüm Kiralanmış Araçları Listele",
                "Müşteriye Göre Listele",
                "Arabaya Göre Listele",
                "Kiralama İşlemi Ekle",
                "Kiralanan Aracı Teslim Al",
                "Kiralama Bilgilerini Güncelle",
                "Çıkış"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---  Araba Kiralama Simülasyonu  ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string selectedMenuItem = drawMainMenu(menuItems);

                switch (selectedMenuItem)
                {
                    case "Tüm Kiralanmış Araçları Listele":
                        RentalFullList();
                        Console.WriteLine("");
                        break;
                    case "Müşteriye Göre Listele":
                        CustomerList();
                        Console.Write("Müşteri Id'si: ");
                        int customerId = int.Parse(Console.ReadLine());
                        ListRentalByCustomerId(customerId);
                        Console.WriteLine("");
                        break;
                    case "Arabaya Göre Listele":
                        CarList();
                        Console.Write("Araba Id'si: ");
                        int carId = int.Parse(Console.ReadLine());
                        ListRentalByCarId(carId);
                        Console.WriteLine("");
                        break;
                    case "Kiralama İşlemi Ekle":
                        GetAllCarsIsNotNull();
                        Console.Write("\nKiralanacak arabanın Id'sini giriniz: ");
                        int _carId = int.Parse(Console.ReadLine());
                        CustomerList();
                        Console.Write("\nHangi müşteriye kiralanacak? Müşteri Id'si giriniz: ");
                        int _customerId = int.Parse(Console.ReadLine());
                        RentAdd(_carId, _customerId);
                        break;
                    case "Kiralanan Aracı Teslim Al":
                        RentDeliver();
                        break;
                    case "Kiralama Bilgilerini Güncelle":
                        RentUpdate();
                        break;
                    case "Çıkış":
                        indexMainMenu = 0;
                        Menu();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

