using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGeneration.Domain
{
    public static class EnumList
    {
        public static List<Type> GetTypesForJavascriptGeneration()
        {
            var types = new List<Type>
            {
                typeof (Jedi),
                typeof (LightSaber),
                typeof (TIESeriesFigther)
            };

            return types;
        }
    }
}