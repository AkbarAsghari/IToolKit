using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;

partial class ToolProviderGridItem
{
    [Parameter] public string Link { get; set; }
    [Parameter] public string Title { get; set; }
    [Parameter] public string Description { get; set; }
    [Parameter] public string Icon { get; set; }
}
