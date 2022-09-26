using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Common
{
    public class CustomExceptions : Exception
    {
        public static List<String> CustomException(Exception e)
        {
            var customMessage = $"Exception type: {e.GetType()}";            
            List<String> result = new List<String>() { customMessage, e.Message };
            return result;
        }

        public static List<String> CustomFormatException(FormatException e)
        {
            var customMessage = $"Exception type: {e.GetType()}";
            List<String> result = new List<String>() { customMessage, e.Message };
            return result;
        }
        public static List<String> CustomOverflowException(OverflowException e)
        {
            var customMessage = $"Exception type: {e.GetType()}";
            List<String> result = new List<String>() { customMessage, e.Message };
            return result;
        }

        public static List<String> CustomNullReferenceException(NullReferenceException e)
        {
            var customMessage = $"Exception type: {e.GetType()}";
            List<String> result = new List<String>() { customMessage, e.Message };
            return result;
        }

        public static List<String> CustomInvalidOperationException(InvalidOperationException e)
        {
            var customMessage = $"Exception type: {e.GetType()}";
            List<String> result = new List<String>() { customMessage, e.Message };
            return result;
        }

        public static List<String> CustomDbUpdateException(System.Data.Entity.Infrastructure.DbUpdateException e)
        {
            var customMessage = $"Exception type: {e.GetType()}";
            var message = "The db cannot be modified because it is existing data in the script. Try loading a new record...";
            List<String> result = new List<String>() { customMessage, e.Message, message };
            return result;
        }
    }
}
