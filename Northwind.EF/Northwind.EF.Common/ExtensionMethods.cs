using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Linq.Common
{
    public class ExtensionMethods : Exception
    {
        public static string CustomException(Exception e)
        {
            var message = "An unexpected error has occurred!";
            return message;
        }

        public static string CustomFormatException(FormatException e)
        {
            var message = "Format error!.";
            return message;
        }
        public static string CustomOverflowException(OverflowException e)
        {
            var message = "You have exceeded the maximum size allowed!.";
            return message;
        }

        public static string CustomNullReferenceException(NullReferenceException e)
        {
            var message = "You cannot leave the requested fields blank or null!."; 
            return message;
        }

        public static string CustomInvalidOperationException(InvalidOperationException e)
        {
            var message = "Invalid Operation.";
            return message;
        }

        public static string CustomDbUpdateException(System.Data.Entity.Infrastructure.DbUpdateException e)
        {
            var message = "Cannot delete because this table is related to another table. Try deleting a new record...";            
            return message;
        }

        public static string DbEntityValidation(System.Data.Entity.Validation.DbEntityValidationException e)
        {
            var message = "You cannot leave the requested fields blank or null!.";            
            return message;
        }
    }
}
