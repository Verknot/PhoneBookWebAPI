using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity.Enum
{
    public static class EnumExtension
    {
        public static string GetNameEnum(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString()).First().Name;
        }
    }
}
