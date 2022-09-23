using Bit.BlazorUI;
using System.Reflection;

namespace IToolKit.Shared
{
    partial class NavMenu
    {

        public NavMenu()
        {
            AllNavLinks.Add(new BitNavLinkItem
            {
                Name = "Encryption",
                IconName = BitIconName.Switch,
                Links = new List<BitNavLinkItem>
                    {
                        new BitNavLinkItem {
                            Name = "Rijndael",
                            Url = "Encryption/Rijndael",
                            IconName= BitIconName.ReturnKey
                        },
                    }
            });
        }

        private void onChange(string value)
        {
            BasicNoToolTipNavLinks = AllNavLinks.Where(x => x.Name.ToLower().Contains(value.ToLower())).ToList();
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
                Url = "http://example.com",
                Title = "",
                CollapseAriaLabel = "Collapse Home section",
                ExpandAriaLabel = "Expand Home section",
                IconName = BitIconName.Home,
            }
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                BasicNoToolTipNavLinks = AllNavLinks;
                await this.InvokeAsync(() => this.StateHasChanged());
            }
        }
    }
}
