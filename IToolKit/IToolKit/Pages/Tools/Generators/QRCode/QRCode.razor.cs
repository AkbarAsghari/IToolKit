using IToolKit.API.Enums.Tools.Generators;
using IToolKit.API.Tools.Generators;
using MudBlazor.Utilities;
using static IToolKit.API.Tools.Generators.QRCodeTools;

namespace IToolKit.Pages.Tools.Generators.QRCode;

partial class QRCode
{
    string _Base64Image;

    MudColor _LightColor = new MudColor("#fffff1ff");
    MudColor _DarkColor = new MudColor("#000001ff");

    QRCodeTypeEnum QRCodeType = QRCodeTypeEnum.Text;

    WifiPayload Wifi = new WifiPayload();
    TextPayload Text = new TextPayload();
    MailPayload Mail = new MailPayload();
    SMSPayload SMS = new SMSPayload();
    ContactDataPayload Contact = new ContactDataPayload();
    CalendarEventPayload CalendarEvent = new CalendarEventPayload();

    bool IsInputReady
    {
        get
        {
            return QRCodeType switch
            {
                QRCodeTypeEnum.Text => Text.IsReady,
                QRCodeTypeEnum.URL => Text.IsReady,
                QRCodeTypeEnum.VCard => Contact.IsReady,
                QRCodeTypeEnum.Email => Mail.IsReady,
                QRCodeTypeEnum.SMS => SMS.IsReady,
                QRCodeTypeEnum.Wifi => Wifi.IsReady,
                QRCodeTypeEnum.Event => CalendarEvent.IsReady,
                _ => false
            };
        }
    }

    async Task Generate()
    {
        byte[] darkColor = new byte[] { _DarkColor.R, _DarkColor.G, _DarkColor.B, _DarkColor.A };
        byte[] lightColor = new byte[] { _LightColor.R, _LightColor.G, _LightColor.B, _LightColor.A };

        switch (QRCodeType)
        {
            case QRCodeTypeEnum.Text:
            case QRCodeTypeEnum.URL:
                _Base64Image = QRCodeTools.ToBase64(Text,
            darkColorRgba: darkColor,
            lightColorRgba: lightColor);
                break;
            case QRCodeTypeEnum.VCard:
                _Base64Image = QRCodeTools.ToBase64(Contact,
           darkColorRgba: darkColor,
           lightColorRgba: lightColor);
                break;
            case QRCodeTypeEnum.Email:
                _Base64Image = QRCodeTools.ToBase64(Mail,
           darkColorRgba: darkColor,
           lightColorRgba: lightColor);
                break;
            case QRCodeTypeEnum.SMS:
                _Base64Image = QRCodeTools.ToBase64(SMS,
           darkColorRgba: darkColor,
           lightColorRgba: lightColor);
                break;
            case QRCodeTypeEnum.Wifi:
                _Base64Image = QRCodeTools.ToBase64(Wifi,
            darkColorRgba: darkColor,
            lightColorRgba: lightColor);
                break;
            case QRCodeTypeEnum.Event:
                _Base64Image = QRCodeTools.ToBase64(CalendarEvent,
            darkColorRgba: darkColor,
            lightColorRgba: lightColor);
                break;
            default:
                break;
        }

        await Task.CompletedTask;
    }
}
