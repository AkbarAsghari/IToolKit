using IToolKit.API.Enums.Components;
using Microsoft.AspNetCore.Components;

namespace IToolKit.Shared.Components;

partial class CustomImage
{
    [Parameter] public ImageTypeEnum ImageType { get; set; } = ImageTypeEnum.File;

    protected override Task OnParametersSetAsync()
    {
        switch (ImageType)
        {
            case ImageTypeEnum.Base64:
                Src = $"data:image/jpeg;base64,{Src}";
                break;
            case ImageTypeEnum.File:
            default:
                break;
        }
        return base.OnParametersSetAsync();
    }
}
