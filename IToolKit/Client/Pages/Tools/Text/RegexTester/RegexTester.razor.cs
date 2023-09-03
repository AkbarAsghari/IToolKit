using System.Text;
using System.Text.RegularExpressions;

namespace IToolKit.Client.Pages.Tools.Text.RegexTester;
partial class RegexTester
{
    string _Text;
    string _Pattern;
    string _Result;
    void RegularExpressionOnChange()
    {
        if (String.IsNullOrEmpty(_Text) || String.IsNullOrEmpty(_Pattern))
        {
            _Result = String.Empty;
            return;
        }
        try
        {
            _Result = Regex.Replace(_Text, _Pattern, x => $"<span class='mud-dark-text mud-warning'>{x.Value}</span>");
        }
        catch (Exception)
        {
            _Result = String.Empty;
        }
    }
}
