using TMPro;
using UnityEngine;


namespace Code {

    public class GameInterface : MonoBehaviour {

        [SerializeField] private TMP_Text
            difficulty,
            wordLives, lives,
            wordBombs, bombs,
            wordScore, score,
            wordTime,  time;
        [SerializeField] private UnityEngine.ParticleSystem particleSystem;

        
        public int Time {
            set { if (time) time.text = $"{value / 3600}:{value / 60 % 60:00}:{value % 60:00}"; } // m:ss:tt
        }


        private void Awake () {
            (_.Game = new Game (this, particleSystem)).Start ();
            ApplyLocale ();
        }


        private void ApplyLocale () {
            var l = _.Locale;
            difficulty.text = _.Difficulty.Choose (l.Easy, l.Normal, l.Hard, l.Trolling).ToUpper ();
            wordLives .text = l.Lives;
            wordBombs .text = l.Bombs;
            wordScore .text = l.Score;
            wordTime  .text = l.Time;
        }


        private void Update () {
            _.Game.Update ();
        }


        private void OnDestroy () {
            _.Game = null;
        }

    }

}
