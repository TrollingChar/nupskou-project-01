namespace Code {

    public class Game {

        public          int            Time { get; private set; }
        public readonly UpdateSystem   UpdateSystem;
        public readonly ParticleSystem RoundBulletSystem;
        public          Player         Player;


        public Game (UnityEngine.ParticleSystem roundBulletSystem) {
            UpdateSystem      = new UpdateSystem ();
            RoundBulletSystem = new ParticleSystem (roundBulletSystem);
        }


        public void Update () {
            Time++;
            UpdateSystem     .Work ();
            RoundBulletSystem.Work ();
            // добавить системы коллизий и т.д.
        }
        
        
        public void StartNextStage () {
            if (_.Stages.Count > 0) {
                _.Stages.Dequeue ().Spawn ();
            }
            else {
                // вернуться в меню
            }
        }

    }

}
