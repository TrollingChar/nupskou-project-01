using System.Collections.Generic;
using Code.Locales;
using Code.Stages;
using Code.Utils;


namespace Code.Core {

    public static class _ {

        public static Game           Game;
        public static Difficulty     Difficulty = Difficulty.Normal;
        public static Queue <Entity> Stages     = new Queue <Entity> (new [] {
            new Stage1Sub1 (),
            new Stage1Sub1 (),
        });
        public static Locale         Locale;

    }

}
