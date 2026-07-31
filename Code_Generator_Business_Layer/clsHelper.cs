using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    internal class clsHelper
    {
        /// <summary>
        /// Formats a C# data type string to represent a nullable type (adding '?') if applicable based on nullability and type category.
        /// </summary>
        /// <param name="cSharpType">The base C# data type name (e.g., "int", "DateTime", "string").</param>
        /// <param name="isNullable">True if the column in the database allows NULL values; otherwise, false.</param>
        /// <returns>
        /// Returns the formatted type name with '?' appended if it is a value type and isNullable is true; 
        /// otherwise, returns the original type name.
        /// </returns>
        static public string FormatNullableType(string cSharpType, bool isNullable)
        {
            if (isNullable && cSharpType != "string" && cSharpType != "byte[]" && cSharpType != "object")
                cSharpType += "?";
            return cSharpType;
        }

        /// <summary>
        /// Returns a default initial C# value as a string representation based on the given data type.
        /// </summary>
        /// <param name="dataType">The C# data type name (supports both nullable and non-nullable types).</param>
        /// <returns>
        /// A string representing the default literal value (e.g., "0", "false", "DateTime.Now", "null").
        /// </returns>
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
        /// <summary>
        /// Formats and joins a list of property names into a comma-separated string, 
        /// optionally applying a prefix to properties after a specified index threshold.
        /// </summary>
        /// <param name="PropertiyList">The list of property or column names to format.</param>
        /// <param name="AddBefore">The prefix string to prepend (e.g., "ref ", "out "). Default is empty.</param>
        /// <param name="ApplyThisAfter">The zero-based index after which the prefix should start applying. Default is 0.</param>
        /// <returns>
        /// A comma-separated string containing the formatted elements (e.g., "ID, ref Name, ref Age").
        /// </returns>
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

        /// <summary>
        /// Formats a database column name into a C# safe parameter name using camelCase.
        /// Automatically handles reserved C# keywords by appending the '@' prefix (e.g., "class" becomes "@class").
        /// </summary>
        /// <param name="columnName">The name of the database column or property.</param>
        public static string ToSafeParamName(string columnName)
        {
            string paramName = char.ToLower(columnName[0]) + columnName.Substring(1);

            string[] reservedKeywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
            "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
            "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
            "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
            "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte",
            "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
            "ushort", "using", "virtual", "void", "volatile", "while"};

            if (reservedKeywords.Contains(paramName))
            {
                return "_" + paramName;
            }

            return paramName;
        }
    }
}
