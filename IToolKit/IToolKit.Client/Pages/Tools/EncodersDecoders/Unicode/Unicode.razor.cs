using IToolKit.Client.API.Enums.Tools.EncodersDecoders;
using IToolKit.Client.API.Enums.Tools.Text;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IToolKit.Client.Pages.Tools.EncodersDecoders.Unicode;
partial class Unicode
{
    EncodeDecodeTypeEnum _EncodeDecodeType = EncodeDecodeTypeEnum.Encode;
    string _CurrentValue;
    string _Result;

    private void OnEncodeDecodeTypeChange(EncodeDecodeTypeEnum hashType)
    {
        _EncodeDecodeType = hashType;
        OnChangeEvent(_CurrentValue);
    }

    private void OnChangeEvent(string value)
    {
        _CurrentValue = value;

        if (String.IsNullOrEmpty(value))
        {
            _Result = value;
            return;
        }

        Calc(value);
    }

    void Calc(string value)
    {
        if (_EncodeDecodeType == EncodeDecodeTypeEnum.Encode)
        {
            _Result = EncodeNonAsciiCharacters(_CurrentValue);
        }
        else
        {
            _Result = DecodeEncodedNonAsciiCharacters(_CurrentValue);
        }
    }

    static string EncodeNonAsciiCharacters(string value)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in value)
        {
            string encodedValue = "\\u" + ((int)c).ToString("x4");
            sb.Append(encodedValue);
        }
        return sb.ToString();
    }

    static string DecodeEncodedNonAsciiCharacters(string value)
    {
        return Regex.Replace(
            value,
            @"\\u(?<Value>[a-zA-Z0-9]{4})",
            m =>
            {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            });
    }
}
