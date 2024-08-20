using System.Text.RegularExpressions;

namespace IToolKit.Pages.Tools.Text.RegEx;
partial class RegEx
{
    string _Text;
    string _Pattern;
    string _Result;
    string errorMsg;
    IEnumerable<MatchDetails>? MatchesGroups;

    bool _EcmaScript, _CultureInvariant, _IgnoreCase, _Singleline, _IgnoreWhitespace, _Multiline, _RightToLeft;
    bool EcmaScript
    {
        get { return _EcmaScript; }
        set { _EcmaScript = value; RegularExpressionOnChange(); }
    }
    bool CultureInvariant
    {
        get { return _CultureInvariant; }
        set { _CultureInvariant = value; RegularExpressionOnChange(); }
    }
    bool IgnoreCase
    {
        get { return _IgnoreCase; }
        set { _IgnoreCase = value; RegularExpressionOnChange(); }
    }
    bool Singleline
    {
        get { return _Singleline; }
        set { _Singleline = value; RegularExpressionOnChange(); }
    }
    bool IgnoreWhitespace
    {
        get { return _IgnoreWhitespace; }
        set { _IgnoreWhitespace = value; RegularExpressionOnChange(); }
    }
    bool Multiline
    {
        get { return _Multiline; }
        set { _Multiline = value; RegularExpressionOnChange(); }
    }
    bool RightToLeft
    {
        get { return _RightToLeft; }
        set { _RightToLeft = value; RegularExpressionOnChange(); }
    }

    void RegularExpressionOnChange()
    {
        errorMsg = String.Empty;

        if (String.IsNullOrEmpty(_Text) || String.IsNullOrEmpty(_Pattern))
        {
            _Result = String.Empty;
            MatchesGroups = null;
            return;
        }

        try
        {
            MatchCollection? matches = null;
            Regex? regex = null;

            string? pattern = _Pattern.Trim('/');
            regex = new Regex(_Pattern, GetOptions());
            matches = regex.Matches(_Text);

            if (matches != null)
            {
                _Result = regex.Replace(_Text, x => $"<span class='mud-dark-text mud-warning'>{x.Value}</span>");

                MatchesGroups = matches
                               .Cast<Match>()
                               .SelectMany(
                                   (c, inx) => c.Groups
                                       .Cast<Group>()
                                       .OrderBy(g => g.Index)
                                       .Select(mm => new MatchDetails
                                       {
                                           Title = (mm.Name == "0" ? $"Match {inx + 1}:" : $"    Group \"{mm.Name}\""),
                                           Range = $"{mm.Index}-{mm.Index + mm.Length}",
                                           Value = mm.Value
                                       }));
            }
            else
            {
                _Result = String.Empty;
                MatchesGroups = null;
            }
        }
        catch (Exception ex)
        {
            _Result = String.Empty;
            MatchesGroups = null;
            errorMsg = ex.Message;
        }
    }

    private RegexOptions GetOptions()
    {
        RegexOptions options = RegexOptions.None;
        if (EcmaScript)
        {
            options |= RegexOptions.ECMAScript;
        }
        if (CultureInvariant)
        {
            options |= RegexOptions.CultureInvariant;
        }
        if (IgnoreCase)
        {
            options |= RegexOptions.IgnoreCase;
        }
        if (IgnoreWhitespace && !EcmaScript)
        {
            options |= RegexOptions.IgnorePatternWhitespace;
        }
        if (Singleline && !EcmaScript)
        {
            options |= RegexOptions.Singleline;
        }
        if (Multiline)
        {
            options |= RegexOptions.Multiline;
        }
        if (RightToLeft && !EcmaScript)
        {
            options |= RegexOptions.RightToLeft;
        }

        return options;
    }

    public record MatchDetails
    {
        public string Title { get; set; } = string.Empty;

        public string Range { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}
