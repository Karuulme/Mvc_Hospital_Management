using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalManagament.Buisness
{
    public class HospitalMedicinesProductDal
    {
        public bool AddAndUpdate(HospitalMedicinesProduct hospitalMedicinesProduct)
        {
            using (Connnection context = new Connnection())
            {
                var Hastaneİhtiyaclari = context.hospitalMedicinesProduct.SingleOrDefault(p => p.MedicineName.ToLower() == hospitalMedicinesProduct.MedicineName.ToLower());
                if (Hastaneİhtiyaclari != null)
                {
                    Hastaneİhtiyaclari.Number += hospitalMedicinesProduct.Number;
                    var DeleteEntity = context.Entry(Hastaneİhtiyaclari);
                    DeleteEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    var DeleteEntity = context.Entry(hospitalMedicinesProduct);
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
                var Delete = context.hospitalMedicinesProduct.SingleOrDefault(p => p.Id == Id);
                if (Delete != null)
                {
                    var DeleteEntity = context.Entry(Delete);
                    DeleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }

            }
        }
        public List<HospitalMedicinesProduct> GetAll()
        {
            using (Connnection context = new Connnection())
            {

                return context.hospitalMedicinesProduct.ToList();
            }

        }
    }
}