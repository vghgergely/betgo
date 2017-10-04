using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Betgo.Models
{
    public class LaterDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "yyyy MM dd HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);

        }
    }
}