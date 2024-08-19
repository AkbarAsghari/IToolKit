using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;

namespace IToolKit.Client.Pages.Tools.Cipthers.AES
{
    [Parent(CiphersGroupToolProvider.InternalName)]
    [Order(0)]
    internal sealed class AESToolProvider : IToolProvider
    {
        public string Header => "AES";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;

        public string Route => "AES";

        public Type Component => typeof(AES);
    }
}
