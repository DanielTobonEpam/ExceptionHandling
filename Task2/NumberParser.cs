using System;
using System.IO;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {

            try
            {
                if (stringValue == null)
                {
                    throw new ArgumentNullException("Null exception in Parse method: stringValue cannot be null");
                }


                if (Convert.ToInt32(stringValue) > int.MaxValue || Convert.ToInt32(stringValue) < int.MinValue)
                {
                    throw new OverflowException($"Over flow exception in Parse method: '{stringValue}' is out of range");
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format for integer " + stringValue, ex);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Convert.ToInt32(stringValue);
        }
    }
}