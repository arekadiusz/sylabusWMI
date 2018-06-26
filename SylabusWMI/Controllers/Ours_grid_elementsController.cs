﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SylabusWMI.Models;

namespace SylabusWMI.Controllers
{
    public class Ours_grid_elementsController : ApiController
    {
        private sylabusWMIEntities db = new sylabusWMIEntities();

        // GET: api/Ours_grid_elements
        public IQueryable<Ours_grid_elements> GetOurs_grid_elements()
        {
            return db.Ours_grid_elements;
        }

        // GET: api/Ours_grid_elements/5
        [ResponseType(typeof(Ours_grid_elements))]
        public async Task<IHttpActionResult> GetOurs_grid_elements(int id)
        {
            Ours_grid_elements ours_grid_elements = await db.Ours_grid_elements.FindAsync(id);
            if (ours_grid_elements == null)
            {
                return NotFound();
            }

            return Ok(ours_grid_elements);
        }

        // PUT: api/Ours_grid_elements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOurs_grid_elements(int id, Ours_grid_elements ours_grid_elements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ours_grid_elements.Id)
            {
                return BadRequest();
            }

            db.Entry(ours_grid_elements).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ours_grid_elementsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ours_grid_elements
        [ResponseType(typeof(Ours_grid_elements))]
        public async Task<IHttpActionResult> PostOurs_grid_elements(Ours_grid_elements ours_grid_elements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ours_grid_elements.Add(ours_grid_elements);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Ours_grid_elementsExists(ours_grid_elements.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ours_grid_elements.Id }, ours_grid_elements);
        }

        // DELETE: api/Ours_grid_elements/5
        [ResponseType(typeof(Ours_grid_elements))]
        public async Task<IHttpActionResult> DeleteOurs_grid_elements(int id)
        {
            Ours_grid_elements ours_grid_elements = await db.Ours_grid_elements.FindAsync(id);
            if (ours_grid_elements == null)
            {
                return NotFound();
            }

            db.Ours_grid_elements.Remove(ours_grid_elements);
            await db.SaveChangesAsync();

            return Ok(ours_grid_elements);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ours_grid_elementsExists(int id)
        {
            return db.Ours_grid_elements.Count(e => e.Id == id) > 0;
        }
    }
}