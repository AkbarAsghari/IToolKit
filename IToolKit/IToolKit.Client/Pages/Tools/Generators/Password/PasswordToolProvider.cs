using IToolKit.Client.API.Interfaces;
using IToolKit.Client.API.Attributes;
using IToolKit.Client.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Client.Pages.Tools.Generators.Password
{
    [Parent(GeneratorsGroupToolProvider.InternalName)]
    [Order(3)]
    internal sealed class PasswordToolProvider : IToolProvider
    {
        public string Header => "Password Generator";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Password";
        
        public string Route => "Password";

        public Type Component => typeof(Password);
    }
}
