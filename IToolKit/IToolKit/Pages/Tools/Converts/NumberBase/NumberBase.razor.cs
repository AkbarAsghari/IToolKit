namespace IToolKit.Pages.Tools.Converts.NumberBase
{
    public partial class NumberBase
    {
        string _Hexadecimal;
        string _Decimal;
        string _Octal ;
        string _Binary;
        public void GoConvert(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                _Hexadecimal = _Decimal = String.Empty;
            }
            _Hexadecimal = int.Parse(input).ToString("X");
            _Decimal = decimal.Parse(input).ToString("N0");
            _Octal = Convert.ToInt32(input, 8).ToString();
            _Binary = Convert.ToString(int.Parse(input), 2);
        }
    }
}