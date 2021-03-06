﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGeneration.Domain
{
    /// <summary>
    /// Class used to generate a Enum file for use in javascript based on the C# enums chosen.
    /// </summary>
    public class JavascriptEnumFileGeneration
    {
        private readonly string autoGeneratedText =
@"/*
Auto generated file.
Do not edit this file directly.
*/
";

        private readonly string globalNamespaceDeclarationPatternTemplate = @"{0}.{1} = {0}.{1} || {{}};";

        private readonly string namespaceDeclarationPatternTemplate = @"var {0} = {0} || {{}};";

        private readonly string enumValuePatternTemplate = @"  {0} : function () {{ var fn = function () {{ return {2}; }}; fn.Text = ""{1}""; fn.Value = {2}; fn.Key = ""{0}""; return fn; }}()";

        private readonly string lookupValuePatternTemplate = @"  {0} : ""{1}""";

        private readonly string IIFEstart = @"(function ({0}) {{";

        private readonly string IIFEend = @"}}({0}));";

        #region Public Methods

        /// <summary>
        /// Generate the file and save to this file path.
        /// </summary>
        /// <param name="javascriptNamespace">Optional namespace for the javascript objects.</param>
        public string GenerateFileContents(IEnumerable<Type> enumsToUse, string javascriptNamespace = null, string globalObject = "window")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(autoGeneratedText);

            sb.AppendLine();

            var useNamespace = !String.IsNullOrEmpty(javascriptNamespace);
            var useGlobalObjectForNamespace = !String.IsNullOrEmpty(globalObject);

            var useIIFE = true;

            if (useNamespace)
            {
                sb.AppendLine("// Namespace.");
                if (useGlobalObjectForNamespace)
                {
                    sb.AppendFormat(globalNamespaceDeclarationPatternTemplate, globalObject, javascriptNamespace);
                }
                else
                {
                    sb.AppendFormat(namespaceDeclarationPatternTemplate, javascriptNamespace);
                }
                sb.AppendLine();
                sb.AppendLine();
            }

            var prefix = useNamespace ? javascriptNamespace + "." : "var ";
            var linePrePadding = "";

            if (useIIFE)
            {
                sb.AppendFormat(IIFEstart, javascriptNamespace);
                sb.AppendLine();
                linePrePadding = "    ";
            }

            var enumValuePattern = linePrePadding + enumValuePatternTemplate;
            var lookupValuePattern = linePrePadding + lookupValuePatternTemplate;

            var sorter = Comparer<object>.Create((x, y) => { int a = (int)x; int b = (int)y; return a.CompareTo(b); });

            foreach (var enumType in enumsToUse)
            {
                var enumNames = Enum.GetNames(enumType);
                var enumValues = Enum.GetValues(enumType);
                Array.Sort(enumValues, sorter);

                if (enumValues.Length > 0 && enumNames.Length == enumValues.Length) // Ie distinct values for each name.
                {
                    sb.Append(linePrePadding + prefix);
                    sb.Append(enumType.Name);
                    sb.Append(" = {");
                    sb.AppendLine();

                    foreach (var value in enumValues)
                    {
                        var description = ((Enum)value).ToDescription();
                        var name = Enum.GetName(enumType, value).PascalToSpacedString();
                        var intValue = (int)value;
                        sb.AppendFormat(enumValuePattern, value /*0*/, description/*1*/, intValue /*2*/);
                        sb.Append(",");
                        sb.AppendLine();

                        if (intValue >= 0)
                        {
                            sb.AppendFormat(lookupValuePattern, intValue, description);
                        }
                        else
                        {
                            sb.AppendFormat(lookupValuePattern, "\"" + intValue.ToString() + "\"", description);
                        }
                        sb.Append(",");
                        sb.AppendLine();
                    }
                    // remove the last comma, and new line.
                    sb.Length = sb.Length - 1 - System.Environment.NewLine.Length;

                    sb.AppendLine();
                    sb.Append(linePrePadding + "};");
                    sb.AppendLine();
                }
            }

            if (useIIFE)
            {
                var IIFEvariable = useGlobalObjectForNamespace ? globalObject + "." + javascriptNamespace : javascriptNamespace;

                sb.AppendFormat(IIFEend, IIFEvariable);
            }

            return sb.ToString();
        }

        #endregion
    }
}
