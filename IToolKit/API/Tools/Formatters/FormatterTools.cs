using System.Text;
using System.Xml.Linq;
using System.Xml;
using IToolKit.API.Enums.Tools.Formatters;
using IToolKit.Extensions;

namespace IToolKit.API.Tools.Formatters;
public static class FormatterTools
{
    public static string FormatJson(string str, FormatterSpacesEnum spacesEnum = FormatterSpacesEnum.FourSpaces)
    {
        string INDENT_STRING = GetIndentString(spacesEnum);

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

    public static string FormatXML(string str, FormatterSpacesEnum spacesEnum = FormatterSpacesEnum.FourSpaces)
    {
        string INDENT_STRING = GetIndentString(spacesEnum);
        try
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(str);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = INDENT_STRING;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
        catch (Exception)
        {
            return String.Empty;
        }
    }

    private static string GetIndentString(FormatterSpacesEnum spacesEnum)
    {
        string INDENT_STRING = String.Empty;

        switch (spacesEnum)
        {
            case FormatterSpacesEnum.TwoSpaces:
                INDENT_STRING = "  ";
                break;
            case FormatterSpacesEnum.FourSpaces:
                INDENT_STRING = "    ";
                break;
            case FormatterSpacesEnum.Tab:
                INDENT_STRING = "   ";
                break;
        }

        return INDENT_STRING;
    }
}