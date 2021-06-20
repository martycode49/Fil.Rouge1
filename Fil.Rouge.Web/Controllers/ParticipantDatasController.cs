﻿namespace Fil.Rouge.Web.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Fil.Rouge.Web.Services;
    using Fil.Rouge.Web.Models;

    public class ParticipantDatasController : Controller
    {
        //private FilRougeContext db = new FilRougeContext();
        private readonly ParticipantDataService participantDataService = new ParticipantDataService();

        // GET: Quiz/5
        public async Task<ActionResult> Index()
        {
            var list = await participantDataService.GetAll();
            return View(list);
        }

        // GET: Quizs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quiz = await participantDataService.Get((int)id);

            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        public async Task<ActionResult> Create()
        {
            var vm = new CreateUpdateViewModel();
            return View(vm);
        }

        // POST: Quizs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await participantDataService.Create(vm.ParticipantData);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Quizs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quiz = participantDataService.Get((int)id);
            if (quiz == null)
            {
                return HttpNotFound();
            }

            var vm = new CreateUpdateViewModel
            {
                ParticipantData = await quiz
            };
            return View(vm);
        }

        // POST: Quizs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await participantDataService.Update(vm.ParticipantData.Id, vm.ParticipantData);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Quizs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var quiz = await participantDataService.Get((int)id);

            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await participantDataService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
