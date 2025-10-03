using System; 
namespace healthclinic.Exceptions
{
    // Excepción personalizada para cuando una mascota no se encuentra
    public class  PwfiException : Exception 
    {
        public PwfiException() {} // constructor por defecto
        public PwfiException(string message) : base(message) {} // constructor que recibe un mensaje
        public PwfiException(string message, Exception inner) : base (message, inner) {} // constructor que recibe un mensaje y una excepción interna
    }
}