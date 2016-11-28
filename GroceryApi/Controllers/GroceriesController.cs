using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroceryDataAccess;
using System.Threading;

namespace GroceryApi.Controllers
{
    public class GroceriesController : ApiController
    {

        public HttpResponseMessage Get(string Done="All")
        {

            using(GroceryDBEntities entities = new GroceryDBEntities())
            {
                switch(Done.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Groceries.ToList());
                    case "yes":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Groceries.Where(e => e.Done.ToLower() == "yes").ToList());
                    case "no":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Groceries.Where(e => e.Done.ToLower() == "no").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                                           
            }
            
        }

        public Grocery Get(int id)
        {
            using (GroceryDBEntities entities = new GroceryDBEntities())
            {
                return entities.Groceries.FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
