using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlazorExample.Site.Controllers;

public class UtilitiesApiController  : UmbracoApiController
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public UtilitiesApiController(IUmbracoContextAccessor umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }
    
    [HttpGet]
    // Umbraco/Api/UtilitiesApi/GetSiteName
    public string GetSiteName()
    {
        _umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext);
        var contentType = umbracoContext.Content.GetContentType("Website");
        var website = umbracoContext.Content.GetByContentType(contentType).FirstOrDefault();
        var websiteModel = website as Website;
        return websiteModel.WebsiteName;
    }
}