﻿using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Sitecore.Foundation.Speedy.Extensions;
using Sitecore.Foundation.Speedy.Model;
using Sitecore.Foundation.Speedy.Models.API.ResponseWrapper;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;

/// <summary>
/// Note: This WEB API controller is meant to be used on a developer 'standalone' environment.
/// This file is patched in via:  /App_config/Include/Speedy/Foundation/Foundation.Speedy.Routes.config
/// </summary>
namespace Sitecore.Foundation.Speedy.Controllers
{
    public class CriticalController : ApiController
    {
        /// <summary>
        /// Lookup the the by pass url for a particular item in Sitecore.
        /// </summary>
        /// <param name="id">The Site Guid</param>
        /// <returns>A full site URL that can be used to generate Critical HTML from. Note that by specifying the pass through parameter it turns off any pre-existing critical CSS that might affect the generation.</returns>
        [AllowAnonymous]
        [HttpGet]
        [System.Web.Http.Route("critical/api/get/{id}")]
        public HttpResponseMessage Get([FromUri]string id)
        {
            Item item = Sitecore.Data.Database.GetDatabase("master").GetItem(new Sitecore.Data.ID(id));
            string url = item.GetUrlForContextSite() + $"?{SpeedyConstants.ByPass.ByPassParameter}=true";

            return Request.CreateResponse(HttpStatusCode.OK,
                new WebApiResponse<string>(HttpUtility.HtmlEncode(url)));
        }

        /// <summary>
        /// Submit the critical HTML for storage in Sitecore.
        /// </summary>
        /// <param name="submit">A critical JSON object, contains the object ID and the critical HTML result that is generated by the node application on a developers machine.</param>
        /// <returns>A HTTP verb indicating success</returns>
        [AllowAnonymous]
        [HttpPost]
        [System.Web.Http.Route("critical/api/put")]
        public HttpResponseMessage Put([FromBody] CriticalJson submit)
        {
            Item item = Sitecore.Data.Database.GetDatabase("master").GetItem(new Sitecore.Data.ID(submit.Id));
            using (new SecurityDisabler())
            {
                item.Editing.BeginEdit();
                item.Fields[SpeedyConstants.Fields.CriticalCss].Value = submit.Result;
                item.Editing.EndEdit();
                item.Editing.AcceptChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK,
                new WebApiResponse<bool>(true));
        }
    }
}