using System;
using System.Collections.Generic;


namespace Code.Systems {

    public class UpdateSystem {

        private List <Component> components = new List <Component> ();


        public void Update () {
            for (int i = 0; i < components.Count; i++) {
                if (components [i].Alive) components [i].Update ();
            }
            Clean ();
        }


        public void Add (Component c) {
            components.Add (c);
            c.Alive = true;
        }


        private void Clean () {
            components.RemoveAll (c => !c.Alive);
        }


        public class Component {

            public bool   Alive;
            public Action Update;


            public Component (Action update) {
                Update = update;
            }

        }

    }

}
