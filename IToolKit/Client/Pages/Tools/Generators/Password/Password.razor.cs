using System.Text;

namespace IToolKit.Client.Pages.Tools.Generators.Password
{
    public partial class Password
    {
        string _Result = String.Empty;

        int _CharactersLength = 14;
        bool _CapitalLetters = true;
        bool _LowerCaseLetters = false;
        bool _Numbers = false;
        bool _Symbuls = false;

        void GeneratePassword()
        {
            string valid = String.Empty;
            if (_CapitalLetters)
            {
                valid += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (_LowerCaseLetters)
            {
                valid += "abcdefghijklmnopqrstuvwxyz";
            }
            if (_Numbers)
            {
                valid += "1234567890";
            }
            if (_Symbuls)
            {
                valid += "!@#$%^&*";
            }

            _Result = CreatePassword(valid ,_CharactersLength);
        }

        public string CreatePassword(string valid, int length)
        {
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
