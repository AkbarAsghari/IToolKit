using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.Hashings;
using IToolKit.API.Tools.Hashings;

namespace IToolKit.Pages.Tools.Generators.Hash
{
    public partial class Hash
    {
        string _CurrentValue;

        string _SHA1Result;
        string _SHA256Result;
        string _SHA384Result;
        string _SHA512Result;

        bool _IsAutoUpdate = true;

        private void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (String.IsNullOrWhiteSpace(value) || !_IsAutoUpdate)
                return;

            CalcHash(value);
        }

        void CalcHash(string value)
        {
            _SHA1Result = HashingsTool.ComputeSHA1Hash(value);
            _SHA256Result = HashingsTool.ComputeSHA256Hash(value);
            _SHA384Result = HashingsTool.ComputeSHA384Hash(value);
            _SHA512Result = HashingsTool.ComputeSHA512Hash(value);
        }

    }
}
