using EnumGeneration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGeneration.UnitTests
{
    public class JavascriptEnumFileGenerationV3
    {
        public string GenerateFileContents(IEnumerable<Type> enumsToUse)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var enumType in enumsToUse)
            {
                var enumNames = Enum.GetNames(enumType);
                var enumValues = Enum.GetValues(enumType);

                sb.Append("var ");
                sb.Append(enumType.Name);
                sb.Append(" = {");
                sb.AppendLine();

                foreach (var value in enumValues)
                {
                    var name = Enum.GetName(enumType, value).ToString();
                    var description = ((Enum)value).ToDescription();
                    var intValue = (int)value;
                    sb.AppendFormat(@"  {0} : function () {{ var fn = function () {{ return {2}; }}; fn.Text = ""{1}""; fn.Value = {2}; fn.Key = ""{0}""; return fn; }}()", name, description, intValue);
                    sb.Append(",");
                    sb.AppendLine();
                }

                sb.Append("};");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
