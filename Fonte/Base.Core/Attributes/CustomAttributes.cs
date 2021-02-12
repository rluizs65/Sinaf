using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Base.Core.Attributes
{
    public class CustomAttributes
    {

        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        public sealed class DatabaseConnection : Attribute
        {
            public string Name { get; set; }
        }

        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        public sealed class DatabaseSchema : Attribute
        {
            public string Name { get; set; }
        }

        public sealed class NumberDiffValue : ValidationAttribute
        {
            public double Value { get; set; }
            public new string ErrorMessage { get; set; }

            protected override ValidationResult IsValid(object expression, ValidationContext validationContext)
            {
                try
                {
                    double value = Convert.ToDouble(expression);

                    if (value != Value)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                catch
                {
                    return new ValidationResult(ErrorMessage);
                }

            }
        }

        public sealed class StringDiffNullOrEmpty : ValidationAttribute
        {
            public new string ErrorMessage { get; set; }

            protected override ValidationResult IsValid(object expression, ValidationContext validationContext)
            {
                try
                {
                    string value = expression.ToString();

                    if ((!string.IsNullOrEmpty(value)) || (value.Trim().Length > 0))
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                catch
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }

        public sealed class DatetimeDiffMinValue : ValidationAttribute
        {
            public string ErrorMessage { get; set; }

            protected override ValidationResult IsValid(object expression, ValidationContext validationContext)
            {
                try
                {
                    DateTime value = Convert.ToDateTime(expression);

                    if (value != DateTime.MinValue)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(ErrorMessage);
                }
                catch
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }

        public sealed class EnsureOneElementAttribute : ValidationAttribute
        {
            public new string ErrorMessage { get; set; }

            protected override ValidationResult IsValid(object expression, ValidationContext validationContext)
            {
                try
                {
                    var list = expression as IList;

                    if (list != null)
                    {
                        if (list.Count > 0)
                            return ValidationResult.Success;
                        else
                            return new ValidationResult(ErrorMessage);
                    }
                    else
                        return new ValidationResult(ErrorMessage);
                }
                catch
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
    }
}
