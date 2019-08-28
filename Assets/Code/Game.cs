using System.Collections.Generic;
using Code.Stages;
using Code.Systems;
using TMPro;
using UnityEngine;


namespace Code {

    public class Game : MonoBehaviour {

        [SerializeField] private TMP_Text timeText;
    

        private int t;
        public UpdateSystem UpdateSystem { get; private set; }


        public int Time {
            get { return t; }
            private set {
                if (t == value) return;
                t = value;
                if (timeText) timeText.text = $"{value / 3600}:{value / 60 % 60:00}:{value % 60:00}"; // m:ss:tt
            }
        }


        private void Awake () {
            UpdateSystem = new UpdateSystem ();
            _.Game = this;
            StartNextStage ();
            t = -1;
        }


        private void Update () {
            Time++;
            UpdateSystem.Update ();
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
