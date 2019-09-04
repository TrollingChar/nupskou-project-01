namespace Code {

    public class Game {

        public           int            Time { get; private set; }
        public readonly  UpdateSystem   UpdateSystem;
        public readonly  ParticleSystem RoundBulletSystem;
        public           Player         Player;
        private readonly GameInterface  gameInterface;


        public Game (GameInterface gameInterface, UnityEngine.ParticleSystem roundBulletSystem) {
            this.gameInterface = gameInterface;
            UpdateSystem       = new UpdateSystem ();
            RoundBulletSystem  = new ParticleSystem (roundBulletSystem);
        }
        
        
        public void Start () {
            (Player = new Player ()).Spawn ();
            StartNextStage ();
            Time = -1;
            Update ();
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
