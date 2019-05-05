using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventStore.Models;

namespace EventStore.Controllers
{
    public class EventController : Controller
    {
        private EventStoreDB db = new EventStoreDB();

        [AllowAnonymous]
        public ActionResult LastMinuteDeal()
        {
            var events = GetLastMinuteDeal();
            return PartialView("_LastMinuteDeal", events);
        }

        //get last minute deals
        private object GetLastMinuteDeal()
        {
            var events = db.Events
                .Where(a => a.StartDate > DateTime.Now)
                .ToList()
                .Where(a => a.StartDate < DateTime.Now.AddDays(2))
                .OrderBy(a => a.StartDate);
            return events;
        }

        [AllowAnonymous]
        public ActionResult EventSearch(string q, string a)
        {
            var events = GetEvents(q, a);
            return PartialView("_EventSearch", events);
        }

        private List<Event> GetEvents(string searchString1, string searchString2)
        {
            return db.Events
                .Where(a => a.Title.Contains(searchString1))
                .ToList()
                .Where(a => a.City.Contains(searchString2))
                .ToList();
        }

        public ActionResult Register(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event
        [AllowAnonymous]
        public ActionResult Index()
        {
            var events = db.Events.Include(a => a.Type);
            return View(events.ToList());
        }

        // GET: Event/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "Type");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventTypeID,Title,Description,StartDate,EndDate,Organizer,ContactInfo,City,State,MaxTickets,AvailTickets")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "Type", @event.EventTypeID);
            return View(@event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "Type", @event.EventTypeID);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventTypeID,Title,Description,StartDate,EndDate,Organizer,ContactInfo,City,State,MaxTickets,AvailTickets")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "Type", @event.EventTypeID);
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            var events = db.Events.Include(a => a.Type);
            return View(events.ToList());
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
