using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.Cipthers.AES
{
    [Order(1)]
    internal sealed class AESToolProvider : IToolProvider
    {
        public string Header => "AES";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => throw new NotImplementedException();

        public string Route => "AES";

        public Type Component => typeof(AES);
    }
}
