using IToolKit.API.Interfaces;
using IToolKit.API.Tools.Attributes;

namespace IToolKit.Pages.Tools.Generators.Password
{
    [Order(3)]
    internal sealed class PasswordToolProvider : IToolProvider
    {
        public string Header => "Password Generator";

        public string Description => throw new NotImplementedException();
    }
}
