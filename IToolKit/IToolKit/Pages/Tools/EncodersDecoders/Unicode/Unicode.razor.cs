using IToolKit.API.Enums.Tools.EncodersDecoders;
using IToolKit.API.Enums.Tools.Text;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IToolKit.Pages.Tools.EncodersDecoders.Unicode;
partial class Unicode
{
    EncodeDecodeTypeEnum _EncodeDecodeType = EncodeDecodeTypeEnum.Encode;
    string _CurrentValue;
    string _Result;
    bool _IsAutoUpdate = true;

    private void OnEncodeDecodeTypeChange(EncodeDecodeTypeEnum hashType)
    {
        _EncodeDecodeType = hashType;
        OnChangeEvent(_CurrentValue);
    }

    private void OnChangeEvent(string value)
    {
        _CurrentValue = value;

        if (!_IsAutoUpdate)
            return;

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
            if (c > 127)
            {
                // This character is too big for ASCII
                string encodedValue = "\\u" + ((int)c).ToString("x4");
                sb.Append(encodedValue);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    static string DecodeEncodedNonAsciiCharacters(string value)
    {
        return Regex.Replace(
            value,
            @"\\u(?<Value>[a-zA-Z0-9]{4})",
            m => {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            });
    }
}
