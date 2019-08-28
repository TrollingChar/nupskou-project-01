using System;


namespace Code {

    public enum EntityState { Initial, Alive, Dead }


    public class Entity {

        private EntityState state = EntityState.Initial;
        private int         spawnedAt;

        
        public void Spawn () {
            if (state != EntityState.Initial) {
                throw new InvalidOperationException (_.Locale.SpawnFail);
            }
            state     = EntityState.Alive;
            spawnedAt = _.Game.Time;
            OnSpawn ();
        }


        public void Update () {
            if (state != EntityState.Alive) {
                throw new InvalidOperationException (_.Locale.UpdateFail);
            }
            OnUpdate ();
        }


        public void Despawn () {
            if (state != EntityState.Alive) {
                throw new InvalidOperationException (_.Locale.DespawnFail);
            }
            state = EntityState.Dead;
            OnDespawn ();
        }


        public int  Age   => _.Game.Time - spawnedAt;
        public bool Alive => state == EntityState.Alive;


        protected virtual void OnSpawn   () {}
        protected virtual void OnUpdate  () {}
        protected virtual void OnDespawn () {}

    }

}
