using Laurids_Vestergaard.Factories;
using Laurids_Vestergaard.Models.BaseModels;
using Laurids_Vestergaard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurids_Vestergaard.Controllers
{
    public class HomeController : Controller
    {
        HomeFactory homeFac = new HomeFactory();
        AboutFactory aboutFac = new AboutFactory();
        GalleryFactory galleryFac = new GalleryFactory();
        GalleryItemsFactory galleryItemFac = new GalleryItemsFactory();
        ContactFactory contactFac = new ContactFactory();
        ApartmentsFactory apartmentsFac = new ApartmentsFactory();
        PrivateFactory privateFac = new PrivateFactory();
        CommercialFactory commercialFac = new CommercialFactory();

        // GET: Home
        public ActionResult Forside()
        {
            Homes h = homeFac.Get(1);
            return View(h);
        }

        public ActionResult OmMig()
        {
            Abouts a = aboutFac.Get(1);
            return View(a);
        }

        public ActionResult Galleri()
        {
            List<GalleryListItem> galleries = new List<GalleryListItem>();
            foreach (Galleries gallery in galleryFac.GetAll())
            {
                galleries.Add(new GalleryListItem()
                {
                    Gallery = gallery,
                    GalleryItem = galleryItemFac.GetAll().Find(x => x.GalleryID == gallery.GalleryID) //db.GalleryItems.FirstOrDefault(x => x.GalleryID == gallery.GalleryID)
                });
            }
            return View(galleries);
        }

        public ActionResult VisGalleri(int id)
        {
            List<GalleryItems> gallery = galleryItemFac.GetAll().Where(x => x.GalleryID == id).ToList(); //db.GalleryItems.Where(x => x.GalleryID == id).ToList();
            ViewBag.GalleryTitle = galleryFac.GetAll().Where(x => x.GalleryID == id).SingleOrDefault().Title;
            return View(gallery);
        }

        public ActionResult FlytteLejligheder()
        {
            Apartments apartments = apartmentsFac.Get(1);
            return View(apartments);
        }

        public ActionResult Private()
        {
            Private p = privateFac.Get(1);
            return View(p);
        }

        public ActionResult Erhverv()
        {
            Commercial c = commercialFac.Get(1);
            return View(c);
        }

        public ActionResult Kontakt()
        {
            Contacts c = contactFac.Get(1);
            return View(c);
        }

        public ActionResult ErrorPage(string error)
        {
            TempData["Error"] = error;
            return View();
        }
    }
}