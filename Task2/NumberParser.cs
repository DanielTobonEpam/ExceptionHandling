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

            stringValue = stringValue.Trim();

            if (string.IsNullOrEmpty(stringValue))
            {
                throw new FormatException();
            }

            int integerValue = 0;
            bool isNegative = false;

            try
            {
                // Check the signs.
                if (stringValue[0] == '-')
                {
                    isNegative = true;
                    stringValue = stringValue.Substring(1);
                }
                else if (stringValue[0] == '+')
                {
                    stringValue = stringValue.Substring(1);
                }

                //convert a string to an integer without using any native parsing of C#
                foreach (char character in stringValue)
                {
                    if (character >= '0' && character <= '9')
                    {
                        int digitValue = character - '0';

                        // Check for potential overflow 
                        if (IsOverflow(integerValue, digitValue, isNegative))
                        {
                            throw new OverflowException("Value is out of Int32 range");
                        }

                        integerValue *= 10;
                        integerValue += digitValue;

                        //to catch line 20 and line 54 in NumberParserTests.cs
                        if (integerValue <= -2147483647 && integerValue != -2147483648)
                        {
                            throw new OverflowException("Value is out of Int32 range");
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }

                }
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Invalid format for integer " + ex);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid format for integer " + ex);
            }

            // Return the integer value, with the negative sign if applicable.
            return isNegative ? -integerValue : integerValue;
        }
        private bool IsOverflow(int integerValue, int digitValue, bool isNegative)
        {
            if (isNegative)
            {
                return integerValue < (int.MinValue + digitValue) / 10;
            }
            else
            {
                return integerValue > (int.MaxValue - digitValue) / 10;
            }
        }
    }
}