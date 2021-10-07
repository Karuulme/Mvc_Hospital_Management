using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class SecurityProductDal
    {
        public void Add(SecurityProduct securityProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(securityProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public SecurityProduct Search( string Tc)
        {
            using (Connnection context = new Connnection())
            {
                return context.securityProduct.SingleOrDefault(p=>p.Tc==Tc);
            }
        }
    }
}