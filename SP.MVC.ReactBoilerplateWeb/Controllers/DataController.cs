﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SP.MVC.ReactBoilerplateWeb.Controllers
{
    public class DataController : ApiController
    {
        // GET: api/Data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Data/5
        [SharePointContextWebAPIFilter]
        [System.Web.Http.HttpGet]
        public string Get(int id)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext.Current);

            Microsoft.SharePoint.Client.User spUser = null;
            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    spUser = clientContext.Web.CurrentUser;

                    clientContext.Load(spUser, user => user.Title);

                    clientContext.ExecuteQuery();
                }
            }
            return "user: " + spUser.Title + " - " + id;
        }

        // POST: api/Data
        public void Post([FromBody]string value)
        {
            
        }

        // PUT: api/Data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
