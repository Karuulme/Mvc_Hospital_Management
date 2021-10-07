using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class RandevuDoctorProduct
    {
        public int Id { get; set; }
        public string RandevuFirstName { get; set; }
        public string RandevuLastName { get; set; }
        public string RandevuTc { get; set; }
        public string Doctor { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }
    }
}