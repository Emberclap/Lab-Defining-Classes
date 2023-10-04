using CarManufacturer;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

using System.Globalization;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
          
            string input = string.Empty;
            List<Tire[]> tierList = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[4]
                {
                    new Tire (int.Parse(tokens[0]), double.Parse(tokens[1], CultureInfo.InvariantCulture)),
                    new Tire (int.Parse(tokens[2]), double.Parse(tokens[3], CultureInfo.InvariantCulture)),
                    new Tire (int.Parse(tokens[4]), double.Parse(tokens[5], CultureInfo.InvariantCulture)),
                    new Tire (int.Parse(tokens[6]), double.Parse(tokens[7], CultureInfo.InvariantCulture)),
                };

                tierList.Add(tires);
            }
            
            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1], CultureInfo.InvariantCulture);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }
            
            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3], CultureInfo.InvariantCulture);
                double fuelConsumption = double.Parse(tokens[4], CultureInfo.InvariantCulture);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
                
                    var engine = engines[engineIndex];
                    var tires = tierList[tiresIndex];
                    cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires));
                

            }
            
            foreach (Car car in cars)
            {
                double pressureSum = 0;
                pressureSum = car.Tires.Sum(x => x.Pressure);
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && pressureSum >= 9 && pressureSum <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
            

        }
    }
}