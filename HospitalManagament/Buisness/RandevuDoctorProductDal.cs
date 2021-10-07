using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class RandevuDoctorProductDal
    {
        public void Add(RandevuDoctorProduct randevuDoctorProduct)
        {
            using (Connnection context = new Connnection())
            {
                var DeleteEntity = context.Entry(randevuDoctorProduct);
                DeleteEntity.State = EntityState.Added;
                context.SaveChanges();


            }
        }
        public void Delete(RandevuDoctorProduct randevuDoctorProduct)
        {
            using (Connnection context = new Connnection())
            {
                var DeleteEntity = context.Entry(randevuDoctorProduct);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }
        public List<RandevuDoctorProduct> GetRandevuTime(string Key)
        {
            using (Connnection context = new Connnection())
            {
                return context.randevuDoctorProduct.Where(p => p.Doctor == Key).ToList();
            }
        }
        public RandevuDoctorProduct GetDouble(string Doctor,string Saat,string Tarih)
        {
            using (Connnection context = new Connnection())
            {

                return context.randevuDoctorProduct.SingleOrDefault(p =>p.Doctor == Doctor && p.Saat==Saat && p.Tarih==Tarih);


            }
        }
        public RandevuDoctorProduct GetTc(string Tc)
        {
            using (Connnection context = new Connnection())
            {

                return context.randevuDoctorProduct.SingleOrDefault(p =>p.RandevuTc == Tc);


            }
        }
 
    }
}