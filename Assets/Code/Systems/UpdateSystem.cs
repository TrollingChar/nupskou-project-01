using System;
using System.Collections.Generic;


namespace Code {

    // а может лучше использовать не компоненты а сами сущности
    public class UpdateSystem {

        private List <Entity> entities = new List <Entity> ();


        public void Work () {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < entities.Count; i++) {
                if (entities [i].State != EntityState.Dead) entities [i].Update ();
            }
            Clean ();
        }


        public void Add (Entity e) {
            if (e.State != EntityState.Alive) throw new ArgumentException ();
            entities.Add (e);
        }


        private void Clean () {
            entities.RemoveAll (c => c.State == EntityState.Dead);
        }

    }

}
