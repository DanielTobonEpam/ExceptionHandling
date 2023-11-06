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
            if (Convert.ToInt32(stringValue) > int.MaxValue || Convert.ToInt32(stringValue) < int.MinValue)
            {
                throw new OverflowException($"Over flow exception in Parse method: '{stringValue}' is out of range");
            }

            int integerValue = 0;
            bool isNegative = false;
            try
            {
                // Check negative sign.
                if (stringValue[0] == '-')
                {
                    isNegative = true;
                    stringValue = stringValue.Substring(1);
                }
                //convert a string to an integer without using any native parsing of C#
                foreach (char character in stringValue)
                {
                    if (character >= '0' && character <= '9')
                    {
                        int digitValue = character - '0';

                        integerValue *= 10;
                        integerValue += digitValue;
                    }
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
            // Return the integer value, with the negative sign if applicable.
            return isNegative ? -integerValue : integerValue;
        }
    }
}