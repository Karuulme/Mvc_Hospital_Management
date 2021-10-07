using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class HospitalMedicinesProduct
    {
        public int Id { get; set; }
        public string TMYCode { get; set; }
        public string PharmacyCode { get; set; }
        public string MedicineName { get; set; }
        public string Measurement { get; set; }
        public string Quantity { get; set; }
        public int Number { get; set; }

    }
}