using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RealTimeApp.DAL;

namespace RealTimeApp.Models
{
    public class TimeController : ApiController
    {
        private TimeContext db = new TimeContext();

        // GET api/Time
        public IEnumerable<Month> GetMonths()
        {
            return db.Months.AsEnumerable();
        }

        // GET api/Time/5
        public Month GetMonth(int id)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return month;
        }

        // PUT api/Time/5
        public HttpResponseMessage PutMonth(int id, Month month)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != month.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(month).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Time
        public HttpResponseMessage PostMonth(Month month)
        {
            if (ModelState.IsValid)
            {
                db.Months.Add(month);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, month);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = month.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Time/5
        public HttpResponseMessage DeleteMonth(int id)
        {
            Month month = db.Months.Find(id);
            if (month == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Months.Remove(month);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, month);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}