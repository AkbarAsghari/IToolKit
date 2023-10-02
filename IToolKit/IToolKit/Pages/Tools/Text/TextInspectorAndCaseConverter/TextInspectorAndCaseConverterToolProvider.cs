using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.Text.TextInspectorAndCaseConverter
{
    [Order(1)]
    internal sealed class TextInspectorAndCaseConverterToolProvider : IToolProvider
    {
        public string Header => "Text Case Converter and Inspector";

        public string Description => throw new NotImplementedException();
    }
}
