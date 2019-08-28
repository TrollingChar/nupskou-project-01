using System;
using System.Collections.Generic;


namespace Code.Systems {

    // а может лучше использовать не компоненты а сами сущности
    public class UpdateSystem {

        private List <Entity> entities = new List <Entity> ();


        public void Update () {
            for (int i = 0; i < entities.Count; i++) {
                if (entities [i].Alive) entities [i].Update ();
            }
            Clean ();
        }


        public void Add (Entity c) {
            entities.Add (c);
        }


        private void Clean () {
            entities.RemoveAll (c => !c.Alive);
        }

    }

}
