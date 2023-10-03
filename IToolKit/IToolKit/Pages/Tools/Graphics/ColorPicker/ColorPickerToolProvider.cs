using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Graphics.ColorPicker
{
    [Order(1)]
    internal sealed class ColorPickerToolProvider : IToolProvider
    {
        public string Header => "Color Picker";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
     
        public string Route => "ColorPicker";

        public Type Component => typeof(ColorPicker);
    }
}
