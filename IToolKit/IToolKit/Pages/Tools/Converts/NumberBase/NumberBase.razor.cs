namespace IToolKit.Pages.Tools.Converts.NumberBase
{
    public partial class NumberBase
    {
        string _Hexadecimal;
        string _Decimal;
        public void Convert(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                _Hexadecimal = _Decimal = String.Empty;
            }
            _Hexadecimal = int.Parse(input).ToString("X");
            _Decimal = decimal.Parse(input).ToString("N0");
        }
    }
}