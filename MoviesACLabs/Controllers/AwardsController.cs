using MoviesACLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesACLabs.Controllers
{

    
    public class AwardsController : ApiController
    {

        private static int x = 5;

        private int y = 6;

        public static List<AwardModel> list=new List<AwardModel>();
        public static int countId=0;


        public AwardModel GetAward()
        {
            x++;
            y++;
            var award = new AwardModel() { Id=0, ActorId = 2, Title = "Academy Award", Description = "jsbfhjsf" };

            return award;
        }

        public void PostAward(AwardModel award)
        {
            countId++;
            award.Id = countId;
            list.Add(award);
            
        }

        [Route("myAward/{id:int}")]
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

        }


    }
}
