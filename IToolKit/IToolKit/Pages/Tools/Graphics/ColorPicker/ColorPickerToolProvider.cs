using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.Graphics.ColorPicker
{
    [Order(1)]
    internal sealed class ColorPickerToolProvider : IToolProvider
    {
        public string Header => "Color Picker";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
    }
}
