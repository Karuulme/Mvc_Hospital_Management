using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class AreaProductDal
    {
        public List<AreaProduct> GetAll(string Key)
        {
            using (Connnection context =new Connnection())
            {

                return context.areaProduct.Where(p => p.Area.ToLower() == Key.ToLower()).ToList();

            }
        }
        public List<AreaProduct> AllDoctor()
        {
            using (Connnection context = new Connnection())
            {

                return context.areaProduct.ToList();

            }
        }



        public AreaProduct Control(string Key)
        {
            using (Connnection context = new Connnection())
            {

                return context.areaProduct.SingleOrDefault(p => p.Area.ToLower() == Key.ToLower());

            }


        }
        public List<AreaProduct> GetDoctor(string Key)
        {
            using (Connnection context = new Connnection())
            {

              return  context.areaProduct.Where(p => p.Doctor.ToLower() == Key.ToLower()).ToList();

            }


        }

        public List<AreaProduct> DockerControl(string Key)
        {
            using (Connnection context = new Connnection())
            {

                return context.areaProduct.Where(p=>p.Doctor.ToLower()==Key.ToLower()).ToList();

            }
        }

        public void Add(AreaProduct areaProduct)
        {
            using (Connnection context = new Connnection())
            {
                var addedEntity = context.Entry(areaProduct);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }


    }
}