using IToolKit.API.Interfaces;

namespace IToolKit.Pages.Tools.EncodersDecoders.JWT
{
    internal sealed class JWTToolProvider : IToolProvider
    {
        public string Header => "JWT Decoder";

        public string Description => throw new NotImplementedException();
    }
}
