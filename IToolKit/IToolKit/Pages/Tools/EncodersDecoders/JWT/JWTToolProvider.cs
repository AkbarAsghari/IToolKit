using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.JWT
{
    [Order(6)]
    internal sealed class JWTToolProvider : IToolProvider
    {
        public string Header => "JWT Decoder";

        public string Description => throw new NotImplementedException();
    }
}
