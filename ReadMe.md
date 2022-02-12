## What is this?

This is a simple Umbraco 9 website, showing Blazor WASM running in the back office on a dashboard. This project also shows the setup to have Blazor hosted in the same site as Umbraco, so you don't have to deploy a front and backend. See current problems below.

The way Blazor is running is using a new feature of .Net called Blazor Custom Elements, and you can [read more about that here](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-net-6-rc-1/#blazor-custom-elements)

In addition, if you are a Tailwind Css fan like me. This project shows how to have Tailwind CSS for the front end AND also have it used in the back office with a separate stylesheet, that uses prefixes so it doesn't clash/break the Umbraco styles. The Blazor dashboard is styled using Tailwind CSS.

For me. This is a super exciting project, having Blazor running in the Umbraco back office is a game changer. I'm looking for the community to help get involved and fix the current problems and improve the project.

## Login Details

Just run the site and login to the back office using the below credentials

admin@admin.com  
1234567890

## Current Problems

The biggest issue I had to get Blazor running, is the Umbraco back office uses a base tag in the HTML like so.

`<base href="/umbraco/" />`

This completely screws loading Blazor as it expects the base to be the root of the app `"/"`. To get around this, you have to set the base of Blazor to /umbraco/ a couple of ways.

1) Setting `app.UseBlazorFrameworkFiles("/umbraco");` in the .Site `Startup.cs`
2) Add the following to the Blazor project .csproj file. `<StaticWebAssetBasePath>umbraco</StaticWebAssetBasePath>`

However, while this now fixes the backoffice. It means you cannot use Blazor on the front end of your site. Because it's expected a base of /umbraco/ to load the Blazor boot Json file. This is where I am stuck and looking for help from someone smarter than me. Because the beauty of Blazor will be using it front and back end!

Lastly. This may be a Rider IDE thing or because I'm using Custom Elements. But you can't debug the Blazor files like you would normally in your IDE. Again, looking to the community to help figure it out.