using FirebaseClassLibrary.Entities;
using FirebaseClassLibrary.Services;
using FirebaseWebApplication.Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace FirebaseWebApplication.Controllers.Api
{
    public abstract class BaseApiController<T> : ApiController where T : class, ApiItem, DbItem, new()
    {
        protected WebApiDbContext db = new WebApiDbContext();

        [Route()]
        [HttpGet]
        public IQueryable<T> GetItems()
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "GetItems" });
            });
            return db.Set<T>();
        }

        [Route("{subItem}")]
        [HttpGet]
        public IQueryable<T> GetItems(string subItem)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "GetItems with subItem" });
            });
            return db.Set<T>().Include(subItem);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> GetItem(long id)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "GetItem" });
            });
            T item = await db.Set<T>().FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [Route()]
        [HttpGet]
        public async Task<IHttpActionResult> GetItemWithSub(long id, string subItem)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "GetItemWithSub" });
            });
            T item = await db.Set<T>().Include(subItem).FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutItem(long id, T item)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "PutItem" });
            });
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        [Route()]
        [HttpPost]
        public async Task<IHttpActionResult> PostItem(T item)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "PostItem" });
            });
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Set<T>().Add(item);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteItem(long id)
        {
            Task.Factory.StartNew(() =>
            {
                RealtimeDatabaseService.Instance.LogApiAction(new T().GetType().Name, new FirebaseLog() { CurrentTime = DateTime.Now, Data = "DeleteItem" });
            });
            T item = await db.Set<T>().FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Set<T>().Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(long id)
        {
            return db.Set<T>().Count(e => e.Id == id) > 0;
        }
    }
}