using Bit.BlazorUI;
using System.Reflection;

namespace IToolKit.Shared
{
    partial class NavMenu
    {

        public NavMenu()
        {
        }
        private void onClearSearch()
        {
            BasicNoToolTipNavLinks = AllNavLinks;
        }
        private void onChange(string value)
        {
            BasicNoToolTipNavLinks = AllNavLinks.Where(x =>
           x.Name.ToLower().Contains(value.ToLower()) ||
           x.Links.Any(l => l.Name.ToLower().Contains(value.ToLower()))).ToList();
        }

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private List<BitNavLinkItem> BasicNoToolTipNavLinks = new List<BitNavLinkItem>();

        private readonly List<BitNavLinkItem> AllNavLinks = new()
        {
            new BitNavLinkItem
            {
                Name = "Home",
                Url = "/",
                Title = "",
                Key = "Key1",
                CollapseAriaLabel = "Collapse Home section",
                ExpandAriaLabel = "Expand Home section",
                IconName = BitIconName.Home,
            },
            new BitNavLinkItem
            {
                Name = "Encode/Decode",
                Key = "Key3" ,
                IconName = BitIconName.ChangeEntitlements,
                Links = new List<BitNavLinkItem>
                {
                    new BitNavLinkItem
                    {
                        Name = "Base64 Text",
                        Url = "EncodersDecoders/Base64TextEncoderDecoder",
                        Key = "Key4" ,
                    },
                    new BitNavLinkItem
                    {
                        Name = "Base32 Text",
                        Url = "EncodersDecoders/Base32TextEncoderDecoder",
                        Key = "Key5" ,
                    },
                    new BitNavLinkItem
                    {
                        Name = "URL",
                        Url = "EncodersDecoders/URL",
                        Key = "Key6" ,
                    },
                    new BitNavLinkItem
                    {
                        Name = "HTML",
                        Url = "EncodersDecoders/HTML",
                        Key = "Key7" ,
                    }
                }
            },
            new BitNavLinkItem
            {
                Name = "Graphics",
                Key = "Key8",
                IconName = BitIconName.PictureStretch,
                Links = new List<BitNavLinkItem>
                {
                    new BitNavLinkItem
                    {
                        Name = "Color Picker",
                        Url = "Graphics/ColorPicker",
                        Key = "Key9" ,
                    },
                }
            },
            new BitNavLinkItem
            {
                Name = "Generators",
                Key = "Key2",
                IconName = BitIconName.Generate,
                Links = new List<BitNavLinkItem>
                {
                    new BitNavLinkItem
                    {
                        Name = "Hash",
                        Url = "Generators/Hash",
                        Key = "Key10" ,
                    },
                    new BitNavLinkItem
                    {
                        Name = "UUID",
                        Url = "Generators/UUID",
                        Key = "Key11" ,
                    },
                }
            },
            new BitNavLinkItem
            {
                Name = "Text",
                Key = "Key12",
                IconName = BitIconName.InsertTextBox,
                Links = new List<BitNavLinkItem>
                {
                    new BitNavLinkItem
                    {
                        Name = "Inspector And CaseConverter",
                        Url = "Text/TextInspectorAndCaseConverter",
                        Key = "Key13" ,
                    }
                }
            }
        };
        void ToggleNavMenu(BitNavLinkItem item)
        {
            ToggleNavMenu();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                AllNavLinks.ForEach(x => x.Links.ToList().ForEach(i => i.OnClick += ToggleNavMenu));
                AllNavLinks.Where(x => x.Links.Count() == 0).ToList().ForEach(x => x.OnClick += ToggleNavMenu);

                BasicNoToolTipNavLinks = AllNavLinks;
                await this.InvokeAsync(() => this.StateHasChanged());
            }
        }
    }
}
