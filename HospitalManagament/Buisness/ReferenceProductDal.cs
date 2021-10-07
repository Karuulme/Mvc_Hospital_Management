using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class ReferenceProductDal
    {
        public List<ReferenceProduct> Control(string Key)
        {
            using (Connnection context = new Connnection())
            {
                return context.referenceProduct.Where(p => p.Kod == Key).ToList();

            }
        }
        public void Add(ReferenceProduct referenceProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(referenceProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(ReferenceProduct referenceProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(referenceProduct);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }
        public ReferenceProduct GetOne(string Key)
        {
            using (Connnection context = new Connnection())
            {
                return context.referenceProduct.SingleOrDefault(p=>p.Kod==Key);

            }
        }
    }
}