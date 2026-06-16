using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
   public interface IPersistence
    {
		List<Doctor> GetDoctors();
		List<Speciality> GetSpecialities();

		void AddDoctor(Doctor doctor);
	}
}
