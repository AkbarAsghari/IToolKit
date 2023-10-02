using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;
partial class ToolUI
{
    [Parameter] public string Header { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment Actions { get; set; }
}
