using IToolKit.Client.API.Assembly;
using IToolKit.Client.API.Interfaces;
using MudBlazor;

namespace IToolKit.Client.Shared.Components.Search
{
    partial class SearchTools
    {
        private MudTheme Theme = new MudTheme();

        MudTextField<string> SearchTextField;
        bool _IsOpen = false;

        List<Tuple<string, IToolProvider>> _FoundTools = new List<Tuple<string, IToolProvider>>();

        void Search(string input)
        {
            _FoundTools.Clear();

            var FindTools = AssemblyTools.GetRouteAndToolProviders()
                .Where(x => x.Item2.Header.Contains(input, StringComparison.InvariantCultureIgnoreCase));

            _FoundTools.AddRange(FindTools);

            _IsOpen = _FoundTools.Count > 0;
        }

        void SearchItemClick()
        {
            _IsOpen = false;
            _FoundTools.Clear();

            SearchTextField.Clear();
        }

        async void OnBlur()
        {
            await Task.Delay(100);
            SearchItemClick();
        }
    }
}
