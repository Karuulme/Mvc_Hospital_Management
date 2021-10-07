using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HospitalManagament.Models;

namespace HospitalManagament.Connection
{
    public class DataInitializer:DropCreateDatabaseAlways<Connnection>
    {
        protected override void Seed(Connnection context)
        {
            
        }

    } 
}