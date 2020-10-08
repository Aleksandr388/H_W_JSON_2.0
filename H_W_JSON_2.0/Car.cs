using System;
using System.Runtime.Serialization;

namespace H_W_JSON_2._0
{
    
    public class Car
    {
       
        public string Name { get; set; }
        
        public int Price { get; set; }
        [MyIgnore]
        public int Age { get; set; }
        
        public string Color { get; set; }
        [MyIgnore]
        public int VinCode { get; set; }
    }
}
