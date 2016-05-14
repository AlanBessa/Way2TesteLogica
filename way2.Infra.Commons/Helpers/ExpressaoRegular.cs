using System.Globalization;
using System.Text;

namespace way2.Infra.Commons.Helpers
{
    public class ExpressaoRegular
    {
        public string RemoverAcentos(string palavra)
        {
            string s = palavra.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }
    }
}
