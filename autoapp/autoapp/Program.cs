using autoapp.Model;

namespace autoapp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Auto> cars = Auto.LoadCars();
            Console.WriteLine($"5. feladat: {cars.Count} autó található a listában");


            Console.WriteLine($"6. feladat: {cars.Average(x => x.Eladottdb):N1}");


            Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók: ");
            foreach (var x in cars.Where(x => x.Gyartasiev >= 2019).ToList())
            {
                Console.WriteLine($"\t- {x.Marka} {x.Modell}: {x.Gyartasiev}");
            }

            Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján: ");

            cars.OrderByDescending(x => x.Eladottdb).GroupBy(x => x.Marka).ToList().ForEach(x =>
            {
                Console.WriteLine($"\t- {x.Key}: {x.Sum(x => x.Eladottdb)} darab");
            });

        }
    }
}
