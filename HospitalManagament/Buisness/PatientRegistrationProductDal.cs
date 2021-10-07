using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class PatientRegistrationProductDal
    {
       

        public void Add(PatientRegistrationProduct patientRegistrationProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(patientRegistrationProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }


        }
        public List<PatientRegistrationProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {

                return context.patientRegistrationProduct.ToList();

            }


        }
        public void Delete(PatientRegistrationProduct patientRegistrationProduct)
        {
            using (Connnection context = new Connnection())
            {
                var DeleteEntity = context.Entry(patientRegistrationProduct);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }


        }




        public PatientRegistrationProduct GetKey(int Id)
        {
            using (Connnection context = new Connnection())
            {
               return context.patientRegistrationProduct.SingleOrDefault(p=>p.Id==Id);
            }
        } 

        public List<PatientRegistrationProduct> PatientControl(string TC)
        {
            using (Connnection context = new Connnection())
            {

               return context.patientRegistrationProduct.Where(p=>p.Tc==TC).ToList();


            }


        }  
        public List<PatientRegistrationProduct> SearchKey(string Key)
        {
            using (Connnection context = new Connnection())
            {

                return context.patientRegistrationProduct.Where(p => p.FirstName.ToLower().Contains(Key.ToLower())).ToList();


            }


        }

        public void Update(PatientRegistrationProduct patientRegistrationProduct)
        {
            using (Connnection context = new Connnection())
            {
                var UpdateEntity = context.Entry(patientRegistrationProduct);
                UpdateEntity.State = EntityState.Modified;
                context.SaveChanges();

            }


        }
        
    }
}