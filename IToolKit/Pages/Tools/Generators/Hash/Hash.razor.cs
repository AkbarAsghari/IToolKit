using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.Hashings;
using IToolKit.API.Tools.Hashings;

namespace IToolKit.Pages.Tools.Generators.Hash
{
    public partial class Hash
    {
        string _CurrentValue;
        string _CurrentSecret;

        string _SHA1Result;
        string _SHA256Result;
        string _SHA384Result;
        string _SHA512Result;

        bool _IsAutoUpdate = true;
        bool _IsUpperCase = true;

        private void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (_IsAutoUpdate)
                CalcHash();
        }

        void CalcHash()
        {
            if (String.IsNullOrWhiteSpace(_CurrentValue))
            {
                _SHA1Result = _SHA256Result = _SHA384Result = _SHA512Result = String.Empty;
                return;
            }

            _SHA1Result = HashingsTool.ComputeSHA1Hash(_CurrentValue);
            _SHA256Result = HashingsTool.ComputeSHA256Hash(_CurrentValue);
            _SHA384Result = HashingsTool.ComputeSHA384Hash(_CurrentValue);
            _SHA512Result = HashingsTool.ComputeSHA512Hash(_CurrentValue);

            ChangeTextCase(_IsUpperCase);
        }

        void ChangeTextCase(bool value)
        {
            if (!value)
            {
                _SHA1Result = _SHA1Result.ToLower();
                _SHA256Result = _SHA256Result.ToLower();
                _SHA384Result = _SHA384Result.ToLower();
                _SHA512Result = _SHA512Result.ToLower();
            }
            else
            {
                _SHA1Result = _SHA1Result.ToUpper();
                _SHA256Result = _SHA256Result.ToUpper();
                _SHA384Result = _SHA384Result.ToUpper();
                _SHA512Result = _SHA512Result.ToUpper();
            }
        }
    }
}
