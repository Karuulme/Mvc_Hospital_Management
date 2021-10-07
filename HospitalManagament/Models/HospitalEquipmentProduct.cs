using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class HospitalEquipmentProduct
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string PlaceOfUse { get; set; }
        public int Number { get; set; }
    }
}