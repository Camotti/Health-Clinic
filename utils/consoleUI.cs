
using System;
using System.ComponentModel.DataAnnotations;
using healthclinic.Interfaces;

public class ConsoleUI
{
    private readonly IPatientService _patientService;
    private readonly IveterinarianRepository _veterinarianService;
    private readonly Validator _validator; 
}