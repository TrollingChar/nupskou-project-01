using Code.Systems;
using UnityEngine;


namespace Code.Stages {

    // стейджи должны будут идти по цепочке
    // придется в деспавне смотреть какой стейдж следующий в цепочке и спавнить его
    public class Stage1Sub1 : Entity {

        private UpdateSystem.Component updateComponent;
        

        protected override void OnSpawn () {
            _.Game.UpdateSystem.Add (updateComponent = new UpdateSystem.Component (Update));
        }


        private void Update () {
            Debug.Log (Age);
            if (Age == 10) Despawn ();
        }


        protected override void OnDespawn () {
            updateComponent.Alive = false;
        }

    }

}
