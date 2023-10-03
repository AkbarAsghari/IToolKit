using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Text.RegEx
{
    [Order(2)]
    internal sealed class RegExToolProvider : IToolProvider
    {
        public string Header => "RegEx Tester";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();
        
        public string Route => "RegEx";

        public Type Component => typeof(RegEx);
    }
}
