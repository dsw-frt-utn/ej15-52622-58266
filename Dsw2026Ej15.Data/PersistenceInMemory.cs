using Dsw2026Ej15.Domain;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private readonly List<Doctor> _doctors;
        private readonly List<Speciality> _specialities;

        public object JsonHelper { get; private set; }

        public PersistenceInMemory()
        {
            _specialities = LoadSpecialities();
            _doctors = new List<Doctor>();
        }

        public List<Doctor> GetDoctors()
        {
            return _doctors;
        }

        public List<Speciality> GetSpecialities()
        {
            return _specialities;
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        private List<Speciality> LoadSpecialities()
        {
            return JsonHelper.ReadFromFile<Speciality>("specialities");
        }
        public Doctor CreateDoctor(string name, string licenseNumber, int specialityId)
        {
          

            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("El nombre es requerido");

            if (string.IsNullOrWhiteSpace(licenseNumber))
                throw new Exception("La matrícula es requerida");

            var speciality = _specialities.FirstOrDefault(s => s.Id == specialityId);

            if (speciality == null)
                throw new Exception("La especialidad no existe");

            var doctor = new Doctor
            {
                Name = name,
                LicenseNumber = licenseNumber,
                Speciality = speciality,
                IsActive = true
            };

            _doctors.Add(doctor);

            return doctor;
        }

    }

    public interface IPersistence
    {
    }
}
