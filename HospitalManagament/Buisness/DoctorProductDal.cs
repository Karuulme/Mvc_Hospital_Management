using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class DoctorProductDal
    {
        public void Add(DockerProduct dockerProduct)
        {
            using (Connnection context = new Connnection())
            {

                var addedEntity = context.Entry(dockerProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();


            }

        }
        public List<DockerProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {

                return context.dockerProduct.ToList();


            }
        }
        public void Delete(int Id)
        {
            using (Connnection context = new Connnection())
            {

                var DeleteEntity = context.Entry(Id);
                DeleteEntity.State = EntityState.Detached;
                context.SaveChanges();


            }


        }

        public void Update(DockerProduct dockerProduct)
        {
            using (Connnection context = new Connnection())
            {
                var UpdateEntity = context.Entry(dockerProduct);
                UpdateEntity.State = EntityState.Modified;
                context.SaveChanges();


            }


        }

    }
}