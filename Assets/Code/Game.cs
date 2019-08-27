using TMPro;
using UnityEngine;


namespace Code {

    public class Game : MonoBehaviour {

        [SerializeField] private TMP_Text timeText;
    

        private int t = 0;


        public int Time {
            get { return t; }
            private set {
                if (t == value) return;
                t = value;
                if (timeText) timeText.text = $"{value / 3600}:{value / 60 % 60:00}:{value % 60:00}"; // m:ss:tt
            }
        }


        void Awake () {
            _.Game = this;
        }


        void Update () {
            Time++;
        }

    }

}
