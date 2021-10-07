using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class AreaListProductDal
    {
        public AreaListProduct GetOne(string Key)
        {
            using (Connnection context = new Connnection())
            {

                return context.areaListProduct.SingleOrDefault(p => p.Area.ToLower() == Key.ToLower());

            }
        }
        public AreaListProduct GetOneId(int Key)
        {
            using (Connnection context = new Connnection())
            {

                return context.areaListProduct.SingleOrDefault(p => p.Id == Key);

            }


        }


        public List<AreaListProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {

                return context.areaListProduct.ToList();

            }
        }
        public bool Add(AreaListProduct Key)
        {
            using (Connnection context = new Connnection())
            {
                try
                {
                    var DeleteEntity = context.Entry(Key);
                    DeleteEntity.State = EntityState.Added;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
        public bool Delete(AreaListProduct Key)
        {
            using (Connnection context = new Connnection())
            {
                if (GetOneId(Key.Id)!=null)
                {
                    var DeleteEntity = context.Entry(Key);
                    DeleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
              
            }
        }

    }
}