using IToolKit.API.Enums.Tools.Text;
using Microsoft.Extensions.Logging;
using System.Text;

namespace IToolKit.Pages.Tools.Text.StringEscapeUnescape;
partial class StringEscapeUnescape
{
    EscapeUnescapeTypeEnum _EscapeUnscapeType = EscapeUnescapeTypeEnum.Escape;
    string _CurrentValue;
    string _Result;
    bool _IsAutoUpdate = true;

    private void OnEscapeTypeChange(EscapeUnescapeTypeEnum escapeUnescapeType)
    {
        _EscapeUnscapeType = escapeUnescapeType;
        OnChangeEvent(_CurrentValue);
    }

    private void OnChangeEvent(string value)
    {
        _CurrentValue = value;

        if (String.IsNullOrWhiteSpace(value) || !_IsAutoUpdate)
            return;

        Calc(value);
    }

    void Calc(string value)
    {
        if (_EscapeUnscapeType == EscapeUnescapeTypeEnum.Escape)
        {
            _Result = EscapeStringAsync(_CurrentValue);
        }
        else
        {
            _Result = UnescapeStringAsync(_CurrentValue);
        }
    }

    private string EscapeStringAsync(string? data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return string.Empty;
        }

        var encoded = new StringBuilder();

        try
        {
            int i = 0;
            while (i < data!.Length)
            {
                string replacementString = string.Empty;
                int jumpLength = 0;
                if (TextMatchAtIndex(data, "\n", i))
                {
                    jumpLength = 1;
                    replacementString = "\\n";
                }
                else if (TextMatchAtIndex(data, "\r", i))
                {
                    jumpLength = 1;
                    replacementString = "\\r";
                }
                else if (TextMatchAtIndex(data, "\t", i))
                {
                    jumpLength = 1;
                    replacementString = "\\t";
                }
                else if (TextMatchAtIndex(data, "\b", i))
                {
                    jumpLength = 1;
                    replacementString = "\\b";
                }
                else if (TextMatchAtIndex(data, "\f", i))
                {
                    jumpLength = 1;
                    replacementString = "\\f";
                }
                else if (TextMatchAtIndex(data, "\"", i))
                {
                    jumpLength = 1;
                    replacementString = "\\\"";
                }
                else if (TextMatchAtIndex(data, "\\", i))
                {
                    jumpLength = 1;
                    replacementString = "\\\\";
                }

                if (!string.IsNullOrEmpty(replacementString) && jumpLength > 0)
                {
                    encoded.Append(replacementString);
                    i += jumpLength;
                }
                else
                {
                    encoded.Append(data[i]);
                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return encoded.ToString();
    }

    private string UnescapeStringAsync(string? data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return string.Empty;
        }

        var decoded = new StringBuilder();

        try
        {
            int i = 0;
            while (i < data!.Length)
            {
                string replacementString = string.Empty;
                int jumpLength = 0;
                if (TextMatchAtIndex(data, "\\n", i))
                {
                    jumpLength = 2;
                    replacementString = "\n";
                }
                else if (TextMatchAtIndex(data, "\\r", i))
                {
                    jumpLength = 2;
                    replacementString = "\r";
                }
                else if (TextMatchAtIndex(data, "\\t", i))
                {
                    jumpLength = 2;
                    replacementString = "\t";
                }
                else if (TextMatchAtIndex(data, "\\b", i))
                {
                    jumpLength = 2;
                    replacementString = "\b";
                }
                else if (TextMatchAtIndex(data, "\\f", i))
                {
                    jumpLength = 2;
                    replacementString = "\f";
                }
                else if (TextMatchAtIndex(data, "\\\"", i))
                {
                    jumpLength = 2;
                    replacementString = "\"";
                }
                else if (TextMatchAtIndex(data, "\\\\", i))
                {
                    jumpLength = 2;
                    replacementString = "\\";
                }

                if (!string.IsNullOrEmpty(replacementString) && jumpLength > 0)
                {
                    decoded.Append(replacementString);
                    i += jumpLength;
                }
                else
                {
                    decoded.Append(data[i]);
                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return decoded.ToString();
    }

    private bool TextMatchAtIndex(string data, string test, int startIndex)
    {
        if (string.IsNullOrEmpty(test))
        {
            return false;
        }

        if (data.Length < test.Length)
        {
            return false;
        }

        for (int i = 0; i < test.Length; i++)
        {
            if (data[startIndex + i] != test[i])
            {
                return false;
            }
        }

        return true;
    }
}
