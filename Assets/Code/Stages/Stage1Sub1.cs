namespace Code {

    // уровни должны будут идти по цепочке
    // придется в деспавне смотреть какой стейдж следующий в цепочке и спавнить его
    public class Stage1Sub1 : Entity {

        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
        }


        protected override void OnUpdate () {
//            var v = new XY (Age * Const.phiAngle);
            if (Age % 10 == 0)
            foreach (var v in Danmaku.Ring (XY.Down, 40)) {
                var w = new XY (v.X * 4, v.Y).Rotated (Age);
                new Bullet (new XY (0, 100), w * 1.5f).Spawn ();
            }
            
            if (Age == Utils.Time (20, 00)) {
                Despawn ();
                _.Game.StartNextStage ();
            }
        }

    }

}
