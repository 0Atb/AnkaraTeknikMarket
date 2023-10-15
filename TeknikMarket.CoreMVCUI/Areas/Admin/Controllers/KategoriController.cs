using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Business.Concrete;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.ViewModel.Area.Admin;
using TeknikMarket.Model.ViewModel.Area.Admin.Kategories;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
        private readonly IKategoriBS kategoriBS;
        private readonly IMapper mapper;

        public KategoriController(IKategoriBS kategoriBS, IMapper mapper)
        {
            this.kategoriBS = kategoriBS;
            this.mapper = mapper;
        }

        public IActionResult Liste()
        {
            KategoriListeViewModel model = new KategoriListeViewModel();
            List<Kategori> kategories = kategoriBS.GetAll().ToList();

            model.KategoriListesi = kategories;

            model.KategoriSelectList = kategories.Select(x => new SelectListItem() { Text = x.KategoriGorunum, Value = x.Id.ToString() }).ToList();

            model.KategoriSelectList.Insert(0, new SelectListItem("Lütfen Üst Kategori Seçiniz", "-1"));

            int sira = 0;
            if (kategories.Count == 0)
            {
                sira = 1;
            }
            else
            {
                sira = kategories.OrderByDescending(x => x.Sira).FirstOrDefault().Sira ?? 1;
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(KategoriListeViewModel model)
        {
            //Kategori kategori = new Kategori();
            //kategori.KategoriAdi = model.KategoriAdi;
            //kategori.Sira = model.Sira;
            //kategori.Aktif = model.Aktif;
            //kategori.UstKategoriId = model.UstKategoriId;

            Kategori kategori = mapper.Map<Kategori>(model);


            if (model.UstKategoriId != -1)
            {
                Kategori ustkategori = kategoriBS.Get(x => x.Id == model.UstKategoriId);

                kategori.KategoriGorunum = ustkategori.KategoriGorunum + " > " + model.KategoriAdi;
            }
            else
            {
                kategori.KategoriGorunum = model.KategoriAdi;
            }

            kategori.Id = null;
            kategori.Aktif = model.Aktif;
            kategori.Sira = model.Sira;
            kategori.OlusturmaTarihi = DateTime.Now;
            kategori.GuncellemeTarihi = DateTime.Now;

            kategoriBS.Insert(kategori);

            List<Kategori> kategories = kategoriBS.GetAll();

            int sira = kategories.OrderByDescending(x => x.Sira).FirstOrDefault().Sira ?? 1;

            sira = sira + 1;


            return Json(new { result = true, mesaj = "Kategori Başarıyla Eklendi.", kategoriListesi = kategories, sira = sira });
        }

        public IActionResult Delete(int KategoriId)
        {
            Kategori kategori = kategoriBS.Get(x => x.Id == KategoriId);
            kategoriBS.Delete(kategori);

            List<Kategori> kategories = kategoriBS.GetAll();

            return Json(new { result = true, mesaj = "Kategori Başarıyla Eklendi.", kategoriListesi = kategories });
        }

        public IActionResult GetById(int KategoriId)
        {
            Kategori kategori = kategoriBS.Get(x=>x.Id== KategoriId);
            List<Kategori> kategories = kategoriBS.GetAll();

            return Json(new { result = true,kategori = kategori,kategoriListesi=kategories });
        }

        public IActionResult Update(KategoriListeViewModel model)
        {
            Kategori kategori = mapper.Map<Kategori>(model);
            if (model.UstKategoriId != -1)
            {
                Kategori ustkategori = kategoriBS.Get(x => x.Id == model.UstKategoriId);

                kategori.KategoriGorunum = ustkategori.KategoriGorunum + " > " + model.KategoriAdi;

            }
            else
            {
                kategori.KategoriGorunum = model.KategoriAdi;
            }

            kategori.Aktif = model.Aktif;
            kategori.Sira = model.Sira;
            kategori.OlusturmaTarihi = DateTime.Now;
            kategori.GuncellemeTarihi = DateTime.Now;

            kategoriBS.Update(kategori);

            List<Kategori> kategories = kategoriBS.GetAll();

            return Json(new { result = true, mesaj = "Kategori Başarıyla Güncellendi.", kategoriListesi= kategories});
        }

        public IActionResult Aktiflik(int KategoriId,bool Aktiflik)
        {
            Kategori k = kategoriBS.Get(x=>x.Id== KategoriId);
            if (k!=null)
            {
                k.Aktif = Aktiflik;
                kategoriBS.Update(k);
            }

            string mesaj = "";

            if (k.Aktif)
            {
                mesaj = "Kategori Başarıyla Aktifleştirildi";
            }
            else
            {
                mesaj = "Kategori Başarıyla Pasifleştirildi";
            }
            return Json(new { result = true,mesaj = mesaj});

        }
    }
}
