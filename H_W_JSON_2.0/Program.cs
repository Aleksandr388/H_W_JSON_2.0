using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using System.Text;

namespace H_W_JSON_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            for (int i = 0; i < 50; i++)
            {
                cars.Add(new Car($"Name: {i}," + i + i + ""));
            }

            var jsonFormater = new DataContractJsonSerializer(typeof(List<Car>));

            using (var file = new FileStream("cars.json", FileMode.Create))
            {
                jsonFormater.WriteObject(file, cars);
            }

            using (var file = new FileStream("cars.json", FileMode.OpenOrCreate))
            {
                var newCars = jsonFormater.ReadObject(file) as List<Car>;

                if (newCars != null)
                {
                    foreach (var car in newCars)
                    {
                        Console.WriteLine(car);
                    }
                }
            }
            Console.ReadLine();

            Car carObj = new Car
            {
                Name = "Zaz",
                Price = 987654321,
                Age = 4,
                Color = "Yellow",
                VinCode = 51259512
            };

            Console.WriteLine(JsonSerialiser(carObj));

            Console.ReadLine();
        }

        public static string JsonSerialiser(object carObj)
        {
            StringBuilder result = new StringBuilder();

            var wealds = carObj
                .GetType()
                .GetFields(BindingFlags
                .Instance | BindingFlags
                .NonPublic | BindingFlags.Public).Where(x => x.GetCustomAttribute<MyIgnoreAttribute>() == null);

            if (!wealds.Any())
            {
                throw new MyCustomException();
            }

            result.Append("{");
            foreach (var f in wealds)
            {
                result.Append("\"" + f.Name + "\":");
                if (f.GetValue(carObj).GetType() == "".GetType())
                {
                    result.Append("\"" + f.GetValue(carObj) + "\",");
                }
                else
                {
                    result.Append(f.GetValue(carObj) + ",");
                }
            }
            result[result.Length - 1] = '}';

            return result.ToString();
        }
    }
}
