using healthclinic.models;
using System;

namespace healthclinic.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository <Appointment>
    {  
        //agregar mas metodos
      IEnumerable<Appointment> GetAppointmentsByPatientId(Guid patientId);
      IEnumerable<Appointment> GetAppointmentsByVeterinarianId(Guid veterinarianId);
    }
}