using System.Text;
using IToolKit.API.Enums.Tools.Formatters;
using IToolKit.Extensions;

public static class JsonFormatterTools{
    public static string FormatJson(string str , JsonFormatterSpacesEnum spacesEnum = JsonFormatterSpacesEnum.FourSpaces)
    {
        string INDENT_STRING = String.Empty;

        switch (spacesEnum)
        {
            case JsonFormatterSpacesEnum.TwoSpaces:
                INDENT_STRING = "  ";
                break;
            case JsonFormatterSpacesEnum.FourSpaces:
                INDENT_STRING = "    ";
                break;
            case JsonFormatterSpacesEnum.Tab:
                INDENT_STRING = "   ";
                break;
        }

        var indent = 0;
        var quoted = false;
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            var ch = str[i];
            switch (ch)
            {
                case '{':
                case '[':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    break;
                case '}':
                case ']':
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    sb.Append(ch);
                    break;
                case '"':
                    sb.Append(ch);
                    bool escaped = false;
                    var index = i;
                    while (index > 0 && str[--index] == '\\')
                        escaped = !escaped;
                    if (!escaped)
                        quoted = !quoted;
                    break;
                case ',':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                    }
                    break;
                case ':':
                    sb.Append(ch);
                    if (!quoted)
                        sb.Append(" ");
                    break;
                default:
                    sb.Append(ch);
                    break;
            }
        }
        return sb.ToString();
    }
}