using IToolKit.Client.API.Enums.Tools.EncodersDecoders;
using IToolKit.Client.API.Tools.EncodersDecoders;

namespace IToolKit.Client.Pages.Tools.EncodersDecoders.URL
{
    public partial class URL
    {
        EncodeDecodeTypeEnum _EncodeDecodeType = EncodeDecodeTypeEnum.Encode;
        string _CurrentValue;
        string _Result;
        bool _IsAutoUpdate = true;

        private void OnHashTypeChange(EncodeDecodeTypeEnum hashType)
        {
            _EncodeDecodeType = hashType;
            OnChangeEvent(_CurrentValue);
        }

        private void OnChangeEvent(string value)
        {
            _CurrentValue = value;

            if (String.IsNullOrWhiteSpace(value) || !_IsAutoUpdate)
            {
                _Result = String.Empty;
                return;
            }

            Calc(value);
        }

        void Calc(string value)
        {
            try
            {
                switch (_EncodeDecodeType)
                {
                    case EncodeDecodeTypeEnum.Encode:
                        _Result = EncoderDecoderTools.URLEncode(value);
                        break;
                    case EncodeDecodeTypeEnum.Decode:
                        _Result = EncoderDecoderTools.URLDecode(value);
                        break;
                    default:
                        _Result = "Type not found!";
                        break;
                }
            }
            catch (Exception)
            {
                _Result = String.Empty;
            }
        }
    }
}
