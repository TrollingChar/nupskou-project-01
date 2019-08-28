using System;


namespace Code {

    public enum EntityState { Initial, Alive, Dead }


    public class Entity {

        public  EntityState State { get; private set; } = EntityState.Initial;
        private int         spawnedAt;

        
        public void Spawn () {
            if (State != EntityState.Initial) {
                throw new InvalidOperationException ();
            }
            State     = EntityState.Alive;
            spawnedAt = _.Game.Time;
            OnSpawn ();
        }


        public void Update () {
            if (State != EntityState.Alive) {
                throw new InvalidOperationException ();
            }
            OnUpdate ();
        }


        public void Despawn () {
            if (State != EntityState.Alive) {
                throw new InvalidOperationException ();
            }
            State = EntityState.Dead;
            OnDespawn ();
        }


        public int Age => _.Game.Time - spawnedAt;


        protected virtual void OnSpawn   () {}
        protected virtual void OnUpdate  () {}
        protected virtual void OnDespawn () {}

    }

}
