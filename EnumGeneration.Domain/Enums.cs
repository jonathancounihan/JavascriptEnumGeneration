using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGeneration.Domain
{
    public enum Jedi
    {
        Youngling = 0,
        Padawan = 1,
        Knight = 2,
        Master = 3
    }

    public enum LightSaber
    {
        Blue = 0,
        Green = 1,
        Red = 2,
        Purple = 3
    }

    public enum TIESeriesFigther
    {
        [Description("TIE Starfighter")]
        TIEStarfighter = 0,
        [Description("TIE/LN Starfighter (Light Duty)")]
        TIELNStarfighter_Light_Duty = 1,
        [Description("Super TIE")]
        SuperTIE = 2,
        [Description("TIE/IN Interceptor (Emperor's Royal Guard)")]
        TIEINInterceptor_Emperors_Royal_Guard = 3,
        [Description("TIE Hunter")]
        TIEHunter = 4,
        [Description("TIE Heavy Bomber")]
        TIEHeavyBomber = 5
    }
}
