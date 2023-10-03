using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Generators.Password
{
    [Parent(GeneratorsGroupToolProvider.InternameName)]
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
