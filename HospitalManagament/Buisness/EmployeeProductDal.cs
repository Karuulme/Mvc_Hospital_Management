using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
	public class EmployeeProductDal
	{
		public void Add(EmployeeProduct employeeProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(employeeProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }
        public EmployeeProduct GetOne(string Tc)
        {
            using (Connnection context = new Connnection())
            {
                return context.employeeProduct.SingleOrDefault(p=>p.Tc==Tc);
            }


        }






    }
}