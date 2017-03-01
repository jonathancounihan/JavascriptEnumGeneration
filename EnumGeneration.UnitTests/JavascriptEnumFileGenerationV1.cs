using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGeneration.UnitTests
{
    public class JavascriptEnumFileGenerationV1
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
                    var intValue = (int)value;
                    sb.Append(" " + name);
                    sb.Append(": " + intValue);
                    sb.Append(",");
                }

                sb.AppendLine();
                sb.Append("};");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
