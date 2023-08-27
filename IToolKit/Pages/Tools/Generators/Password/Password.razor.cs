using System.Text;

namespace IToolKit.Pages.Tools.Generators.Password
{
    public partial class Password
    {
        string _Result = String.Empty;

        protected override async Task OnInitializedAsync()
        {
            for (int i = 0; i < 7; i++)
            {
                _Result = CreatePassword(16);
                _Result += $"\n{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                _Result += $"{CreatePassword(16)}\n";
                StateHasChanged();
                await Task.Delay(100);
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
