using IToolKit.API.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;
partial class ToolUI
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment Actions { get; set; }
    [Parameter] public string Header { get; set; }
}
