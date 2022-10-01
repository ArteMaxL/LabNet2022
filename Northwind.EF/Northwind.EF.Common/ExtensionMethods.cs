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
            var message = "Ha ocurrido un error inesperado!";
            return message;
        }

        public static string CustomFormatException(FormatException e)
        {
            var message = "Error de Formato!.";
            return message;
        }
        public static string CustomOverflowException(OverflowException e)
        {
            var message = "Se ha excedido el valor máximo soportado.";
            return message;
        }

        public static string CustomNullReferenceException(NullReferenceException e)
        {
            var message = "El objeto no existe."; 
            return message;
        }

        public static string CustomInvalidOperationException(InvalidOperationException e)
        {
            var message = "Operacion no valida.";
            return message;
        }

        public static string CustomDbUpdateException(System.Data.Entity.Infrastructure.DbUpdateException e)
        {
            var message = "No se puede eliminar un objeto que esté relacionado con otra tabla.";            
            return message;
        }

        public static string DbEntityValidation(System.Data.Entity.Validation.DbEntityValidationException e)
        {
            var message = "You cannot leave the requested fields blank or null!.";            
            return message;
        }
    }
}
