namespace Fil.Rouge.Web.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Fil.Rouge.Web.Services;
    using Fil.Rouge.Web.Models;

    public class AgentsController : Controller
    {
        //private FilRougeContext db = new FilRougeContext();
        private readonly AgentService agentService = new AgentService();

        // GET: Agents
        public async Task<ActionResult> Index()
        {
            var list = await agentService.GetAll();
            return View(list);
        }

        // GET: Agents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = await agentService.Get((int)id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            var vm = new CreateUpdateViewModel();
            return View(vm);
        }

        // POST: Agents/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await agentService.Create(vm.Agent);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Agents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = agentService.Get((int)id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            var vm = new CreateUpdateViewModel
            {
                Agent = await agent
            };
            return View(vm);
        }

        // POST: Agents/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await agentService.Update(vm.Agent.Id, vm.Agent);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Agents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = await agentService.Get((int)id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await agentService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
