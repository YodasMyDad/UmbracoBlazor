using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorExample.Components.Components.PropertyEditors;

/// <summary>
/// In this example we use the property editor example on Umbraco docs site 
/// </summary>
/// <example>
///  https://our.umbraco.com/documentation/Tutorials/creating-a-property-editor/#setting-up-a-plugin
/// </example>
public partial class SuggestionsExample : ComponentBase
{
    [Inject] public IJSRuntime JS { get; set; }
    [Inject] public HttpClient HttpClient { get; set; }
    private string? _suggestionValue;
    private readonly List<string?> _suggestions = new()
    {
        "You should take a break",
        "I suggest that you visit the Eiffel Tower",
        "How about starting a book club today or this week?",
        "Go outside for a walk",
        "Book CodeGarden tickets"
    };
    
    protected override async Task OnInitializedAsync()
    {
        _suggestionValue = await JS.InvokeAsync<string>("suggestionValue");
    }

    private async Task GetSuggestions()
    {
        _suggestionValue = _suggestions.MinBy(x => Guid.NewGuid());
        await JS.InvokeVoidAsync("setSuggestionValue", _suggestionValue);
    }
}