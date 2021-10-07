using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class RandevuProduct
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tc { get; set; }
        public string Tel { get; set; }
        public string Area { get; set; }
        public string Doctor { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; }
    }
}