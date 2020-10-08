using System;
using System.Runtime.Serialization;

namespace H_W_JSON_2._0
{
    [DataContract]
    public class Car
    {
        [MyIgnore]
        private Random random = new Random();

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Color { get; set; }

        [MyIgnore]
        public int VinCode { get; set; }

        public Car(string name)
        {
            Name = name;
            Price = random.Next(1, 50) * 3000;
            Age = 5;
            Color = "Black";
        }

        public Car()
        {
        }

        public override string ToString()
        {
            return $"cars:{Name}, price: {Price}, age: {Age}, color: {Color}";
        }
    }
}
