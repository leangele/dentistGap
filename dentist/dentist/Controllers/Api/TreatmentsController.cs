using Newtonsoft.Json;
using System.Web.Http;

namespace dentist.Controllers.Api
{
    public class TreatmentsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TreatmentsController()
        {
            
        }

        // GET: api/Me
        [Authorize]
        public string GetTreatments()
        {
            var treatments = _unitOfWork.Treatment.GetTreatments();
            return JsonConvert.SerializeObject(treatments);
        }

        //GET: api/Treatments/5
        [Authorize]
        public string GetTreatment(int id)
        {
            var treatment = _unitOfWork.Treatment.GetTreatment(id);
            //if (treatment == null)
            //{
            //    return NotFound();
            //}

            return JsonConvert.SerializeObject(treatment);
        }

        //// PUT: api/Treatments/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutTreatment(int id, Treatment treatment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != treatment.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(treatment).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TreatmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Treatments
        //[ResponseType(typeof(Treatment))]
        //public async Task<IHttpActionResult> PostTreatment(Treatment treatment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Treatments.Add(treatment);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = treatment.Id }, treatment);
        //}

        //// DELETE: api/Treatments/5
        //[ResponseType(typeof(Treatment))]
        //public async Task<IHttpActionResult> DeleteTreatment(int id)
        //{
        //    Treatment treatment = await db.Treatments.FindAsync(id);
        //    if (treatment == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Treatments.Remove(treatment);
        //    await db.SaveChangesAsync();

        //    return Ok(treatment);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TreatmentExists(int id)
        //{
        //    return db.Treatments.Count(e => e.Id == id) > 0;
        //}
    }
}