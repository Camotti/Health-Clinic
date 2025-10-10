using System;
using System.Collections.Generic;
using healthclinic.models;

namespace healthclinic.services
{
    public class AppointmentService
    {
        private readonly List<Appointment> _appointments = new();
        //añadir cita 
        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }


        // obtener todas las citas 
        public List<Appointment> GetAll() => _appointments;


        //buscar cita por ID
        public Appointment? GetById(Guid Id)
        {
            return _appointments.FirstOrDefault(a => a.Id == Id);
        }


        //eliminar una cita por ID 
        public bool Delete( Guid id)
        {
            var appointment = GetById(id);
            if (appointment == null)
                return false;

            _appointments.Remove(appointment);
            return true;
        }
    }
}