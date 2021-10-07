using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class NurseProductDal
    {
        public void Add(NurseProduct nurseProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(nurseProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<NurseProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {
              return context.nurseProduct.ToList();
            }
        }

    }
}