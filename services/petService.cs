using healthclinic.models;
using healthclinic.repositories;
using healthclinic.utils;
using System;
using System.Collections.Generic;

namespace healthclinic.services
{
    public class Petservice
    {
        private readonly PatientRepository _patientRepository = new();

        public void Add()
        {
            var name = ConsoleHelper.ReadNonEmptyString("Nombre");
            var age = ConsoleHelper.Readbyte("Edad");
            var email = ConsoleHelper.ReadNonEmptyString("Email");
            var phone = ConsoleHelper.ReadNonEmptyString("Teléfono");
            var gender = ConsoleHelper.ReadNonEmptyString("Género");

            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                Email = email,
                Phone = phone,
                Gender = gender
            };

            _patientRepository.Add(patient);
            Console.WriteLine("✅ Paciente registrado correctamente.");
        }

        public void List()
        {
            var patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                Console.WriteLine("⚠️ No hay pacientes registrados.");
                return;
            }

            Console.WriteLine("\n📋 Lista de pacientes:");
            foreach (var p in patients)
            {
                Console.WriteLine($"🧍 {p.Id} | {p.Name} | {p.Email} | {p.Gender}");
            }
        }

        public Patient? GetById(Guid id)
        {
            return _patientRepository.GetById(id);
        }

        public void ShowById()
        {
            var patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                Console.WriteLine("⚠️ No hay pacientes registrados.");
                return;
            }

            List();
            var id = ConsoleHelper.ReadGuid("Ingrese el ID del paciente");
            var patient = GetById(id);

            if (patient != null)
                Console.WriteLine($"✅ Encontrado: {patient.Name} ({patient.Email})");
            else
                Console.WriteLine("❌ Paciente no encontrado.");
        }

        public void Update()
        {
            var patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                Console.WriteLine("⚠️ No hay pacientes registrados.");
                return;
            }

            List();
            var id = ConsoleHelper.ReadGuid("Ingrese el ID del paciente a actualizar");
            var patient = GetById(id);

            if (patient == null)
            {
                Console.WriteLine("❌ No se encontró el paciente.");
                return;
            }

            Console.WriteLine("Deja vacío para mantener el valor actual.");

            var name = ConsoleHelper.ReadNonEmptyString($"Nuevo nombre (actual: {patient.Name}): ");
            var email = ConsoleHelper.ReadNonEmptyString($"Nuevo email (actual: {patient.Email}): ");
            var phone = ConsoleHelper.ReadNonEmptyString($"Nuevo teléfono (actual: {patient.Phone}): ");

            if (!string.IsNullOrWhiteSpace(name))
                patient.Name = name;

            if (!string.IsNullOrWhiteSpace(email))
                patient.Email = email;

            if (!string.IsNullOrWhiteSpace(phone))
                patient.Phone = phone;

            _patientRepository.Update(patient);
            Console.WriteLine("✅ Paciente actualizado correctamente.");
        }

        public void Delete()
        {
            var patients = _patientRepository.GetAll();
            if (patients.Count == 0)
            {
                Console.WriteLine("⚠️ No hay pacientes registrados.");
                return;
            }

            List();
            var id = ConsoleHelper.ReadGuid("Ingrese el ID del paciente a eliminar");
            var patient = GetById(id);

            if (patient == null)
            {
                Console.WriteLine("❌ No se encontró el paciente.");
                return;
            }

            _patientRepository.Delete(id);
            Console.WriteLine("🗑️ Paciente eliminado correctamente.");
        }
    }
}
