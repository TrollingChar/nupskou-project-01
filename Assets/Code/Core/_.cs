using System;
using System.Collections.Generic;


namespace Code {

    public static class _ {

        // это подготавливается в главном меню: режим и сложность
        public static Difficulty     Difficulty = Difficulty.Easy;
        public static Queue <Entity> Stages     = new Queue <Entity> (new [] { new Stage1Sub1 () });

        // это подготавливается в сцене игры
        public static Game           Game;
        public static Random         Random     = new Random ();
        
        // пока не используется, возможно сделаю через свойство с событием
        public static Locale         Locale     = new Ru ();

    }

}
