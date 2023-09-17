using IToolKit.API.Enums.Tools.EncodersDecoders;
using IToolKit.API.Tools.EncodersDecoders;

namespace IToolKit.Pages.Tools.EncodersDecoders.Base32TextEncoderDecoder
{
    public partial class Base32TextEncoderDecoder
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
            try
            {
                switch (_EncodeDecodeType)
                {
                    case EncodeDecodeTypeEnum.Encode:
                        _Result = EncoderDecoderTools.Base32Encode(value);
                        break;
                    case EncodeDecodeTypeEnum.Decode:
                        _Result = EncoderDecoderTools.Base32Decode(value);
                        break;
                    default:
                        _Result = "Type not found!";
                        break;
                }
            }
            catch (Exception)
            {
                _Result = string.Empty;
            }
        }
    }
}
