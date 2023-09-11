
using IToolKit.API.Tools.Formatters;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace IToolKit.Pages.Tools.EncodersDecoders.JWT;
public partial class JWT
{
    string _Token;

    string _Header;
    string _Payload;
    List<Tuple<string, object, string>> _TokenValues = new List<Tuple<string, object, string>>();

    Dictionary<string, string> Explanations = new Dictionary<string, string>()
    {
        {"typ","always set to 'JWT'" },
        {"alg", "the algorithm used for signing the JWT" },
        {"sub","the principal about which the token asserts information, such as the user of an app" },
        {"iat","the time at which the JWT was issued" },
        {"exp","the expiration time after which JWT must not be accepted" },
    };
    void Calc()
    {
        try
        {
            _TokenValues.Clear();
            var token = new JwtSecurityTokenHandler().ReadJwtToken(Regex.Replace(_Token, @"\s+", string.Empty));
            _Header = FormatterTools.FormatJson(token.Header.SerializeToJson());
            _Payload = FormatterTools.FormatJson(token.Payload.SerializeToJson());

            foreach (var claim in token.Header)
            {
                string explain = String.Empty;

                if (Explanations.ContainsKey(claim.Key))
                {
                    explain = Explanations.GetValueOrDefault(claim.Key)!;
                }

                _TokenValues.Add(new Tuple<string, object, string>(claim.Key, claim.Value, explain));
            }

            foreach (var claim in token.Payload)
            {
                string explain = String.Empty;

                if (Explanations.ContainsKey(claim.Key))
                {
                    explain = Explanations.GetValueOrDefault(claim.Key)!;
                }

                _TokenValues.Add(new Tuple<string, object, string>(claim.Key, claim.Value, explain));
            }
        }
        catch (Exception)
        {
            _Header = _Payload = String.Empty;
            _TokenValues.Clear();
        }
    }
}
