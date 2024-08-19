using QRCoder;
using System.Numerics;
using static QRCoder.PayloadGenerator;

namespace IToolKit.Client.API.Tools.Generators
{
    public class QRCodeTools
    {
        static QRCodeGenerator qrGenerator = new QRCodeGenerator();

        public static string TextToBase64(string text)
        {
            return ToBase64(new TextPayload { Text = text }, new byte[] { 0, 0, 0 }, new byte[] { 255, 255, 255 });
        }

        public static string ToBase64(Payload payload, byte[] darkColorRgba, byte[] lightColorRgba)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            return Convert.ToBase64String(qrCode.GetGraphic(pixelsPerModule: 20, darkColorRgba, lightColorRgba));
        }

        public abstract class Payload
        {
            public override string ToString()
            {
                return String.Empty;
            }

            public abstract bool IsReady { get; }
        }

        public class TextPayload : Payload
        {
            public string Text { get; set; }

            public override bool IsReady => !String.IsNullOrEmpty(Text);

            public override string ToString()
            {
                return Text;
            }
        }

        public class WifiPayload : Payload
        {
            public string SSID { get; set; }
            public string Pass { get; set; }
            public WiFi.Authentication Authentication { get; set; }
            public bool IsHidden { get; set; } = false;

            public override bool IsReady => !(String.IsNullOrEmpty(SSID) && String.IsNullOrEmpty(Pass));

            public override string ToString()
            {
                return new WiFi(SSID, Pass, Authentication, IsHidden).ToString();
            }
        }

        public class MailPayload : Payload
        {
            public string MailReciver { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }

            public override bool IsReady => !(String.IsNullOrEmpty(MailReciver) && String.IsNullOrEmpty(Subject) && String.IsNullOrEmpty(Message));

            public override string ToString()
            {
                return new Mail(MailReciver, Subject, Message).ToString();
            }
        }
        public class SMSPayload : Payload
        {
            public string Number { get; set; }
            public string Subject { get; set; }

            public override bool IsReady => !(String.IsNullOrEmpty(Number) && String.IsNullOrEmpty(Subject));

            public override string ToString()
            {
                return new SMS(Number, Subject).ToString();
            }
        }

        public class ContactDataPayload : Payload
        {
            public ContactData.ContactOutputType ContactOutput { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NickName { get; set; }
            public string Phone { get; set; }
            public string MobilePhone { get; set; }
            public string WorkPhone { get; set; }
            public string Email { get; set; }

            public override bool IsReady => !(String.IsNullOrEmpty(FirstName) &&
                String.IsNullOrEmpty(LastName) &&
                String.IsNullOrEmpty(NickName) &&
                String.IsNullOrEmpty(Phone) &&
                String.IsNullOrEmpty(MobilePhone) &&
                String.IsNullOrEmpty(WorkPhone) &&
                String.IsNullOrEmpty(Email));

            public override string ToString()
            {
                return new ContactData(ContactOutput, FirstName, LastName, NickName, Phone, MobilePhone, WorkPhone, Email).ToString();
            }
        }

        public class CalendarEventPayload : Payload
        {
            public string Subject { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public DateTime? Start { get; set; } = DateTime.Now;
            public DateTime? End { get; set; } = DateTime.Now;
            public bool AllDayEvent { get; set; }

            public override bool IsReady => !(String.IsNullOrEmpty(Subject) &&
                String.IsNullOrEmpty(Description) &&
                String.IsNullOrEmpty(Subject) &&
                String.IsNullOrEmpty(Location) &&
                Start == null &&
                End == null);

            public override string ToString()
            {
                return new CalendarEvent(Subject, Description, Location, Start!.Value, End!.Value, AllDayEvent).ToString();
            }
        }
    }
}
