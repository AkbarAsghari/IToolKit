using Bit.BlazorUI;

namespace IToolKit.Shared
{
    partial class NavMenu
    {
        private void onChange(string value)
        {
            BasicNoToolTipNavLinks = AllNavLinks.Where(x => x.Name.Contains(value)).ToList();
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
            },
            new BitNavLinkItem
            {
                Name = "Converters",
                IconName = BitIconName.ChangeEntitlements,
                Links = new List<BitNavLinkItem>
                {
                    new BitNavLinkItem { Name = "Timestamp", Url = "http://msn.com", IconName= BitIconName.Clock },
                }
            },
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
