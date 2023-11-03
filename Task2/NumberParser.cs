using System;
using System.IO;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("Null exception in Parse method: stringValue cannot be null");
            }
            if (int.Parse(stringValue) > 2147483647 || int.Parse(stringValue) < -2147483648) 
            {
                throw new OverflowException($"Over flow exception in Parse method: '{stringValue}' is out of range");
            }

            // Try to parse the string as an integer.
            if (!int.TryParse(stringValue, out int number))
            {
                throw new FormatException($"Could not parse the string '{stringValue}' as an integer.");
            }
            return number;

            ////Invalid Number Format
            //int n;
            //try
            //{
            //    n = int.Parse(stringValue);
            //}
            //catch (FormatException e)
            //{

            //    throw new FormatException("Invalid format exception in Parse method: stringValue cannot be null",e);
            //}

            //throw new NotImplementedException();
        }
    }
}