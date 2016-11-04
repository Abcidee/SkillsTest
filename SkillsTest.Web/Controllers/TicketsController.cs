using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkillsTest.Domain;
using SkillsTest.Domain.Models;
using SkillsTest.Domain.Services;
using SkillsTest.Web.ViewModels.Tickets;
using System.Configuration;
using SkillsTest.Web.Infrastructure;

namespace SkillsTest.Web.Controllers
{
    public class TicketsController : BaseController
    {
        #region #region CTOR // DTOR

        protected ITicketService _ticketService;
        protected IUserService _userSertvice;

        public TicketsController(IUserService userSertvice, ITicketService ticketService)
        {
            this._ticketService = ticketService;
            this._userSertvice = userSertvice;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this._ticketService.Dispose();
            this._userSertvice.Dispose();
        }

        #endregion


        public ActionResult Index(int page = 1, bool desc = false, string name = "Id")
        {
            return View(new IndexViewModel()
            {
                TicketsPaged = this._ticketService.Get(desc, name, page, Convert.ToInt32(ConfigurationManager.AppSettings["TablePageSize"]))
            });
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                this._ticketService.Add(vm.Ticket);

                return RedirectToAction("Index").Success("Ticket successfully created.");
            }

            return View(vm);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = this._ticketService.GetWithComments(id.Value);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(new EditViewModel()
            {
                Ticket = ticket
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                this._ticketService.Update(vm.Ticket);
                return RedirectToAction("Index").Success("Ticket successfully updated.");
            }

            return View(vm);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = this._ticketService.GetWithComments(id.Value);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(new DeleteViewModel()
            {
                Ticket = ticket
            });
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this._ticketService.Delete(id);
            return RedirectToAction("Index").Success("Ticket successfully deleted.");
        }
    }
}
