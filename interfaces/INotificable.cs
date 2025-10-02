namespace healthclinic.Interfaces; // Define el namespace

public interface INotificable // Interfaz para notificaciones
{
    void SendNotification(string message); // Metodo para enviar una notificacion
}