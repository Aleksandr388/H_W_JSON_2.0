using System;
using System.Reflection;
using System.Linq;
using System.Text;

namespace H_W_JSON_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

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

        public static string JsonSerialiser(Car carObj)
        {
            StringBuilder result = new StringBuilder();
            var properties = carObj.GetType()
                .GetProperties(BindingFlags
                .Instance | BindingFlags
                .NonPublic | BindingFlags
                .Public)
                .Where(x => x.GetCustomAttribute<MyIgnoreAttribute>() == null);

            if (!properties.Any())
            {
                throw new MyCustomException();
            }

            result.Append("{");

            foreach (var f in properties)
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
