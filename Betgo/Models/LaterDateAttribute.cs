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
                "MM/dd/yyyy HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);

        }
    }
}