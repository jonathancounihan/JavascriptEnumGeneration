using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EnumGeneration.Domain;
using System.Text;

namespace EnumGeneration.UnitTests
{
    [TestClass]
    public class Sandbox
    {
        [TestMethod]
        public void GenerationV1()
        {
            IEnumerable<Type> enumsToUse = new List<Type>()
            {
                typeof(Jedi),
                typeof(LightSaber),
                typeof(TIESeriesFigther),
            };

            JavascriptEnumFileGenerationV1 generator = new JavascriptEnumFileGenerationV1();

            var fileContents = generator.GenerateFileContents(enumsToUse);
        }

        [TestMethod]
        public void GenerationV2()
        {
            IEnumerable<Type> enumsToUse = new List<Type>()
            {
                typeof(Jedi),
                typeof(LightSaber),
                typeof(TIESeriesFigther),
            };

            JavascriptEnumFileGenerationV2 generator = new JavascriptEnumFileGenerationV2();

            var fileContents = generator.GenerateFileContents(enumsToUse);
        }

        [TestMethod]
        public void GenerationV3()
        {
            IEnumerable<Type> enumsToUse = new List<Type>()
            {
                typeof(Jedi),
                typeof(LightSaber),
                typeof(TIESeriesFigther),
            };

            JavascriptEnumFileGenerationV3 generator = new JavascriptEnumFileGenerationV3();

            var fileContents = generator.GenerateFileContents(enumsToUse);
        }
    }
}
