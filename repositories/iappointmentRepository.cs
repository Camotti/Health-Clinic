using System.Data.Common;
using healthclinic.Data;
using healthclinic.Interfaces;
using healthclinic.models;


namespace healthclinic.repositories
{
    public class AppointmentRepository: IAppointmentRepository
    {
        public void Add(Appointment entity)
        {
            Database.Appointments.Add(entity);
        }


        public void Delete(Guid id)
        {
            var appointment = Database.Appointments.FirstOrDefault(Ap => Ap.Id == id);
            if (appointment != null)
            {
                Database.Appointments.Remove(appointment);
            }
        }

        public List<Appointment> GetAll()
        {
            return Database.Appointments;
        }


        public Appointment? GetById(Guid id)
        {
            return Database.Appointments.FirstOrDefault(a => a.Id == id);
        }


        public void Update(Appointment entity)
        {
            var update = Database.Appointments.FirstOrDefault(up => up.Id == entity.Id);
            if (update != null)
            {
                update.PatientID = entity.PatientID;
                update.VeterinarianID = entity.VeterinarianID;
                update.Date = entity.Date;
                update.Reason = entity.Reason;
            }
        }


        public void Save()
        {
            
        }
    }
}