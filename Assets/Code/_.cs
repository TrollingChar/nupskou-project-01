using System.Collections.Generic;
using Code.Locales;
using Code.Stages;
using Code.Util;


namespace Code {

    public static class _ {

        public static Game           Game;
        public static Difficulty     Difficulty = Difficulty.Normal;
        public static Queue <Entity> Stages; // когда деспавнится старый стейдж, мы спавним сразу новый
        public static Locale         Locale;

    }

}
