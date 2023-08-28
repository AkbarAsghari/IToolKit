using IToolKit.API.Enums.Tools.Formatters;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace IToolKit.Pages.Tools.Formatters.XML;
partial class XML
{
    string _InputValue;
    string _XMLFormatedResult;

    async Task Format()
    {
        if (String.IsNullOrEmpty(_InputValue))
        {
            _XMLFormatedResult = String.Empty;
            return;
        }

        try
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(_InputValue);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            _XMLFormatedResult = stringBuilder.ToString();
        }
        catch (Exception)
        {
            // Handle and throw if fatal exception here; don't just ignore them
            _XMLFormatedResult = String.Empty;
        }
    }
}
