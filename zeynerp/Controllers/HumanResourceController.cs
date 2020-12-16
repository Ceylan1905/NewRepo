using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeynerp.BL;
using zeynerp.Common.Helpers.Select;
using zeynerp.Entities;
using zeynerp.Entities.HumanResource;

namespace zeynerp.Controllers
{
    public class HumanResourceController : Controller
    {
        private Manager<Employee> manager_employee = new Manager<Employee>();
        private HumanResourceManager<Personnel> manager_personnel = new HumanResourceManager<Personnel>();

        [Route("insan-kaynaklari/personel-listesi")]
        [Authorize]
        public ActionResult PersonnelList()
        {
            Employee employee = Session["employee"] as Employee;
            List<Personnel> personnels = manager_personnel.GetPersonnels(employee.CompanyName);
            return View(personnels);
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        public ActionResult PersonnelAdd(int? id)
        {
            List<SelectListItem> chiefList = new List<SelectListItem>() {
                new SelectListItem() { Text = "", Value = "0" },
                new SelectListItem() { Text = "Abdulkadir UĞURLU", Value = "1" },
                new SelectListItem() { Text = "Ali YETİŞ", Value = "2" },
                new SelectListItem() { Text = "Bahtiyar ÇAĞLAR", Value = "3" },
                new SelectListItem() { Text = "Bülent AKYEL", Value = "4" },
                new SelectListItem() { Text = "Ceylan Nur ÖZTÜRK", Value = "5" },
                new SelectListItem() { Text = "Doğuş KAMA", Value = "6" },
                new SelectListItem() { Text = "Ercan SEKİN", Value = "7" },
                new SelectListItem() { Text = "Eren ÇABUKCAN", Value = "8" },
                new SelectListItem() { Text = "Erkan KUNDUZ", Value = "9" },
                new SelectListItem() { Text = "Erman KÖSOĞLU", Value = "10" },
                new SelectListItem() { Text = "Kenan SERDAR", Value = "11" },
                new SelectListItem() { Text = "Mervenur SAĞLAM", Value = "12" },
                new SelectListItem() { Text = "Muhammet FETTAHOĞLU", Value = "13" },
                new SelectListItem() { Text = "Nurullah ALAGEYİK", Value = "14" },
                new SelectListItem() { Text = "Sefa TÜRK", Value = "15" },
                new SelectListItem() { Text = "Selim SELİMOĞLU", Value = "16" }
            };
            ViewBag.ChiefList = new SelectList(chiefList, "Value", "Text", "0");

            List<SelectListItem> positions = new List<SelectListItem>() {
                new SelectListItem() { Text = "", Value = "0" },
                new SelectListItem() { Text = "Genel Müdür", Value = "Genel Müdür" },
                new SelectListItem() { Text = "Fabrika Yöneticisi", Value = "Fabrika Yöneticisi" },
                new SelectListItem() { Text = "Muhasebe Müdürü", Value = "Muhasebe Müdürü" },
                new SelectListItem() { Text = "Pazarlama Müdürü", Value = "Pazarlama Müdürü" },
                new SelectListItem() { Text = "Satın Alma Yöneticisi", Value = "Satın Alma Yöneticisi" },
                new SelectListItem() { Text = "Stok Yöneticisi", Value = "Stok Yöneticisi" },
                new SelectListItem() { Text = "Bilgi İşlem Yöneticisi", Value = "Bilgi İşlem Yöneticisi" },
                new SelectListItem() { Text = "Kalite Kontrol Müdürü", Value = "Kalite Kontrol Müdürü" },
                new SelectListItem() { Text = "Dizayn Müdürü", Value = "Dizayn Müdürü" },
                new SelectListItem() { Text = "Ön İmalat Yöneticisi", Value = "Ön İmalat Yöneticisi" },
                new SelectListItem() { Text = "Üretim Müdürü", Value = "Üretim Müdürü" },
                new SelectListItem() { Text = "Proje Mühendisi", Value = "Proje Mühendisi" },
                new SelectListItem() { Text = "İmalat Ustası", Value = "İmalat Ustası" },
                new SelectListItem() { Text = "Gaz Altı Kaynak Ustası", Value = "Gaz Altı Kaynak Ustası" },
                new SelectListItem() { Text = "Argon Kaynak Ustası", Value = "Argon Kaynak Ustası" },
                new SelectListItem() { Text = "Taşlama Ustası", Value = "Taşlama Ustası" },
                new SelectListItem() { Text = "Talaşlı İmalat Ustası", Value = "Talaşlı İmalat Ustası" },
                new SelectListItem() { Text = "Yardımcı Usta", Value = "Yardımcı Usta" },
                new SelectListItem() { Text = "Yardımcı Eleman", Value = "Yardımcı Eleman" },
                new SelectListItem() { Text = "Saha Elemanı", Value = "Saha Elemanı" },
                new SelectListItem() { Text = "Ofis Elemanı", Value = "Ofis Elemanı" },
                new SelectListItem() { Text = "Güvenlik Elemanı", Value = "Güvenlik Elemanı" },
                new SelectListItem() { Text = "Bakım & Onarım Personeli", Value = "Bakım & Onarım Personeli" },
                new SelectListItem() { Text = "Ağır Vasıta Şoförü", Value = "Ağır Vasıta Şoförü" },
                new SelectListItem() { Text = "Forklift Operatörü", Value = "Forklift Operatörü" },
                new SelectListItem() { Text = "Vinç Operatörü", Value = "Vinç Operatörü" },
                new SelectListItem() { Text = "Stajyer", Value = "Stajyer" },
                new SelectListItem() { Text = "Web Tasarımcısı", Value = "Web Tasarımcısı" },
                new SelectListItem() { Text = "Teknik Ressam", Value = "Teknik Ressam" },
                new SelectListItem() { Text = "Yazılım Uzmanı", Value = "Yazılım Uzmanı" },
                new SelectListItem() { Text = "İş Geliştirmeci", Value = "İş Geliştirmeci" },
                new SelectListItem() { Text = "CNC Torna Ustası", Value = "CNC Torna Ustası" },
                new SelectListItem() { Text = "Makine Teknikeri", Value = "Makine Teknikeri" },
                new SelectListItem() { Text = "Temizlik Görevlisi", Value = "Temizlik Görevlisi" },
                new SelectListItem() { Text = "Satış Mühendisi", Value = "Satış Mühendisi" },
                new SelectListItem() { Text = "Finansal Analist", Value = "Finansal Analist" },
                new SelectListItem() { Text = "Kalite Kontrol Sorumlusu", Value = "Kalite Kontrol Sorumlusu" }
            };
            ViewBag.Positions = new SelectList(positions, "Value", "Text", "0");

            List<SelectListItem> companies = new List<SelectListItem>() {
                new SelectListItem() { Text = "", Value = "0" },
                new SelectListItem() { Text = "Kadro", Value = "Kadro" },
                new SelectListItem() { Text = "Erdağ Makine", Value = "Erdağ Makine" },
                new SelectListItem() { Text = "Fatih Ertekin", Value = "Fatih Ertekin" },
                new SelectListItem() { Text = "Mustafa Akar", Value = "Mustafa Akar" },
                new SelectListItem() { Text = "Pınarbaşı", Value = "Pınarbaşı" },
                new SelectListItem() { Text = "SM Makina / Aynur YENER", Value = "SM Makina / Aynur YENER" }
            };
            ViewBag.Companies = new SelectList(companies, "Value", "Text", "0");

            List<SelectListItem> S_Centrals = new List<SelectListItem>() {
                new SelectListItem() { Text = "", Value = "0" },
                new SelectListItem() { Text = "S-Mak", Value = "S-Mak" },
                new SelectListItem() { Text = "S-Gaz", Value = "S-Gaz" },
                new SelectListItem() { Text = "S-Gaz Bursa", Value = "S-Gaz Bursa" },
                new SelectListItem() { Text = "Çimaş", Value = "Çimaş" },
                new SelectListItem() { Text = "S-Nak", Value = "S-Nak" },
                new SelectListItem() { Text = "Hurda", Value = "Hurda" },
                new SelectListItem() { Text = "Kira Geliri", Value = "Kira Geliri" },
                new SelectListItem() { Text = "Teşvik Gelirleri", Value = "Teşvik Gelirleri" },
                new SelectListItem() { Text = "S-Mak Industries", Value = "S-Mak Industries" },
                new SelectListItem() { Text = "SS Şahsi", Value = "SS Şahsi" }
            };
            ViewBag.S_Centrals = new SelectList(S_Centrals, "Value", "Text", "0");

            if (id != null)
            {
                Employee employee = Session["employee"] as Employee;
                Personnel personnel = manager_personnel.GetPersonnel(employee.CompanyName, id.Value);

                return View(personnel);
            }

            return View();
        }

        [Route("insan-kaynaklari/personel-ekleme")]
        [HttpPost]
        public ActionResult PersonnelAdd(Personnel personnel, HttpPostedFileBase imageFile)
        {
            Employee employee = Session["employee"] as Employee;
            if (ModelState.IsValid) {

                if (imageFile != null && (imageFile.ContentType == "image/jpeg" || imageFile.ContentType == "image/jpg" || imageFile.ContentType == "image/png"))
                {
                    string filename = $"{employee.CompanyId}_{personnel.Id}.{imageFile.ContentType.Split('/')[1]}";

                    imageFile.SaveAs(Server.MapPath($"~/images/{filename}"));
                    personnel.ProfileImage = filename;
                    manager_personnel.PersonnelAdd(employee.CompanyName, personnel);
                }
                return RedirectToAction("PersonnelList");
            }
            return View();
        }

        [Route("insan-kaynaklari/personel-sil")]
        public ActionResult PersonnelDelete(int? id)
        {
            if(id != null)
            {
                Employee employee = Session["employee"] as Employee;
                manager_personnel.PersonnelDelete(employee.CompanyName, id.Value);
                return RedirectToAction("PersonnelList");
            }
            return View(); // Error
        }
    }
}