usinf system; 
namespace healthclinic.Exceptions
{
    // Excepción personalizada para cuando una mascota no se encuentra
    public class  PwfiException : Exception 
    {
        public PwfiException() {}
        public PwfiException(string message) : base(message) {}
        public PwfiException(string message, Exception inner) : base (message, inner) {}
    }
}