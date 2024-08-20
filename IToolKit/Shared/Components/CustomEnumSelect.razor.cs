using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace IToolKit.Shared.Components;

partial class CustomEnumSelect<T> where T : Enum
{
    protected override void OnInitialized()
    {
        Variant = Variant.Outlined;

        RenderFragment SelectItems = (builder) =>
        {
            foreach (var item in Enum.GetValues(typeof(T)).Cast<T>())
            {
                builder.OpenComponent(0, typeof(MudSelectItem<T>));
                builder.AddAttribute(1, "Value", item);
                builder.CloseComponent();
            }
        };

        ChildContent = SelectItems;
    }
}
