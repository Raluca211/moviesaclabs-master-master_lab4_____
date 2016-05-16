using AutoMapper;
using MoviesACLabs.Data;
using MoviesACLabs.Entities;
using MoviesACLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MoviesACLabs.Controllers
{

    
    public class AwardsController : ApiController
    {

        // private static int x = 5;

        //private int y = 6;

        private MoviesContext db = new MoviesContext();

        public static List<AwardModel> list=new List<AwardModel>();
        public static int countId=0;


        // GET: api/Awards
        public IList<AwardModel> GetAwards()
        {
            var awards = db.Awards;
            var awardsModel = Mapper.Map<IList<AwardModel>>(awards);
            return awardsModel;
        }

        // GET: api/Awards/5
        [ResponseType(typeof(AwardModel))]
        public IHttpActionResult GetAward(int id)
        {
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return NotFound();
            }

            var awardModel = Mapper.Map<AwardModel>(award);

            return Ok(awardModel);
        }

        

        // POST: api/Awards
        [ResponseType(typeof(AwardModel))]
        public IHttpActionResult PostAward(AwardModel awardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var award = Mapper.Map<Award>(awardModel);

            db.Awards.Add(award);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = award.Id }, award);
        }

        // DELETE: api/Awards/5
        public IHttpActionResult DeleteAward(int id)
        {
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return NotFound();
            }

            db.Awards.Remove(award);
            db.SaveChanges();

            return Ok();
        }


        // PUT: api/Awards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAward(int id, AwardModel awardModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != awardModel.Id)
            {
                return BadRequest();
            }

            var actor = Mapper.Map<Award>(awardModel);

            db.Entry(actor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardExists(id))
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
        private bool AwardExists(int id)
        {
            return db.Awards.Any(e => e.Id == id);
        }


        /*public AwardModel GetAward()
        {
            x++;
            y++;
            var award = new AwardModel() { Id=0, ActorId = 2, Title = "Academy Award", Description = "jsbfhjsf" };

            return award;
        }*/
        /*
        public void PostAward(AwardModel award)
        {
            countId++;
            award.Id = countId;
            list.Add(award);
            
        }*/

        /* [Route("myAward/{id:int}")]
         public AwardModel GetAward(int id)
         {


             foreach(AwardModel element in list)
             {

                 if (element.Id == id)
                 {
                     return element;
                 }

             }

             return null;


         }

         public Boolean DeleteAward(int id)
         {
             foreach (AwardModel element in list)
             {

                 if (element.Id == id)
                 {
                     list.Remove(element);
                     return true;
                 }

             }

             return false;

         }*/


    }
}
