## What is this?

This is a simple Umbraco 9 website, showing Blazor WASM running in the back office on a dashboard. This project also shows the setup to have Blazor hosted in the same site as Umbraco, so you don't have to deploy a front and backend. See current problems below.

The way Blazor is running is using a new feature of .Net called Blazor Custom Elements, and you can [read more about that here](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-net-6-rc-1/#blazor-custom-elements)

In addition, if you are a Tailwind Css fan like me. This project shows how to have Tailwind CSS for the front end AND also have it used in the back office with a separate stylesheet, that uses prefixes so it doesn't clash/break the Umbraco styles. The Blazor dashboard is styled using Tailwind CSS.

For me. This is a super exciting project, having Blazor running in the Umbraco back office is a game changer. I'm looking for the community to help get involved and fix the current problems and improve the project.

## What Components?

#### Twitter Dashboard

Simple Twitter dashboard that displays the latest tweets from the #umbraco hashtag, build in Blazor. Auto refreshes every 10 seconds to show latest tweets.

You will need to add in your own Twitter API credentials from [https://developer.twitter.com/en/portal/projects-and-apps](https://developer.twitter.com/en/portal/projects-and-apps)

Also calls the AngularJs notificationService.success once tweets are fetched.

#### Reading Content

Little component that grabs the content from the root website node when you click a button.

#### Blazor Property Editor

A copy of the Suggestions example property editor in the [Umbraco Docs](https://our.umbraco.com/documentation/Tutorials/creating-a-property-editor/), but built in Blazor which is pretty cool.

Allows the value to be sent back to the AngularJs scope so the value can be saved, when the page is saved. 

## Login Details

Just run the site and login to the back office using the below credentials.

admin@admin.com  
1234567890

Don't forget to run NPM if you want to change anything to do with Tailwind.

## Work Arounds

Because the Blazor.Webassembly.js relies on the base url to fetch the blazor.boot.json file, which will contain the /umbraco/ url when called from the back-office, the only way to get it working would be to have it fully configured to work from the Frontend first, and then have an additional controller redirecting the /umbraco/_framework/* files back to the original frontend url so that every file can be fetched!

However, this is working fine with the controller.

[Read more here](https://github.com/dotnet/aspnetcore/issues/22220)

Also, had to set 

`"bundleOptions": "None"`

in the package.manifest to stop Umbraco bundling and minifying the scripts, which broke Blazor in production.
