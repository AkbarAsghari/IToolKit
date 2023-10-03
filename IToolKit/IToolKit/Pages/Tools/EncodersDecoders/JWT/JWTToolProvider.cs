using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.JWT
{
    [Order(6)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class JWTToolProvider : IToolProvider
    {
        public string Header => "JWT Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();

        public string Route => "JWT";

        public Type Component => typeof(JWT);
    }
}
