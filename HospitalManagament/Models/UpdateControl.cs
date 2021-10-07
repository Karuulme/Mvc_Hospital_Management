using HospitalManagament.Buisness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagament.Models
{
    public class UpdateControl
    {
        public bool ControlTest = true;
        public PatientRegistrationProduct control(PatientRegistrationProduct Model)
        {
            PatientRegistrationProductDal Patient = new PatientRegistrationProductDal();
            AreaListProductDal AreaListDockers = new AreaListProductDal(); // alan

            AreaProductDal AreaControl = new AreaProductDal(); // docker ve alan
            foreach (var property in typeof(PatientRegistrationProduct).GetProperties())
            {
                var propertyInfo = property.GetValue(Model);

                if (property.Name != "Gender" && property.Name != "GenderLink")
                {
                    if (propertyInfo == null || propertyInfo == "" || propertyInfo == " ")
                    {
                        ControlTest = false;



                        break;
                    }

                }

            }
            if (ControlTest != false)
            {
                var Ablout = Patient.GetKey(Model.Id);
                Model.Gender = Ablout.Gender;
                Model.GenderLink = Ablout.GenderLink;
                if (Model.Status == "0")
                {
                    Model.Status = "STABİL";

                }
                else if (Model.Status == "1")
                {
                    Model.Status = "KRITİK";

                }
                else
                {

                    Model.Status = "ACİL";
                }
                var AreaControlT = AreaControl.Control(Model.Area);
                if (Model.Area == AreaControlT.Area && Model.SelectDoctor == AreaControlT.Doctor)
                {

                    Model.Area = Model.Area.ToUpper();

                }


            }
            return Model;






        }



    }
}