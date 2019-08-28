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
                // здесь достать из очереди стейджей новый стейдж и заспавнить
                // если там пусто вернуться в главное меню
                // даже не нужно лазить в OnDespawn
            }
        }

    }

}
