using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class HospitalEquipmentProductDal
    {
        public bool AddAndUpdate(HospitalEquipmentProduct hospitalEquipmentProduct)
        {
            using (Connnection context = new Connnection())
            {
                var Hastaneİhtiyaclari = context.hospitalEquipmentProduct.SingleOrDefault(p => p.Type.ToLower() == hospitalEquipmentProduct.Type.ToLower());
                if (Hastaneİhtiyaclari!=null)
                {
                    Hastaneİhtiyaclari.Number += hospitalEquipmentProduct.Number;
                    var DeleteEntity = context.Entry(Hastaneİhtiyaclari);
                    DeleteEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    var DeleteEntity = context.Entry(hospitalEquipmentProduct);
                    DeleteEntity.State = EntityState.Added;
                    context.SaveChanges();
                    return false;
                }
                
            }
        }
        public void Delete(int Id)
        {
            using (Connnection context = new Connnection())
            {
                var Delete = context.hospitalEquipmentProduct.SingleOrDefault(p => p.Id == Id);
                if (Delete!=null)
                {
                    var DeleteEntity = context.Entry(Delete);
                    DeleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
               
            }
        }
        public List<HospitalEquipmentProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {

                return context.hospitalEquipmentProduct.ToList();
            }

        }


    }
}