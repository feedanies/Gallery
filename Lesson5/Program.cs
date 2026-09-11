
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


        static void Main(string[] args)
        {
            var context = new GalleryContext();
            var carRepo = new CarRepository(context);

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
                Console.WriteLine("0. Cixis");
                Console.Write("Secim: ");

                var input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

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
                    case "0":
                        return;
                    default:
                        Console.Write("Yanlis secim: Zehmet olmasa yeniden secim edin: ");
                        break;
                }
            }


        }
    }



}
