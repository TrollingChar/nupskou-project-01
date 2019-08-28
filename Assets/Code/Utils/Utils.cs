namespace Code.Utils {

    // если в твоем коде написано Utils.Utils.Time (...), значит ты делаешь это неправильно.
    // пиши using static в начале файла
    public static class Utils {

        public static int Time (int seconds, int ticks)              => ticks + seconds * 60;
        public static int Time (int minutes, int seconds, int ticks) => ticks + seconds * 60 + minutes * 3600;

    }

}
