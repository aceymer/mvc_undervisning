using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jysk2_0.ToastrHelper;
using Jysk2_0.Models;
using Jysk2_0.Attributes;

namespace Jysk2_0.Controllers
{
    public class PapersController : AbstractMessageController
    {
        private JyskDBEntities db = new JyskDBEntities();

        // GET: Papers
        public ActionResult Index()
        {
            List<Paper> papers =  db.Papers.ToList();
            PaperListViewModel viewModel = new PaperListViewModel();
            viewModel.PaperSelectedList = papers.Select(x => new PaperSelectedViewModel() { Paper = x }).ToList();
            return View(viewModel);
        }

        // GET: Papers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = await db.Papers.FindAsync(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }
        [AccessDeniedAuthorizeAttribute(Roles = "Admin")]
        // GET: Papers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessDeniedAuthorizeAttribute(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Amount,Readers,PricePrMM")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Papers.Add(paper);
                await db.SaveChangesAsync();
                this.AddToastMessage("Congratulations", "Paper is created", ToastType.Success);
                return RedirectToAction("Index");
            }

            return View(paper);
        }

        // GET: Papers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = await db.Papers.FindAsync(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Amount,Readers,PricePrMM")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = await db.Papers.FindAsync(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        public JavaScriptResult DeleteConfirmed(int id)
        {
            Paper paper = db.Papers.Find(id);
            this.AddToastMessage("Congratulations", "You have deleted the paper!!!", ToastType.Success);
            db.Papers.Remove(paper);
            db.SaveChanges();
            return JavaScript("location.reload(true)");
        }

        [HttpPost]
        public async Task<ActionResult> ReCalculate(string ids, string strSelected)
        {
            this.AddToastMessage("Congratulations", "You made it all the way here!", ToastType.Success);
            RecalcViewModel viewModel = new RecalcViewModel();
            List<Color> colors = await db.Colors.ToListAsync();
            int parsedValue = 0;

            if (Int32.TryParse(strSelected, out parsedValue))
            {
                viewModel.Colors = new SelectList(colors, "Id", "Name", new { id = parsedValue });
                viewModel.SelectedColorId = parsedValue;
            }
            else
            {
                viewModel.Colors = new SelectList(colors, "Id", "Name");
            }
            viewModel.ColumnWidths = new SelectList(await db.ColumnWidths.ToListAsync(), "Id", "ColumnWidthString");
            viewModel.PaperTypes = new SelectList(await db.PaperTypes.ToListAsync(), "Id", "Name");

            ViewBag.Id = ids;
            return PartialView("_Recalc", viewModel);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
