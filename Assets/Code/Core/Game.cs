using Code.Systems;
using TMPro;
using UnityEngine;
using ParticleSystem = UnityEngine.ParticleSystem;


namespace Code.Core {

    public class Game : MonoBehaviour {

        [SerializeField] private TMP_Text       timeText;
        [SerializeField] private ParticleSystem particleSystem;

        private int                    t;
        public  UpdateSystem           UpdateSystem   { get; private set; }
        public  Systems.ParticleSystem ParticleSystem { get; private set; }
        public  Player                 Player         { get; private set; }


        public int Time {
            get { return t; }
            private set {
                if (t == value) return;
                t = value;
                if (timeText) timeText.text = $"{value / 3600}:{value / 60 % 60:00}:{value % 60:00}"; // m:ss:tt
            }
        }


        private void Awake () {
            UpdateSystem   = new UpdateSystem ();
            ParticleSystem = new Systems.ParticleSystem (particleSystem);

            _.Game = this;
            (Player = new Player ()).Spawn ();
            StartNextStage ();
            t = -1;
        }


        private void Update () {
            Time++;
            UpdateSystem  .Work ();
            ParticleSystem.Work ();
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
