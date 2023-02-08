using Bit.BlazorUI;
using System.Reflection;

namespace IToolKit.Shared
{
    partial class NavMenu
    {
        public class IToolKitMenu
        {
            public string Text { get; set; } = string.Empty;
            public string Url { get; set; } = string.Empty;
            public bool IsEnabled { get; set; } = true;
            public BitIconName Icon { get; set; }
            public List<IToolKitMenu> Links { get; set; } = new();
        }

        public NavMenu()
        {
        }

        private void onClearSearch()
        {
            searchedText = String.Empty;
        }
        private void onChange(string value)
        {
            searchedText = value;
        }
        private string searchedText = String.Empty;
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private async Task ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            await this.InvokeAsync(() => StateHasChanged());
        }

        private async Task ToggleNavMenu(bool toggle)
        {
            if (toggle)
            {
                await ToggleNavMenu();
            }
        }

        private readonly List<IToolKitMenu> AllNavLinks = new()
        {
            new IToolKitMenu
            {
                Text = "Home",
                Url = "/",
                Icon = BitIconName.Home,
            },
            new IToolKitMenu
            {
                Text = "Encode/Decode",
                Icon = BitIconName.ChangeEntitlements,
                Links = new List<IToolKitMenu>
                {
                    new IToolKitMenu
                    {
                        Text = "Base64 Text",
                        Url = "EncodersDecoders/Base64",
                    },
                    new IToolKitMenu
                    {
                        Text = "Base32 Text",
                        Url = "EncodersDecoders/Base32",
                    },
                    new IToolKitMenu
                    {
                        Text = "URL",
                        Url = "EncodersDecoders/URL",
                    },
                    new IToolKitMenu
                    {
                        Text = "HTML",
                        Url = "EncodersDecoders/HTML",
                    }
                }
            },
            new IToolKitMenu
            {
                Text = "Generators",
                Icon = BitIconName.Generate,
                Links = new List<IToolKitMenu>
                {
                    new IToolKitMenu
                    {
                        Text = "Hash",
                        Url = "Generators/Hash",
                    },
                    new IToolKitMenu
                    {
                        Text = "UUID",
                        Url = "Generators/UUID",
                    },
                }
            },
            new IToolKitMenu
            {
                Text = "Ciphers",
                Icon = BitIconName.Permissions,
                Links = new List<IToolKitMenu>
                {
                    new IToolKitMenu
                    {
                        Text = "AES",
                        Url = "Ciphers/AES" ,
                    }
                }
            },
            new IToolKitMenu
            {
                Text = "Graphics",
                Icon = BitIconName.PictureStretch,
                Links = new List<IToolKitMenu>
                {
                    new IToolKitMenu
                    {
                        Text = "Color Picker",
                        Url = "Graphics/ColorPicker",
                    },
                }
            },
            new IToolKitMenu
            {
                Text = "Text",
                Icon = BitIconName.InsertTextBox,
                Links = new List<IToolKitMenu>
                {
                    new IToolKitMenu
                    {
                        Text = "Inspector And CaseConverter",
                        Url = "Text/TextInspectorAndCaseConverter",
                    }
                }
            },
            new IToolKitMenu
            {
                Text = "Repository",
                Icon = BitIconName.OpenSource,
                Url = "https://github.com/AkbarAsghari/IToolKit"
            }
        };
    }
}
