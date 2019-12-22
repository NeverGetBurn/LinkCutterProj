using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LinkCutter.Models;

namespace LinkCutter.Controllers
{
    public class LinkController : Controller
    {
        private readonly Repo repo; //объект репозитория CRUD
        public LinkController(Repo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index() //при обращение получает все объекты из бд
        {
            var model = repo.GetLinks();
            return View(model);
        }

        public IActionResult LinkEdit(Guid id)
        {
            Link model = id == default ? new Link() : repo.FindLink(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult LinkEdit(Link model)
        {
            if (ModelState.IsValid)
            {
                if (repo.AlreadyInBD(model))
                {
                    ViewBag.Error = "Ссылка уже есть в базе данных";
                    return View(model);
                }

                model.CreationTime = DateTime.Now.ToString("dd:MM:yyyy");
                model.ShortName = Cutter.GetShortLink();
                repo.SaveLink(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult LinkDelete(Guid id)
        {
            repo.DeleteLink(new Link() { Id = id });
            return RedirectToAction("Index");
        }

        public IActionResult LinkRedirect(Guid id)
        {
            var model = repo.FindLink(id);
            model.RedirectCount += 1;
            repo.SaveLink(model);
            return Redirect(model.LongName);
        }
    }
}
