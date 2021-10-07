using HospitalManagament.Buisness;
using HospitalManagament.Connection;
using HospitalManagament.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HospitalManagament.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public bool ControlAcceptance = false;
        static PatientRegistrationProduct PersonAcceptance = new PatientRegistrationProduct();
        PatientRegistrationProductDal Patient = new PatientRegistrationProductDal();
        AreaProductDal Area = new AreaProductDal();
        AreaListProductDal AreaList = new AreaListProductDal();
        AreaListProduct kayit = new AreaListProduct();
        AreaProductDal _doctor = new AreaProductDal();
        EmployeeProduct _personel = new EmployeeProduct();
        EmployeeProductDal _personelBuisness = new EmployeeProductDal();
        static bool controlcu = false;
        ReferenceProductDal _kodKontrol = new ReferenceProductDal();
        DoctorProductDal DoctorList = new DoctorProductDal();
        NurseProductDal _nurse = new NurseProductDal();
        SecurityProductDal _security = new SecurityProductDal();
        static RandevuProduct _randevu = new RandevuProduct();
        static bool RandevuKontrol = false;
        RandevuDoctorProductDal _randevuDoctor= new RandevuDoctorProductDal();
        RandevuProductDal _randevuHasta = new RandevuProductDal();
        HospitalMedicinesProductDal _medicinesProduct=new HospitalMedicinesProductDal();
        HospitalEquipmentProductDal _equipmentProduct = new HospitalEquipmentProductDal();

        public ActionResult Index()
        {
            // PatientList();
            ViewBag.listte = Patient.GetAll();
            ViewBag.deneme ="asdasdasdasdasd";
            ViewBag.Doctor = _doctor.AllDoctor();
            ViewBag.Nurse = _nurse.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult KisiselBilgi(string FirstName, string LastName, string Tc, string Tel, string Status, string problem)
        {


            if (FirstName != null && LastName != null && Tc != null && Tel != null && Status != null)
            {
                PersonAcceptance.FirstName = FirstName;
                PersonAcceptance.LastName = LastName;
                PersonAcceptance.Proglem = problem;
                PersonAcceptance.Tc = Tc;
                PersonAcceptance.Tel = Tel;
                if (Status == "0")
                {
                    PersonAcceptance.Status = "STABİL";
                }
                if (Status == "1")
                {
                    PersonAcceptance.Status = "KRITİK";
                }
                if (Status == "2")
                {
                    PersonAcceptance.Status = "ACİL";
                }
                ViewBag.Bolum2 = true;
                ViewBag.ListeArea = AreaList.GetAll();
                ControlAcceptance = true;



            }
            else
            {
                ViewBag.Bolum1Control = true;

            }
            return PartialView("Acceptance");

        }
        [HttpPost]
        public ActionResult KisiselBilgiArea(string _Area)
        {
            if (_Area != null && AreaList.GetOne(_Area) != null)
            {s
                PersonAcceptance.Area = _Area;
                ViewBag.ListeDocker = Area.GetAll(_Area);
                ViewBag.Bolum3 = true;
                controlcu = true;


            }
            else
            {
                ViewBag.ListeArea = AreaList.GetAll();
                ViewBag.Bolum2 = true;
                ViewBag.Bolum2Control = true;


            }
            return PartialView("Acceptance");
        }
        public ActionResult Employee()
        {
            return View();

        }
        public ActionResult EmployeeGiris(string Tc, string Password, string Key)
        {
            if (Tc != null && Password != null && Key != null && Tc != "" && Password != "" && Key != "")
            {
                var Kayit = _personelBuisness.GetOne(Tc);
                if (Kayit != null)
                {
                    if (Kayit.Password == Password && Kayit.Key == Key)
                    {
                        ViewBag.AdminBilgileri = Kayit;
                        ViewBag.Admin = "1";

                    }
                    else
                    {
                        ViewBag.GirisHata = "Lütfen Bilgilerinizi Kontrol ediniz...";

                    }
                }
                else
                {
                    ViewBag.GirisHata = "Lütfen Bilgilerinizi Kontrol ediniz...";


                }

            }
            else {
                ViewBag.GirisHata = "Lütfen Boş Alan Bırakmayınız...";

            }
            return PartialView("Employee");
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult EmployeeKayit(string FirstName, string LastName, string Tc, string Password, string Key, string Kod)
        {
            if (FirstName != null && LastName != null && Tc != null && Password != null && Key != null && Kod != null)
            {
                var GetDataKod = _kodKontrol.GetOne(Kod);
                if (GetDataKod != null)
                {
                    _personel.Id = 0;
                    _personel.FirstName = FirstName;
                    _personel.LastName = LastName;
                    _personel.Tc = Tc;
                    _personel.Password = Password;
                    _personel.Key = Key;
                    _personelBuisness.Add(_personel);
                    ViewBag.Kayit = "Kayit Başarılı";
                    _kodKontrol.Delete(GetDataKod);
                }
                else
                {
                    ViewBag.Kayit = "Geçersiz Kod";
                }
            }
            else
            {
                ViewBag.Hata = "Boş Kutucuk bırakmayınız...";


            }
            return PartialView("Employee");


        }







        [HttpPost]
        public ActionResult KisiselBilgiDoctor(string Doctor)
        {
            if (controlcu == true)
            {
                controlcu = false;


                var AreaListGet = Area.DockerControl(Doctor);
                if (Doctor != null && AreaListGet.Count() != 0)
                {
                    PersonAcceptance.SelectDoctor = Doctor;
                    if (Patient.PatientControl(PersonAcceptance.Tc).Count() == 0)
                    {
                        PersonAcceptance.Gender = "Erkek";
                        PersonAcceptance.GenderLink = "Man.png";
                        Add(PersonAcceptance);
                        ViewBag.Bolum4 = true;



                    }
                    else
                    {
                        ViewBag.Bolum5 = true;

                    }



                }
                else
                {
                    ViewBag.ListeDocker = Area.GetAll(PersonAcceptance.Area);
                    ViewBag.Bolum3Control = true;
                    ViewBag.Bolum3 = true;



                }
            }
            else
            {
                ViewBag.ListeDocker = Area.GetAll(PersonAcceptance.Area);
                ViewBag.Bolum3Control = true;
                ViewBag.Bolum3 = true;


            }
            return PartialView("Acceptance");


        }
        [Route("Acceptance")]
        public ActionResult Acceptance()
        {
            return View();
        }
        public void Add(PatientRegistrationProduct patientRegistrationProduct)
        {
            Patient.Add(patientRegistrationProduct);

        }









        [HttpPost]
        public JsonResult SearchKey(string Key)
        {
            if (Key != null && Key != "" && Key != " ")
            {
                return Json(Patient.SearchKey(Key), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Patient.GetAll(), JsonRequestBehavior.AllowGet);
            }
        }
        public bool SayiMi(string text)
        {
            bool control = true;
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) control = false;
                else { }

            }
            return control;


        }

        public ActionResult Visitor(int Key = -1)
        {
            if (Key >= 0)
            {
                var Ablout = Patient.GetKey(Key);
                var SelectDocker = Area.GetAll(Ablout.Area);
                var SelectArea = AreaList.GetAll();
                ViewBag.GetOne = Ablout;
                ViewBag.GetArea = SelectDocker;
                ViewBag.SelectArea = SelectArea;

            }

            return View();
        }
        public ActionResult GetAll()
        {
            ViewBag.GetAll = Patient.GetAll();
            return View();

        }
        [HttpPost]
        public ActionResult Update(PatientRegistrationProduct Model, string _Update, string _Delete)
        {
            UpdateControl Control = new UpdateControl();


            if (_Update == "" && _Delete == null)
            {
                Control.control(Model);

                if (Control.ControlTest == true)
                {

                    Patient.Update(Model);
                    var UpdateData = Patient.GetKey(Model.Id);
                    var SelectDocker = Area.GetAll(UpdateData.Area);
                    var SelectArea = AreaList.GetAll();
                    ViewBag.GetOne = UpdateData;
                    ViewBag.GetArea = SelectDocker;
                    ViewBag.SelectArea = SelectArea;
                    ViewBag.UpdateControl = Control.ControlTest;


                }
                else
                {


                    var Ablout = Patient.GetKey(Model.Id);
                    var SelectDocker = Area.GetAll(Ablout.Area);
                    var SelectArea = AreaList.GetAll();
                    ViewBag.GetOne = Ablout;
                    ViewBag.GetArea = SelectDocker;
                    ViewBag.SelectArea = SelectArea;
                    ViewBag.UpdateControl = Control.ControlTest;

                }



            }
            else if (_Delete == "" && _Update == null)
            {
                Patient.Delete(Model);
                ViewBag.Delete = "1";
            }

            return View("Visitor");
        }
        public ActionResult Doctor()
        {

            ViewBag.Area = AreaList.GetAll();
            return View();


        }
        public ActionResult AreaAd(string Area)
        {
            if (Area != " " && Area != "")
            {
                if (AreaList.GetOne(Area) == null)
                {

                    kayit.Area = Area;
                    kayit.Id = 0;
                    var Donus = AreaList.Add(kayit);
                    if (Donus == true) {
                        ViewBag.AreaList = AreaList.GetAll();
                        ViewBag.Kayit = "Kayıt Başarılı";
                        return View("AreaAdd");
                    }
                    else
                    {
                        ViewBag.AreaList = AreaList.GetAll();
                        ViewBag.Kayit = "Kayıt Başarısız";
                        return View("AreaAdd");
                    }
                }
                else
                {
                    ViewBag.AreaList = AreaList.GetAll();
                    ViewBag.Kayit = "Böyle Bir Kayıt Mevcut";
                    return View("AreaAdd");
                }
            }
            else
            {
                ViewBag.AreaList = AreaList.GetAll();
                ViewBag.AreaAdControl = true;
                return View("AreaAdd");
            }


        }


        public ActionResult AreaAdd(string id)
        {
            if (id != null)
            {
                AreaListProduct delete = new AreaListProduct();
                delete.Id = Convert.ToInt16(id);
                AreaList.Delete(delete);
                ViewBag.AreaList = AreaList.GetAll();

            }
            else
            {
                ViewBag.AreaList = AreaList.GetAll();



            }
            return View();


        }




        public ActionResult DoctorAdd(string Area, string Doctor)
        {
            if (Area != "Seçiniz" && Doctor != "")
            {
                if (AreaList.GetOne(Area) != null && _doctor.GetDoctor(Doctor).Count == 0)
                {
                    AreaProduct DoctorAdd = new AreaProduct();
                    DoctorAdd.Id = 0;
                    DoctorAdd.Area = Area;
                    DoctorAdd.Doctor = Doctor;
                    _doctor.Add(DoctorAdd);
                    ViewBag.ErrorMesage = "Kayıt Başarılı";
                    ViewBag.Area = AreaList.GetAll();
                }
                else
                {
                    ViewBag.Area = AreaList.GetAll();
                    ViewBag.ErrorMesage = "Böyle bir kayıt mevcut";
                }

            }
            else
            {
                ViewBag.Area = AreaList.GetAll();
                ViewBag.ErrorMesage = "Boş Alanları Doldurunuz";


            }
            return View("Doctor");


        }

        public ActionResult Kod(string Key)
        {
            if (Key != null)
            {

                Random rastgele = new Random();
                string[] Harfler = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
                int Kontrolcu = 0;
                do
                {
                    string[] blokkod = new string[2];
                    string[] Kontrolkodu = new string[10];
                    for (var i = 0; i < 10; i++)
                    {
                        string Harf = Harfler[rastgele.Next(0, 22)];
                        int sayi = rastgele.Next(0, 10);
                        int blok = rastgele.Next(0, 2);
                        int secenek = rastgele.Next(0, 2);
                        blokkod[0] = Harf;
                        blokkod[1] = sayi.ToString();
                        Kontrolkodu[i] = blokkod[secenek].ToString();
                    }
                    string Test = "";
                    for (var i = 0; i < 9; i++)
                    {
                        if (i != 0 && i % 3 == 0)
                            Test += "-" + Kontrolkodu[i];
                        else Test += Kontrolkodu[i];
                    }
                    var test = _kodKontrol.Control(Test);
                    if (test.Count == 0)
                    {
                        ReferenceProduct Add = new ReferenceProduct();
                        Add.Id = 0;
                        Add.Kod = Test;
                        _kodKontrol.Add(Add);
                        ViewBag.KOD = Test;
                        Kontrolcu++;
                    }
                }
                while (Kontrolcu == 0);
            }
            return View();
        }
        public ActionResult Nurse()
        {
            ViewBag.Doctor = _doctor.AllDoctor();
            return View();
        }
        public ActionResult NurseAdd(string Doctor, string FirstName, string LastName)
        {
            if (FirstName != null && LastName != null && FirstName != "" && LastName != "" && FirstName != " " && LastName != " ")
            {
                NurseProduct Nurse = new NurseProduct();
                Nurse.Id = 0;
                Nurse.FirstName = FirstName;
                Nurse.LastName = LastName;
                var DoktorKontrol = _doctor.GetDoctor(Doctor);
                if (DoktorKontrol.Count == 0)
                {
                    _nurse.Add(Nurse);
                    ViewBag.Mesaj = "Başarıyla Eklendi.";
                }




            }
            else
            {
                ViewBag.Mesaj = "Boş Değer Girmeyiniz.";
            }


            ViewBag.Doctor = DoctorList.GetAll();
            return View("Nurse");
        }

        public ActionResult Security()
        {
            return View();


        }
        public ActionResult SecurityAdd(string FirstName, string LastName, string Tc)
        {
            if (FirstName != null && LastName != null && Tc != null && FirstName != "" && LastName != "" && Tc != "")
            {

                if (_security.Search(Tc) != null)
                {
                    SecurityProduct Security = new SecurityProduct();
                    Security.Id = 0;
                    Security.FirtName = FirstName;
                    Security.LastName = LastName;
                    Security.Tc = Tc;
                    _security.Add(Security);
                    ViewBag.Mesaj = "Kayıt Başarılı";
                }
                else
                {
                    ViewBag.Mesaj = "Böyle bir kayıt zaten var.";
                }
            }
            else
            {
                ViewBag.Mesaj = "Boş alan bırakmayınız.";
            }


            return PartialView("Security");


        }
        public ActionResult Randevu(string FirstName,string LastName,string Tc,string Tel,
                                    string Area,string Doctor,string Bolum1,string Bolum2,
                                    string Bolum3, string Tarih,string Onay)
        {
            string[] GunSaatleri = new string[] { "9", "10", "11", "13", "14", "15", "16" };
            string[] SaatDakikalari = new string[] { "00", "15", "30", "45" };
            string[] HGunler = new string[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };


            int TarihVer = 0;
            if (Bolum1!=null)
            {
                ViewBag.RandevuBolum = "1";
                ViewBag.RandevuArea = AreaList.GetAll();

            }
            else if (Bolum2 != null)
            {
                ViewBag.RandevuDoctor = _doctor.GetAll(_randevu.Area);
                ViewBag.RandevuBolum = "2";

            }
            else if (Bolum3 != null && RandevuKontrol == false)
            {
                TarihVer = 1;
                ViewBag.RandevuBolum = "3";

            }
            else if (FirstName!=null && LastName != null && Tc != null && Tel != null && Area != null &&
             FirstName!="" && LastName != "" && Tc != "" && Tel != "" && Area != "" &&
             FirstName!=" " && LastName != " " && Tc != " " && Tel != " " && Area != " " )
            {
                    RandevuKontrol = false;
                    _randevu.FirstName = FirstName;
                    _randevu.LastName = LastName;
                    _randevu.Tc = Tc;
                    _randevu.Tel = Tel;
                    _randevu.Area = Area;
                    ViewBag.RandevuDoctor = _doctor.GetAll(Area);
                    ViewBag.RandevuBolum = "2";



              
            }
            else if (Doctor!="Seçiniz" && Doctor != null)
            {
                _randevu.Doctor = Doctor;
                TarihVer = 1;
                ViewBag.RandevuBolum = "3";
            }
            else if (Tarih!=null && Tarih != "" && Tarih != " ")
            {
                var TarihBolum = Tarih.Split('-');
                bool SaatKontrol = false;
                foreach(var i in GunSaatleri)
                {
                    foreach (var j in SaatDakikalari)
                    {
                        if ((i+":"+j)== TarihBolum[0])
                        {
                            SaatKontrol = true;

                        }

                    }

                }
                if(_randevuDoctor.GetDouble(_randevu.Doctor, TarihBolum[0],TarihBolum[1])==null && SaatKontrol==true)
                {
                    _randevu.Saat = TarihBolum[0];
                    _randevu.Tarih = TarihBolum[1];
                    ViewBag.RandevuBilgileri = _randevu;
                    ViewBag.RandevuBolum = "4";
                }
                else
                {
                    TarihVer = 1;
                    ViewBag.RandevuBolum = "3";
                    ViewBag.RandevuBolumErrorTarih = "Geçersiz Tarih Seçimi";

                }
               
            }
            else if (Onay == "Onay" && RandevuKontrol==false)
            {

                RandevuKontrol = true;
                ViewBag.RandevuBilgileri = _randevu;
                RandevuDoctorProduct RandevuDoctor = new RandevuDoctorProduct();
                RandevuDoctor.RandevuFirstName = _randevu.FirstName;
                RandevuDoctor.RandevuLastName = _randevu.LastName;
                RandevuDoctor.RandevuTc = _randevu.Tc;
                RandevuDoctor.Doctor = _randevu.Doctor;
                RandevuDoctor.Saat = _randevu.Saat;
                RandevuDoctor.Tarih = _randevu.Tarih;
                _randevuDoctor.Add(RandevuDoctor);
                _randevuHasta.Add(_randevu);
                ViewBag.RandevuBolum = "4";
                ViewBag.RandevuOnay = "1";
            }
            else
            {
               
                ViewBag.RandevuArea = AreaList.GetAll();
                ViewBag.RandevuBolum = "1";

            }



            if (TarihVer == 1)
            {
                
                ViewBag.DoctorRandevuTime = _randevuDoctor.GetRandevuTime(_randevu.Doctor);
                DateTime dt = DateTime.Now;
                DateTime aysonu = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
                string GunuVer = CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)DateTime.Now.DayOfWeek];
                ViewBag.Bugun = Convert.ToInt16(dt.Day);
                ViewBag.Ay = Convert.ToInt16(dt.Month);
                ViewBag.Yıl = Convert.ToInt16(dt.Year);
                ViewBag.IlkHafta = Convert.ToInt16(DateTime.Today.AddDays(((int)DayOfWeek.Monday - (int)DateTime.Today.DayOfWeek + 7) % 7).Day);
                ViewBag.AySonu = Convert.ToInt16(Convert.ToString(aysonu.Day));
                ViewBag.GunSaatleri = GunSaatleri;
                ViewBag.SaatDakikalari = SaatDakikalari;
                ViewBag.GunIdName = Array.IndexOf(HGunler, GunuVer);
                ViewBag.HGunler = HGunler;

            }
            return View();
        }
        public ActionResult RandevuBilgileri(string Doctor,string Delete)
        {

            if ( Doctor != "Seçiniz" && Doctor !=null)
            {
                ViewBag.TumRandevularHasta = _randevuHasta.GetAll(Doctor);
            }
            else if (Delete!=null)
            {
                    bool DeleteKontrol = true;
                    foreach (char chr in Delete)
                    {
                    if (!Char.IsNumber(chr)) DeleteKontrol = false;
                    }

                if (DeleteKontrol==true)
                {
                  var DeleteGetHasta = _randevuHasta.GetId(Convert.ToInt32(Delete));
                  var DeleteGetDoctor = _randevuDoctor.GetTc(DeleteGetHasta.Tc);
                    if (DeleteGetHasta != null)
                    {
                        _randevuHasta.Delete(DeleteGetHasta);
                        _randevuDoctor.Delete(DeleteGetDoctor);
                        ViewBag.DeleteMessage = "Kayıt Silindi";

                    }
                    else
                    {
                        ViewBag.DeleteMessage = "Kayıt Bulunamadı";

                    }
                    

                }
                else
                {

                    ViewBag.DeleteError = "Bulunamadı";
                }
                    
                
               
              

            }
            else
            {
                ViewBag.TumRandevularHasta = _randevuHasta.GetAll();
            }
            ViewBag.RandevuDoctor = _doctor.AllDoctor();
            return View();
            

        }
        public ActionResult Stok(string TKMYKodu,string EKodu,string IlacAdi, string Birimi,string Miktar,string Turu,string KullanımAlani,string ilac,string AracGerec, string Adet)
        {
            if (ilac != null)
            {
                if (TKMYKodu != null && EKodu != null && IlacAdi != null && Birimi != null && Miktar != null && Adet!=null&&
                    TKMYKodu != "" && EKodu != "" && IlacAdi != "" && Birimi != "" && Miktar != "" && Adet != "" &&
                    TKMYKodu != " " && EKodu != " " && IlacAdi != " " && Birimi != " " && Miktar != " " && Adet != " " 
                    )
                {
                    HospitalMedicinesProduct Medicines = new HospitalMedicinesProduct();
                    Medicines.Id = 0;
                    Medicines.TMYCode = TKMYKodu;
                    Medicines.PharmacyCode = EKodu;
                    Medicines.MedicineName = IlacAdi;
                    Medicines.Measurement = Birimi;
                    Medicines.Quantity = Miktar;
                    Medicines.Number = Convert.ToInt32(Adet);
                   ViewBag.KayitKontrol1=_medicinesProduct.AddAndUpdate(Medicines);
                }
                else
                {

                    ViewBag.KayitErorMessage1 = "Boş Alan Bırakmayınız";

                }
              
            }
            else if (AracGerec != null)
            {
                if (Turu != null && KullanımAlani != null && Adet != null &&
                    Turu != "" && KullanımAlani != ""  &&  Adet != "" &&
                    Turu != " " && KullanımAlani != " "  &&  Adet != " "
                    )
                {
                    HospitalEquipmentProduct Equipment = new HospitalEquipmentProduct();
                    Equipment.Id = 0;
                    Equipment.Type = Turu;
                    Equipment.PlaceOfUse = KullanımAlani;
                    Equipment.Number = Convert.ToInt32(Adet);
                    ViewBag.KayitKontrol2= _equipmentProduct.AddAndUpdate(Equipment);
                }
                else
                {
                    ViewBag.KayitErorMessage2 = "Boş Alan Bırakmayınız";

                }  
            }

            return View();



        }
        public ActionResult StokTakip(string IDeleteId,string ADeleteId)
        {
            if (IDeleteId != null)
            {

                _medicinesProduct.Delete(Convert.ToInt32(IDeleteId));

            }
            else if (ADeleteId != null)
            {
                _equipmentProduct.Delete(Convert.ToInt32(ADeleteId));
            }
            ViewBag.ilaclar= _medicinesProduct.GetAll();
            ViewBag.AracGerec=_equipmentProduct.GetAll();
            return View();

        }







    }
}













  