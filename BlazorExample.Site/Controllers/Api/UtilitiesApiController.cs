using System.Linq;
using BlazorExample.Shared.Models.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace BlazorExample.Site.Controllers.Api;

public class UtilitiesApiController  : ControllerBase
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly BlazorExampleAppSettings _blazorExampleAppSettings;

    public UtilitiesApiController(IUmbracoContextAccessor umbracoContextAccessor, IOptions<BlazorExampleAppSettings> options)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
        _blazorExampleAppSettings = options.Value;
    }
    
    [HttpGet]
    [Route("/Api/UtilitiesApi/GetWebsiteContent")]
    public string GetWebsiteContent()
    {
        _umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext);
        var contentType = umbracoContext.Content.GetContentType("Website");
        var website = umbracoContext.Content.GetByContentType(contentType).FirstOrDefault();
        var websiteModel = website as Website;
        return $"{websiteModel.WebsiteName}. {websiteModel.WebsiteText}";
    }

    [HttpGet]
    [Route("umbraco/_framework/{path}")]
    public IActionResult GetBlazorFiles([FromRoute]string path)
    {
        return Redirect($"{Request.Scheme}://{Request.Host}/_framework/{path}");
    }

}