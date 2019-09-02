using System;


namespace Code.Utils {

    public static class DifficultyExtension {

        public static T Choose <T> (this Difficulty d, T easy, T normal, T hard, T trolling) {
            switch (d) {
                case Difficulty.Easy:     return easy;
                case Difficulty.Normal:   return normal;
                case Difficulty.Hard:     return hard;
                case Difficulty.Trolling: return trolling;
                default:                  throw new ArgumentOutOfRangeException (nameof (d), d, null);
            }
        }

    }

}