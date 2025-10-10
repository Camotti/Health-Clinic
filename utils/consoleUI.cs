
using System;
using System.ComponentModel.DataAnnotations;
using healthclinic.Interfaces;
using healthclinic.Services;

public class ConsoleUI
{
    private readonly IPatientService _patientService;
    private readonly IveterinarianRepository _veterinarianService;
    private readonly Validator _validator; 




    // constructor 

    public ConsoleUI(
        IPatientService patientService,
        IveterinarianRepository iveterinarianRepository,
        _validator validator )

    {
        _patientService = patientService;
        _veterinarianService = veterinarianService,
        _validator = validator;
    }
}