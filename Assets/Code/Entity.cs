using System;


namespace Code {

    public enum EntityState { Initial, Alive, Dead }


    public class Entity {

        public EntityState State;
        public int         SpawnedAt;

        
        public void Spawn () {
            if (State != EntityState.Initial) throw new InvalidOperationException ();
            SpawnedAt = _.Game.Time;
            AddSprite ();
            State = EntityState.Alive;
        }


        public void Update () {
            if (State != EntityState.Alive) throw new InvalidOperationException ();
        }


        public void Despawn () {
            if (State != EntityState.Alive) throw new InvalidOperationException ();
            RemoveSprite ();
            State = EntityState.Dead;
        }
        

        public void AddSprite    () {}
        public void RemoveSprite () {}
        
    }

}
