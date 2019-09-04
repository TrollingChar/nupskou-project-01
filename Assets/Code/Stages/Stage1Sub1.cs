namespace Code {

    // уровни должны будут идти по цепочке
    // придется в деспавне смотреть какой стейдж следующий в цепочке и спавнить его
    public class Stage1Sub1 : Entity {

        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
        }


        protected override void OnUpdate () {
//            var v = new XY (Age * Const.phiAngle);
            int delay   = _.Difficulty.Choose (20, 15, 12, 10);
            int bullets = _.Difficulty.Choose (30, 40, 50, 60);
            if (Age % delay == 0)
            foreach (var v in Danmaku.Ring (XY.Down, bullets)) {
                var w = new XY (v.X * 3, v.Y).Rotated (Age / delay * Const.phiAngle / 2);
                new Bullet (new XY (0, 135), w).Spawn ();
            }
            
            if (Age == Utils.Time (20, 00)) {
                Despawn ();
                _.Game.StartNextStage ();
            }
        }

    }

}
