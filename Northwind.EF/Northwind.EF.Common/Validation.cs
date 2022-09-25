using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Common
{
    public class Validation
    {
        public bool IsValid(string input)
        {
            try
            {
                var validInput = int.Parse(input);
                return true;
            }
            catch (FormatException e)
            {
                CustomExceptions.CustomFormatException(e);                
                return false;
            }
            catch (Exception e)
            {
                CustomExceptions.CustomException(e);
                return false;
            }
        }

        public bool CategoryLong(string input, int limit = 15)
        {
            int count = input.Length;
            
            if (count <= limit) return true;
            else return false;
        }
    }
}
