using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class RandevuProductDal
    {
        public void Add(RandevuProduct RandevuProduct)
        {
            using (Connnection context = new Connnection())
            {
               
                    var DeleteEntity = context.Entry(RandevuProduct);
                    DeleteEntity.State = EntityState.Added;
                    context.SaveChanges();
                    
             
            }
        }
        public void Delete(RandevuProduct randevuProduct)
        {
            using (Connnection context = new Connnection())
            {
                var DeleteEntity = context.Entry(randevuProduct);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public RandevuProduct GetId(int Id)
        {
            using (Connnection context = new Connnection())
            {

                return context.randevuProduct.SingleOrDefault(p => p.Id == Id);


            }
        }
        public RandevuProduct GetOne(string Tc)
        {
            using (Connnection context = new Connnection())
            {

                return context.randevuProduct.SingleOrDefault(p=>p.Tc==Tc);
                    
             
            }
        } 
        public List<RandevuProduct> GetAll(string Doctor=null)
        {
            using (Connnection context = new Connnection())
            {
                if (Doctor!=null)
                {
                    return context.randevuProduct.Where(p=>p.Doctor==Doctor).ToList();
                }
                else
                {
                    return context.randevuProduct.ToList();
                }
            }
        }


    }
}