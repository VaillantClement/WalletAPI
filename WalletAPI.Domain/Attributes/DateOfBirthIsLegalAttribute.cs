using System;
using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DateOfBirthIsLegalAttribute : ValidationAttribute
    {
        public DateOfBirthIsLegalAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dateOfBirth = (DateTime)value;

            var ageIsLegal = dateOfBirth < DateTime.Now.AddYears(-18);

            return ageIsLegal;
        }
    }
}