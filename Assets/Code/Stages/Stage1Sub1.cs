using UnityEngine;
using static Code.Utils.Utils;


namespace Code.Stages {

    // уровни должны будут идти по цепочке
    // придется в деспавне смотреть какой стейдж следующий в цепочке и спавнить его
    public class Stage1Sub1 : Entity {

        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (this);
        }


        protected override void OnUpdate () {
            Debug.Log (Age);
            if (Age == Time (20, 00)) {
                Despawn ();
                _.Game.StartNextStage ();
            }
        }

    }

}
