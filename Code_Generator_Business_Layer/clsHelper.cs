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
        static public string DefaultValue(string dataType)
        {
            switch (dataType.ToLower().Replace("?", ""))
            {
                case "string":
                    return "null";

                case "int":
                case "long":
                case "short":
                case "byte":
                    return "0";

                case "decimal":
                case "float":
                case "double":
                    return "0";

                case "bool":
                    return "false";

                case "datetime":
                    return "DateTime.Now";

                case "guid":
                    return "Guid.Empty";

                default:
                    return "null";
            }
        }
        static public string FormatingProperties(List<string> PropertiyList, string AddBefore = "", int ApplyThisAfter = 0)
        {
            string result = "";

            List<string> list = new List<string>();

            for (int i = 0; i < PropertiyList.Count; i++)
            {
                if (i < ApplyThisAfter)
                {
                    list.Add(PropertiyList[i]);
                }
                else
                {
                    list.Add($"{AddBefore}{PropertiyList[i]}");
                }
            }

            result = string.Join(", ", list);

            return result;
        }
    }
}
