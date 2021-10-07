
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HospitalManagament.Connection
{
    public class Connnection : DbContext
    {

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public Connnection():base("name=HospitalDatabase")
        {
          //Database.SetInitializer<Connnection>(new DropCreateDatabaseAlways<Connnection>());
        }




        public DbSet<DockerProduct> dockerProduct { get; set; }
        public DbSet<PatientRegistrationProduct> patientRegistrationProduct { get; set; }
        public DbSet<AreaProduct> areaProduct { get; set; }
        public DbSet<AreaListProduct> areaListProduct { get; set; }
        public DbSet<EmployeeProduct> employeeProduct { get; set; }
        public DbSet<ReferenceProduct> referenceProduct { get; set; }
        public DbSet<NurseProduct> nurseProduct { get; set; }
        public DbSet<SecurityProduct> securityProduct { get; set; }
        public DbSet<RandevuProduct> randevuProduct { get; set; }
        public DbSet<RandevuDoctorProduct> randevuDoctorProduct { get; set; }
        public DbSet<HospitalEquipmentProduct> hospitalEquipmentProduct { get; set; }
        public DbSet<HospitalMedicinesProduct> hospitalMedicinesProduct { get; set; }
        

    }

    
}