using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Common
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
            catch (OverflowException e)
            {
                ExtensionMethods.CustomOverflowException(e);
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

        public bool ValidCharId(string input,int min = 5, int limit = 15)
        {
            int count = input.Length;
            if (input.Trim() != string.Empty)
            {
                if (count == min && count <= limit) return true;
                else return false;
            }
            return false;
        }

        public string GenerateStringID(int length = 4)
        {
            Guid guid = Guid.NewGuid();
            string ID = guid.ToString().Substring(0, length);

            return "Z" + ID;
        }
    }
}
