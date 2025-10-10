using System;
using System.Collections.Generic;
using healthclinic.models;

namespace healthclinic.services
{
    public class AppointmentService
    {
        private readonly List<Appointment> _appointments = new();

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public List<Appointment> GetAll() => _appointments;
    }
}