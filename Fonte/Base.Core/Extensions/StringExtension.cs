using Base.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Core.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Retorna string com data no formato dd/MM/yyyy
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string FormatDate(this DateTime d)
        {
            return string.Format("{0:dd/MM/yyyy}", d);
        }

        /// <summary>
        /// Retorna string com data no formato dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string FormatDateTime(this DateTime d)
        {
            return string.Format("{0:dd/MM/yyyy HH:mm}", d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fNumber"></param>
        /// <returns></returns>
        public static string FormatNumber(this int fNumber)
        {
            return FormatNumberToString(fNumber, 4);
        }

        /// <summary>
        /// Retorna string com número formatado com casas decimais delimitadas
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace">Número de casas decimais</param>
        /// <returns></returns>
        public static string FormatNumber(this float fNumber, int decimalPlace)
        {
            string stringFormat = "0:0.";
            char spad = Convert.ToChar("0");

            if (!Single.IsNaN(fNumber))

                return String.Format("{" + stringFormat.PadRight(decimalPlace + 4, spad) + "}", fNumber);
            else
                return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace"></param>
        /// <param name="subsZero"></param>
        /// <returns></returns>
        public static string FormatNumber(this float fNumber, int decimalPlace, string subsZero)
        {
            string stringFormat = "0:0.";
            char spad = Convert.ToChar("0");
            string result = String.Empty;

            if (!Single.IsNaN(fNumber))
            {
                result = String.Format("{" + stringFormat.PadRight(decimalPlace + 4, spad) + "}", fNumber);
                if ((fNumber == 0) && (!String.IsNullOrEmpty(subsZero)))
                    result = subsZero;
            }
            else
            {
                if (!String.IsNullOrEmpty(subsZero))
                    result = subsZero;
            }
            return result;
        }

        /// <summary>
        /// Retorna string com número formatado com casas decimais delimitadas
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace">Número de casas decimais</param>
        /// <returns></returns>
        public static string FormatNumber(this double fNumber, int decimalPlace)
        {
            string stringFormat = "0:0.";
            char spad = Convert.ToChar("0");

            if (!Double.IsNaN(fNumber))

                return String.Format("{" + stringFormat.PadRight(decimalPlace + 4, spad) + "}", fNumber);
            else
                return "";
        }

        /// <summary>
        /// Retorna string com número formatado com casas decimais delimitadas
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace">Número de casas decimais</param>
        /// <param name="subsZero"></param>
        /// <returns></returns>
        public static string FormatNumber(this double fNumber, int decimalPlace, string subsZero)
        {
            string stringFormat = "0:0.";
            char spad = Convert.ToChar("0");
            string result = String.Empty;

            if (!double.IsNaN(fNumber))
            {
                result = String.Format("{" + stringFormat.PadRight(decimalPlace + 4, spad) + "}", fNumber);
                if ((fNumber == 0) && (!String.IsNullOrEmpty(subsZero)))
                    result = subsZero;
            }
            else
            {
                if (!String.IsNullOrEmpty(subsZero))
                    result = subsZero;
            }
            return result;
        }

        /// <summary>
        /// Retorna string com número formatado com casas decimais delimitadas
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace">Número de casas decimais</param>
        /// <returns></returns>
        public static string FormatNumber(this decimal fNumber, int decimalPlace)
        {
            string stringFormat = "0:0.";
            char spad = Convert.ToChar("0");

            if (!Double.IsNaN((double)fNumber))

                return String.Format("{" + stringFormat.PadRight(decimalPlace + 4, spad) + "}", fNumber);
            else
                return "";
        }

        private static string FormatNumberToString(object number, int decimalPlace)
        {
            double doubleNumber = Convert.ToDouble(number);

            return Double.IsNaN(doubleNumber)
                ? string.Empty
                : String.Format("{" + "0:0.".PadRight(decimalPlace, '0') + "}", doubleNumber);
        }

        /// <summary>
        /// Trunca uma string
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="lenght">Comprimento definido da string</param>
        /// <returns></returns>
        public static string Truncate(this string s, int lenght)
        {
            return (s.Length >= lenght ? s.Substring(0, lenght) : s);
        }

        /// <summary>
        /// Recupera parte da string, delimitada após um caracter específico
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SubsAfterString(this string s, string value)
        {
            return s.Substring(s.LastIndexOf(value) + 1);
        }

        /// <summary>
        /// Recupera parte da string, delimitada até um caracter específico
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SubsBeforeString(this string s, string value)
        {
            return s.Substring(0, s.LastIndexOf(value));
        }

        /// <summary>
        /// Modifica string por um determinado valor através de uma condição
        /// </summary>
        /// <param name="s"></param>
        /// <param name="values">Pares condição,resultado</param>
        /// <returns></returns>
        public static string ReplaceForCondition(this string s, params string[] values)
        {
            string sRet = "";
            for (int i = 0; i < values.Length; i += 2)
            {
                if (values[i] == s)
                {
                    sRet = values[i + 1];
                    break;
                }
            }
            return sRet;
        }

        /// <summary>
        /// Coloca a primeira letra em caixa alta
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUpperFirstLetter(this string s)
        {
            string temp = s.Substring(0, 1);
            return temp.ToUpper() + s.Remove(0, 1).ToLower();
        }

        /// <summary>
        /// Retorna string com número formatado com casas decimais delimitadas
        /// </summary>
        /// <param name="fNumber"></param>
        /// <param name="decimalPlace">Número de casas decimais</param>
        /// <returns></returns>
        public static string ToStringOfItems<T>(this ICollection<T> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item.ToString());
                sb.Append(", ");
            }

            if (list.Count > 0)
            {
                // retira o último ", "
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Remove acentos da string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string s)
        {
            String normalizedString = s.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Preenche string com determinado caracter
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="length">Comprimento</param>
        /// <param name="paddingChar">Caracter a ser utilizado no preenchimento</param>
        /// <returns></returns>
        public static string PadBoth(this string str, int length, char paddingChar)
        {
            int spaces = length - str.Length;
            int pad = spaces / 2;
            return str.PadLeft(pad, paddingChar).PadRight(pad, paddingChar);
        }

        /// <summary>
        /// Converte string para código Soundex
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToSoundex(this string str, int length)
        {
            ISoundex phonetic = new Soundex(length);
            return phonetic.GetToken(str);
        }

        /// <summary>
        /// Valida se a string está no formato de email
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsValidateEmail(this string str)
        {
            string rule = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            return (System.Text.RegularExpressions.Regex.IsMatch(str, rule) ? true : false);
        }
    }
}
