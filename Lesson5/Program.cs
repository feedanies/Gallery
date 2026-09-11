
using Lesson5.DataAccess;
using Lesson5.Domain.Entities;
using System.Text.RegularExpressions;

namespace Lesson5
{
    internal class Program
    {
        static void AddCar(CarRepository carRepo)
        {
            Console.Write("Model: ");
            var model = Console.ReadLine();
            Console.Write("Year: ");
            var year = int.Parse(Console.ReadLine());
            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Color: ");
            var color = Console.ReadLine();
            Console.Write("IsNew (true/false): ");
            bool isNew = bool.Parse(Console.ReadLine());

            var car = new Car
            {
                Model = model,
                Year = year,
                Price = price,
                Color = color,
                IsNew = isNew
            };
            carRepo.Add(car);
            carRepo.SaveChanges();
            Console.WriteLine("Avtomobil elave olundu.");
        }

        static void UpdateCar(CarRepository carRepo)
        {
            Console.Write("Yenilenecek avtomobilin ID-si: ");
            var id = int.Parse(Console.ReadLine());
            var car = carRepo.Get(id);
            if (car == null)
            {
                Console.WriteLine("Avtomobil tapilmadi.");
                return;
            }

            Console.Write($"Model deyisilsin? (Cari: {car.Model}) [0-Xeyr / 1-Bəli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Model: ");
                car.Model = Console.ReadLine();
            }

            Console.Write($"Year deyisilsin? (Cari: {car.Year}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Year: ");
                car.Year = int.Parse(Console.ReadLine());
            }

            Console.Write($"Price deyisilsin? (Cari: {car.Price}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Price: ");
                car.Price = decimal.Parse(Console.ReadLine());
            }

            Console.Write($"Color deyisilsin? (Cari: {car.Color}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Color: ");
                car.Color = Console.ReadLine();
            }

            Console.Write($"IsNew deyisilsin? (Cari: {car.IsNew}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni IsNew (true/false): ");
                car.IsNew = bool.Parse(Console.ReadLine());
            }

            carRepo.Update(car);
            carRepo.SaveChanges();
            Console.WriteLine("Avtomobil yenilendi.");
        }

        static void DeleteCar(CarRepository carRepo)
        {
            Console.Write("Silinecek avtomobilin Id-si: ");
            int id = int.Parse(Console.ReadLine());

            var car = carRepo.Get(id);
            if (car == null)
            {
                Console.WriteLine("Bele Id-de avtomobil tapilmadi.");
                return;
            }

            carRepo.Delete(car);
            carRepo.SaveChanges();
            Console.WriteLine("Avtomobil silindi.");
        }

        static void ReadAllCars(CarRepository carRepo)
        {
            var cars = from c in carRepo.GetAll()
                       select c;

            foreach (var c in cars)
            {
                Console.WriteLine("Id: "+c.Id);
                Console.WriteLine("Model: "+c.Model);
                Console.WriteLine("Year: "+c.Year);
                Console.WriteLine("Price: "+c.Price);
                Console.WriteLine("Color: "+c.Color);
                Console.WriteLine("IsNew: "+c.IsNew);
                Console.WriteLine("------------------------------------");
            }
        }

        static void FilterByPrice(CarRepository carRepo)
        {
            Console.Write("Min qiymət: ");
            decimal min = decimal.Parse(Console.ReadLine());
            Console.Write("Max qiymət: ");
            decimal max = decimal.Parse(Console.ReadLine());

            var cars = from c in carRepo.GetAll()
                       where c.Price >= min && c.Price <= max
                       select c;
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Model} - {c.Price} AZN");
            }
        }

        static void SearchByModel(CarRepository carRepo)
        {
            Console.Write("Axtarilacaq model: ");
            var model = Console.ReadLine();
            var cars = from c in carRepo.GetAll()
                       where c.Model.Contains(model)
                       select c;

            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Model} - {c.Year} - {c.Price} AZN");
            }
        }

        static void ShowNewCars(CarRepository carRepo)
        {
            var cars=from c in carRepo.GetAll()
                     where c.IsNew
                     select c;
            foreach (var c in cars)
            {
                Console.WriteLine($"{c.Model} - {c.Year} - {c.Price} AZN");
            }
        }

        static void GroupByModel(CarRepository carRepo)
        {
            var groups = from c in carRepo.GetAll()
                         group c by c.Model into g
                         select g;

            foreach (var g in groups)
            {
                Console.WriteLine($"Model: {g.Key}");
                foreach (var c in g)
                    Console.WriteLine($"  -> {c.Year} - {c.Price} AZN");
            }
        }

        /////////////////////////////////////////////////////////////////

        static void AddCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Fullname: ");
            var fullname = Console.ReadLine();
            Console.Write("Phone: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            var customer = new Customer
            {
                Fullname = fullname,
                Phone = phone,
                Email = email
            };
            customerRepo.Add(customer);
            customerRepo.SaveChanges();
            Console.WriteLine("Musteri elave olundu.");
        }

        static void UpdateCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Yenilenecek musterinin ID-si: ");
            var id = int.Parse(Console.ReadLine());
            var customer = customerRepo.Get(id);
            if (customer == null)
            {
                Console.WriteLine("Musteri tapilmadi.");
                return;
            }

            Console.Write($"Fullname deyisilsin? (Cari: {customer.Fullname}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Fullname: ");
                customer.Fullname = Console.ReadLine();
            }

            Console.Write($"Phone deyisilsin? (Cari: {customer.Phone}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Phone: ");
                customer.Phone = Console.ReadLine();
            }

            Console.Write($"Email deyisilsin? (Cari: {customer.Email}) [0-Xeyr / 1-Beli]: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Yeni Email: ");
                customer.Email = Console.ReadLine();
            }

            customerRepo.Update(customer);
            customerRepo.SaveChanges();
            Console.WriteLine("Musteri yenilendi.");
        }

        static void DeleteCustomer(CustomerRepository customerRepo)
        {
            Console.Write("Silinecek musterinin ID-si: ");
            var id = int.Parse(Console.ReadLine());
            var customer = customerRepo.Get(id);
            if (customer == null)
            {
                Console.WriteLine("Musteri tapilmadi.");
                return;
            }

            customerRepo.Delete(customer);
            customerRepo.SaveChanges();
            Console.WriteLine("Musteri silindi.");
        }

        static void ReadAllCustomers(CustomerRepository customerRepo)
        {
            foreach (var c in customerRepo.GetAll())
            {
                Console.WriteLine($"Id: {c.Id}, Fullname: {c.Fullname}, Phone: {c.Phone}, Email: {c.Email}");
                Console.WriteLine("------------------------------------");
            }
        }


        //////////////////////////////////////////////////////////////////

        static void AddSale(SaleRepository saleRepo, CarRepository carRepo, CustomerRepository customerRepo)
        {
            Console.Write("Avtomobilin ID-si: ");
            var carId = int.Parse(Console.ReadLine());
            var car = carRepo.Get(carId);
            if (car == null)
            {
                Console.WriteLine("Bele Id-de avtomobil tapilmadi.");
                return;
            }

            Console.Write("Musterinin ID-si: ");
            var customerId = int.Parse(Console.ReadLine());
            var customer = customerRepo.Get(customerId);
            if (customer == null)
            {
                Console.WriteLine("Musteri tapilmadi.");
                return;
            }

            Console.Write("Satis qiymeti: ");
            var salePrice = decimal.Parse(Console.ReadLine());

            var sale = new Sale
            {
                CarId = carId,
                CustomerId = customerId,
                SaleDate = DateTime.Now,
                SalePrice = salePrice
            };
            saleRepo.Add(sale);
            saleRepo.SaveChanges();
            Console.WriteLine("Satis qeyde alindi.");
        }

        static void DeleteSale(SaleRepository saleRepo)
        {
            Console.Write("Silinecek satisin ID-si: ");
            var id = int.Parse(Console.ReadLine());
            var sale = saleRepo.Get(id);
            if (sale == null)
            {
                Console.WriteLine("Satis tapilmadi.");
                return;
            }

            saleRepo.Delete(sale);
            saleRepo.SaveChanges();
            Console.WriteLine("Satis silindi.");
        }

        static void ReadAllSales(SaleRepository saleRepo)
        {
            foreach (var s in saleRepo.GetAll())
            {
                Console.WriteLine($"Id: {s.Id}, CarId: {s.CarId}, CustomerId: {s.CustomerId}, Tarix: {s.SaleDate}, Qiymet: {s.SalePrice} AZN");
                Console.WriteLine("------------------------------------");
            }
        }



        static void Main(string[] args)
        {
            var context = new GalleryContext();
            var carRepo = new CarRepository(context);
            var customerRepo = new CustomerRepository(context);
            var saleRepo = new SaleRepository(context);

            while (true)
            {
                Console.WriteLine("==== Car Gallery Menu ====");
                Console.WriteLine("1. Yeni avtomobil elave et");
                Console.WriteLine("2. Avtomobili yenile");
                Console.WriteLine("3. Avtomobili sil");
                Console.WriteLine("4. Butun avtomobillere bax");
                Console.WriteLine("5. Qiymete gore filter");
                Console.WriteLine("6. Marka/modele göre axtaris");
                Console.WriteLine("7. Yalniz yeni avtomobiller");
                Console.WriteLine("8. Marka uzre qruplasdirma");
                Console.WriteLine("9. Yeni musteri elave et");
                Console.WriteLine("10. Musterini yenile");
                Console.WriteLine("11. Musterini sil");
                Console.WriteLine("12. Butun musterilere bax");
                Console.WriteLine("13. Yeni satis qeyde al");
                Console.WriteLine("14. Satisi sil");
                Console.WriteLine("15. Butun satislara bax");
                Console.WriteLine("0. Cixis");
                Console.Write("Secim: ");

                var input = Console.ReadLine();
                

                try
                {
                    switch (input)
                    {
                        case "1":
                            AddCar(carRepo);
                            break;
                        case "2":
                            UpdateCar(carRepo);
                            break;
                        case "3":
                            DeleteCar(carRepo);
                            break;
                        case "4":
                            ReadAllCars(carRepo);
                            break;
                        case "5":
                            FilterByPrice(carRepo);
                            break;
                        case "6":
                            SearchByModel(carRepo);
                            break;
                        case "7":
                            ShowNewCars(carRepo);
                            break;
                        case "8":
                            GroupByModel(carRepo);
                            break;
                        case "9":
                            AddCustomer(customerRepo);
                            break;
                        case "10":
                            UpdateCustomer(customerRepo);
                            break;
                        case "11":
                            DeleteCustomer(customerRepo);
                            break;
                        case "12":
                            ReadAllCustomers(customerRepo);
                            break;
                        case "13":
                            AddSale(saleRepo, carRepo, customerRepo);
                            break;
                        case "14":
                            DeleteSale(saleRepo);
                            break;
                        case "15":
                            ReadAllSales(saleRepo);
                            break;
                        case "0":
                            return;
                        default:
                            Console.Write("Yanlis secim: Zehmet olmasa yeniden secim edin: ");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Xeta bas verdi: " + ex.Message);
                }
                
            }


        }
    }



}
