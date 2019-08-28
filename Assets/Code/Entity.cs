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
            spawnedAt = _.Game.Time;
            OnSpawn ();
            state = EntityState.Alive;
        }


        public void Despawn () {
            if (state != EntityState.Alive) {
                throw new InvalidOperationException (_.Locale.DespawnFail);
            }
            OnDespawn ();
            state = EntityState.Dead;
        }


        public int Age => _.Game.Time - spawnedAt;


        protected virtual void OnSpawn   () {}
        protected virtual void OnDespawn () {}
        
    }

}
