using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Graphics.ColorPicker
{
    [Parent(GraphicsGroupToolProvider.InternalName)]
    [Order(1)]
    internal sealed class ColorPickerToolProvider : IToolProvider
    {
        public string Header => "Color Picker";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
     
        public string Route => "ColorPicker";

        public Type Component => typeof(ColorPicker);
    }
}
