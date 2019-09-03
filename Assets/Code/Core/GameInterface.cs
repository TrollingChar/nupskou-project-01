using TMPro;
using UnityEngine;


namespace Code {

    public class GameInterface : MonoBehaviour {

        [SerializeField] private TMP_Text                   timeText;
        [SerializeField] private UnityEngine.ParticleSystem particleSystem;

        
        public int Time {
            set { if (timeText) timeText.text = $"{value / 3600}:{value / 60 % 60:00}:{value % 60:00}"; } // m:ss:tt
        }


        private void Awake () {
            _.Game = new Game (particleSystem);
            /*
            UpdateSystem   = new UpdateSystem ();
            ParticleSystem = new ParticleSystem (particleSystem);

            _.GameInitializer = this;
            (Player = new Player ()).Spawn ();
            StartNextStage ();
            t = -1;
            */
        }


        private void Update () {
            _.Game.Update ();
        }


        private void OnDestroy () {
            _.Game = null;
        }

    }

}
