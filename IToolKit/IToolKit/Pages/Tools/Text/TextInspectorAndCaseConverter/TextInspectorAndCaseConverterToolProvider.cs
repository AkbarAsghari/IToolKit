using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Text.TextInspectorAndCaseConverter
{
    [Parent(TextGroupToolProvider.InternalName)]
    [Order(1)]
    internal sealed class TextInspectorAndCaseConverterToolProvider : IToolProvider
    {
        public string Header => "Text Case Converter and Inspector";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "TextInspectorAndCaseConverter";
        
        public Type Component => typeof(TextInspectorAndCaseConverter);
    }
}
