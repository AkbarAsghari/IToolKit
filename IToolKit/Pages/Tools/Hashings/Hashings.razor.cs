using Bit.BlazorUI;
using IToolKit.API.Enums.Tools.Hashings;
using IToolKit.API.Tools.Hashings;

namespace IToolKit.Pages.Tools.Hashings
{
    public partial class Hashings
    {
        HashTypeEnum _HashType = HashTypeEnum.SHA1;
        string _CurrentValue;
        string _Result;
        bool _IsAutoUpdate = true;

        private void OnHashTypeChange(BitDropDownItem hashType)
        {
            if (Enum.TryParse(hashType.Value, true, out HashTypeEnum type))
            {
                _HashType = type;
            }

            OnChangeEvent(_CurrentValue);
        }

        private void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (String.IsNullOrWhiteSpace(value) || !_IsAutoUpdate)
                return;

            CalcHash(value);
        }

        void CalcHash(string value)
        {
            switch (_HashType)
            {
                case HashTypeEnum.SHA1:
                    _Result = HashingsTool.ComputeSHA1Hash(value);
                    break;
                case HashTypeEnum.SHA256:
                    _Result = HashingsTool.ComputeSHA256Hash(value);
                    break;
                case HashTypeEnum.SHA384:
                    _Result = HashingsTool.ComputeSHA384Hash(value);
                    break;
                case HashTypeEnum.SHA512:
                    _Result = HashingsTool.ComputeSHA512Hash(value);
                    break;
                default:
                    _Result = "Type not found!";
                    break;
            }
        }

        private List<BitDropDownItem> GetHashTypeItems()
        {
            return new()
         {
             new BitDropDownItem()
             {
                 ItemType = BitDropDownItemType.Normal,
                 Text = "SHA1",
                 Value = "SHA1"                 
             },
             new BitDropDownItem()
             {
                 ItemType = BitDropDownItemType.Normal,
                 Text = "SHA256",
                 Value = "SHA256"
             },
             new BitDropDownItem()
             {
                 ItemType = BitDropDownItemType.Normal,
                 Text = "SHA384",
                 Value = "SHA384"
             },
              new BitDropDownItem()
             {
                 ItemType = BitDropDownItemType.Normal,
                 Text = "SHA512",
                 Value = "SHA512"
             },
         };
        }
    }
}
