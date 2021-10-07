using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class PatientRegistrationProduct
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tc { get; set; }
        public string Tel { get; set; }
        public string Gender { get; set; }
        public string GenderLink { get; set; }
        public string Proglem { get; set; }
        public string Status { get; set; }
        public string Area { get; set; }
        public string SelectDoctor { get; set; }
    }
}