using System;
using System.Collections.Generic;
using System.Linq;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
        _patientRepo.Add(new Patient(1, "John Johnson", 500, "Female"));
        _patientRepo.Add(new Patient(2, "Alan Smith", 45, "Male"));
        _patientRepo.Add(new Patient(3, "Jet Lee", 33, "Female"));

        _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
        _prescriptionRepo.Add(new Prescription(2, 1, "Paracetamol", DateTime.Now.AddDays(-5)));
        _prescriptionRepo.Add(new Prescription(3, 2, "Ibuprofen", DateTime.Now.AddDays(-7)));
        _prescriptionRepo.Add(new Prescription(4, 3, "Cetirizine", DateTime.Now.AddDays(-3)));
        _prescriptionRepo.Add(new Prescription(5, 2, "Vitamin D", DateTime.Now.AddDays(-1)));
    }

    public void BuildPrescriptionMap()
    {
        _prescriptionMap = _prescriptionRepo
            .GetAll()
            .GroupBy(p => p.PatientId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public void PrintAllPatients()
    {
        foreach (var patient in _patientRepo.GetAll())
        {
            Console.WriteLine($"{patient.Id}: {patient.Name} ({patient.Age} y/o, {patient.Gender})");
        }
    }

    public void PrintPrescriptionsForPatient(int id)
    {
        if (_prescriptionMap.ContainsKey(id))
        {
            Console.WriteLine($"\nPrescriptions for Patient ID {id}:");
            foreach (var prescription in _prescriptionMap[id])
            {
                Console.WriteLine($"- {prescription.MedicationName} (Issued: {prescription.DateIssued.ToShortDateString()})");
            }
        }
        else
        {
            Console.WriteLine("No prescriptions found for this patient.");
        }
    }

    public void Run()
    {
        SeedData();
        BuildPrescriptionMap();

        Console.WriteLine("=== All Patients ===");
        PrintAllPatients();

        Console.Write("\nEnter Patient ID to view prescriptions: ");
        if (int.TryParse(Console.ReadLine(), out int patientId))
        {
            PrintPrescriptionsForPatient(patientId);
        }
        else
        {
            Console.WriteLine("Invalid ID entered.");
        }
    }
}
