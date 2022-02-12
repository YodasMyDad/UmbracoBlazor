using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlazorExample.Site.Controllers.Api;

public class UtilitiesApiController  : ControllerBase
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public UtilitiesApiController(IUmbracoContextAccessor umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }
    
    [HttpGet]
    [Route("/Api/UtilitiesApi/GetSiteName")]
    public string GetSiteName()
    {
        _umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext);
        var contentType = umbracoContext.Content.GetContentType("Website");
        var website = umbracoContext.Content.GetByContentType(contentType).FirstOrDefault();
        var websiteModel = website as Website;
        return websiteModel.WebsiteName;
    }

    [HttpGet]
    [Route("umbraco/_framework/{path}")]
    public IActionResult GetBlazorFiles([FromRoute]string path)
    {
        return Redirect($"{Request.Scheme}://{Request.Host}/_framework/{path}");
    }

}