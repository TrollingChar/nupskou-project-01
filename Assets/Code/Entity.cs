using System;


namespace Code {

    public enum EntityState { Initial, Alive, Dead }


    public class Entity {

        public EntityState State;
        public int         SpawnedAt;


        public void Spawn () {
            if (State != EntityState.Initial) throw new InvalidOperationException ();

            State = EntityState.Alive;
        }


        public void Despawn () {
            if (State != EntityState.Alive) throw new InvalidOperationException ();

            State = EntityState.Dead;
        }

    }

}
