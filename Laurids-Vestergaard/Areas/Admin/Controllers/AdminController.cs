using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laurids_Vestergaard.Models.BaseModels;
using System.IO;
using Laurids_Vestergaard.Factories;

namespace Laurids_Vestergaard.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        HomeFactory homeFac = new HomeFactory();
        AboutFactory aboutFac = new AboutFactory();
        GalleryFactory galleryFac = new GalleryFactory();
        GalleryItemsFactory galleryItemFac = new GalleryItemsFactory();
        ContactFactory contactFac = new ContactFactory();
        ApartmentsFactory apartmentsFac = new ApartmentsFactory();
        PrivateFactory privateFac = new PrivateFactory();
        CommercialFactory commercialFac = new CommercialFactory();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            Homes h = homeFac.Get(1); //db.Home.FirstOrDefault(x => x.HomeID == 1);
            return View(h);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditHome(Homes newHome)
        {
            homeFac.Update(newHome);
            return View("Home");
        }

        public ActionResult About()
        {
            Abouts a = aboutFac.Get(1);
            return View(a);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditAbout(Abouts newAbout)
        {
            aboutFac.Update(newAbout);
            return View("About");
        }

        public ActionResult Contact()
        {
            Contacts c = contactFac.Get(1);
            return View(c);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditContact(Contacts newContact)
        {
            contactFac.Update(newContact);
            return View("Contact");
        }

        public ActionResult Gallery()
        {
            List<Galleries> galleries = galleryFac.GetAll();
            return View(galleries);
        }

        public ActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGallery(Galleries gallery)
        {
            gallery.DateAdded = DateTime.Now.Date;
            galleryFac.Add(gallery);
            return RedirectToAction("Gallery");
        }

        public ActionResult DeleteGallery(int id)
        {
            Galleries g = galleryFac.Get(id);
            galleryFac.Delete(g.GalleryID);

            List<GalleryItems> galleryItemsAffiliated = galleryItemFac.GetAll().Where(x => x.GalleryID == id).ToList();
            galleryItemsAffiliated.ForEach(x =>
            {
                string path = Request.PhysicalApplicationPath + "/Content/Images/Gallery/" + x.Image;
                System.IO.File.Delete(path);
                System.IO.File.Delete("tn_" + path);
                galleryItemFac.Delete(x.GalleryItemID);
            });

            return RedirectToAction("Gallery");
        }

        public ActionResult EditGallery(int id)
        {
            Galleries g = galleryFac.Get(id);
            return View(g);
        }

        [HttpPost]
        public ActionResult EditGallery(Galleries g)
        {
            galleryFac.Update(g);
            TempData["MSG"] = "Ítem Edited.";
            return RedirectToAction("Gallery");
        }

        [HttpPost]
        public ActionResult GetGallery(int id)
        {
            TempData["GalleryList"] = galleryItemFac.GetAll().Where(x => x.GalleryID == id).ToList();
            TempData["GalleryID"] = id;
            return RedirectToAction("Gallery");
        }

        public ActionResult AddGalleryItem(int id)
        {
            TempData["Gallery"] = galleryFac.Get(id);
            return View();
        }

        [HttpPost]
        public ActionResult AddGalleryItem(GalleryItems galleryItem, HttpPostedFileBase file)
        {
            galleryItem.DateAdded = DateTime.Now.Date;

            if (file.ContentLength > 0 && file != null)
            {
                Uploader uploader = new Uploader();
                galleryItem.Image = uploader.UploadImage(file, @"Content\Images\Gallery\", 0, true, true, 300);
            }

            galleryItemFac.Add(galleryItem);

            TempData["MSG"] = "Ítem Added.";
            return RedirectToAction("Gallery");
        }

        public ActionResult DeleteGalleryItem(int id)
        {
            GalleryItems galleryItem = galleryItemFac.Get(id);
            galleryItemFac.Delete(galleryItem.GalleryItemID);
            TempData["MSG"] = "Gallery Item with name: " + galleryItem.Name + " has been deleted.";

            return RedirectToAction("Gallery");
        }

        public ActionResult EditGalleryItem(int id)
        {
            GalleryItems galleryItem = galleryItemFac.Get(id);
            return View(galleryItem);
        }

        [HttpPost]
        public ActionResult EditGalleryItem(GalleryItems galleryItem)
        {
            galleryItemFac.Update(galleryItem);
            TempData["MSG"] = "Ítem Edited.";
            return RedirectToAction("Gallery");
        }

        public ActionResult EditApartments()
        {
            Apartments apartments = apartmentsFac.Get(1);
            return View(apartments);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult OnEditApartmentsSubmit(Apartments editApartments)
        {
            apartmentsFac.Update(editApartments);
            return RedirectToAction("EditApartments");
        }

        public ActionResult EditPrivate()
        {
            Private p = privateFac.Get(1);
            return View(p);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult OnEditPrivateSubmit(Private editPrivate)
        {
            privateFac.Update(editPrivate);
            return RedirectToAction("EditPrivate");
        }

        public ActionResult EditCommercial()
        {
            Commercial c = commercialFac.Get(1);
            return View(c);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult OnEditCommercialSubmit(Commercial editCommercial)
        {
            commercialFac.Update(editCommercial);
            return RedirectToAction("EditCommercial");
        }
    }
}