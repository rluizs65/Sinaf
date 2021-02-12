using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Base.Core.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Recupera o valor do description attribute de um enum.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns>Valor do description</returns>
        public static string GetDescriptionAttribute(this Enum enumValue)
        {
            string description = string.Empty;

            try
            {
                Type type = enumValue.GetType();
                MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
                object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
            catch
            { }

            return description;
        }

        /// <summary>
        /// Recupera o Valor do enum, realizando cast
        /// </summary>
        /// <typeparam name="T">tipo do objeto(int,char)</typeparam>
        /// <param name="enumValue"></param>
        /// <returns>retorna um valor do tipo T</returns>
        public static T GetValue<T>(this Enum enumValue)
        {
            var obj = Convert.ChangeType(enumValue, typeof(T));

            return (T)obj;
        }

        /// <summary>
        /// Recupera o Valor do enum, convertendo para string
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum enumValue)
        {
            return Convert.ChangeType(enumValue, typeof(char)).ToString();
        }

        /// <summary>
        /// Retorna o código do enumerador
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetCode(this Enum enumValue)
        {
            return Convert.ChangeType(enumValue, typeof(int)).ToString();
        }

        public static string Description(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? enumValue.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }

        public static string DisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attributes = field.GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length == 0 ? enumValue.ToString() : ((DisplayAttribute)attributes[0]).Name;
        }

        /// <summary>
        /// Recupera o valor do description attribute de um enum.
        /// </summary>
        /// <param name="enumValue">Enumerador</param>
        /// <returns>Valor do description</returns>
        public static string GetAttributeDescription(this Enum enumValue)
        {
            string description = string.Empty;

            try
            {
                Type type = enumValue.GetType();
                MemberInfo[] memInfo = type.GetMember(enumValue.ToString());
                object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
            catch
            { }

            return description;
        }

    }
}
