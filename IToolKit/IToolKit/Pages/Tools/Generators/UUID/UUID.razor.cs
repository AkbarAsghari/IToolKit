using System.Text;

namespace IToolKit.Pages.Tools.Generators.UUID
{
    public partial class UUID
    {
        string _Result = String.Empty;
        int _Count = 5;

        bool _IsHyphens = true;
        bool _IsUpperCase = false;
        string _UuidVersion = "Four";

        private static readonly DateTimeOffset GregorianCalendarStart = new(1582, 10, 15, 0, 0, 0, TimeSpan.Zero);
        private const int VariantByte = 8;
        private const int VariantByteMask = 0x3f;
        private const int VariantByteShift = 0x80;
        private const int VersionByte = 7;
        private const int VersionByteMask = 0x0f;
        private const int VersionByteShift = 4;
        private const int ByteArraySize = 16;
        private const byte TimestampByte = 0;
        private const byte NodeByte = 10;
        private const byte GuidClockSequenceByte = 8;
        internal const string VersionOne = "One";
        private static readonly Random Random = new();

        void GnerateUUID()
        {
            _Result = String.Empty;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _Count; i++)
            {
                string guidStringFormat;
                if (_IsHyphens)
                {
                    guidStringFormat = "D";
                }
                else
                {
                    guidStringFormat = "N";
                }

                string? guid;
                if (string.Equals(VersionOne, _UuidVersion, StringComparison.Ordinal))
                {
                    guid = GenerateTimeBasedGuid().ToString(guidStringFormat);
                }
                else
                {
                    guid = Guid.NewGuid().ToString(guidStringFormat);
                }

                if (_IsUpperCase)
                {
                    guid = guid.ToUpperInvariant();
                }

                stringBuilder.AppendLine(guid);
            }
            _Result = stringBuilder.ToString();
        }


        private Guid GenerateTimeBasedGuid()
        {
            DateTime dateTime = DateTime.UtcNow;
            long ticks = dateTime.Ticks - GregorianCalendarStart.Ticks;

            byte[] guid = new byte[ByteArraySize];
            byte[] timestamp = BitConverter.GetBytes(ticks);

            // copy node
            byte[]? nodes = GenerateNodeBytes();
            Array.Copy(nodes, 0, guid, NodeByte, Math.Min(6, nodes.Length));

            // copy clock sequence
            byte[]? clockSequence = GenerateClockSequenceBytes(dateTime);
            Array.Copy(clockSequence, 0, guid, GuidClockSequenceByte, Math.Min(2, clockSequence.Length));

            // copy timestamp
            Array.Copy(timestamp, 0, guid, TimestampByte, Math.Min(8, timestamp.Length));

            // set the variant
            guid[VariantByte] &= (byte)VariantByteMask;
            guid[VariantByte] |= (byte)VariantByteShift;

            // set the version
            guid[VersionByte] &= (byte)VersionByteMask;
            guid[VersionByte] |= (byte)((byte)GuidVersion.TimeBased << VersionByteShift);

            return new Guid(guid);
        }
        public byte[] GenerateClockSequenceBytes(DateTime dt)
        {
            DateTime utc = dt.ToUniversalTime();

            byte[]? bytes = BitConverter.GetBytes(utc.Ticks);

            if (bytes.Length == 0)
            {
                return new byte[] { 0x0, 0x0 };
            }

            if (bytes.Length == 1)
            {
                return new byte[] { 0x0, bytes[0] };
            }

            return new byte[] { bytes[0], bytes[1] };
        }

        public byte[] GenerateNodeBytes()
        {
            byte[]? node = new byte[6];

            Random.NextBytes(node);
            return node;
        }

        private enum GuidVersion
        {
            TimeBased = 0x01,
            Reserved = 0x02,
            NameBased = 0x03,
            Random = 0x04
        }
    }
}
