using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    internal class clsHelper
    {
        static public string FormatNullableType(string cSharpType, bool isNullable)
        {
            if (isNullable && cSharpType != "string" && cSharpType != "byte[]" && cSharpType != "object")
                cSharpType += "?";
            return cSharpType;
        }
    }
}
