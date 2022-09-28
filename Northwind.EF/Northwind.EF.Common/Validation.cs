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
                ExtensionMethods.CustomFormatException(e);                
                return false;
            }
            catch (Exception e)
            {
                ExtensionMethods.CustomException(e);
                return false;
            }
        }

        public bool IsValidString(string input)
        {
            if (input != null)
            {
                return true;
            }
            return false;
        }
        public bool NameLong(string input, int limit = 15)
        {
            int count = input.Length;
            
            if (count <= limit) return true;
            else return false;
        }

        public string GenerateStringID(int length = 4)
        {
            System.Guid guid = System.Guid.NewGuid();
            string ID = guid.ToString().Substring(0, length);

            return "Z" + ID;
        }
    }
}
