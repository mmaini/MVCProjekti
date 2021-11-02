using Microsoft.AspNetCore.Mvc;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class SongController : Controller
    {
        private readonly AppDbContext _db;
        public SongController(AppDbContext db)
        {
            _db = db;
        
        }

        //u ovom primjeru koristimo isti View za Unos i Ažuriranje

        [HttpGet]
        public IActionResult Create()
        {
            //kad pozovemo Create vraćamo praznu pjesmu
            ViewBag.Action = "Unos";
            //dohvaćamo listu žanrova
            ViewBag.Genres = _db.Genres.OrderBy(x => x.Name).ToList();
            //preusmjeravamo na Edit view jer nam on služi za unos/ažuriranje
            return View("Edit",new Song());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //kad pozovemo Edit dohvaćamo pjesmu koju želimo ažurirati i nju prosljeđujemo
            ViewBag.Action = "Ažuriranje";
            //dohvaćamo listu žanrova
            ViewBag.Genres = _db.Genres.OrderBy(x => x.Name).ToList();
            var song = _db.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if(ModelState.IsValid)
            {
                //akp je Id == 0 znači da se radi o unosu nove pjesme (default vrijednost za int je 0)
                if(song.Id ==0)
                {
                    //ako nemamo Id (odnosno 0 je) onda se radi o unosu
                    _db.Songs.Add(song);
                }
                else
                {
                    //u suprotnom se radi o Update-u
                    _db.Songs.Update(song);
                }

                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Action = song.Id == 0 ? "Unos" : "Ažuriranje";
            //dohvaćamo listu žanrova
            ViewBag.Genres = _db.Genres.OrderBy(x => x.Name).ToList();
            return View(song);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var song = _db.Songs.Find(id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            _db.Songs.Remove(song);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
