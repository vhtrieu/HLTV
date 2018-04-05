
namespace HLTV.Web.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using HLTV.Web.Models;
    public class HOCVIENsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region Api in use 
        [ResponseType(typeof(HOCVIEN))]
        public IHttpActionResult GetHOCVIEN(string SearchText)
        {
            var query = (from x in db.HOCVIENs
                         join y in db.HOCVIEN_IMGs on x.HOV_ID equals y.IMG_HOVID
                         where SearchText.Equals(x.HOV_FullName) || SearchText.Equals(x.HOV_FirstName) || SearchText.Equals(x.HOV_LastName)
                               || SearchText.Equals(x.HOV_Phone) || SearchText.Equals(x.HOV_BirthDay)
                         select new { x, y }).ToList().Select(t => new HOCVIEN
                         {
                            HOV_ID= t.x.HOV_ID,
                             HOV_FullName =t.x.HOV_FullName,
                             HOV_BirthDay= t.x.HOV_BirthDay,
                             HOV_NoiSinh=t.x.HOV_NoiSinh,
                             HOV_QuocTich=t. x.HOV_QuocTich,
                             IMG_Image = ((t.y.IMG_Image == null) ? null : ((from a in db.HOCVIEN_IMGs where (a.IMG_HOVID == t.x.HOV_ID) select a.IMG_Image).FirstOrDefault()))
                         }).ToList();
            return Ok(query);

            
        }

        // GET: api/HOCVIENs/5
        [ResponseType(typeof(HOCVIEN))]
        public IHttpActionResult GetHOCVIEN(int id)
        {
            HOCVIEN hOCVIEN = db.HOCVIENs.Find(id);


            var query = (from x in db.HOCVIENs
                         join y in db.HOCVIEN_IMGs on x.HOV_ID equals y.IMG_HOVID
                         join z in db.CAP_CHUNGCHIs on x.HOV_ID equals z.CCC_HOVID
                         join w in db.CHUNG_CHIs on z.CCC_CHCID equals w.CHC_ID
                         where z.CCC_HOVID == id
                         select new { x, y,z,w }).ToList().Select(t => new HOCVIEN
                         {
                             HOV_ID = t.x.HOV_ID,
                             HOV_FullName = t.x.HOV_FullName,
                             HOV_BirthDay = t.x.HOV_BirthDay,
                             HOV_NoiSinh = t.x.HOV_NoiSinh,
                             HOV_QuocTich = t.x.HOV_QuocTich,
                             IMG_Image = ((t.y.IMG_Image == null) ? null : ((from a in db.HOCVIEN_IMGs where (a.IMG_HOVID == t.x.HOV_ID) select a.IMG_Image).FirstOrDefault())),
                             CCC_SoCC = t.z.CCC_SoCC,
                             CCC_NgayCap = t.z.CCC_NgayCap,
                             CCC_NgayHetHan = t.z.CCC_NgayHetHan,
                             CCC_Status = t.z.CCC_Status,//CCC_Status =1 => "Cấp mới"| CCC_Status = 2 => "Cấp đổi" | CCC_Status = 3 =>"Cấp lại"
                             CHC_Name = t.w.CHC_Name
                             
                         }).ToList();
            return Ok(query);
        }
        #endregion Api in use 



        // GET: api/HOCVIENs
        public IQueryable<HOCVIEN> GetHOCVIENs()
        {
            return db.HOCVIENs;
        }

        // PUT: api/HOCVIENs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHOCVIEN(int id, HOCVIEN hOCVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hOCVIEN.HOV_ID)
            {
                return BadRequest();
            }

            db.Entry(hOCVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HOCVIENExists(id))
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

        // POST: api/HOCVIENs
        [ResponseType(typeof(HOCVIEN))]
        public IHttpActionResult PostHOCVIEN(HOCVIEN hOCVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HOCVIENs.Add(hOCVIEN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hOCVIEN.HOV_ID }, hOCVIEN);
        }

        // DELETE: api/HOCVIENs/5
        [ResponseType(typeof(HOCVIEN))]
        public IHttpActionResult DeleteHOCVIEN(int id)
        {
            HOCVIEN hOCVIEN = db.HOCVIENs.Find(id);
            if (hOCVIEN == null)
            {
                return NotFound();
            }

            db.HOCVIENs.Remove(hOCVIEN);
            db.SaveChanges();

            return Ok(hOCVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HOCVIENExists(int id)
        {
            return db.HOCVIENs.Count(e => e.HOV_ID == id) > 0;
        }
    }
}