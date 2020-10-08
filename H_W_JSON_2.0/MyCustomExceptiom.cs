using System;

namespace H_W_JSON_2._0
{
    public class MyCustomException : Exception
    {
        public override string Message
        {
            get { return $"No properties without {nameof(MyIgnoreAttribute)}!"; }
        }
    }
}
