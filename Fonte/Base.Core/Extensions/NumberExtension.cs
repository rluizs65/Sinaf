using System;
using System.Globalization;

namespace Base.Core.Extensions
{
    public static class NumberExtension
    {
        /// <summary>
        /// Converte string para float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ConvertToFloat(this string s)
        {
            float fTemp = 0;
            if (float.TryParse(s, out fTemp))
                return fTemp;
            else
                return float.NaN;
        }

        /// <summary>
        /// Converte string para double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ConvertToDouble(this string s)
        {
            double fTemp = 0;
            if (double.TryParse(s, out fTemp))
                return fTemp;
            else
                return double.NaN;
        }

        /// <summary>
        /// Converte string para inteiro
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ConvertToInteger(this string s)
        {
            int fTemp = 0;
            if (int.TryParse(s, out fTemp))
                return fTemp;
            else
                return int.MinValue;
        }

        /// <summary>
        /// Arredonda valor
        /// </summary>
        /// <param name="fNumber"></param>
        /// <returns></returns>
        public static double RoundValue(this double fNumber)
        {
            double dLog;
            double dValorFinal;
            dLog = Math.Round(Math.Log10(fNumber));
            fNumber = fNumber / Math.Pow(10, (dLog - 1));
            fNumber = (int)fNumber;
            fNumber++;
            dValorFinal = (fNumber * Math.Pow(10, (dLog - 1)));

            //Caso o valor de dValorFinal seja NaN será atribuído a ele o valor zero
            if (double.IsNaN(dValorFinal))
                dValorFinal = 0;

            return dValorFinal;
        }

        public static int ToInteger(this object o)
        {
            return Convert.ToInt32(o.ToString());
        }

        public static double GMSToDecimalDegree(string gms)
        {
            double result;
            double grau, minuto, segundo;
            string[] valores;
            CultureInfo cult = new CultureInfo("en-US", true);

            valores = gms.Split(':');
            grau = ConvertToDouble(valores[0]);
            minuto = ConvertToDouble(valores[1]);
            segundo = Convert.ToDouble(valores[2], cult.NumberFormat);

            result = Math.Abs(grau) + (minuto / 60) + (segundo / 3600);
            result *= grau < 0 ? -1 : 1;

            return result;
        }

        public static double GMSToSeconds(string gms)
        {
            double result;
            double grau, minuto, segundo;
            string[] valores;
            CultureInfo cult = new CultureInfo("en-US", true);

            valores = gms.Split(':');
            grau = ConvertToDouble(valores[0]);
            minuto = ConvertToDouble(valores[1]);
            segundo = Convert.ToDouble(valores[2], cult.NumberFormat);

            result = (Math.Abs(grau) * 3600) + (minuto * 60) + (segundo);
            result *= grau < 0 ? -1 : 1;

            return result;
        }

    }
}
