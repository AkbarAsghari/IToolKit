using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace IToolKit.Pages.Tools.Text.TextInspectorAndCaseConverter
{
    public partial class TextInspectorAndCaseConverter
    {
        string _Text;
        string _Orginal;
        bool _IsEdited = false;

        public string _Result
        {
            get
            {
                return _Text;
            }
            set
            {
                if (!_IsEdited)
                    _Orginal = value;

                _Text = value;
            }
        }

        void ToTrainCase()
        {
            ToTitleCase();
            _Result = _Result.Replace(' ', '-');
        }

        void ToSnakeCase()
        {
            _IsEdited = true;
            if (_Text.Length < 2)
            {
                _Result = _Text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(_Text[0]));
            for (int i = 1; i < _Text.Length; ++i)
            {
                char c = _Text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            _Result = sb.ToString();
        }
        void ToConstantCase()
        {
            _IsEdited = true;
            if (_Text.Length < 2)
            {
                _Result = _Text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToUpper(_Text[0]));
            for (int i = 1; i < _Text.Length; ++i)
            {
                char c = _Text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                }
                sb.Append(char.ToUpper(c));
            }
            _Result = sb.ToString();
        }

        void ToInverseCase()
        {
            _IsEdited = true;
            _Text = _Text.ToLower();
            char[] characters = _Text.ToCharArray();
            for (int i = 1; i < characters.Length; i += 2)
            {
                characters[i] = char.ToUpper(characters[i]);
            }
            _Result = new string(characters);
        }

        void ToAlternatingCase()
        {
            _IsEdited = true;
            _Text = _Text.ToLower();
            char[] characters = _Text.ToCharArray();
            for (int i = 0; i < characters.Length; i += 2)
            {
                characters[i] = char.ToUpper(characters[i]);
            }
            _Result = new string(characters);
        }

        void ToCobolCase()
        {
            ToConstantCase();
            _Result = _Result.Replace('_', '-');
        }

        void ToKebabCase()
        {
            ToSnakeCase();
            _Result = _Result.Replace('_', '-');
        }
        void ToPascalCase()
        {
            _IsEdited = true;
            var x = _Text.Replace(" ", "");
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            _Result = char.ToUpper(x[0]) + x.Substring(1);
        }

        void ToCamelCase()
        {
            _IsEdited = true;
            var x = _Text.Replace(" ", "");
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            _Result = char.ToLower(x[0]) + x.Substring(1);
        }

        void ToOrginal()
        {
            _IsEdited = false;
            _Result = _Orginal;
        }

        void ToUpper()
        {
            _IsEdited = true;
            _Result = _Text.ToUpper();
        }
        void ToLower()
        {
            _IsEdited = true;
            _Result = _Text.ToLower();
        }

        void ToSentence()
        {
            _IsEdited = true;
            var lowerCase = _Text.ToLower();
            // matches the first sentence of a string, as well as subsequent sentences
            var r = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
            // MatchEvaluator delegate defines replacement of setence starts to uppercase
            _Result = r.Replace(lowerCase, s => s.Value.ToUpper());
        }

        void ToTitleCase()
        {
            _IsEdited = true;
            _Result = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(_Text.ToLower());
        }

    }
}
